using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Reincarapp.Components.Pages.Configuracion.Seguridad.UsuarioCliente2
{
    public partial class UsuarioCliente
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

        protected IEnumerable<Reincarapp.Models.reincardb.UsuarioCliente> usuarioClienteCollection;

        protected RadzenDataGrid<Reincarapp.Models.reincardb.UsuarioCliente> grid0;

        protected string search = "";

        [Inject]
        protected SecurityService Security { get; set; }

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            usuarioClienteCollection = await reincardbService.GetUsuarioCliente(new Query { Filter = $@"i => i.AspNetUserId.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Cliente,Usuario,Aspnetusers" });
        }
        protected override async Task OnInitializedAsync()
        {
            usuarioClienteCollection = await reincardbService.GetUsuarioCliente(new Query { Filter = $@"i => i.AspNetUserId.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Cliente,Usuario,Aspnetusers" });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddUsuarioCliente>("Add UsuarioCliente", options: new DialogOptions { Resizable = false, Draggable = false });
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Reincarapp.Models.reincardb.UsuarioCliente> args)
        {
            await DialogService.OpenAsync<EditUsuarioCliente>("Edit UsuarioCliente", new Dictionary<string, object> { {"Id_Usuario_Cliente", args.Data.Id_Usuario_Cliente} }, new DialogOptions { Resizable = false, Draggable = false });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Reincarapp.Models.reincardb.UsuarioCliente usuarioCliente)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await reincardbService.DeleteUsuarioCliente(usuarioCliente.Id_Usuario_Cliente);

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
                    Detail = $"Unable to delete UsuarioCliente"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await reincardbService.ExportUsuarioClienteToCSV(new Query
                {
                    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
                    OrderBy = $"{grid0.Query.OrderBy}",
                    Expand = "Cliente,Usuario,Aspnetusers",
                    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
                }, "UsuarioCliente");
            }

            if (args == null || args.Value == "xlsx")
            {
                await reincardbService.ExportUsuarioClienteToExcel(new Query
                {
                    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
                    OrderBy = $"{grid0.Query.OrderBy}",
                    Expand = "Cliente,Usuario,Aspnetusers",
                    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
                }, "UsuarioCliente");
            }
        }
    }
}