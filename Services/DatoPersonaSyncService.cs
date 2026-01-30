
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
        
        private readonly reincardbContext2 _reincardbContext2;
        private readonly reincardbContext _reincardbContext;

        public DatoPersonaSyncService(reincardbContext2 reincardbContext2, reincardbContext reincardbContext)
        {
            
            _reincardbContext2 = reincardbContext2;
            _reincardbContext = reincardbContext;
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

            // Obtener persona del histórico con sus datos
            var personaHistorica = await _reincardbContext2.Persona
                .Include(x => x.DatoPersona)
                .Where(x => x.Numero_Documento == numeroDocumento)
                .FirstOrDefaultAsync();

            if (personaHistorica == null || personaHistorica.DatoPersona == null || !personaHistorica.DatoPersona.Any())
            {
                return 0; // No hay datos para sincronizar
            }

            int registrosAfectados = 0;

            // Lista temporal para acumular los datos a sincronizar
            List<DatoPersona> datosTemporales = new List<DatoPersona>();

         

                // Recorrer cada dato persona del histórico
                foreach (var datoHistorico in personaHistorica.DatoPersona)
                {
                    // Verificar si ya existe para evitar duplicados
                    bool existe = await _reincardbContext.Persona
                                                         .Include(x => x.DatoPersona)
                                                         .Where(x => x.Numero_Documento == numeroDocumento && x.DatoPersona.Any(dp => dp.Id_Tipo_Dato_Persona == datoHistorico.Id_Tipo_Dato_Persona && dp.Dato.ToLower() == datoHistorico.Dato.ToLower()))
                                                         .AnyAsync();

                if (!existe)
                    {
                        // Crear nuevo registro en la BD principal
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
                    await _reincardbContext.DatoPersona.AddRangeAsync(datosTemporales);
                    // Guardar todos los cambios en una sola transacción
                    registrosAfectados = await _reincardbContext.SaveChangesAsync();
            }
                

                return registrosAfectados;





           

           
        }
    }
}