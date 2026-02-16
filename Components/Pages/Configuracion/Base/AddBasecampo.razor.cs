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
    public partial class AddBasecampo
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

            basesForBaseId = await reincardbService.GetBase();
            camposclaves = await reincardbService.GetCampoclave();
        }
        protected bool errorVisible;
        protected Reincarapp.Models.reincardb.Basecampo basecampo;

        protected IEnumerable<Reincarapp.Models.reincardb.Base> basesForBaseId;
        protected IEnumerable<Reincarapp.Models.reincardb.Campoclave> camposclaves;

        protected async Task FormSubmit()
        {
            try
            {
                await reincardbService.CreateBasecampo(basecampo);
                DialogService.Close(basecampo);
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





        bool hasBaseIdValue;

        [Parameter]
        public long? BaseId { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            basecampo = new Reincarapp.Models.reincardb.Basecampo();

            hasBaseIdValue = parameters.TryGetValue<long?>("BaseId", out var hasBaseIdResult);

            if (hasBaseIdValue)
            {
                basecampo.BaseId = hasBaseIdResult;
            }
            await base.SetParametersAsync(parameters);
        }
    }
}