using Microsoft.EntityFrameworkCore;
using Reincarapp.Data;
using Reincarapp.Models.reincardb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reincarapp.Services
{
    public class DatoPersonaSyncService
    {
        private readonly IDbContextFactory<reincardbContext2> _contextFactory2;
        private readonly IDbContextFactory<reincardbContext> _contextFactory;

        public DatoPersonaSyncService(
            IDbContextFactory<reincardbContext2> contextFactory2, 
            IDbContextFactory<reincardbContext> contextFactory)
        {
            _contextFactory2 = contextFactory2;
            _contextFactory = contextFactory;
        }

        /// <summary>
        /// Sincroniza datos de persona desde la base de datos histórica a la principal
        /// </summary>
        /// <param name="numeroDocumento">Número de documento de la persona</param>
        /// <param name="idPersona">ID de la persona en la BD principal</param>
        /// <returns>Número de registros sincronizados</returns>
        public async Task<int> SincronizarDatosPersonaAsync(string numeroDocumento, long idPersona)
        {
            if (string.IsNullOrEmpty(numeroDocumento))
                throw new ArgumentNullException(nameof(numeroDocumento));

            // Usar contextos independientes para evitar conflictos de concurrencia
            using var contextHistorico = await _contextFactory2.CreateDbContextAsync();
            using var contextPrincipal = await _contextFactory.CreateDbContextAsync();

            // Obtener persona del histórico con sus datos
            var personaHistorica = await contextHistorico.Persona
                .Include(x => x.DatoPersona)
                .Where(x => x.Numero_Documento == numeroDocumento)
                .FirstOrDefaultAsync();

            if (personaHistorica == null || personaHistorica.DatoPersona == null || !personaHistorica.DatoPersona.Any())
            {
                return 0;
            }

            int registrosAfectados = 0;
            List<DatoPersona> datosTemporales = new List<DatoPersona>();

            // Recorrer cada dato persona del histórico
            foreach (var datoHistorico in personaHistorica.DatoPersona)
            {
                // Verificar si ya existe para evitar duplicados
                bool existe = await contextPrincipal.Persona
                    .Include(x => x.DatoPersona)
                    .Where(x => x.Numero_Documento == numeroDocumento && 
                           x.DatoPersona.Any(dp => dp.Id_Tipo_Dato_Persona == datoHistorico.Id_Tipo_Dato_Persona && 
                                                  dp.Dato.ToLower() == datoHistorico.Dato.ToLower()))
                    .AnyAsync();

                if (!existe)
                {
                    var nuevoDato = new DatoPersona
                    {
                        Id_Persona = idPersona,
                        Id_Tipo_Dato_Persona = datoHistorico.Id_Tipo_Dato_Persona,
                        Dato = datoHistorico.Dato
                    };

                    datosTemporales.Add(nuevoDato);
                }
            }

            if (datosTemporales.Count > 0)
            {
                await contextPrincipal.DatoPersona.AddRangeAsync(datosTemporales);
                registrosAfectados = await contextPrincipal.SaveChangesAsync();
            }

            return registrosAfectados;
        }
    }
}