using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using Reincarapp.Components.Pages.Transaccional.Gestionar;
using Reincarapp.Data;
using Reincarapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reincarapp.Components.Pages.Transaccional.Gestionar.ClienteDeuda
{
    public partial class ClienteDeuda : IAsyncDisposable
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
        public IDbContextFactory<reincardbContext> DbContextFactory { get; set; }

        [Inject]
        protected ILogger<ClienteDeuda> Logger { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected ILogAppService LogAppService { get; set; }

        protected IEnumerable<Reincarapp.Models.reincardb.ClienteDeuda> clienteDeuda;
        protected RadzenDataGrid<Reincarapp.Models.reincardb.ClienteDeuda> grid0;
        protected string search = "";
        protected string searchValue = "";
        protected bool isBusy = false;

        private DateTime now = DateTime.Now;
        private DateTime startDate;
        private DateTime endDate;
        private bool _isLoading = false;

        private List<Models.reincardb.UsuarioCliente> usuarioClientes = new List<Models.reincardb.UsuarioCliente>();
        protected IEnumerable<Reincarapp.Models.reincardb.Cliente> clientesForIdCliente;

        private long? IdCliente;

        protected async Task Search(ChangeEventArgs args)
        {
            try
            {
                search = $"{args.Value}";
                Logger.LogInformation("Búsqueda iniciada con término: {SearchTerm}", search);

                if (grid0 != null)
                {
                    await grid0.GoToPage(0);
                }

                Logger.LogInformation("Búsqueda completada exitosamente");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error en búsqueda con término: {SearchTerm}", search);

                // Registrar error en logapp usando el servicio
                await LogAppService.RegistrarErrorAsync(
                    "ClienteDeuda.Search",
                    ex,
                    $"Error al buscar con término: {search}",
                    0,
                    Security?.User?.Id
                );


                await ShowErrorNotification("Error en búsqueda", ex.Message);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Logger.LogInformation("Inicializando componente ClienteDeuda para usuario: {Username}", Security?.User?.UserName);

                startDate = new DateTime(now.Year, now.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);

                Logger.LogInformation("Rango de fechas establecido: {StartDate} - {EndDate}", startDate, endDate);

                using var context = await DbContextFactory.CreateDbContextAsync();

                usuarioClientes = await context.UsuarioCliente
                    .Include(x => x.Usuario)
                    .Where(x => x.Usuario.Usuario1 == Security.User.UserName)
                    .AsNoTracking()
                    .ToListAsync();

                Logger.LogInformation("UsuarioClientes cargados: {Count}", usuarioClientes.Count);

                if (Security.IsInRole(new string[] { "Administrador" }))
                {
                    Logger.LogInformation("Usuario es Administrador, cargando todos los clientes");
                    
                    clientesForIdCliente = await context.Cliente
                        .Where(x => x.sp_ins == "SP_INSERT_GENERICO")
                        .AsNoTracking()
                        .ToListAsync();
                }
                else
                {
                    Logger.LogInformation("Usuario no es Administrador, filtrando clientes por permisos");
                    
                    var clienteIds = usuarioClientes.Select(y => y.Id_Cliente).ToList();
                    
                    clientesForIdCliente = (await context.Cliente
                        .Where(x => x.sp_ins == "SP_INSERT_GENERICO")
                        .AsNoTracking()
                        .ToListAsync())
                        .Where(x => clienteIds.Contains(x.Id_Cliente));
                }

                Logger.LogInformation("Clientes cargados exitosamente: {Count}", clientesForIdCliente?.Count() ?? 0);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al inicializar componente ClienteDeuda para usuario: {Username}", Security?.User?.UserName);


                await LogAppService.RegistrarErrorAsync(
                   "ClienteDeuda.OnInitializedAsync",
                   ex,
                   "Error al inicializar componente",
                   0,
                   Security?.User?.Id
               );


                await ShowErrorNotification("Error de inicialización", "No se pudo cargar la información inicial");
            }
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            try
            {
                Logger.LogInformation("Botón Agregar presionado, cargando datos para IdCliente: {IdCliente}", IdCliente);

                if (!IdCliente.HasValue)
                {
                    Logger.LogWarning("No se ha seleccionado un cliente");
                    await ShowWarningNotification("Selección requerida", "Por favor seleccione un cliente");
                    return;
                }

                isBusy = true;
                await InvokeAsync(() => StateHasChanged());

                await LoadData();

                Logger.LogInformation("Datos cargados exitosamente para IdCliente: {IdCliente}", IdCliente);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al cargar datos para IdCliente: {IdCliente}", IdCliente);
                await ShowErrorNotification("Error al cargar datos", ex.Message);
            }
            finally
            {
                isBusy = false;
                await InvokeAsync(() => StateHasChanged());
            }
        }

        protected string GetMejorGestion(Models.reincardb.ClienteDeuda clienteDeudum)
        {
            try
            {
                if (clienteDeudum == null)
                {
                    Logger.LogWarning("GetMejorGestion llamado con clienteDeudum null");
                    return "Sin Gestion";
                }

                string res = "Sin Gestion";
                var evento = clienteDeudum.ClienteDeudaCons?.FirstOrDefault()?.Evento1;
                
                if (evento == null)
                {
                    return res;
                }

                if (evento.Fecha_Creacion_Evento >= startDate && evento.Fecha_Creacion_Evento <= endDate)
                {
                    res = evento.ResultadoEvento?.Nombre_Resultado_Evento ?? "Sin Resultado";
                }

                return res;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al obtener mejor gestión para ClienteDeuda: {IdClienteDeuda}", 
                    clienteDeudum?.Id_Cliente_Deuda);
                return "Error";
            }
        }

        protected string GetUltimaGestion(Models.reincardb.ClienteDeuda clienteDeudum)
        {
            try
            {
                if (clienteDeudum == null)
                {
                    Logger.LogWarning("GetUltimaGestion llamado con clienteDeudum null");
                    return "Sin Gestion";
                }

                string res = "Sin Gestion";
                var evento = clienteDeudum.ClienteDeudaCons?.FirstOrDefault()?.Evento;
                
                if (evento == null)
                {
                    return res;
                }

                if (evento.Fecha_Creacion_Evento >= startDate && evento.Fecha_Creacion_Evento <= endDate)
                {
                    res = evento.ResultadoEvento?.Nombre_Resultado_Evento ?? "Sin Resultado";
                }

                return res;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al obtener última gestión para ClienteDeuda: {IdClienteDeuda}", 
                    clienteDeudum?.Id_Cliente_Deuda);
                return "Error";
            }
        }

        private async Task LoadData()
        {
            try
            {
                if (_isLoading)
                {
                    Logger.LogWarning("LoadData ya está en ejecución, omitiendo llamada duplicada");
                    return;
                }

                _isLoading = true;

                Logger.LogInformation("Cargando datos para IdCliente: {IdCliente}, SearchValue: {SearchValue}, Rango: {StartDate} - {EndDate}", 
                    IdCliente, searchValue, startDate, endDate);

                bool isSearchValueNumeric = long.TryParse(searchValue, out _);

                using var context = await DbContextFactory.CreateDbContextAsync();

                var query = context.ClienteDeudaDato
                    .AsNoTracking()
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
                    .Where(x => x.Id_Cliente == this.IdCliente && 
                           x.Fecha_Final == null && 
                           x.Fecha_Inicial >= startDate && 
                           x.Fecha_Inicial <= endDate);

                if (!string.IsNullOrEmpty(searchValue))
                {
                    if (isSearchValueNumeric)
                    {
                        query = query.Where(x => x.Identificacion.Contains(searchValue));
                    }
                    else
                    {
                        query = query.Where(x => x.Dato.Contains(searchValue));
                    }
                }

                var clienteDeudaList = await query.ToListAsync();

                clienteDeuda = clienteDeudaList
                    .Select(x => x.ClienteDeuda)
                    .OrderBy(x => x.Persona?.Numero_Documento)
                    .ThenBy(x => x.Persona?.Nombre_Persona)
                    .ToList();

                Logger.LogInformation("Datos cargados exitosamente. Total registros: {Count}", clienteDeuda?.Count() ?? 0);

                if (grid0 != null)
                {
                    await grid0.Reload();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al cargar datos para IdCliente: {IdCliente}, SearchValue: {SearchValue}", 
                    IdCliente, searchValue);


                await LogAppService.RegistrarErrorAsync(
                    "ClienteDeuda.LoadData",
                    ex,
                    $"Error al cargar datos. IdCliente: {IdCliente}, SearchValue: {searchValue}",
                    0,
                    Security?.User?.Id
                );


                clienteDeuda = Enumerable.Empty<Reincarapp.Models.reincardb.ClienteDeuda>();
                await ShowErrorNotification("Error al cargar datos", ex.Message);
            }
            finally
            {
                _isLoading = false;
            }
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Reincarapp.Models.reincardb.ClienteDeuda> args)
        {
            try
            {
                if (args?.Data == null)
                {
                    Logger.LogWarning("EditRow llamado con datos null");
                    return;
                }

                Logger.LogInformation("Abriendo diálogo de gestión para ClienteDeuda: {IdClienteDeuda}", 
                    args.Data.Id_Cliente_Deuda);

                await DialogService.OpenAsync<GestionarDeuda>(
                    "Gestionando...",
                    new Dictionary<string, object> { { "registro", args.Data } },
                    new DialogOptions { Width = "100%", Height = "100%", Draggable = false, Resizable = false }
                );

                Logger.LogInformation("Diálogo cerrado, recargando datos");
                await LoadData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al editar ClienteDeuda: {IdClienteDeuda}", args?.Data?.Id_Cliente_Deuda);
                await ShowErrorNotification("Error al abrir gestión", ex.Message);
            }
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Reincarapp.Models.reincardb.ClienteDeuda clienteDeudum)
        {
            try
            {
                if (clienteDeudum == null)
                {
                    Logger.LogWarning("GridDeleteButtonClick llamado con clienteDeudum null");
                    return;
                }

                Logger.LogInformation("Intentando eliminar ClienteDeuda: {IdClienteDeuda}", clienteDeudum.Id_Cliente_Deuda);

                if (await DialogService.Confirm("¿Está seguro que desea eliminar este registro?") == true)
                {
                    var deleteResult = await reincardbService.DeleteClienteDeuda(clienteDeudum.Id_Cliente_Deuda);

                    if (deleteResult != null)
                    {
                        Logger.LogInformation("ClienteDeuda eliminado exitosamente: {IdClienteDeuda}", 
                            clienteDeudum.Id_Cliente_Deuda);

                        await LoadData();

                        NotificationService.Notify(new NotificationMessage
                        {
                            Severity = NotificationSeverity.Success,
                            Summary = "Éxito",
                            Detail = "Registro eliminado correctamente",
                            Duration = 3000
                        });
                    }
                }
                else
                {
                    Logger.LogInformation("Eliminación cancelada por el usuario para ClienteDeuda: {IdClienteDeuda}", 
                        clienteDeudum.Id_Cliente_Deuda);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al eliminar ClienteDeuda: {IdClienteDeuda}", clienteDeudum?.Id_Cliente_Deuda);
                
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = $"No se pudo eliminar el registro: {ex.Message}",
                    Duration = 5000
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            try
            {
                Logger.LogInformation("Exportando ClienteDeuda a formato: {Format}", args?.Value ?? "xlsx");

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
                    Expand = "EstadoClienteDeudum,Cliente,Persona,Usuario,Usuario1,Asignacion,ResultadoEvento1,ResultadoEvento",
                    Select = string.Join(",", grid0.ColumnsCollection
                        .Where(c => c.GetVisible() && !string.IsNullOrEmpty(c.Property))
                        .Select(c => c.Property.Contains(".") ? c.Property + " as " + c.Property.Replace(".", "") : c.Property))
                };

                if (args?.Value == "csv")
                {
                    await reincardbService.ExportClienteDeudaToCSV(query, "ClienteDeuda");
                    Logger.LogInformation("Exportación a CSV completada exitosamente");
                }
                else
                {
                    await reincardbService.ExportClienteDeudaToExcel(query, "ClienteDeuda");
                    Logger.LogInformation("Exportación a Excel completada exitosamente");
                }

                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = "Exportación exitosa",
                    Detail = "Los datos se han exportado correctamente",
                    Duration = 3000
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al exportar ClienteDeuda a formato: {Format}", args?.Value ?? "xlsx");
                await ShowErrorNotification("Error al exportar", ex.Message);
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
                Logger.LogInformation("Disposing ClienteDeuda component");
                // Cleanup resources if needed
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al disponer componente ClienteDeuda");
            }
        }
    }
}