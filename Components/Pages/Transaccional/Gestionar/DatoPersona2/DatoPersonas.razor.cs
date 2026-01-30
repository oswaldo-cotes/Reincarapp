using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using Reincarapp.Models.reincardb;
using Reincarapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reincarapp.Components.Pages.Transaccional.Gestionar.DatoPersona2
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

        [Inject]
        public DatoPersonaSyncService datoPersonaSyncService { get; set; }


        protected IEnumerable<Reincarapp.Models.reincardb.DatoPersona> datoPersonas;

        protected RadzenDataGrid<Reincarapp.Models.reincardb.DatoPersona> grid0;


        IList<Reincarapp.Models.reincardb.DatoPersona> selectedEmployees;

        [Parameter]
        public Action<Reincarapp.Models.reincardb.DatoPersona> EnabledDisabledParent { get; set; }


        [Parameter]
        public long PersonaId { get; set; }


        protected string search = "";

        [Inject]
        protected SecurityService Security { get; set; }

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

             datoPersonas = (await reincardbService.GetDatoPersona(new Query { Filter = $@"i => i.Dato.Contains(@0) && i.Id_Persona == @1", FilterParameters = new object[] { search,PersonaId }, Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVium,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3" })).Where(x=>x.Dato.Trim().Replace(" ", "") != "'#-'").ToList();
        }
        protected override async Task OnInitializedAsync()
        {
            //datoPersonas = (await reincardbService.GetDatoPersona(new Query { Filter = $@"i => i.Dato.Contains(@0) && i.Id_Persona == @1", FilterParameters = new object[] { search,PersonaId }, Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVium,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3" })).Where(x=>x.Dato.Trim().Replace(" ", "") != "'#-'").ToList();
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {

                // **SINCRONIZACIÓN DE DATOS PERSONA DESDE HISTÓRICO**
                try
                {

                    var persona = await reincardbService.GetPersonaByIdPersona(PersonaId);

                    int registrosSincronizados = await datoPersonaSyncService.SincronizarDatosPersonaAsync(
                        persona.Numero_Documento,
                        PersonaId
                    );

                    if (registrosSincronizados > 0)
                    {
                        // Actualizar la lista de datos persona en pantalla
                        datoPersonas = (await reincardbService.GetDatoPersona(new Query { Filter = $@"i => i.Dato.Contains(@0) && i.Id_Persona == @1", FilterParameters = new object[] { search, PersonaId }, Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVium,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3" })).Where(x => x.Dato.Trim().Replace(" ", "") != "'#-'").ToList();

                        // await ShowNotification(new Radzen.NotificationMessage()
                        // {
                        //     Severity = Radzen.NotificationSeverity.Success,
                        //     Summary = "Sincronización",
                        //     Detail = $"{registrosSincronizados} dato(s) sincronizado(s) desde histórico",
                        //     Duration = 3000
                        // });
                    }
                }
                catch (Exception ex)
                {
                    // await ShowNotification(new Radzen.NotificationMessage()
                    // {
                    //     Severity = Radzen.NotificationSeverity.Warning,
                    //     Summary = "Sincronización",
                    //     Detail = $"No se pudieron sincronizar datos históricos: {ex.Message}",
                    //     Duration = 3000
                    // });
                }

                StateHasChanged();
            }

        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddDatoPersona>("Add DatoPersona", new Dictionary<string, object> { { "PersonaId", PersonaId } });

            datoPersonas = (await reincardbService.GetDatoPersona(new Query { Filter = $@"i => i.Dato.Contains(@0) && i.Id_Persona == @1", FilterParameters = new object[] { search, PersonaId }, Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVium,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3" })).Where(x => x.Dato.Trim().Replace(" ", "") != "'#-'").ToList();

            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Reincarapp.Models.reincardb.DatoPersona> args)
        {
            await DialogService.OpenAsync<EditDatoPersona>("Edit DatoPersona", new Dictionary<string, object> { {"Id_Dato_Persona", args.Data.Id_Dato_Persona} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Reincarapp.Models.reincardb.DatoPersona datoPersona)
        {
            try
            {

                await DialogService.OpenAsync<EditDatoPersona>("Edit DatoPersona", new Dictionary<string, object> { { "Id_Dato_Persona", datoPersona.Id_Dato_Persona } });

                //if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                //{
                //    var deleteResult = await reincardbService.DeleteDatoPersona(datoPersona.Id_Dato_Persona);

                //    if (deleteResult != null)
                //    {
                //        await grid0.Reload();
                //    }
                //}
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = $"Error",
                    Detail = $"Unable to delete DatoPersona"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await reincardbService.ExportDatoPersonaToCSV(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVium,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "DatoPersonas");
            }

            if (args == null || args.Value == "xlsx")
            {
                await reincardbService.ExportDatoPersonaToExcel(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVium,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "DatoPersonas");
            }
        }


        protected void OnRowClick(DataGridRowMouseEventArgs<Reincarapp.Models.reincardb.DatoPersona> args)
        {
            EnabledDisabledParent(args.Data);
        }

    }
}