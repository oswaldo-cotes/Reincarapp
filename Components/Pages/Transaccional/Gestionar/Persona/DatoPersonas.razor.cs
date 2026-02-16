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
    public partial class DatoPersonas
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

        protected IEnumerable<Reincarapp.Models.reincardb.DatoPersona> datoPersonas;

        protected RadzenDataGrid<Reincarapp.Models.reincardb.DatoPersona> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            datoPersonas = await reincardbService.GetDatoPersona(new Query { Filter = $@"i => i.Dato.Contains(@0) || i.Zona_Ubic.Contains(@0) || i.Zona_Ubic_1.Contains(@0) || i.Zona_Ubic_2.Contains(@0) || i.Zona_Ubic_3.Contains(@0) || i.Tipo_Via_Num_1.Contains(@0) || i.Tipo_Via_Num_2.Contains(@0)", FilterParameters = new object[] { search }, Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVia,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3" });
        }
        protected override async Task OnInitializedAsync()
        {
            datoPersonas = await reincardbService.GetDatoPersona(new Query { Filter = $@"i => i.Dato.Contains(@0) || i.Zona_Ubic.Contains(@0) || i.Zona_Ubic_1.Contains(@0) || i.Zona_Ubic_2.Contains(@0) || i.Zona_Ubic_3.Contains(@0) || i.Tipo_Via_Num_1.Contains(@0) || i.Tipo_Via_Num_2.Contains(@0)", FilterParameters = new object[] { search }, Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVia,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3" });
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await reincardbService.ExportDatoPersonaToCSV(new Query
                {
                    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
                    OrderBy = $"{grid0.Query.OrderBy}",
                    Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVia,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3",
                    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
                }, "DatoPersonas");
            }

            if (args == null || args.Value == "xlsx")
            {
                await reincardbService.ExportDatoPersonaToExcel(new Query
                {
                    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
                    OrderBy = $"{grid0.Query.OrderBy}",
                    Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVia,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3",
                    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
                }, "DatoPersonas");
            }
        }

        protected Reincarapp.Models.reincardb.DatoPersona datoPersonaChild;

        [Inject]
        protected SecurityService Security { get; set; }
        protected async Task GetChildData(Reincarapp.Models.reincardb.DatoPersona args)
        {
            datoPersonaChild = args;
        }
    }
}