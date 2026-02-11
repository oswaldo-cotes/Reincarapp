using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Radzen;
using Radzen.Blazor;

namespace Reincarapp.Components.Pages.Transaccional.Gestionar.DatoPersona2
{
    public partial class AddDatoPersona : IAsyncDisposable
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
        protected SecurityService Security { get; set; }

        [Inject]
        protected ILogger<AddDatoPersona> Logger { get; set; }

        [Parameter]
        public long PersonaId { get; set; }

        protected bool errorVisible;
        protected string errorMessage = string.Empty;
        protected Reincarapp.Models.reincardb.DatoPersona datoPersona;
        protected bool hasChanges = false;
        protected bool canEdit = true;

        protected IEnumerable<Reincarapp.Models.reincardb.TipoDatoPersona> tipoDatoPersonasForIdTipoDatoPersona;
        protected IEnumerable<Reincarapp.Models.reincardb.Persona> personasForIdPersona;
        protected IEnumerable<Reincarapp.Models.reincardb.Departamento> departamentosForIdDepartamento;
        protected IEnumerable<Reincarapp.Models.reincardb.Municipio> municipiosForIdMunicipio;
        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacion;
        protected IEnumerable<Reincarapp.Models.reincardb.TipoVia> tipoViaForIdTipoVia;
        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacion1;
        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacion2;
        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacion3;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Logger.LogInformation("Inicializando AddDatoPersona para PersonaId: {PersonaId}", PersonaId);

                if (PersonaId <= 0)
                {
                    throw new ArgumentException("PersonaId debe ser mayor a 0", nameof(PersonaId));
                }

                datoPersona = new Reincarapp.Models.reincardb.DatoPersona() { Id_Persona = PersonaId };

                Logger.LogInformation("Cargando catálogos para formulario de DatoPersona");

                // Cargar todos los catálogos en paralelo para mejor rendimiento
                // Ejecutar consultas en paralelo sin Task.Run para mantener el contexto de Blazor
                var getTipoDatoPersonas = reincardbService.GetTipoDatoPersona();
                var getPersonas = reincardbService.GetPersona();
                var getDepartamentos = reincardbService.GetDepartamento();
                var getMunicipios = reincardbService.GetMunicipio();
                var getZonaUbicacion = reincardbService.GetZonaUbicacion();
                var getTipoVia = reincardbService.GetTipoVia();
                var getZonaUbicacion1 = reincardbService.GetZonaUbicacion();
                var getZonaUbicacion2 = reincardbService.GetZonaUbicacion();
                var getZonaUbicacion3 = reincardbService.GetZonaUbicacion();

                await Task.WhenAll(
                    getTipoDatoPersonas,
                    getPersonas,
                    getDepartamentos,
                    getMunicipios,
                    getZonaUbicacion,
                    getTipoVia,
                    getZonaUbicacion1,
                    getZonaUbicacion2,
                    getZonaUbicacion3
                );

                tipoDatoPersonasForIdTipoDatoPersona = await getTipoDatoPersonas;
                personasForIdPersona = await getPersonas;
                departamentosForIdDepartamento = await getDepartamentos;
                municipiosForIdMunicipio = await getMunicipios;
                zonaUbicacionsForIdZonaUbicacion = await getZonaUbicacion;
                tipoViaForIdTipoVia = await getTipoVia;
                zonaUbicacionsForIdZonaUbicacion1 = await getZonaUbicacion1;
                zonaUbicacionsForIdZonaUbicacion2 = await getZonaUbicacion2;
                zonaUbicacionsForIdZonaUbicacion3 = await getZonaUbicacion3;

              

                Logger.LogInformation("Catálogos cargados exitosamente. TipoDatoPersona: {Count}",
                    tipoDatoPersonasForIdTipoDatoPersona?.Count() ?? 0);
            }
            catch (ArgumentException argEx)
            {
                Logger.LogWarning(argEx, "Argumento inválido en inicialización. PersonaId: {PersonaId}", PersonaId);

                errorVisible = true;
                errorMessage = argEx.Message;

                await ShowErrorNotification("Error de validación", argEx.Message);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al inicializar AddDatoPersona para PersonaId: {PersonaId}", PersonaId);

                errorVisible = true;
                errorMessage = "No se pudo cargar el formulario. Por favor, intente nuevamente.";

                await ShowErrorNotification("Error de inicialización", errorMessage);
            }
        }

        protected async Task FormSubmit()
        {
            try
            {
                if (datoPersona == null)
                {
                    throw new InvalidOperationException("El dato persona no puede ser nulo");
                }

                Logger.LogInformation("Iniciando creación de DatoPersona. PersonaId: {PersonaId}, TipoDato: {TipoDato}",
                    datoPersona.Id_Persona, datoPersona.Id_Tipo_Dato_Persona);

                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(datoPersona.Dato))
                {
                    throw new ArgumentException("El dato es requerido");
                }

                if (datoPersona.Id_Tipo_Dato_Persona <= 0)
                {
                    throw new ArgumentException("El tipo de dato persona es requerido");
                }

                await reincardbService.CreateDatoPersona(datoPersona);

                Logger.LogInformation("DatoPersona creado exitosamente. IdDatoPersona: {IdDatoPersona}",
                    datoPersona.Id_Dato_Persona);

                await ShowSuccessNotification("Éxito", "Dato de persona creado correctamente");

                DialogService.Close(datoPersona);
            }
            catch (ArgumentException argEx)
            {
                Logger.LogWarning(argEx, "Error de validación al crear DatoPersona. PersonaId: {PersonaId}",
                    datoPersona?.Id_Persona);

                errorMessage = argEx.Message;
                errorVisible = true;

                await ShowErrorNotification("Error de validación", argEx.Message);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException concEx)
            {
                Logger.LogWarning(concEx, "Error de concurrencia al crear DatoPersona. PersonaId: {PersonaId}",
                    datoPersona?.Id_Persona);

                hasChanges = true;
                canEdit = false;
                errorVisible = true;
                errorMessage = "El registro ha sido modificado por otro usuario. Por favor, recargue el formulario.";

                await ShowErrorNotification("Error de concurrencia", errorMessage);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                Logger.LogError(dbEx, "Error de base de datos al crear DatoPersona. PersonaId: {PersonaId}",
                    datoPersona?.Id_Persona);

                errorVisible = true;
                errorMessage = "Error al guardar en la base de datos. Por favor, verifique los datos e intente nuevamente.";

                await ShowErrorNotification("Error de base de datos", errorMessage);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error inesperado al crear DatoPersona. PersonaId: {PersonaId}",
                    datoPersona?.Id_Persona);

                hasChanges = ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException;
                canEdit = !(ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException);
                errorVisible = true;
                errorMessage = ex.InnerException?.Message ?? ex.Message;

                await ShowErrorNotification("Error al guardar", errorMessage);
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            try
            {
                Logger.LogInformation("Usuario canceló la creación de DatoPersona. PersonaId: {PersonaId}", PersonaId);
                DialogService.Close(null);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al cerrar el diálogo de AddDatoPersona");

                // Intentar cerrar de todas formas
                try
                {
                    DialogService.Close(null);
                }
                catch
                {
                    // Si falla, al menos mostramos notificación
                    await ShowErrorNotification("Error", "No se pudo cerrar el diálogo correctamente");
                }
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

        public async ValueTask DisposeAsync()
        {
            try
            {
                Logger.LogInformation("Disposing AddDatoPersona component");
                // Cleanup resources if needed
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error al disponer componente AddDatoPersona");
            }
        }
    }
}