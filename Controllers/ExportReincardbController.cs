using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Reincarapp.Data;

namespace Reincarapp.Controllers
{
    public partial class ExportreincardbController : ExportController
    {
        private readonly reincardbContext context;
        private readonly reincardbService service;

        public ExportreincardbController(reincardbContext context, reincardbService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/reincardb/actcampocoomultrasan/csv")]
        [HttpGet("/export/reincardb/actcampocoomultrasan/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportActCampoCoomultrasanToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetActCampoCoomultrasan(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/actcampocoomultrasan/excel")]
        [HttpGet("/export/reincardb/actcampocoomultrasan/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportActCampoCoomultrasanToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetActCampoCoomultrasan(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/acueducto/csv")]
        [HttpGet("/export/reincardb/acueducto/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAcueductoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAcueducto(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/acueducto/excel")]
        [HttpGet("/export/reincardb/acueducto/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAcueductoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAcueducto(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/asiggestaux/csv")]
        [HttpGet("/export/reincardb/asiggestaux/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAsigGestAuxToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAsigGestAux(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/asiggestaux/excel")]
        [HttpGet("/export/reincardb/asiggestaux/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAsigGestAuxToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAsigGestAux(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/asignacion/csv")]
        [HttpGet("/export/reincardb/asignacion/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAsignacionToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAsignacion(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/asignacion/excel")]
        [HttpGet("/export/reincardb/asignacion/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAsignacionToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAsignacion(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/asignaciongestor/csv")]
        [HttpGet("/export/reincardb/asignaciongestor/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAsignacionGestorToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAsignacionGestor(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/asignaciongestor/excel")]
        [HttpGet("/export/reincardb/asignaciongestor/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAsignacionGestorToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAsignacionGestor(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/avvillas/csv")]
        [HttpGet("/export/reincardb/avvillas/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAvvillasToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAvvillas(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/avvillas/excel")]
        [HttpGet("/export/reincardb/avvillas/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAvvillasToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAvvillas(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/avvillasbuc/csv")]
        [HttpGet("/export/reincardb/avvillasbuc/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAvvillasbucToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAvvillasbuc(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/avvillasbuc/excel")]
        [HttpGet("/export/reincardb/avvillasbuc/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAvvillasbucToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAvvillasbuc(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/bancobogota/csv")]
        [HttpGet("/export/reincardb/bancobogota/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBancobogotaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBancobogota(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/bancobogota/excel")]
        [HttpGet("/export/reincardb/bancobogota/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBancobogotaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBancobogota(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/bancoomeva/csv")]
        [HttpGet("/export/reincardb/bancoomeva/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBancoomevaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBancoomeva(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/bancoomeva/excel")]
        [HttpGet("/export/reincardb/bancoomeva/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBancoomevaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBancoomeva(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/base/csv")]
        [HttpGet("/export/reincardb/base/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBaseToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBase(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/base/excel")]
        [HttpGet("/export/reincardb/base/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBaseToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBase(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/basejuridica/csv")]
        [HttpGet("/export/reincardb/basejuridica/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBaseJuridicaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBaseJuridica(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/basejuridica/excel")]
        [HttpGet("/export/reincardb/basejuridica/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBaseJuridicaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBaseJuridica(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/basecampo/csv")]
        [HttpGet("/export/reincardb/basecampo/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBasecampoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBasecampo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/basecampo/excel")]
        [HttpGet("/export/reincardb/basecampo/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBasecampoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBasecampo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/bktarea/csv")]
        [HttpGet("/export/reincardb/bktarea/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBktareaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBktarea(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/bktarea/excel")]
        [HttpGet("/export/reincardb/bktarea/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBktareaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBktarea(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/bloqueocontacto/csv")]
        [HttpGet("/export/reincardb/bloqueocontacto/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBloqueocontactoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBloqueocontacto(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/bloqueocontacto/excel")]
        [HttpGet("/export/reincardb/bloqueocontacto/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBloqueocontactoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBloqueocontacto(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/campohonorario/csv")]
        [HttpGet("/export/reincardb/campohonorario/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCampoHonorarioToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCampoHonorario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/campohonorario/excel")]
        [HttpGet("/export/reincardb/campohonorario/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCampoHonorarioToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCampoHonorario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/campoclave/csv")]
        [HttpGet("/export/reincardb/campoclave/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCampoclaveToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCampoclave(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/campoclave/excel")]
        [HttpGet("/export/reincardb/campoclave/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCampoclaveToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCampoclave(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/cdrepetidaspersona/csv")]
        [HttpGet("/export/reincardb/cdrepetidaspersona/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCdRepetidasPersonaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCdRepetidasPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/cdrepetidaspersona/excel")]
        [HttpGet("/export/reincardb/cdrepetidaspersona/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCdRepetidasPersonaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCdRepetidasPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/cedulaborrar/csv")]
        [HttpGet("/export/reincardb/cedulaborrar/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCedulaborrarToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCedulaborrar(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/cedulaborrar/excel")]
        [HttpGet("/export/reincardb/cedulaborrar/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCedulaborrarToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCedulaborrar(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/censprejuridico/csv")]
        [HttpGet("/export/reincardb/censprejuridico/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCensprejuridicoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCensprejuridico(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/censprejuridico/excel")]
        [HttpGet("/export/reincardb/censprejuridico/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCensprejuridicoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCensprejuridico(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/checprejuridico/csv")]
        [HttpGet("/export/reincardb/checprejuridico/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportChecprejuridicoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetChecprejuridico(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/checprejuridico/excel")]
        [HttpGet("/export/reincardb/checprejuridico/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportChecprejuridicoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetChecprejuridico(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/citibank/csv")]
        [HttpGet("/export/reincardb/citibank/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitibankToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCitibank(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/citibank/excel")]
        [HttpGet("/export/reincardb/citibank/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitibankToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCitibank(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/citibank2/csv")]
        [HttpGet("/export/reincardb/citibank2/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitibank2ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCitibank2(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/citibank2/excel")]
        [HttpGet("/export/reincardb/citibank2/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitibank2ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCitibank2(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/citibank4/csv")]
        [HttpGet("/export/reincardb/citibank4/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitibank4ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCitibank4(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/citibank4/excel")]
        [HttpGet("/export/reincardb/citibank4/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitibank4ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCitibank4(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clasificacionadicional/csv")]
        [HttpGet("/export/reincardb/clasificacionadicional/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClasificacionAdicionalToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClasificacionAdicional(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clasificacionadicional/excel")]
        [HttpGet("/export/reincardb/clasificacionadicional/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClasificacionAdicionalToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClasificacionAdicional(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproc/csv")]
        [HttpGet("/export/reincardb/clideuproc/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProcToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCliDeuProc(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproc/excel")]
        [HttpGet("/export/reincardb/clideuproc/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProcToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCliDeuProc(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproc1/csv")]
        [HttpGet("/export/reincardb/clideuproc1/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProc1ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCliDeuProc1(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproc1/excel")]
        [HttpGet("/export/reincardb/clideuproc1/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProc1ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCliDeuProc1(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproc2/csv")]
        [HttpGet("/export/reincardb/clideuproc2/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProc2ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCliDeuProc2(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproc2/excel")]
        [HttpGet("/export/reincardb/clideuproc2/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProc2ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCliDeuProc2(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproc3/csv")]
        [HttpGet("/export/reincardb/clideuproc3/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProc3ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCliDeuProc3(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproc3/excel")]
        [HttpGet("/export/reincardb/clideuproc3/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProc3ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCliDeuProc3(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproctranbuc/csv")]
        [HttpGet("/export/reincardb/clideuproctranbuc/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProcTranBucToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCliDeuProcTranBuc(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproctranbuc/excel")]
        [HttpGet("/export/reincardb/clideuproctranbuc/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProcTranBucToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCliDeuProcTranBuc(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproctranflo/csv")]
        [HttpGet("/export/reincardb/clideuproctranflo/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProcTranFloToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCliDeuProcTranFlo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproctranflo/excel")]
        [HttpGet("/export/reincardb/clideuproctranflo/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProcTranFloToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCliDeuProcTranFlo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproctran1/csv")]
        [HttpGet("/export/reincardb/clideuproctran1/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProcTran1ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCliDeuProcTran1(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproctran1/excel")]
        [HttpGet("/export/reincardb/clideuproctran1/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProcTran1ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCliDeuProcTran1(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproctran2/csv")]
        [HttpGet("/export/reincardb/clideuproctran2/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProcTran2ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCliDeuProcTran2(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clideuproctran2/excel")]
        [HttpGet("/export/reincardb/clideuproctran2/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCliDeuProcTran2ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCliDeuProcTran2(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/cliente/csv")]
        [HttpGet("/export/reincardb/cliente/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCliente(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/cliente/excel")]
        [HttpGet("/export/reincardb/cliente/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCliente(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeuda/csv")]
        [HttpGet("/export/reincardb/clientedeuda/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClienteDeuda(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeuda/excel")]
        [HttpGet("/export/reincardb/clientedeuda/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClienteDeuda(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudaagrup/csv")]
        [HttpGet("/export/reincardb/clientedeudaagrup/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaAgrupToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClienteDeudaAgrup(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudaagrup/excel")]
        [HttpGet("/export/reincardb/clientedeudaagrup/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaAgrupToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClienteDeudaAgrup(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudaaux/csv")]
        [HttpGet("/export/reincardb/clientedeudaaux/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaAuxToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClienteDeudaAux(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudaaux/excel")]
        [HttpGet("/export/reincardb/clientedeudaaux/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaAuxToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClienteDeudaAux(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudacons/csv")]
        [HttpGet("/export/reincardb/clientedeudacons/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaConsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClienteDeudaCons(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudacons/excel")]
        [HttpGet("/export/reincardb/clientedeudacons/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaConsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClienteDeudaCons(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudadato/csv")]
        [HttpGet("/export/reincardb/clientedeudadato/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaDatoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClienteDeudaDato(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudadato/excel")]
        [HttpGet("/export/reincardb/clientedeudadato/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaDatoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClienteDeudaDato(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudahonorario/csv")]
        [HttpGet("/export/reincardb/clientedeudahonorario/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaHonorarioToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClienteDeudaHonorario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudahonorario/excel")]
        [HttpGet("/export/reincardb/clientedeudahonorario/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaHonorarioToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClienteDeudaHonorario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudausuario/csv")]
        [HttpGet("/export/reincardb/clientedeudausuario/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaUsuarioToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClienteDeudaUsuario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudausuario/excel")]
        [HttpGet("/export/reincardb/clientedeudausuario/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClienteDeudaUsuarioToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClienteDeudaUsuario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudaborrar/csv")]
        [HttpGet("/export/reincardb/clientedeudaborrar/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClientedeudaborrarToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClientedeudaborrar(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/clientedeudaborrar/excel")]
        [HttpGet("/export/reincardb/clientedeudaborrar/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportClientedeudaborrarToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClientedeudaborrar(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/comparendos/csv")]
        [HttpGet("/export/reincardb/comparendos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportComparendosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetComparendos(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/comparendos/excel")]
        [HttpGet("/export/reincardb/comparendos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportComparendosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetComparendos(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc1/csv")]
        [HttpGet("/export/reincardb/conscvc1/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC1ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConsCvC1(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc1/excel")]
        [HttpGet("/export/reincardb/conscvc1/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC1ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConsCvC1(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc12/csv")]
        [HttpGet("/export/reincardb/conscvc12/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC12ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConsCvC12(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc12/excel")]
        [HttpGet("/export/reincardb/conscvc12/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC12ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConsCvC12(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc13/csv")]
        [HttpGet("/export/reincardb/conscvc13/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC13ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConsCvC13(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc13/excel")]
        [HttpGet("/export/reincardb/conscvc13/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC13ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConsCvC13(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc14/csv")]
        [HttpGet("/export/reincardb/conscvc14/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC14ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConsCvC14(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc14/excel")]
        [HttpGet("/export/reincardb/conscvc14/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC14ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConsCvC14(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc1credidos/csv")]
        [HttpGet("/export/reincardb/conscvc1credidos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC1CredidosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConsCvC1Credidos(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc1credidos/excel")]
        [HttpGet("/export/reincardb/conscvc1credidos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC1CredidosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConsCvC1Credidos(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc1progresa/csv")]
        [HttpGet("/export/reincardb/conscvc1progresa/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC1ProgresaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConsCvC1Progresa(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/conscvc1progresa/excel")]
        [HttpGet("/export/reincardb/conscvc1progresa/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsCvC1ProgresaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConsCvC1Progresa(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/consinftransitobuc/csv")]
        [HttpGet("/export/reincardb/consinftransitobuc/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsInfTransitoBucToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConsInfTransitoBuc(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/consinftransitobuc/excel")]
        [HttpGet("/export/reincardb/consinftransitobuc/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsInfTransitoBucToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConsInfTransitoBuc(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/consinftransitobucfinal/csv")]
        [HttpGet("/export/reincardb/consinftransitobucfinal/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsInfTransitoBucFinalToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConsInfTransitoBucFinal(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/consinftransitobucfinal/excel")]
        [HttpGet("/export/reincardb/consinftransitobucfinal/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsInfTransitoBucFinalToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConsInfTransitoBucFinal(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/consinftransitoflo/csv")]
        [HttpGet("/export/reincardb/consinftransitoflo/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsInfTransitoFloToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConsInfTransitoFlo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/consinftransitoflo/excel")]
        [HttpGet("/export/reincardb/consinftransitoflo/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsInfTransitoFloToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConsInfTransitoFlo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/consinftransitoflofinal/csv")]
        [HttpGet("/export/reincardb/consinftransitoflofinal/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsInfTransitoFloFinalToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConsInfTransitoFloFinal(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/consinftransitoflofinal/excel")]
        [HttpGet("/export/reincardb/consinftransitoflofinal/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConsInfTransitoFloFinalToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConsInfTransitoFloFinal(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomtempcd/csv")]
        [HttpGet("/export/reincardb/coomtempcd/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomTempcdToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCoomTempcd(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomtempcd/excel")]
        [HttpGet("/export/reincardb/coomtempcd/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomTempcdToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCoomTempcd(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomultdic/csv")]
        [HttpGet("/export/reincardb/coomultdic/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomultdicToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCoomultdic(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomultdic/excel")]
        [HttpGet("/export/reincardb/coomultdic/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomultdicToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCoomultdic(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomultrasancastigo/csv")]
        [HttpGet("/export/reincardb/coomultrasancastigo/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomultrasanCastigoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCoomultrasanCastigo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomultrasancastigo/excel")]
        [HttpGet("/export/reincardb/coomultrasancastigo/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomultrasanCastigoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCoomultrasanCastigo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomultrasanjuridica/csv")]
        [HttpGet("/export/reincardb/coomultrasanjuridica/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomultrasanJuridicaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCoomultrasanJuridica(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomultrasanjuridica/excel")]
        [HttpGet("/export/reincardb/coomultrasanjuridica/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomultrasanJuridicaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCoomultrasanJuridica(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomultrasanley79/csv")]
        [HttpGet("/export/reincardb/coomultrasanley79/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomultrasanLey79ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCoomultrasanLey79(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomultrasanley79/excel")]
        [HttpGet("/export/reincardb/coomultrasanley79/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomultrasanLey79ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCoomultrasanLey79(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomultrasantemprana/csv")]
        [HttpGet("/export/reincardb/coomultrasantemprana/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomultrasanTempranaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCoomultrasanTemprana(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coomultrasantemprana/excel")]
        [HttpGet("/export/reincardb/coomultrasantemprana/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoomultrasanTempranaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCoomultrasanTemprana(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coopetrol/csv")]
        [HttpGet("/export/reincardb/coopetrol/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoopetrolToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCoopetrol(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/coopetrol/excel")]
        [HttpGet("/export/reincardb/coopetrol/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCoopetrolToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCoopetrol(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/correspondencia/csv")]
        [HttpGet("/export/reincardb/correspondencia/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCorrespondenciaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCorrespondencia(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/correspondencia/excel")]
        [HttpGet("/export/reincardb/correspondencia/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCorrespondenciaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCorrespondencia(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/credidos/csv")]
        [HttpGet("/export/reincardb/credidos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCredidosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCredidos(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/credidos/excel")]
        [HttpGet("/export/reincardb/credidos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCredidosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCredidos(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/credivalores/csv")]
        [HttpGet("/export/reincardb/credivalores/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCredivaloresToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCredivalores(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/credivalores/excel")]
        [HttpGet("/export/reincardb/credivalores/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCredivaloresToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCredivalores(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/credivalores2/csv")]
        [HttpGet("/export/reincardb/credivalores2/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCredivalores2ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCredivalores2(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/credivalores2/excel")]
        [HttpGet("/export/reincardb/credivalores2/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCredivalores2ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCredivalores2(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/credivaloresalt/csv")]
        [HttpGet("/export/reincardb/credivaloresalt/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCredivaloresaltToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCredivaloresalt(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/credivaloresalt/excel")]
        [HttpGet("/export/reincardb/credivaloresalt/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCredivaloresaltToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCredivaloresalt(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/datoclientedeuda/csv")]
        [HttpGet("/export/reincardb/datoclientedeuda/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatoClienteDeudaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDatoClienteDeuda(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/datoclientedeuda/excel")]
        [HttpGet("/export/reincardb/datoclientedeuda/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatoClienteDeudaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDatoClienteDeuda(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/datopersona/csv")]
        [HttpGet("/export/reincardb/datopersona/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatoPersonaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDatoPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/datopersona/excel")]
        [HttpGet("/export/reincardb/datopersona/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatoPersonaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDatoPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/decisionestado/csv")]
        [HttpGet("/export/reincardb/decisionestado/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDecisionEstadoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDecisionEstado(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/decisionestado/excel")]
        [HttpGet("/export/reincardb/decisionestado/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDecisionEstadoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDecisionEstado(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/departamento/csv")]
        [HttpGet("/export/reincardb/departamento/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDepartamentoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDepartamento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/departamento/excel")]
        [HttpGet("/export/reincardb/departamento/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDepartamentoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDepartamento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/docs/csv")]
        [HttpGet("/export/reincardb/docs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDocsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDocs(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/docs/excel")]
        [HttpGet("/export/reincardb/docs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDocsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDocs(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/empsaludcoop/csv")]
        [HttpGet("/export/reincardb/empsaludcoop/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEmpSaludcoopToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEmpSaludcoop(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/empsaludcoop/excel")]
        [HttpGet("/export/reincardb/empsaludcoop/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEmpSaludcoopToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEmpSaludcoop(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/estadoclientedeuda/csv")]
        [HttpGet("/export/reincardb/estadoclientedeuda/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEstadoClienteDeudaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEstadoClienteDeuda(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/estadoclientedeuda/excel")]
        [HttpGet("/export/reincardb/estadoclientedeuda/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEstadoClienteDeudaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEstadoClienteDeuda(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/estadousuario/csv")]
        [HttpGet("/export/reincardb/estadousuario/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEstadoUsuarioToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEstadoUsuario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/estadousuario/excel")]
        [HttpGet("/export/reincardb/estadousuario/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEstadoUsuarioToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEstadoUsuario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/evento/csv")]
        [HttpGet("/export/reincardb/evento/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEventoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEvento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/evento/excel")]
        [HttpGet("/export/reincardb/evento/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEventoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEvento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/eventoarchivo/csv")]
        [HttpGet("/export/reincardb/eventoarchivo/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEventoArchivoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEventoArchivo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/eventoarchivo/excel")]
        [HttpGet("/export/reincardb/eventoarchivo/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEventoArchivoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEventoArchivo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/eventodet/csv")]
        [HttpGet("/export/reincardb/eventodet/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEventoDetToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEventoDet(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/eventodet/excel")]
        [HttpGet("/export/reincardb/eventodet/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportEventoDetToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEventoDet(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/franja/csv")]
        [HttpGet("/export/reincardb/franja/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFranjaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFranja(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/franja/excel")]
        [HttpGet("/export/reincardb/franja/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFranjaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFranja(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/gestionescoomutemp/csv")]
        [HttpGet("/export/reincardb/gestionescoomutemp/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGestionesCoomuTempToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGestionesCoomuTemp(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/gestionescoomutemp/excel")]
        [HttpGet("/export/reincardb/gestionescoomutemp/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGestionesCoomuTempToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGestionesCoomuTemp(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/honorarioavvillas/csv")]
        [HttpGet("/export/reincardb/honorarioavvillas/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHonorarioAvvillasToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHonorarioAvvillas(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/honorarioavvillas/excel")]
        [HttpGet("/export/reincardb/honorarioavvillas/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHonorarioAvvillasToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHonorarioAvvillas(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/infsaludcoop/csv")]
        [HttpGet("/export/reincardb/infsaludcoop/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInfSaludcoopToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInfSaludcoop(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/infsaludcoop/excel")]
        [HttpGet("/export/reincardb/infsaludcoop/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInfSaludcoopToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInfSaludcoop(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/informe/csv")]
        [HttpGet("/export/reincardb/informe/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInformeToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInforme(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/informe/excel")]
        [HttpGet("/export/reincardb/informe/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInformeToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInforme(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/jamar/csv")]
        [HttpGet("/export/reincardb/jamar/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportJamarToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetJamar(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/jamar/excel")]
        [HttpGet("/export/reincardb/jamar/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportJamarToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetJamar(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/jamarjuridica/csv")]
        [HttpGet("/export/reincardb/jamarjuridica/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportJamarJuridicaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetJamarJuridica(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/jamarjuridica/excel")]
        [HttpGet("/export/reincardb/jamarjuridica/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportJamarJuridicaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetJamarJuridica(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/logclientedeudaestado/csv")]
        [HttpGet("/export/reincardb/logclientedeudaestado/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLogClienteDeudaEstadoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLogClienteDeudaEstado(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/logclientedeudaestado/excel")]
        [HttpGet("/export/reincardb/logclientedeudaestado/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLogClienteDeudaEstadoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLogClienteDeudaEstado(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/logdatopersona/csv")]
        [HttpGet("/export/reincardb/logdatopersona/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLogDatoPersonaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLogDatoPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/logdatopersona/excel")]
        [HttpGet("/export/reincardb/logdatopersona/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLogDatoPersonaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLogDatoPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/logapp/csv")]
        [HttpGet("/export/reincardb/logapp/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLogappToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLogapp(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/logapp/excel")]
        [HttpGet("/export/reincardb/logapp/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLogappToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLogapp(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/mcita/csv")]
        [HttpGet("/export/reincardb/mcita/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMCitaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMCita(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/mcita/excel")]
        [HttpGet("/export/reincardb/mcita/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMCitaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMCita(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/mespecialidad/csv")]
        [HttpGet("/export/reincardb/mespecialidad/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMEspecialidadToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMEspecialidad(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/mespecialidad/excel")]
        [HttpGet("/export/reincardb/mespecialidad/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMEspecialidadToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMEspecialidad(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/mespecialidadmedico/csv")]
        [HttpGet("/export/reincardb/mespecialidadmedico/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMEspecialidadMedicoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMEspecialidadMedico(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/mespecialidadmedico/excel")]
        [HttpGet("/export/reincardb/mespecialidadmedico/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMEspecialidadMedicoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMEspecialidadMedico(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/mestadocita/csv")]
        [HttpGet("/export/reincardb/mestadocita/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMEstadoCitaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMEstadoCita(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/mestadocita/excel")]
        [HttpGet("/export/reincardb/mestadocita/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMEstadoCitaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMEstadoCita(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/mmedico/csv")]
        [HttpGet("/export/reincardb/mmedico/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMMedicoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMMedico(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/mmedico/excel")]
        [HttpGet("/export/reincardb/mmedico/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMMedicoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMMedico(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/msede/csv")]
        [HttpGet("/export/reincardb/msede/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMSedeToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMSede(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/msede/excel")]
        [HttpGet("/export/reincardb/msede/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMSedeToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMSede(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/maf/csv")]
        [HttpGet("/export/reincardb/maf/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMafToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMaf(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/maf/excel")]
        [HttpGet("/export/reincardb/maf/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMafToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMaf(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/menco/csv")]
        [HttpGet("/export/reincardb/menco/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMencoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMenco(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/menco/excel")]
        [HttpGet("/export/reincardb/menco/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMencoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMenco(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/municipio/csv")]
        [HttpGet("/export/reincardb/municipio/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMunicipioToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMunicipio(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/municipio/excel")]
        [HttpGet("/export/reincardb/municipio/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMunicipioToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMunicipio(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/parametro/csv")]
        [HttpGet("/export/reincardb/parametro/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportParametroToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetParametro(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/parametro/excel")]
        [HttpGet("/export/reincardb/parametro/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportParametroToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetParametro(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/parametrovalor/csv")]
        [HttpGet("/export/reincardb/parametrovalor/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportParametroValorToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetParametroValor(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/parametrovalor/excel")]
        [HttpGet("/export/reincardb/parametrovalor/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportParametroValorToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetParametroValor(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/persona/csv")]
        [HttpGet("/export/reincardb/persona/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPersonaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/persona/excel")]
        [HttpGet("/export/reincardb/persona/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPersonaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/promotora/csv")]
        [HttpGet("/export/reincardb/promotora/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPromotoraToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPromotora(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/promotora/excel")]
        [HttpGet("/export/reincardb/promotora/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPromotoraToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPromotora(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/razontiempofuera/csv")]
        [HttpGet("/export/reincardb/razontiempofuera/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRazontiempofueraToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRazontiempofuera(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/razontiempofuera/excel")]
        [HttpGet("/export/reincardb/razontiempofuera/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRazontiempofueraToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRazontiempofuera(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/rediferido/csv")]
        [HttpGet("/export/reincardb/rediferido/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRediferidoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRediferido(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/rediferido/excel")]
        [HttpGet("/export/reincardb/rediferido/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRediferidoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRediferido(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/reseve/csv")]
        [HttpGet("/export/reincardb/reseve/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResEveToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetResEve(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/reseve/excel")]
        [HttpGet("/export/reincardb/reseve/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResEveToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetResEve(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/resevec3/csv")]
        [HttpGet("/export/reincardb/resevec3/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResEveC3ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetResEveC3(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/resevec3/excel")]
        [HttpGet("/export/reincardb/resevec3/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResEveC3ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetResEveC3(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/resultadoevento/csv")]
        [HttpGet("/export/reincardb/resultadoevento/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResultadoEventoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetResultadoEvento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/resultadoevento/excel")]
        [HttpGet("/export/reincardb/resultadoevento/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResultadoEventoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetResultadoEvento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/rol/csv")]
        [HttpGet("/export/reincardb/rol/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRolToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRol(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/rol/excel")]
        [HttpGet("/export/reincardb/rol/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRolToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRol(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/saludcoop/csv")]
        [HttpGet("/export/reincardb/saludcoop/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSaludcoopToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSaludcoop(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/saludcoop/excel")]
        [HttpGet("/export/reincardb/saludcoop/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSaludcoopToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSaludcoop(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/saludcoopcd/csv")]
        [HttpGet("/export/reincardb/saludcoopcd/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSaludcoopcdToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSaludcoopcd(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/saludcoopcd/excel")]
        [HttpGet("/export/reincardb/saludcoopcd/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSaludcoopcdToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSaludcoopcd(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/sms/csv")]
        [HttpGet("/export/reincardb/sms/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSmsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSms(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/sms/excel")]
        [HttpGet("/export/reincardb/sms/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSmsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSms(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/subrepartousuario/csv")]
        [HttpGet("/export/reincardb/subrepartousuario/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSubrepartoUsuarioToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSubrepartoUsuario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/subrepartousuario/excel")]
        [HttpGet("/export/reincardb/subrepartousuario/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSubrepartoUsuarioToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSubrepartoUsuario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tarea/csv")]
        [HttpGet("/export/reincardb/tarea/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTareaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTarea(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tarea/excel")]
        [HttpGet("/export/reincardb/tarea/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTareaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTarea(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tasa/csv")]
        [HttpGet("/export/reincardb/tasa/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTasaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTasa(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tasa/excel")]
        [HttpGet("/export/reincardb/tasa/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTasaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTasa(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tbldelete/csv")]
        [HttpGet("/export/reincardb/tbldelete/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDeleteToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblDelete(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tbldelete/excel")]
        [HttpGet("/export/reincardb/tbldelete/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTblDeleteToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblDelete(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tempevetodelete/csv")]
        [HttpGet("/export/reincardb/tempevetodelete/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTempEveToDeleteToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTempEveToDelete(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tempevetodelete/excel")]
        [HttpGet("/export/reincardb/tempevetodelete/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTempEveToDeleteToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTempEveToDelete(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tempevetoupd/csv")]
        [HttpGet("/export/reincardb/tempevetoupd/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTempEveToUpdToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTempEveToUpd(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tempevetoupd/excel")]
        [HttpGet("/export/reincardb/tempevetoupd/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTempEveToUpdToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTempEveToUpd(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tempidcoomulstrasan/csv")]
        [HttpGet("/export/reincardb/tempidcoomulstrasan/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTempIdcoomulstrasanToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTempIdcoomulstrasan(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tempidcoomulstrasan/excel")]
        [HttpGet("/export/reincardb/tempidcoomulstrasan/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTempIdcoomulstrasanToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTempIdcoomulstrasan(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tempidcoomulstrasan2/csv")]
        [HttpGet("/export/reincardb/tempidcoomulstrasan2/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTempIdcoomulstrasan2ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTempIdcoomulstrasan2(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tempidcoomulstrasan2/excel")]
        [HttpGet("/export/reincardb/tempidcoomulstrasan2/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTempIdcoomulstrasan2ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTempIdcoomulstrasan2(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tiempoevento/csv")]
        [HttpGet("/export/reincardb/tiempoevento/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTiempoEventoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTiempoEvento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tiempoevento/excel")]
        [HttpGet("/export/reincardb/tiempoevento/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTiempoEventoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTiempoEvento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tiempofuera/csv")]
        [HttpGet("/export/reincardb/tiempofuera/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTiempofueraToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTiempofuera(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tiempofuera/excel")]
        [HttpGet("/export/reincardb/tiempofuera/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTiempofueraToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTiempofuera(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipoarchivo/csv")]
        [HttpGet("/export/reincardb/tipoarchivo/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoArchivoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipoArchivo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipoarchivo/excel")]
        [HttpGet("/export/reincardb/tipoarchivo/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoArchivoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipoArchivo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipoclasificacionadicional/csv")]
        [HttpGet("/export/reincardb/tipoclasificacionadicional/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoClasificacionAdicionalToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipoClasificacionAdicional(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipoclasificacionadicional/excel")]
        [HttpGet("/export/reincardb/tipoclasificacionadicional/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoClasificacionAdicionalToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipoClasificacionAdicional(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipocliente/csv")]
        [HttpGet("/export/reincardb/tipocliente/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoClienteToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipoCliente(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipocliente/excel")]
        [HttpGet("/export/reincardb/tipocliente/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoClienteToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipoCliente(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipocomunicacion/csv")]
        [HttpGet("/export/reincardb/tipocomunicacion/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoComunicacionToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipoComunicacion(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipocomunicacion/excel")]
        [HttpGet("/export/reincardb/tipocomunicacion/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoComunicacionToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipoComunicacion(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipocomunicacionresultadoevento/csv")]
        [HttpGet("/export/reincardb/tipocomunicacionresultadoevento/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoComunicacionResultadoEventoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipoComunicacionResultadoEvento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipocomunicacionresultadoevento/excel")]
        [HttpGet("/export/reincardb/tipocomunicacionresultadoevento/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoComunicacionResultadoEventoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipoComunicacionResultadoEvento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipodatopersona/csv")]
        [HttpGet("/export/reincardb/tipodatopersona/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoDatoPersonaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipoDatoPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipodatopersona/excel")]
        [HttpGet("/export/reincardb/tipodatopersona/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoDatoPersonaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipoDatoPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipodocumento/csv")]
        [HttpGet("/export/reincardb/tipodocumento/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoDocumentoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipoDocumento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipodocumento/excel")]
        [HttpGet("/export/reincardb/tipodocumento/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoDocumentoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipoDocumento(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tiporecaudo/csv")]
        [HttpGet("/export/reincardb/tiporecaudo/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoRecaudoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipoRecaudo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tiporecaudo/excel")]
        [HttpGet("/export/reincardb/tiporecaudo/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoRecaudoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipoRecaudo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tiporediferido/csv")]
        [HttpGet("/export/reincardb/tiporediferido/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoRediferidoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipoRediferido(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tiporediferido/excel")]
        [HttpGet("/export/reincardb/tiporediferido/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoRediferidoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipoRediferido(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipotarea/csv")]
        [HttpGet("/export/reincardb/tipotarea/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoTareaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipoTarea(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipotarea/excel")]
        [HttpGet("/export/reincardb/tipotarea/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoTareaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipoTarea(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipovia/csv")]
        [HttpGet("/export/reincardb/tipovia/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoViaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipoVia(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipovia/excel")]
        [HttpGet("/export/reincardb/tipovia/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipoViaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipoVia(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipobase/csv")]
        [HttpGet("/export/reincardb/tipobase/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipobaseToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTipobase(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tipobase/excel")]
        [HttpGet("/export/reincardb/tipobase/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTipobaseToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTipobase(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpclientedeudadic/csv")]
        [HttpGet("/export/reincardb/tmpclientedeudadic/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpClienteDeudaDicToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTmpClienteDeudaDic(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpclientedeudadic/excel")]
        [HttpGet("/export/reincardb/tmpclientedeudadic/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpClienteDeudaDicToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTmpClienteDeudaDic(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpclientedeudaestado/csv")]
        [HttpGet("/export/reincardb/tmpclientedeudaestado/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpClienteDeudaEstadoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTmpClienteDeudaEstado(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpclientedeudaestado/excel")]
        [HttpGet("/export/reincardb/tmpclientedeudaestado/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpClienteDeudaEstadoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTmpClienteDeudaEstado(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpdatoperbor/csv")]
        [HttpGet("/export/reincardb/tmpdatoperbor/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpDatoPerBorToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTmpDatoPerBor(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpdatoperbor/excel")]
        [HttpGet("/export/reincardb/tmpdatoperbor/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpDatoPerBorToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTmpDatoPerBor(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpdatopersona/csv")]
        [HttpGet("/export/reincardb/tmpdatopersona/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpDatoPersonaToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTmpDatoPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpdatopersona/excel")]
        [HttpGet("/export/reincardb/tmpdatopersona/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpDatoPersonaToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTmpDatoPersona(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpdecest/csv")]
        [HttpGet("/export/reincardb/tmpdecest/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpDecEstToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTmpDecEst(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpdecest/excel")]
        [HttpGet("/export/reincardb/tmpdecest/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpDecEstToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTmpDecEst(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpeventosaludcoop/csv")]
        [HttpGet("/export/reincardb/tmpeventosaludcoop/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpEventoSaludcoopToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTmpEventoSaludcoop(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpeventosaludcoop/excel")]
        [HttpGet("/export/reincardb/tmpeventosaludcoop/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpEventoSaludcoopToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTmpEventoSaludcoop(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpgestcoojur/csv")]
        [HttpGet("/export/reincardb/tmpgestcoojur/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpGestCooJurToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTmpGestCooJur(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpgestcoojur/excel")]
        [HttpGet("/export/reincardb/tmpgestcoojur/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpGestCooJurToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTmpGestCooJur(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpusuario/csv")]
        [HttpGet("/export/reincardb/tmpusuario/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpUsuarioToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTmpUsuario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpusuario/excel")]
        [HttpGet("/export/reincardb/tmpusuario/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpUsuarioToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTmpUsuario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpcambiotip/csv")]
        [HttpGet("/export/reincardb/tmpcambiotip/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpcambiotipToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTmpcambiotip(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/tmpcambiotip/excel")]
        [HttpGet("/export/reincardb/tmpcambiotip/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTmpcambiotipToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTmpcambiotip(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/transito/csv")]
        [HttpGet("/export/reincardb/transito/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransitoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTransito(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/transito/excel")]
        [HttpGet("/export/reincardb/transito/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransitoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTransito(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/transitobuc/csv")]
        [HttpGet("/export/reincardb/transitobuc/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransitobucToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTransitobuc(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/transitobuc/excel")]
        [HttpGet("/export/reincardb/transitobuc/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransitobucToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTransitobuc(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/transitoflo/csv")]
        [HttpGet("/export/reincardb/transitoflo/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransitofloToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTransitoflo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/transitoflo/excel")]
        [HttpGet("/export/reincardb/transitoflo/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTransitofloToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTransitoflo(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/usuario/csv")]
        [HttpGet("/export/reincardb/usuario/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUsuarioToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUsuario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/usuario/excel")]
        [HttpGet("/export/reincardb/usuario/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUsuarioToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUsuario(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/usuariocliente/csv")]
        [HttpGet("/export/reincardb/usuariocliente/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUsuarioClienteToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUsuarioCliente(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/usuariocliente/excel")]
        [HttpGet("/export/reincardb/usuariocliente/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUsuarioClienteToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUsuarioCliente(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/usuariorol/csv")]
        [HttpGet("/export/reincardb/usuariorol/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUsuarioRolToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUsuarioRol(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/usuariorol/excel")]
        [HttpGet("/export/reincardb/usuariorol/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUsuarioRolToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUsuarioRol(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/zonaubicacion/csv")]
        [HttpGet("/export/reincardb/zonaubicacion/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZonaUbicacionToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetZonaUbicacion(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/zonaubicacion/excel")]
        [HttpGet("/export/reincardb/zonaubicacion/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZonaUbicacionToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetZonaUbicacion(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/zzzprocavv/csv")]
        [HttpGet("/export/reincardb/zzzprocavv/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZzzProcAvvToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetZzzProcAvv(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/zzzprocavv/excel")]
        [HttpGet("/export/reincardb/zzzprocavv/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZzzProcAvvToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetZzzProcAvv(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/zzztmpborraravvillas/csv")]
        [HttpGet("/export/reincardb/zzztmpborraravvillas/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZzzTmpBorrarAvvillasToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetZzzTmpBorrarAvvillas(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/zzztmpborraravvillas/excel")]
        [HttpGet("/export/reincardb/zzztmpborraravvillas/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZzzTmpBorrarAvvillasToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetZzzTmpBorrarAvvillas(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/zzztmpborraravvillas1/csv")]
        [HttpGet("/export/reincardb/zzztmpborraravvillas1/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZzzTmpBorrarAvvillas1ToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetZzzTmpBorrarAvvillas1(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/zzztmpborraravvillas1/excel")]
        [HttpGet("/export/reincardb/zzztmpborraravvillas1/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZzzTmpBorrarAvvillas1ToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetZzzTmpBorrarAvvillas1(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/zzztmptodeltransito/csv")]
        [HttpGet("/export/reincardb/zzztmptodeltransito/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZzzTmpToDelTransitoToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetZzzTmpToDelTransito(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/zzztmptodeltransito/excel")]
        [HttpGet("/export/reincardb/zzztmptodeltransito/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZzzTmpToDelTransitoToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetZzzTmpToDelTransito(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/aspnetusers/csv")]
        [HttpGet("/export/reincardb/aspnetusers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspnetusersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAspnetusers(), Request.Query, false), fileName);
        }

        [HttpGet("/export/reincardb/aspnetusers/excel")]
        [HttpGet("/export/reincardb/aspnetusers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAspnetusersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAspnetusers(), Request.Query, false), fileName);
        }
    }
}
