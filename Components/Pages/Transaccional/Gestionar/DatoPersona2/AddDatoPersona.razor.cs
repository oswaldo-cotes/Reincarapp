using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Reincarapp.Components.Pages.Transaccional.Gestionar.DatoPersona2
{
    public partial class AddDatoPersona
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

        [Parameter]
        public long PersonaId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            datoPersona = new Reincarapp.Models.reincardb.DatoPersona() { Id_Persona = PersonaId };

            tipoDatoPersonasForIdTipoDatoPersona = await reincardbService.GetTipoDatoPersona();

            personasForIdPersona = await reincardbService.GetPersona();

            departamentosForIdDepartamento = await reincardbService.GetDepartamento();

            municipiosForIdMunicipio = await reincardbService.GetMunicipio();

            zonaUbicacionsForIdZonaUbicacion = await reincardbService.GetZonaUbicacion();

            tipoViaForIdTipoVia = await reincardbService.GetTipoVia();

            zonaUbicacionsForIdZonaUbicacion1 = await reincardbService.GetZonaUbicacion();

            zonaUbicacionsForIdZonaUbicacion2 = await reincardbService.GetZonaUbicacion();

            zonaUbicacionsForIdZonaUbicacion3 = await reincardbService.GetZonaUbicacion();
        }
        protected bool errorVisible;
        protected Reincarapp.Models.reincardb.DatoPersona datoPersona;

        protected IEnumerable<Reincarapp.Models.reincardb.TipoDatoPersona> tipoDatoPersonasForIdTipoDatoPersona;

        protected IEnumerable<Reincarapp.Models.reincardb.Persona> personasForIdPersona;

        protected IEnumerable<Reincarapp.Models.reincardb.Departamento> departamentosForIdDepartamento;

        protected IEnumerable<Reincarapp.Models.reincardb.Municipio> municipiosForIdMunicipio;

        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacion;

        protected IEnumerable<Reincarapp.Models.reincardb.TipoVia> tipoViaForIdTipoVia;

        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacion1;

        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacion2;

        protected IEnumerable<Reincarapp.Models.reincardb.ZonaUbicacion> zonaUbicacionsForIdZonaUbicacion3;

        protected async Task FormSubmit()
        {
            try
            {
                await reincardbService.CreateDatoPersona(datoPersona);
                DialogService.Close(datoPersona);
            }
            catch (Exception ex)
            {
                hasChanges = ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException;
                canEdit = !(ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException);
                errorVisible = true;
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }


        protected bool hasChanges = false;
        protected bool canEdit = true;

        [Inject]
        protected SecurityService Security { get; set; }
    }
}