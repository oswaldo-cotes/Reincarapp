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
    public partial class AddUsuarioCliente
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

        protected override async Task OnInitializedAsync()
        {
            usuarioCliente = new Reincarapp.Models.reincardb.UsuarioCliente();

            clienteForIdCliente = await reincardbService.GetCliente();

            usuarioForIdUsuario = await reincardbService.GetUsuario();

            aspnetusersForAspNetUserId = await reincardbService.GetAspnetusers();
        }
        protected bool errorVisible;
        protected Reincarapp.Models.reincardb.UsuarioCliente usuarioCliente;

        protected IEnumerable<Reincarapp.Models.reincardb.Cliente> clienteForIdCliente;

        protected IEnumerable<Reincarapp.Models.reincardb.Usuario> usuarioForIdUsuario;

        protected IEnumerable<Reincarapp.Models.reincardb.Aspnetusers> aspnetusersForAspNetUserId;

        protected async Task FormSubmit()
        {
            try
            {
                await reincardbService.CreateUsuarioCliente(usuarioCliente);
                DialogService.Close(usuarioCliente);
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