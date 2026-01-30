using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Storage;
using NPOI.OpenXmlFormats.Spreadsheet;
using Reincarapp.Data;

namespace Reincarapp.Services
{
    public class MyReincardbService
    {

        reincardbContext Context
        {
            get
            {
                return this.context;
            }
        }

        private readonly reincardbContext context;
        private readonly NavigationManager navigationManager;

        public MyReincardbService(reincardbContext context)
        {
            this.context = context;
            
        }

        public async Task<Reincarapp.Models.reincardb.Evento> CreateEvento(Reincarapp.Models.reincardb.Evento evento)
        {


            using (IDbContextTransaction transaction = await Context.Database.BeginTransactionAsync())
            {
                try
                {





                    //this._context.Documentos.Update(documento);

                    // if (documento.DocumentoEstados.Count() > 0)
                    // {

                    //     var ar = await this._context.DocumentoEstados.Where(x => x.DocumentoId == documento.Id && x.Fecha_Final == null)
                    //                        .ExecuteUpdateAsync(s => s.SetProperty(e => e.Fecha_Final, e => DateTime.Now));

                    //     await this._context.DocumentoEstados.AddRangeAsync(documento.DocumentoEstados.Where(x => x.Id == 0));


                    // }

                    // _context.Entry(documento).State = EntityState.Modified;

                    await this.Context.SaveChangesAsync();
                    await transaction.CommitAsync();

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                }

                return evento;


            }


        }


        }
}
