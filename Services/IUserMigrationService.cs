namespace Reincarapp.Services;

/// <summary>Encapsulates the result of a user migration attempt.</summary>
/// <param name="Success">True if the user is ready to sign in (migrated or already present).</param>
/// <param name="ErrorMessage">Human-readable reason for failure, if any.</param>
public sealed record UserMigrationResult(bool Success, string? ErrorMessage = null);

public interface IUserMigrationService
{
    /// <summary>
    /// Migrates a user from the legacy database to the current Identity schema,
    /// including role assignments and client associations.
    /// </summary>
    Task<UserMigrationResult> MigrateUserAsync(
        string userName,
        string password,
        CancellationToken cancellationToken = default);
}