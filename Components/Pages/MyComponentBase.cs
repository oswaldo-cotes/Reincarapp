using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Reincarapp.Data;
using Reincarapp.Models.reincardb;
//using Reincarapp.Pages.Configuracion.Seguridad.Usuarios;

namespace Reincarapp.Pages
{
    public class MyComponentBase : ComponentBase
    {

        [Inject]
        private NotificationService notificationService { get; set; }

        



        [Inject]
        public DialogService dialogService { get; set; }

        [Inject]
        public reincardbContext db { get; set; }

        [Inject]
        public SecurityService security { get; set; }


        public Usuario usuarioBd { get; set; } = null;





        public MyComponentBase()
        {
        }


        protected async override  Task OnInitializedAsync()
        {
            //await base.OnInitializedAsync();

            try {

                usuarioBd = await db.Usuario.Include(x => x.UsuarioCliente).Where(x => x.Correo_Electronico == security.User.Email).FirstOrDefaultAsync();

            }
            catch(Exception ex) { 
            
            }

            

        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
            }
        }


        public void WrapFunctionCall(Action function)
        {
            try
            {
                function();
            }
            catch (Exception e)
            {
                //a BUNCH of logic that is the same for all functions
                throw;
            }
        }

      




        public async Task ShowNotification(string res, string _summary)
        {
            notificationService.Notify(new NotificationMessage()
            {
                Severity = res == "OK" ? NotificationSeverity.Success : NotificationSeverity.Error,
                Summary = _summary,
                Detail = res == "OK" ? _summary + "Exitosa" : res,
                Duration = 2000
            });

            //events.Add(DateTime.Now, $"{message.Severity} notification");
            await InvokeAsync(() => { StateHasChanged(); });
        }

    }
}
