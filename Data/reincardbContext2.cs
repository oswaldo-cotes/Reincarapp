using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Reincarapp.Models.reincardb;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Aplica toda la configuración del contexto padre primero.
            base.OnModelCreating(builder);

            // La BD legacy no tiene la columna AspNetUserId en usuario_cliente.
            // Se debe romper la relación desde ambos lados antes de ignorar
            // la propiedad escalar; de lo contrario EF Core lanza error porque
            // la propiedad sigue siendo una FK referenciada.

            // Paso 1: eliminar la navegación inversa en Aspnetusers.
            builder.Entity<Aspnetusers>()
                .Ignore(e => e.UsuarioCliente);

            // Paso 2: eliminar la navegación y luego la propiedad escalar en UsuarioCliente.
            builder.Entity<UsuarioCliente>()
                .Ignore(e => e.Aspnetusers)
                .Ignore(e => e.AspNetUserId);
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
