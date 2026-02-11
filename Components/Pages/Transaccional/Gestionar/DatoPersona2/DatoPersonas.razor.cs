using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Microsoft.Extensions.Logging;
using Radzen;
using Radzen.Blazor;
using Reincarapp.Models.reincardb;
using Reincarapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reincarapp.Data;

namespace Reincarapp.Components.Pages.Transaccional.Gestionar.DatoPersona2
{
    public partial class DatoPersonas : IAsyncDisposable
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

        [Inject]
        public IDbContextFactory<reincardbContext> DbContextFactory { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected ILogger<DatoPersonas> Logger { get; set; }

        protected IEnumerable<Reincarapp.Models.reincardb.DatoPersona> datoPersonas;
        protected RadzenDataGrid<Reincarapp.Models.reincardb.DatoPersona> grid0;
        protected IList<Reincarapp.Models.reincardb.DatoPersona> selectedEmployees;
        protected string search = "";

        private bool _isLoading = false;

        [Parameter]
        public Action<Reincarapp.Models.reincardb.DatoPersona> EnabledDisabledParent { get; set; }

        [Parameter]
        public long PersonaId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Logger.LogInformation("Inicializando componente DatoPersonas para PersonaId: {PersonaId}", PersonaId);

                if (PersonaId <= 0)
                {
                    Logger.LogWarning("PersonaId inválido: {PersonaId}", PersonaId);
                    await ShowWarningNotification("Advertencia", "ID de persona no válido");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al inicializar DatoPersonas para PersonaId: {PersonaId}", PersonaId);
                await ShowErrorNotification("Error de inicialización", ex.Message);
            }
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && !_isLoading)
            {
                _isLoading = true;

                try
                {
                    Logger.LogInformation("Primera renderización de DatoPersonas para PersonaId: {PersonaId}", PersonaId);

                    // Usar contexto independiente para la sincronización
                    using var context = await DbContextFactory.CreateDbContextAsync();
                    var persona = await context.Persona
                        .AsNoTracking()
                        .FirstOrDefaultAsync(p => p.Id_Persona == PersonaId);

                    if (persona != null)
                    {
                        Logger.LogInformation("Iniciando sincronización de datos para documento: {NumeroDocumento}",
                            persona.Numero_Documento);

                        int registrosSincronizados = await datoPersonaSyncService.SincronizarDatosPersonaAsync(
                            persona.Numero_Documento,
                            PersonaId
                        );

                        if (registrosSincronizados > 0)
                        {
                            Logger.LogInformation("Sincronizados {Count} registros para PersonaId: {PersonaId}",
                                registrosSincronizados, PersonaId);
                        }
                        else
                        {
                            Logger.LogInformation("No se encontraron datos para sincronizar. PersonaId: {PersonaId}", PersonaId);
                        }

                        await LoadData();

                        await InvokeAsync(() => StateHasChanged());
                    }
                    else
                    {
                        Logger.LogWarning("No se encontró persona con Id: {PersonaId}", PersonaId);
                        await ShowWarningNotification("Advertencia", "No se encontró la persona especificada");
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "Error sincronizando datos para PersonaId: {PersonaId}", PersonaId);
                    await ShowErrorNotification("Error en sincronización", "No se pudieron sincronizar los datos históricos");
                }
                finally
                {
                    _isLoading = false;
                }
            }
        }

        protected async Task Search(ChangeEventArgs args)
        {
            try
            {
                search = $"{args.Value}";
                Logger.LogInformation("Búsqueda de DatoPersona iniciada. Término: {SearchTerm}, PersonaId: {PersonaId}",
                    search, PersonaId);

                if (grid0 != null)
                {
                    await grid0.GoToPage(0);
                }

                datoPersonas = (await reincardbService.GetDatoPersona(
                    new Query
                    {
                        Filter = $@"i => i.Dato.Contains(@0) && i.Id_Persona == @1",
                        FilterParameters = new object[] { search, PersonaId },
                        Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVia,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3"
                    }))
                    .Where(x => x.Dato.Trim().Replace(" ", "") != "'#-'")
                    .ToList();

                Logger.LogInformation("Búsqueda completada. Resultados: {Count}", datoPersonas?.Count() ?? 0);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error en búsqueda de DatoPersona. Término: {SearchTerm}, PersonaId: {PersonaId}",
                    search, PersonaId);

                datoPersonas = Enumerable.Empty<DatoPersona>();
                await ShowErrorNotification("Error en búsqueda", ex.Message);
            }
        }

        private async Task LoadData()
        {
            try
            {
                //if (_isLoading)
                //{
                //    Logger.LogWarning("LoadData ya está en ejecución, omitiendo llamada duplicada");
                //    return;
                //}

                _isLoading = true;

                Logger.LogInformation("Cargando datos de persona para PersonaId: {PersonaId}", PersonaId);

                using var contextReload = await DbContextFactory.CreateDbContextAsync();

                datoPersonas = await contextReload.DatoPersona
                    .AsNoTracking()
                    .Where(x => x.Id_Persona == PersonaId &&
                           x.Dato.Trim().Replace(" ", "") != "'#-'")
                    .Include(x => x.TipoDatoPersona)
                    .Include(x => x.Persona)
                    .Include(x => x.Departamento)
                    .Include(x => x.Municipio)
                    .Include(x => x.ZonaUbicacion)
                    .Include(x => x.TipoVia)
                    .Include(x => x.ZonaUbicacion1)
                    .Include(x => x.ZonaUbicacion2)
                    .Include(x => x.ZonaUbicacion3)
                    .ToListAsync();

                Logger.LogInformation("Datos cargados exitosamente. Total registros: {Count}",
                    datoPersonas?.Count() ?? 0);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al cargar datos para PersonaId: {PersonaId}", PersonaId);

                datoPersonas = Enumerable.Empty<DatoPersona>();
                await ShowErrorNotification("Error al cargar datos", ex.Message);
            }
            finally
            {
                _isLoading = false;
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            try
            {
                Logger.LogInformation("Abriendo diálogo para agregar DatoPersona. PersonaId: {PersonaId}", PersonaId);

                await DialogService.OpenAsync<AddDatoPersona>(
                    "Add DatoPersona",
                    new Dictionary<string, object> { { "PersonaId", PersonaId } }
                );

                Logger.LogInformation("Diálogo cerrado, recargando datos");

                await LoadData();

                if (grid0 != null)
                {
                    await grid0.Reload();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al agregar DatoPersona para PersonaId: {PersonaId}", PersonaId);
                await ShowErrorNotification("Error al agregar", ex.Message);
            }
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Reincarapp.Models.reincardb.DatoPersona> args)
        {
            try
            {
                if (args?.Data == null)
                {
                    Logger.LogWarning("EditRow llamado con datos null");
                    return;
                }

                Logger.LogInformation("Abriendo diálogo de edición para DatoPersona: {IdDatoPersona}",
                    args.Data.Id_Dato_Persona);

                await DialogService.OpenAsync<EditDatoPersona>(
                    "Edit DatoPersona",
                    new Dictionary<string, object> { { "Id_Dato_Persona", args.Data.Id_Dato_Persona } }
                );

                Logger.LogInformation("Diálogo cerrado, recargando datos");

                await LoadData();

                if (grid0 != null)
                {
                    await grid0.Reload();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al editar DatoPersona: {IdDatoPersona}",
                    args?.Data?.Id_Dato_Persona);
                await ShowErrorNotification("Error al editar", ex.Message);
            }
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Reincarapp.Models.reincardb.DatoPersona datoPersona)
        {
            try
            {
                if (datoPersona == null)
                {
                    Logger.LogWarning("GridDeleteButtonClick llamado con datoPersona null");
                    return;
                }

                Logger.LogInformation("Abriendo diálogo de edición/eliminación para DatoPersona: {IdDatoPersona}",
                    datoPersona.Id_Dato_Persona);

                await DialogService.OpenAsync<EditDatoPersona>(
                    "Edit DatoPersona",
                    new Dictionary<string, object> { { "Id_Dato_Persona", datoPersona.Id_Dato_Persona } }
                );

                Logger.LogInformation("Diálogo cerrado, recargando datos");

                await LoadData();

                if (grid0 != null)
                {
                    await grid0.Reload();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al procesar DatoPersona: {IdDatoPersona}",
                    datoPersona?.Id_Dato_Persona);

                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = $"No se pudo procesar el dato de persona: {ex.Message}",
                    Duration = 5000
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            try
            {
                Logger.LogInformation("Exportando DatoPersonas a formato: {Format}", args?.Value ?? "xlsx");

                if (grid0 == null)
                {
                    Logger.LogWarning("Grid no está inicializado para exportación");
                    await ShowWarningNotification("Error de exportación", "No hay datos para exportar");
                    return;
                }

                var query = new Query
                {
                    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter) ? "true" : grid0.Query.Filter)}",
                    OrderBy = $"{grid0.Query.OrderBy}",
                    Expand = "TipoDatoPersona,Persona,Departamento,Municipio,ZonaUbicacion,TipoVia,ZonaUbicacion1,ZonaUbicacion2,ZonaUbicacion3",
                    Select = string.Join(",", grid0.ColumnsCollection
                        .Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property))
                        .Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
                };

                if (args?.Value == "csv")
                {
                    await reincardbService.ExportDatoPersonaToCSV(query, "DatoPersonas");
                    Logger.LogInformation("Exportación a CSV completada exitosamente");
                }
                else
                {
                    await reincardbService.ExportDatoPersonaToExcel(query, "DatoPersonas");
                    Logger.LogInformation("Exportación a Excel completada exitosamente");
                }

                await ShowSuccessNotification("Exportación exitosa", "Los datos se han exportado correctamente");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al exportar DatoPersonas a formato: {Format}", args?.Value ?? "xlsx");
                await ShowErrorNotification("Error al exportar", ex.Message);
            }
        }

        protected void OnRowClick(DataGridRowMouseEventArgs<Reincarapp.Models.reincardb.DatoPersona> args)
        {
            try
            {
                if (args?.Data == null)
                {
                    Logger.LogWarning("OnRowClick llamado con datos null");
                    return;
                }

                Logger.LogInformation("Fila seleccionada. IdDatoPersona: {IdDatoPersona}, Dato: {Dato}",
                    args.Data.Id_Dato_Persona, args.Data.Dato);

                EnabledDisabledParent?.Invoke(args.Data);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al procesar clic en fila. IdDatoPersona: {IdDatoPersona}",
                    args?.Data?.Id_Dato_Persona);
            }
        }

        private async Task ShowErrorNotification(string summary, string detail)
        {
            try
            {
                await InvokeAsync(() =>
                {
                    NotificationService.Notify(new NotificationMessage
                    {
                        Severity = NotificationSeverity.Error,
                        Summary = summary,
                        Detail = detail,
                        Duration = 5000
                    });
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al mostrar notificación de error");
            }
        }

        private async Task ShowSuccessNotification(string summary, string detail)
        {
            try
            {
                await InvokeAsync(() =>
                {
                    NotificationService.Notify(new NotificationMessage
                    {
                        Severity = NotificationSeverity.Success,
                        Summary = summary,
                        Detail = detail,
                        Duration = 3000
                    });
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al mostrar notificación de éxito");
            }
        }

        private async Task ShowWarningNotification(string summary, string detail)
        {
            try
            {
                await InvokeAsync(() =>
                {
                    NotificationService.Notify(new NotificationMessage
                    {
                        Severity = NotificationSeverity.Warning,
                        Summary = summary,
                        Detail = detail,
                        Duration = 4000
                    });
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al mostrar notificación de advertencia");
            }
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                Logger.LogInformation("Disposing DatoPersonas component para PersonaId: {PersonaId}", PersonaId);
                // Cleanup resources if needed
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al disponer componente DatoPersonas");
            }
        }
    }
}