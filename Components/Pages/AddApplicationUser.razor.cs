using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Reincarapp.Services;

namespace Reincarapp.Components.Pages
{
    public partial class AddApplicationUser
    {
        [Inject] protected IJSRuntime JSRuntime { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject] protected DialogService DialogService { get; set; }
        [Inject] protected TooltipService TooltipService { get; set; }
        [Inject] protected ContextMenuService ContextMenuService { get; set; }
        [Inject] protected NotificationService NotificationService { get; set; }
        [Inject] protected reincardbService reincardbService { get; set; }
        [Inject] protected SecurityService Security { get; set; }
        [Inject] protected IUsuarioClienteSyncService UsuarioClienteSync { get; set; }

        protected IEnumerable<Reincarapp.Models.ApplicationRole> roles;
        protected Reincarapp.Models.ApplicationUser user;
        protected IEnumerable<string> userRoles = Enumerable.Empty<string>();
        protected IEnumerable<Reincarapp.Models.reincardb.Cliente> clientes;
        protected IEnumerable<long> userClientes = Enumerable.Empty<long>();
        protected string error;
        protected bool errorVisible;

        protected override async Task OnInitializedAsync()
        {
            user    = new Reincarapp.Models.ApplicationUser();
            roles   = await Security.GetRoles();
            clientes = await reincardbService.GetCliente();
        }

        protected async Task FormSubmit(Reincarapp.Models.ApplicationUser user)
        {
            try
            {
                errorVisible = false;

            

                user.Roles = roles.Where(role => userRoles.Contains(role.Id)).ToList();
                user       = await Security.CreateUser(user);

                await reincardbService.CreateUsuario(new Reincarapp.Models.reincardb.Usuario
                {
                    Nombre_Usuario = user.UserName,
                    Usuario1 = user.UserName,
                    Correo_Electronico = user.Email
                });

                await UsuarioClienteSync.SyncAsync(user.Id, userClientes);

                DialogService.Close(null);
            }
            catch (Exception ex)
            {
                errorVisible = true;
                error        = ex.Message;
            }
        }

        protected async Task CancelClick() => DialogService.Close(null);
    }
}