using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Reincarapp.Components.Pages.Configuracion.Base
{
    public partial class Bases
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

        protected IEnumerable<Reincarapp.Models.reincardb.Base> bases;

        protected RadzenDataGrid<Reincarapp.Models.reincardb.Base> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            bases = await reincardbService.GetBase(new Query { Filter = $@"i => i.Nombre.Contains(@0) || i.NombreArchivo.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Cliente,Tipobase,Usuario,Usuario1" });
        }
        protected override async Task OnInitializedAsync()
        {
            bases = await reincardbService.GetBase(new Query { Filter = $@"i => i.Nombre.Contains(@0) || i.NombreArchivo.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Cliente,Tipobase,Usuario,Usuario1" });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddBase>("Add Base", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Reincarapp.Models.reincardb.Base> args)
        {
            await DialogService.OpenAsync<EditBase>("Edit Base", new Dictionary<string, object> { {"Id", args.Data.Id} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Reincarapp.Models.reincardb.Base _base)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await reincardbService.DeleteBase(_base.Id);

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
                    Detail = $"Unable to delete Base"
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await reincardbService.ExportBaseToCSV(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "Cliente,Tipobase,Usuario,Usuario1",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "Bases");
            }

            if (args == null || args.Value == "xlsx")
            {
                await reincardbService.ExportBaseToExcel(new Query
{
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}",
    OrderBy = $"{grid0.Query.OrderBy}",
    Expand = "Cliente,Tipobase,Usuario,Usuario1",
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property)).Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
}, "Bases");
            }
        }

        protected Reincarapp.Models.reincardb.Base _baseChild;
        protected async Task GetChildData(Reincarapp.Models.reincardb.Base args)
        {
            _baseChild = args;
            var BasecamposResult = await reincardbService.GetBasecampo(new Query { Filter = $@"i => i.BaseId == {args.Id}", Expand = "Base" });
            if (BasecamposResult != null)
            {
                args.Basecampo = BasecamposResult.ToList();
            }
        }
        protected Reincarapp.Models.reincardb.Basecampo basecampoBasecampos;

        protected IEnumerable<Reincarapp.Models.reincardb.Base> basesForBaseIdBasecampos;

        protected RadzenDataGrid<Reincarapp.Models.reincardb.Basecampo> BasecamposDataGrid;

        [Inject]
        protected SecurityService Security { get; set; }

        protected async Task BasecamposAddButtonClick(MouseEventArgs args, Reincarapp.Models.reincardb.Base data)
        {

            var dialogResult = await DialogService.OpenAsync<AddBasecampo>("Add Basecampos", new Dictionary<string, object> { {"BaseId" , data.Id} });
            await GetChildData(data);
            await BasecamposDataGrid.Reload();

        }

        protected async Task BasecamposRowSelect(DataGridRowMouseEventArgs<Reincarapp.Models.reincardb.Basecampo> args, Reincarapp.Models.reincardb.Base data)
        {
            var dialogResult = await DialogService.OpenAsync<EditBasecampo>("Edit Basecampos", new Dictionary<string, object> { {"Id", args.Data.Id} });
            await GetChildData(data);
            await BasecamposDataGrid.Reload();
        }

        protected async Task BasecamposDeleteButtonClick(MouseEventArgs args, Reincarapp.Models.reincardb.Basecampo basecampo)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await reincardbService.DeleteBasecampo(basecampo.Id);

                    await GetChildData(_baseChild);

                    if (deleteResult != null)
                    {
                        await BasecamposDataGrid.Reload();
                    }
                }
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = $"Error",
                    Detail = $"Unable to delete Basecampo"
                });
            }
        }
    }
}