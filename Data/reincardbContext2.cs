using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Reincarapp.Data
{
    /// <summary>
    /// Segundo contexto de base de datos que usa la cadena de conexión reincardbConnection2.
    /// Hereda toda la configuración del contexto principal reincardbContext.
    /// </summary>
    public class reincardbContext2 : reincardbContext
    {
        public reincardbContext2()
        {
        }

        public reincardbContext2(DbContextOptions<reincardbContext2> options) : base(ChangeOptionsType(options))
        {
        }

        /// <summary>
        /// Convierte las opciones de reincardbContext2 a reincardbContext para la clase base.
        /// </summary>
        private static DbContextOptions<reincardbContext> ChangeOptionsType(DbContextOptions<reincardbContext2> options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<reincardbContext>();
            
            foreach (var extension in options.Extensions)
            {
                ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);
            }

            return optionsBuilder.Options;
        }
    }
}
