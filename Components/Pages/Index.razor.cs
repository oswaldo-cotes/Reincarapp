using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;
using Radzen;
using Radzen.Blazor;
using Reincarapp.Components.Pages.Transaccional.Gestionar;
using Reincarapp.Components.Pages.Transaccional.Gestionar.ClienteDeuda;
using Reincarapp.Models.MyModels;
using Reincarapp.Models.reincardb;
using System.Buffers;
using System.Net.Http;

namespace Reincarapp.Components.Pages
{
    public partial class Index
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
        protected SecurityService Security { get; set; }


        // Selection variables for the dropdown data grids
        long? selectedUsuario;
        long? selectedCliente;

        List<long> selectedUsuarios = new List<long>();

        // Financial metrics
        double totalCartera = 0;
        double recaudo = 0;
        double compromisos = 0;
        double noEfectiva = 0;

        // Reparto data variables
        List<Reparto> repartoData = new List<Reparto>();
        List<RepartoDet> repartoDetData = new List<RepartoDet>();

        List<Usuario> usuarios = new List<Usuario>();
        List<Cliente> clientes = new List<Cliente>();


        public class Appointment
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string Text { get; set; }
            public long Id { get; set; }
            public long IdClienteDeuda { get; set; }
        }


        List<Tarea> Tareas = new List<Tarea>();



        RadzenScheduler<Appointment> scheduler;

        Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();

        IList<Appointment> appointments = new List<Appointment>();
        // {
        //     new Appointment { Start = DateTime.Today.AddDays(-2), End = DateTime.Today.AddDays(-2), Text = "Birthday" },
        //     new Appointment { Start = DateTime.Today.AddDays(-11), End = DateTime.Today.AddDays(-10), Text = "Day off" },
        //     new Appointment { Start = DateTime.Today.AddDays(-10), End = DateTime.Today.AddDays(-8), Text = "Work from home" },
        //     new Appointment { Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(12), Text = "Online meeting" },
        //     new Appointment { Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(13), Text = "Skype call" },
        //     new Appointment { Start = DateTime.Today.AddHours(14), End = DateTime.Today.AddHours(14).AddMinutes(30), Text = "Dentist appointment" },
        //     new Appointment { Start = DateTime.Today.AddDays(1), End = DateTime.Today.AddDays(12), Text = "Vacation" },
        // };

        void OnSlotRender(SchedulerSlotRenderEventArgs args)
        {
            // Highlight today in month view
            if (args.View.Text == "Month" && args.Start.Date == DateTime.Today)
            {
                args.Attributes["style"] = "background: var(--rz-scheduler-highlight-background-color, rgba(255,220,40,.2));";
            }

            // Highlight working hours (9-18)
            if ((args.View.Text == "Week" || args.View.Text == "Day") && args.Start.Hour > 8 && args.Start.Hour < 19)
            {
                args.Attributes["style"] = "background: var(--rz-scheduler-highlight-background-color, rgba(255,220,40,.2));";
            }
        }

        async Task OnSlotSelect(SchedulerSlotSelectEventArgs args)
        {
            //console.Log($"SlotSelect: Start={args.Start} End={args.End}");

            if (args.View.Text != "Year")
            {
                // Appointment data = await DialogService.OpenAsync<AddAppointmentPage>("Add Appointment",
                //     new Dictionary<string, object> { { "Start", args.Start }, { "End", args.End } });

                // if (data != null)
                // {
                //     appointments.Add(data);
                //     // Either call the Reload method or reassign the Data property of the Scheduler
                //     await scheduler.Reload();
                // }
            }
        }

        async Task OnAppointmentSelect(SchedulerAppointmentSelectEventArgs<Appointment> args)
        {
            //console.Log($"AppointmentSelect: Appointment={args.Data.Text}");

            var copy = new Appointment
            {
                Start = args.Data.Start,
                End = args.Data.End,
                Text = args.Data.Text
            };

            // var data = await DialogService.OpenAsync<EditAppointmentPage>("Edit Appointment", new Dictionary<string, object> { { "Appointment", copy } });

            // if (data != null)
            // {
            //     // Update the appointment
            //     args.Data.Start = data.Start;
            //     args.Data.End = data.End;
            //     args.Data.Text = data.Text;
            // }

            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var query = ctx.ClienteDeudaDato
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
                   .Where(x => x.Id_Cliente_Deuda == args.Data.IdClienteDeuda &&
                          x.Fecha_Final == null &&
                          x.Fecha_Inicial >= startDate &&
                          x.Fecha_Inicial <= endDate);

          

            var clienteDeudaList = await query.ToListAsync();

            var clienteDeuda = clienteDeudaList
                .Select(x => x.ClienteDeuda)
                .OrderBy(x => x.Persona?.Numero_Documento)
                .ThenBy(x => x.Persona?.Nombre_Persona)
                .ToList();



            var res =  await DialogService.OpenAsync<GestionarDeuda>(
                 "Gestionando...",
                 new Dictionary<string, object> { { "registro", clienteDeuda.FirstOrDefault() } },
                 new DialogOptions { Width = "100%", Height = "100%", Draggable = false, Resizable = false }
             );


            //var res = await DialogService.OpenAsync<Pages.Transaccional.Gestionar.Evento.AddEvento>("Add Evento", new Dictionary<string, object> { { "ClienteDeudaId", args.Data.IdClienteDeuda }, { "IdNegocio", "" }, { "IdTarea", args.Data.Id } }, new DialogOptions() { Draggable = true, Width = "700px", Height = "800px" });

            if (res != null)
            {

                //var t = await ctx.Tareas.Where(x => x.Id_Tarea == args.Data.Id).FirstOrDefaultAsync();
                var t = await reincardbService.GetTareaByIdTarea(args.Data.Id);
                Tareas.RemoveAll(x => x.Id_Tarea == t.Id_Tarea);


            }






            await scheduler.Reload();
        }

        void OnAppointmentRender(SchedulerAppointmentRenderEventArgs<Appointment> args)
        {
            // Never call StateHasChanged in AppointmentRender - would lead to infinite loop

            if (args.Data.Text == "Birthday")
            {
                args.Attributes["style"] = "background: red";
            }
        }

        async Task OnAppointmentMove(SchedulerAppointmentMoveEventArgs args)
        {
            var draggedAppointment = appointments.FirstOrDefault(x => x == args.Appointment.Data);

            if (draggedAppointment != null)
            {
                draggedAppointment.Start = draggedAppointment.Start + args.TimeSpan;

                draggedAppointment.End = draggedAppointment.End + args.TimeSpan;

                await scheduler.Reload();
            }
        }


        void OnUsuarioChanged(object selectedValue)
        {
            try
            {
                if (selectedValue != null)
                {
                    // var usuarioId = (long)selectedValue;
                    // var selectedUsuarioItem = usuarios.FirstOrDefault(u => u.Id_Usuario == usuarioId);

                    // if (selectedUsuarioItem != null)
                    // {
                    //     Console.WriteLine($"Usuario seleccionado: {selectedUsuarioItem.Nombre_Usuario}");
                    // }
                }
                else
                {
                    Console.WriteLine("Usuario selection cleared");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OnUsuarioChanged: {ex.Message}");
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = "Error al cambiar selección de usuario",
                    Duration = 4000
                });
            }
        }

        async void OnClienteChanged(object selectedValue)
        {
            if (selectedValue != null)
            {
                var clienteId = (long)selectedValue;
                var selectedClienteItem = clientes.FirstOrDefault(c => c.Id_Cliente == clienteId);

                if (selectedClienteItem != null)
                {
                    try
                    {

                        if (securityService.IsCoordinador || securityService.IsAdministrator)
                            usuarios = await ctx.Usuario
                                .Include(x => x.UsuarioCliente)
                                .Where(x => x.UsuarioCliente.Any(uc => uc.Id_Cliente == (long)selectedValue))
                                .ToListAsync();
                        else
                            usuarios = await ctx.Usuario.Where(x => x.Id_Usuario == securityService.usuario.Id_Usuario).ToListAsync();




                        resultadoEventos = await ctx.ResultadoEvento.Where(x => x.id_cliente == (long)selectedValue).ToListAsync();


                        // Get reparto data
                        repartoData = await todoItemService.SpGet<Reparto>("SP_GET_REPARTO_GEN", new object[] { securityService.usuario.Id_Usuario, selectedValue });
                        repartoDetData = await todoItemService.SpGet<RepartoDet>("SP_GET_REPARTO_GEN_DET", new object[] { securityService.usuario.Id_Usuario, DBNull.Value, selectedValue });





                        // Calculate financial metrics from reparto data
                        CalculateFinancialMetrics();

                        Console.WriteLine($"Cliente seleccionado: {selectedClienteItem.Nombre_Cliente}");
                        Console.WriteLine($"Total registros reparto: {repartoData.Count}");
                        Console.WriteLine($"Total registros reparto detalle: {repartoDetData.Count}");

                        // Update UI
                        StateHasChanged();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading reparto data: {ex.Message}");
                    }
                }
            }
            else
            {
                // Handle clear selection - reset data
                repartoData.Clear();
                repartoDetData.Clear();
                ResetFinancialMetrics();
                StateHasChanged();
                Console.WriteLine("Cliente selection cleared");
            }
        }

        private void CalculateFinancialMetrics()
        {
            try
            {
                // Calculate total cartera from reparto data
                totalCartera = repartoData?.Sum(r => r.total_cartera) ?? 0;

                // Calculate recaudo from reparto detail data
                recaudo = repartoDetData?.Sum(rd => rd.valor_recaudo) ?? 0;

                // Calculate compromisos from reparto detail data
                compromisos = repartoDetData?.Sum(rd => rd.valor_compromiso) ?? 0;

                // Calculate honorarios (assuming this is "no efectiva" based on context)
                noEfectiva = repartoDetData?.Sum(rd => rd.valor_honorarios) ?? 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating financial metrics: {ex.Message}");
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = "Error al calcular métricas financieras",
                    Duration = 4000
                });
                ResetFinancialMetrics();
            }
        }

        private void ResetFinancialMetrics()
        {
            try
            {
                totalCartera = 0;
                recaudo = 0;
                compromisos = 0;
                noEfectiva = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resetting financial metrics: {ex.Message}");
            }
        }

        List<ResultadoEvento> resultadoEventos = new List<ResultadoEvento>();

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    if (securityService.IsAdministrator)
                    {
                        // Administrator sees all usuarios and clientes
                        // usuarios = await ctx.Usuarios
                        //     .Include(x => x.UsuarioClientes)
                        //     .ToListAsync();

                        clientes = await ctx.Cliente
                            .Include(x => x.UsuarioCliente)
                            .ToListAsync();
                    }
                    else
                    {
                        // Non-administrator users see filtered data based on their relationships
                        // usuarios = await ctx.Usuarios
                        //     .Include(x => x.UsuarioClientes)
                        //     .Where(x => x.UsuarioClientes.Any(uc => 
                        //         securityService.usuario.UsuarioClientes.Any(suc => suc.Id_Usuario == x.Id_Usuario)))
                        //     .ToListAsync();

                        clientes = securityService.usuario.UsuarioCliente.Select(x => x.Cliente).ToList();

                    }
                    var tareasPorEjec = await ctx.Tarea
                                                 .Include(x => x.ClienteDeuda)
                                                 .ThenInclude(x => x.Persona)
                                                 .Include(x => x.Aspnetusers)
                                                 .Include(x=>x.Aspnetusers1)
                                                 .Include(x=>x.Aspnetusers2)
                                                 .Where(x=> x.Fecha_Ejecucion_Tarea == null)
                                                 .AsNoTracking()
                                                 .ToListAsync();

                    tareasPorEjec.ForEach(x =>
                    {


                        appointments.Add(new Appointment() { Start = x.Fecha_Realizacion_Tarea, End = x.Fecha_Realizacion_Tarea.AddMinutes(15), Text = x.Texto_Tarea + ". Asignado a : " + x.Aspnetusers?.UserName, Id = x.Id_Tarea, IdClienteDeuda = x.Id_Cliente_Deuda ?? 0 });

                    });

                    await scheduler.Reload();


                    StateHasChanged();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in OnAfterRenderAsync: {ex.Message}");
                    NotificationService.Notify(new NotificationMessage
                    {
                        Severity = NotificationSeverity.Error,
                        Summary = "Error",
                        Detail = "Error al cargar datos iniciales",
                        Duration = 4000
                    });
                }
            }
        }


    }
}