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
    public partial class EditBase
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
        public long Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _base = await reincardbService.GetBaseById(Id);

            clientesForIdCliente = await reincardbService.GetCliente();

            tipobasesForIdTipoBase = await reincardbService.GetTipobase();

            usuariosForIdUsuario = await reincardbService.GetUsuario();

            usuariosForIdUsuarioAct = await reincardbService.GetUsuario();
        }
        protected bool errorVisible;
        protected Reincarapp.Models.reincardb.Base _base;

        protected IEnumerable<Reincarapp.Models.reincardb.Cliente> clientesForIdCliente;

        protected IEnumerable<Reincarapp.Models.reincardb.Tipobase> tipobasesForIdTipoBase;

        protected IEnumerable<Reincarapp.Models.reincardb.Usuario> usuariosForIdUsuario;

        protected IEnumerable<Reincarapp.Models.reincardb.Usuario> usuariosForIdUsuarioAct;

        [Inject]
        protected SecurityService Security { get; set; }

        protected async Task FormSubmit()
        {
            try
            {
                await reincardbService.UpdateBase(Id, _base);
                DialogService.Close(_base);
            }
            catch (Exception ex)
            {
                errorVisible = true;
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}