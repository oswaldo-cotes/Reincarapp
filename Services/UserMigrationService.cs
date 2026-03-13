using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reincarapp.Data;
using Reincarapp.Models;
using Reincarapp.Models.reincardb;

namespace Reincarapp.Services;

/// <summary>
/// Handles one-time migration of users from the legacy DB (reincardbContext2)
/// to the new Identity schema (reincardbContext + ApplicationIdentityDbContext).
/// Each private method has a single responsibility (SRP / SOLID).
/// </summary>
public sealed class UserMigrationService : IUserMigrationService
{
    private readonly reincardbContext2 _legacyContext;
    private readonly reincardbContext _newContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly ILogger<UserMigrationService> _logger;

    public UserMigrationService(
        reincardbContext2 legacyContext,
        reincardbContext newContext,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        ILogger<UserMigrationService> logger)
    {
        _legacyContext = legacyContext;
        _newContext    = newContext;
        _userManager   = userManager;
        _roleManager   = roleManager;
        _logger        = logger;
    }

    /// <inheritdoc/>
    public async Task<UserMigrationResult> MigrateUserAsync(
        string userName,
        string password,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(userName))
            return Fail("Username is required.");

        if (string.IsNullOrWhiteSpace(password))
            return Fail("Password is required.");

        // Guard: already migrated — nothing to do, caller will retry sign-in.
        var existing = await _userManager.FindByNameAsync(userName);
        if (existing is not null)
            return Ok();

        var legacyUser = await LoadLegacyUserAsync(userName, cancellationToken);
        if (legacyUser is null)
        {
            _logger.LogWarning("Migration: user '{UserName}' not found in legacy DB.", userName);
            return Fail("Invalid user or password.");
        }

        // Validate legacy plain-text password before creating any record.
        // NOTE: The legacy schema stores passwords as plain text (MaxLength 25).
        // If the format changes, replace this comparison with the appropriate verifier.
        if (!string.Equals(legacyUser.Password, password, StringComparison.Ordinal))
        {
            _logger.LogWarning("Migration: password mismatch for '{UserName}'.", userName);
            return Fail("Invalid user or password.");
        }

        _logger.LogInformation("Migration started for '{UserName}'.", userName);

        // Step 1 — Ensure Usuario exists in the new operational DB.
        var newUsuario = await GetOrCreateUsuarioAsync(legacyUser, cancellationToken);

        // Step 2 — Create the ASP.NET Core Identity user.
        var (identityUser, createError) = await CreateIdentityUserAsync(legacyUser, password);
        if (identityUser is null)
            return Fail(createError!);

        // Step 3 — Assign Identity roles (ASP.NET Core Identity side).
        await AssignIdentityRolesAsync(identityUser, legacyUser);

        // Step 4 — Mirror UsuarioRol records in the new operational DB.
        await MigrateUsuarioRolAsync(newUsuario, legacyUser, cancellationToken);

        // Step 5 — Mirror UsuarioCliente associations.
        await MigrateUsuarioClienteAsync(identityUser.Id, newUsuario.Id_Usuario, legacyUser, cancellationToken);

        _logger.LogInformation(
            "Migration completed for '{UserName}'. IdentityId={IdentityId}, UsuarioId={UsuarioId}.",
            userName, identityUser.Id, newUsuario.Id_Usuario);

        return Ok();
    }

    // -------------------------------------------------------------------------
    // Private helpers — each owns a single concern
    // -------------------------------------------------------------------------

    private async Task<Usuario?> LoadLegacyUserAsync(string userName, CancellationToken ct)
        => await _legacyContext.Usuario
            .Include(u => u.UsuarioRol).ThenInclude(ur => ur.Rol)
            .Include(u => u.UsuarioCliente)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Usuario1 == userName, ct);

    private async Task<Usuario> GetOrCreateUsuarioAsync(Usuario legacy, CancellationToken ct)
    {
        var existing = await _newContext.Usuario
            .FirstOrDefaultAsync(u => u.Usuario1 == legacy.Usuario1, ct);

        if (existing is not null)
            return existing;

        var newUsuario = new Usuario
        {
            Usuario1           = legacy.Usuario1,
            Nombre_Usuario     = legacy.Nombre_Usuario,
            Correo_Electronico = legacy.Correo_Electronico,
            Cedula             = legacy.Cedula,
            Fecha_Ingreso      = legacy.Fecha_Ingreso,
            Fecha_Retiro       = legacy.Fecha_Retiro,
            Estado             = legacy.Estado,
            Direccion          = legacy.Direccion,
            Fecha_Nacimiento   = legacy.Fecha_Nacimiento,
            Telefono           = legacy.Telefono,
            Cargo              = legacy.Cargo,
        };

        _newContext.Usuario.Add(newUsuario);
        await _newContext.SaveChangesAsync(ct);
        return newUsuario;
    }

    private async Task<(ApplicationUser? User, string? Error)> CreateIdentityUserAsync(
        Usuario legacy, string password)
    {
        var identityUser = new ApplicationUser
        {
            UserName       = legacy.Usuario1,
            Email          = string.IsNullOrWhiteSpace(legacy.Correo_Electronico)
                                 ? $"{legacy.Usuario1}@reincarapp.local"
                                 : legacy.Correo_Electronico,
            EmailConfirmed = true,
        };

        var result = await _userManager.CreateAsync(identityUser, password);
        if (result.Succeeded)
            return (identityUser, null);

        var errors = string.Join("; ", result.Errors.Select(e => e.Description));
        _logger.LogError("Identity creation failed for '{UserName}': {Errors}", legacy.Usuario1, errors);
        return (null, errors);
    }

    private async Task AssignIdentityRolesAsync(ApplicationUser identityUser, Usuario legacy)
    {
        // Guard: UsuarioRol can be null if the legacy user has no roles or EF did not load the collection.
        var roleNames = (legacy.UsuarioRol ?? Enumerable.Empty<UsuarioRol>())
            .Where(ur => !string.IsNullOrWhiteSpace(ur.Rol?.Nombre_Rol))
            .Select(ur => ur.Rol!.Nombre_Rol!)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (roleNames.Count == 0)
        {
            _logger.LogWarning("No roles found in legacy DB for '{UserName}'.", identityUser.UserName);
            return;
        }

        // Only assign roles that actually exist in the new Identity system.
        var validRoles = new List<string>(roleNames.Count);
        foreach (var name in roleNames)
        {
            if (await _roleManager.RoleExistsAsync(name))
                validRoles.Add(name);
            else
                _logger.LogWarning("Role '{RoleName}' not found in Identity; skipped for '{UserName}'.",
                    name, identityUser.UserName);
        }

        if (validRoles.Count == 0) return;

        var result = await _userManager.AddToRolesAsync(identityUser, validRoles);
        if (!result.Succeeded)
            _logger.LogWarning("Partial role assignment for '{UserName}': {Errors}",
                identityUser.UserName,
                string.Join("; ", result.Errors.Select(e => e.Description)));
    }

    private async Task MigrateUsuarioRolAsync(Usuario newUsuario, Usuario legacy, CancellationToken ct)
    {
        // Guard: UsuarioRol can be null if the legacy user has no roles or EF did not load the collection.
        var legacyRoleNames = (legacy.UsuarioRol ?? Enumerable.Empty<UsuarioRol>())
            .Where(ur => !string.IsNullOrWhiteSpace(ur.Rol?.Nombre_Rol))
            .Select(ur => ur.Rol!.Nombre_Rol!)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (legacyRoleNames.Count == 0)
        {
            _logger.LogWarning("No UsuarioRol records to migrate for UsuarioId={UsuarioId}.", newUsuario.Id_Usuario);
            return;
        }

        // Resolve Rol IDs from the new DB by matching role names.
        var newRoles = await _newContext.Rol
            .Where(r => legacyRoleNames.Contains(r.Nombre_Rol))
            .ToListAsync(ct);

        if (newRoles.Count == 0)
        {
            _logger.LogWarning("None of the legacy roles exist in the new DB for UsuarioId={UsuarioId}.", newUsuario.Id_Usuario);
            return;
        }

        // Avoid duplicate UsuarioRol entries.
        var existingRolIds = await _newContext.UsuarioRol
            .Where(ur => ur.Id_Usuario == newUsuario.Id_Usuario)
            .Select(ur => ur.Id_Rol)
            .ToListAsync(ct);

        var toInsert = newRoles
            .Where(r => !existingRolIds.Contains(r.Id_Rol))
            .Select(r => new UsuarioRol { Id_Usuario = newUsuario.Id_Usuario, Id_Rol = r.Id_Rol })
            .ToList();

        if (toInsert.Count == 0) return;

        _newContext.UsuarioRol.AddRange(toInsert);
        await _newContext.SaveChangesAsync(ct);
    }

    private async Task MigrateUsuarioClienteAsync(
        string aspNetUserId, long newUsuarioId, Usuario legacy, CancellationToken ct)
    {
        // Guard: UsuarioCliente can be null if the legacy user has no clients or EF did not load the collection.
        var clientIds = (legacy.UsuarioCliente ?? Enumerable.Empty<UsuarioCliente>())
            .Where(uc => uc.Id_Cliente.HasValue)
            .Select(uc => uc.Id_Cliente!.Value)
            .Distinct()
            .ToList();

        if (clientIds.Count == 0)
        {
            _logger.LogWarning("No UsuarioCliente records to migrate for UsuarioId={UsuarioId}.", newUsuarioId);
            return;
        }

        // Avoid duplicates for this Identity user.
        var existingClientIds = await _newContext.UsuarioCliente
            .Where(uc => uc.AspNetUserId == aspNetUserId)
            .Select(uc => uc.Id_Cliente)
            .ToListAsync(ct);

        var toInsert = clientIds
            .Where(id => !existingClientIds.Contains(id))
            .Select(id => new UsuarioCliente
            {
                Id_Cliente   = id,
                Id_Usuario   = newUsuarioId,
                AspNetUserId = aspNetUserId,
            })
            .ToList();

        if (toInsert.Count == 0) return;

        _newContext.UsuarioCliente.AddRange(toInsert);
        await _newContext.SaveChangesAsync(ct);
    }

    private static UserMigrationResult Ok()             => new(true);
    private static UserMigrationResult Fail(string msg) => new(false, msg);
}