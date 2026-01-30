using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Microsoft.Win32;
using Radzen;
using Radzen.Blazor;
using Reincarapp.Data;
//using Reincarapp.Pages.Configuracion.Seguridad.UsarioCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reincarapp.Components.Pages.Transaccional.Gestionar.ClienteDeuda
{
    public partial class ClienteDeuda
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        public reincardbService reincardbService { get; set; }

        [Inject]
        public reincardbContext db { get; set; }

        protected IEnumerable<Reincarapp.Models.reincardb.ClienteDeuda> clienteDeuda;

        protected RadzenDataGrid<Reincarapp.Models.reincardb.ClienteDeuda> grid0;

        protected string search = "";

        string searchValue = "";

        [Inject]
        protected SecurityService Security { get; set; }

        DateTime now = DateTime.Now;
        DateTime startDate;
        DateTime endDate;


        protected bool isBusy = false;

        List<Models.reincardb.UsuarioCliente> usuarioClientes = new List<Models.reincardb.UsuarioCliente>();
        protected IEnumerable<Reincarapp.Models.reincardb.Cliente> clientesForIdCliente;

        long? IdCliente;


        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            /*


            //var  dato = await reincardbService.GetClienteDeudaDatos(new Query { Filter = $@"i => i.Dato.Contains(@0)  ", FilterParameters = new object[] { search }, Expand = "Cliente,ClienteDeudum,ClienteDeudum.EstadoClienteDeudum" });
            if (!Security.IsInRole(new string[] {"Administrador"}))
            {

                clienteDeuda = (await db.ClienteDeudaDatos.Include(x => x.Cliente)
                                                          .Include(x => x.ClienteDeudum.Persona)
                                                          .Include(x => x.ClienteDeudum.EstadoClienteDeudum)
                                                          .Include(x => x.ClienteDeudum.Usuario)
                                                          .Include(x => x.ClienteDeudum.Usuario1)
                                                          .Include(x => x.ClienteDeudum.ResultadoEvento1)
                                                          .Include(x => x.ClienteDeudum.ResultadoEvento)
                                                          //.Include(x => x.ClienteDeudum.Eventos.Where(x=> x.Fecha_Creacion_Evento >= startDate && x.Fecha_Creacion_Evento <= endDate))
                                                          .Where(x => x.dato.Contains(search) && x.Fecha_Final == null && x.Fecha_Inicial >= startDate && x.Fecha_Inicial <= endDate).ToListAsync()).Select(x => x.ClienteDeudum);

            }
            else {

                clienteDeuda = (await db.ClienteDeudaDatos.Include(x => x.Cliente)
                                                          .Include(x => x.ClienteDeudum.Persona)
                                                          .Include(x => x.ClienteDeudum.EstadoClienteDeudum)
                                                          .Include(x => x.ClienteDeudum.Usuario)
                                                          .Include(x => x.ClienteDeudum.Usuario1)
                                                          .Include(x => x.ClienteDeudum.ResultadoEvento1)
                                                          .Include(x => x.ClienteDeudum.ResultadoEvento)
                                                          //.Include(x => x.ClienteDeudum.Eventos.Where(x=> x.Fecha_Creacion_Evento >= startDate && x.Fecha_Creacion_Evento <= endDate))
                                                          .Where(x => usuarioClientes.Select(y => y.Id_Cliente).Contains(x.Cliente.Id_Cliente) && x.dato.Contains(search) && x.Fecha_Final == null && x.Fecha_Inicial >= startDate && x.Fecha_Inicial <= endDate).ToListAsync()).Select(x => x.ClienteDeudum);   //await reincardbService.GetClienteDeuda(new Query { Filter = $@"i => ", FilterParameters = new object[] { search }, Expand = "EstadoClienteDeudum,Cliente,Persona,Usuario,Usuario1,Asignacion,ResultadoEvento1,ResultadoEvento,ClienteDeudaDato" });

            }*/
                
        }
        protected override async Task OnInitializedAsync()
        {

            try { 
             startDate = new DateTime(now.Year, now.Month, 1);
             endDate = startDate.AddMonths(1).AddDays(-1);

                usuarioClientes = await db.UsuarioCliente.Include(x => x.Usuario).Where(x => x.Usuario.Usuario1 == Security.User.UserName).ToListAsync();


                if (Security.IsInRole(new string[] { "Administrador" }))
                {
                    clientesForIdCliente = await db.Cliente.Where(x=>x.sp_ins == "SP_INSERT_GENERICO").ToListAsync();

                }
                else {

                    clientesForIdCliente = (await db.Cliente.Where(x=>x.sp_ins == "SP_INSERT_GENERICO").ToListAsync()).Where(x => usuarioClientes.Select(y => y.Id_Cliente).Contains(x.Id_Cliente));

                }

                    

               

            }
            catch (Exception ex) { 
            
            
            var error = ex.Message;


            }

            //clienteDeuda = await reincardbService.GetClienteDeuda(new Query { Filter = $@"i => i.Nombre_Cliente_Deuda.Contains(@0) || i.Id_Negocio.Contains(@0) || i.Id_Asignacion.Contains(@0) || i.Numero_Documento.Contains(@0) || i.campana_reparto.Contains(@0)", FilterParameters = new object[] { search }, Expand = "EstadoClienteDeudum,Cliente,Persona,Usuario,Usuario1,Asignacion,ResultadoEvento1,ResultadoEvento" });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            isBusy = true;
            await LoadData();
            isBusy = false;
            //await DialogService.OpenAsync<AddClienteDeudum>("Add ClienteDeudum", null);
            //await grid0.Reload();
        }


        string GetMejorGestion(Models.reincardb.ClienteDeuda clienteDeudum) {
            string res = "Sin Gestion";
            var evento = clienteDeudum.ClienteDeudaCons.FirstOrDefault()?.Evento1;
            if (evento == null)
                return res;
            if (evento.Fecha_Creacion_Evento >= startDate && evento.Fecha_Creacion_Evento <= endDate)
            {
                res = evento.ResultadoEvento.Nombre_Resultado_Evento;
            }
            return res;
        }

        string GetUltimaGestion(Models.reincardb.ClienteDeuda clienteDeudum)
        {

            string res = "Sin Gestion";
            var evento = clienteDeudum.ClienteDeudaCons.FirstOrDefault()?.Evento;
            if (evento == null)
                return res;
            if (evento.Fecha_Creacion_Evento >= startDate && evento.Fecha_Creacion_Evento <= endDate)
            {
                res = evento.ResultadoEvento.Nombre_Resultado_Evento;
            }
            return res;

        }

        async Task LoadData() {

            bool isSearchValueNumeric = long.TryParse(searchValue, out _);

            clienteDeuda = ((await db.ClienteDeudaDato.AsNoTracking().Include(x => x.Cliente)
                                                          .Include(x => x.Cliente)
                                                          .Include(x => x.ClienteDeuda.Persona)
                                                          .Include(x => x.ClienteDeuda.EstadoClienteDeuda)
                                                          .Include(x => x.ClienteDeuda.Usuario)
                                                          .Include(x => x.ClienteDeuda.Usuario1)
                                                          .Include(x => x.ClienteDeuda.ResultadoEvento1)
                                                          .Include(x => x.ClienteDeuda.ResultadoEvento)
                                                          .Include(x => x.ClienteDeuda.ClienteDeudaCons)
                                                          .ThenInclude(x => x.Evento)
                                                          .ThenInclude(x => x.ResultadoEvento)
                                                          .Include(x => x.ClienteDeuda.ClienteDeudaCons)
                                                          .ThenInclude(x => x.Evento1)
                                                          .ThenInclude(Evento => Evento.ResultadoEvento)
                                                          //.Include(x => x.ClienteDeudum.Eventos.Where(x=> x.Fecha_Creacion_Evento >= startDate && x.Fecha_Creacion_Evento <= endDate))
                                                          .Where(x => x.Id_Cliente == this.IdCliente && (x.Identificacion.Contains(searchValue) || (!isSearchValueNumeric && x.Dato.Contains(searchValue))) && x.Fecha_Final == null && x.Fecha_Inicial >= startDate && x.Fecha_Inicial <= endDate).ToListAsync()).Select(x => x.ClienteDeuda)).OrderBy(x => x.Persona.Nombre_Persona).OrderBy(x => x.Persona.Numero_Documento).ToList();






            await grid0.Reload();


        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Reincarapp.Models.reincardb.ClienteDeuda> args)
        {
            //await DialogService.OpenAsync<EditClienteDeudum>("Edit ClienteDeudum", new Dictionary<string, object> { {"Id_Cliente_Deuda", args.Data.Id_Cliente_Deuda} });
            await DialogService.OpenAsync<GestionarDeuda>("Gestionando...", new Dictionary<string, object> { { "registro", args.Data } }, new DialogOptions { Width = "100%", Height = "100%", Draggable = false, Resizable = false });

            await LoadData();

            

        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Reincarapp.Models.reincardb.ClienteDeuda clienteDeudum)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await reincardbService.DeleteClienteDeuda(clienteDeudum.Id_Cliente_Deuda);

                    if (deleteResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = $"Error",
                    Detail = $"Unable to delete ClienteDeudum"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await reincardbService.ExportClienteDeudaToCSV(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "EstadoClienteDeudum,Cliente,Persona,Usuario,Usuario1,Asignacion,ResultadoEvento1,ResultadoEvento",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "ClienteDeuda");
            }

            if (args == null || args.Value == "xlsx")
            {
                await reincardbService.ExportClienteDeudaToExcel(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "EstadoClienteDeudum,Cliente,Persona,Usuario,Usuario1,Asignacion,ResultadoEvento1,ResultadoEvento",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "ClienteDeuda");
            }
        }
    }
}