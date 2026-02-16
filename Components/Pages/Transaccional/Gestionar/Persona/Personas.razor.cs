using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Reincarapp.Components.Pages.Transaccional.Gestionar.Persona
{
    public partial class Personas
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

        protected IEnumerable<Reincarapp.Models.reincardb.Persona> personas;

        protected RadzenDataGrid<Reincarapp.Models.reincardb.Persona> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            personas = await reincardbService.GetPersona(new Query { Filter = $@"i => i.Numero_Documento.Contains(@0) || i.Nombre_Persona.Contains(@0)", FilterParameters = new object[] { search }, Expand = "TipoDocumento" });
        }
        protected override async Task OnInitializedAsync()
        {
            personas = await reincardbService.GetPersona(new Query { Filter = $@"i => i.Numero_Documento.Contains(@0) || i.Nombre_Persona.Contains(@0)", FilterParameters = new object[] { search }, Expand = "TipoDocumento" });
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await reincardbService.ExportPersonaToCSV(new Query
                {
                    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
                    OrderBy = $"{grid0.Query.OrderBy}",
                    Expand = "TipoDocumento",
                    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
                }, "Personas");
            }

            if (args == null || args.Value == "xlsx")
            {
                await reincardbService.ExportPersonaToExcel(new Query
                {
                    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
                    OrderBy = $"{grid0.Query.OrderBy}",
                    Expand = "TipoDocumento",
                    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
                }, "Personas");
            }
        }

        protected Reincarapp.Models.reincardb.Persona personaChild;
        protected async Task GetChildData(Reincarapp.Models.reincardb.Persona args)
        {
            personaChild = args;
            var ClienteDeudaResult = await reincardbService.GetClienteDeuda(new Query { Filter = $@"i => i.Id_Persona == {args.Id_Persona}", Expand = "EstadoClienteDeuda,Cliente,Persona,Usuario,Usuario1,Asignacion,ResultadoEvento1,ResultadoEvento" });
            if (ClienteDeudaResult != null)
            {
                args.ClienteDeuda = ClienteDeudaResult.ToList();
            }
            var DatoPersonasResult = await reincardbService.GetDatoPersona(new Query { Filter = $@"i => i.Id_Persona == {args.Id_Persona}", Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVia,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3" });
            if (DatoPersonasResult != null)
            {
                args.DatoPersona = DatoPersonasResult.ToList();
            }
        }
        protected Reincarapp.Models.reincardb.ClienteDeuda clienteDeudumClienteDeuda;

        protected IEnumerable<Reincarapp.Models.reincardb.EstadoClienteDeuda> estadoClienteDeudaForIdEstadoClienteDeudaClienteDeuda;

        protected IEnumerable<Reincarapp.Models.reincardb.Cliente> clientesForIdClienteClienteDeuda;

        protected IEnumerable<Reincarapp.Models.reincardb.Persona> personasForIdPersonaClienteDeuda;

        protected IEnumerable<Reincarapp.Models.reincardb.Usuario> usuariosForIdUsuarioClienteDeuda;

        protected IEnumerable<Reincarapp.Models.reincardb.Usuario> usuariosForIdUsuarioAsignadoClienteDeuda;

        protected IEnumerable<Reincarapp.Models.reincardb.Asignacion> asignacionsForIdAsignacionClienteDeuda;

        protected IEnumerable<Reincarapp.Models.reincardb.ResultadoEvento> resultadoEventosForIdUltimaGestionClienteDeuda;

        protected IEnumerable<Reincarapp.Models.reincardb.ResultadoEvento> resultadoEventosForIdMejorGestionClienteDeuda;

        protected RadzenDataGrid<Reincarapp.Models.reincardb.ClienteDeuda> ClienteDeudaDataGrid;
        protected Reincarapp.Models.reincardb.DatoPersona datoPersonaDatoPersonas;

        protected IEnumerable<Reincarapp.Models.reincardb.TipoDatoPersona> tipoDatoPersonasForIdTipoDatoPersonaDatoPersonas;

        protected IEnumerable<Reincarapp.Models.reincardb.Persona> personasForIdPersonaDatoPersonas;

        protected IEnumerable<Reincarapp.Models.reincardb.Departamento> departamentosForIdDepartamentoDatoPersonas;

        protected IEnumerable<Reincarapp.Models.reincardb.Municipio> municipiosForIdMunicipioDatoPersonas;

        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacionDatoPersonas;

        protected IEnumerable<Reincarapp.Models.reincardb.TipoVia> tipoViaForIdTipoViaDatoPersonas;

        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacion1DatoPersonas;

        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacion2DatoPersonas;

        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacion3DatoPersonas;

        protected RadzenDataGrid<Reincarapp.Models.reincardb.DatoPersona> DatoPersonasDataGrid;

        [Inject]
        protected SecurityService Security { get; set; }
    }
}