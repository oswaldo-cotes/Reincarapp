using Radzen;
using Reincarapp.Models.reincardb;

namespace Reincarapp.Services;

/// <summary>
/// Implementación production-ready de <see cref="IUsuarioClienteSyncService"/>.
/// Estrategia: una sola consulta para cargar registros existentes, luego
/// upsert + eliminación de huérfanos en memoria.
/// </summary>
public sealed class UsuarioClienteSyncService : IUsuarioClienteSyncService
{
    private readonly reincardbService _db;
    private readonly ILogger<UsuarioClienteSyncService> _logger;

    public UsuarioClienteSyncService(
        reincardbService db,
        ILogger<UsuarioClienteSyncService> logger)
    {
        _db     = db;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task SyncAsync(
        string aspNetUserId,
        IEnumerable<long> clienteIds,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(aspNetUserId))
            throw new ArgumentException(
                "El ID del usuario no puede estar vacío.", nameof(aspNetUserId));

        ArgumentNullException.ThrowIfNull(clienteIds);

        var targetIds = clienteIds.Distinct().ToList();

        if (targetIds.Exists(id => id <= 0))
            throw new ArgumentException(
                "Todos los Id_Cliente deben ser valores positivos.", nameof(clienteIds));

        // Una sola query para evitar N+1: cargamos todos los registros del usuario.
        var existing = (await _db.GetUsuarioCliente(new Query
        {
            Filter           = "i => i.AspNetUserId == @0",
            FilterParameters = new object[] { aspNetUserId }
        })).ToList();

        await UpsertAsync(aspNetUserId, targetIds, existing);
        await DeleteOrphansAsync(targetIds, existing);

        _logger.LogInformation(
            "Sync UsuarioCliente completado para '{UserId}': {Count} asociaciones.",
            aspNetUserId, targetIds.Count);
    }

    // -------------------------------------------------------------------------
    // Helpers privados — responsabilidad única (SRP)
    // -------------------------------------------------------------------------

    private async Task UpsertAsync(
        string aspNetUserId,
        IReadOnlyList<long> targetIds,
        IReadOnlyList<UsuarioCliente> existing)
    {
        foreach (var clienteId in targetIds)
        {
            var record = existing.FirstOrDefault(uc => uc.Id_Cliente == clienteId);

            if (record is null)
            {
                await _db.CreateUsuarioCliente(new UsuarioCliente
                {
                    AspNetUserId = aspNetUserId,
                    Id_Cliente   = clienteId
                });

                _logger.LogDebug(
                    "Creado UsuarioCliente: UserId={UserId}, ClienteId={ClienteId}.",
                    aspNetUserId, clienteId);
            }
            else if (record.AspNetUserId != aspNetUserId)
            {
                // Solo actualiza si algo cambió realmente.
                record.AspNetUserId = aspNetUserId;
                await _db.UpdateUsuarioCliente(record.Id_Usuario_Cliente, record);

                _logger.LogDebug(
                    "Actualizado UsuarioCliente {Id}: UserId={UserId}, ClienteId={ClienteId}.",
                    record.Id_Usuario_Cliente, aspNetUserId, clienteId);
            }
        }
    }

    private async Task DeleteOrphansAsync(
        IReadOnlyList<long> targetIds,
        IReadOnlyList<UsuarioCliente> existing)
    {
        var orphans = existing
            .Where(uc => uc.Id_Cliente.HasValue
                      && !targetIds.Contains(uc.Id_Cliente.Value))
            .ToList();

        foreach (var orphan in orphans)
        {
            await _db.DeleteUsuarioCliente(orphan.Id_Usuario_Cliente);

            _logger.LogDebug(
                "Eliminado UsuarioCliente huérfano {Id}: ClienteId={ClienteId}.",
                orphan.Id_Usuario_Cliente, orphan.Id_Cliente);
        }
    }
}   