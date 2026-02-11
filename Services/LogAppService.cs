using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reincarapp.Data;
using Reincarapp.Models.reincardb;
using System;
using System.Threading.Tasks;

namespace Reincarapp.Services
{
    public interface ILogAppService
    {
        Task RegistrarErrorAsync(string procedimiento, Exception ex, string detalle = null, long? idUsuario = null, string nombreUsuario = null);
        Task RegistrarInfoAsync(string procedimiento, string mensaje, long? idUsuario = null, string nombreUsuario = null);
    }

    public class LogAppService : ILogAppService
    {
        private readonly IDbContextFactory<reincardbContext> _dbContextFactory;
        private readonly ILogger<LogAppService> _logger;

        public LogAppService(
            IDbContextFactory<reincardbContext> dbContextFactory,
            ILogger<LogAppService> logger)
        {
            _dbContextFactory = dbContextFactory;
            _logger = logger;
        }

        public async Task RegistrarErrorAsync(string procedimiento, Exception ex, string detalle = null, long? idUsuario = null, string nombreUsuario = null)
        {
            try
            {
                using var context = await _dbContextFactory.CreateDbContextAsync();

                var textoCompleto = $"{detalle ?? ex.Message}\n\n" +
                                   $"StackTrace:\n{ex.StackTrace}";

                if (ex.InnerException != null)
                {
                    textoCompleto += $"\n\nInnerException:\n{ex.InnerException.Message}\n{ex.InnerException.StackTrace}";
                }

                var logapp = new Logapp
                {
                    IdUsuario = idUsuario,
                    Proc = procedimiento,
                    Texto = textoCompleto,
                    FechaCreacion = DateTime.Now,
                    CreatedBy = nombreUsuario
                };

                context.Logapp.Add(logapp);
                await context.SaveChangesAsync();

                _logger.LogInformation("Error registrado en Logapp: {IdLogApp} para procedimiento: {Proc}", 
                    logapp.IdLogApp, procedimiento);
            }
            catch (Exception logEx)
            {
                // Si falla el registro del error, solo lo logueamos pero no interrumpimos el flujo
                _logger.LogError(logEx, "Error al registrar en Logapp. Procedimiento: {Proc}, Error original: {OriginalError}", 
                    procedimiento, ex.Message);
            }
        }

        public async Task RegistrarInfoAsync(string procedimiento, string mensaje, long? idUsuario = null, string nombreUsuario = null)
        {
            try
            {
                using var context = await _dbContextFactory.CreateDbContextAsync();

                var logapp = new Logapp
                {
                    IdUsuario = idUsuario,
                    Proc = procedimiento,
                    Texto = mensaje,
                    FechaCreacion = DateTime.Now,
                    CreatedBy = nombreUsuario
                };

                context.Logapp.Add(logapp);
                await context.SaveChangesAsync();

                _logger.LogInformation("Información registrada en Logapp: {IdLogApp} para procedimiento: {Proc}", 
                    logapp.IdLogApp, procedimiento);
            }
            catch (Exception logEx)
            {
                _logger.LogError(logEx, "Error al registrar información en Logapp. Procedimiento: {Proc}", procedimiento);
            }
        }
    }
}