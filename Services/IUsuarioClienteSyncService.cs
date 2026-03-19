namespace Reincarapp.Services;

/// <summary>
/// Contrato para la sincronización de la tabla usuario_cliente.
/// </summary>
public interface IUsuarioClienteSyncService
{
    /// <summary>
    /// Reemplazo completo: upsert de los <paramref name="clienteIds"/> indicados
    /// y eliminación de los registros huérfanos del usuario.
    /// Funciona igual para Add (ningún registro previo) que para Edit.
    /// </summary>      
    Task SyncAsync(
        string aspNetUserId,
        IEnumerable<long> clienteIds,
        CancellationToken cancellationToken = default);
}