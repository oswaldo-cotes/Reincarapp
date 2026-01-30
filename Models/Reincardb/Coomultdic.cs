using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("coomultdic")]
    public partial class Coomultdic
    {
        [MaxLength(255)]
        public string NROPRO { get; set; }

        [MaxLength(255)]
        public string NRO_PAGARE { get; set; }

        [MaxLength(255)]
        public string FRANJAS { get; set; }

        [MaxLength(255)]
        public string CASA_DE_COBRO { get; set; }

        [MaxLength(255)]
        public string LINEACREDITO { get; set; }

        [MaxLength(255)]
        public string COD_AGENCIA { get; set; }

        [MaxLength(255)]
        public string IDENTIFICACION { get; set; }

        [MaxLength(255)]
        public string NOMBRES { get; set; }

        [MaxLength(255)]
        public string SALDO_TOTAL { get; set; }

        [MaxLength(255)]
        public string DIAS_ACTUAL_COBRO { get; set; }

        [MaxLength(255)]
        public string SALDO_VENC { get; set; }

        [MaxLength(255)]
        public string CAIDAS { get; set; }

        [MaxLength(255)]
        public string RANGOS { get; set; }

        [MaxLength(255)]
        public string TIPO_PAGO { get; set; }

        [MaxLength(255)]
        public string FECHAULTPAGO { get; set; }

        [MaxLength(255)]
        public string PLAZO { get; set; }

        [MaxLength(255)]
        public string VALORCUOTA { get; set; }

        [MaxLength(255)]
        public string VALORULTPAGO { get; set; }

        [MaxLength(255)]
        public string CUOTASCANCELADAS { get; set; }

        [MaxLength(255)]
        public string VALORINICIALCRED { get; set; }

        [MaxLength(255)]
        public string TIPOGARANTIA { get; set; }

        [MaxLength(255)]
        public string EMAIL { get; set; }

        [MaxLength(255)]
        public string EMPRESAPAGADURIA { get; set; }

        [MaxLength(255)]
        public string TELCASA { get; set; }

        [MaxLength(255)]
        public string TELCEL { get; set; }

        [MaxLength(255)]
        public string TELTRABAJO { get; set; }

        [MaxLength(255)]
        public string EMP_DEUDOR { get; set; }

        [MaxLength(255)]
        public string CIUDAD_TRAB_DEUDOR { get; set; }

        [MaxLength(255)]
        public string DIR_TRAB_DEUDOR { get; set; }

        [MaxLength(255)]
        public string DIR_RESIDE_DEUDOR { get; set; }

        [MaxLength(255)]
        public string CIU_RESIDE_DEUDOR { get; set; }

        [MaxLength(255)]
        public string BARRIO_RES_DEUDOR { get; set; }

        [MaxLength(255)]
        public string OCUPACION { get; set; }

        [MaxLength(255)]
        public string RFAM_NOMBRES { get; set; }

        [MaxLength(255)]
        public string RFAM_DOMICILIO { get; set; }

        [MaxLength(255)]
        public string RFAM_CIUDAD { get; set; }

        [MaxLength(255)]
        public string RFAM_TEL1 { get; set; }

        [MaxLength(255)]
        public string REFAM_PARENTEZCO { get; set; }

        [MaxLength(255)]
        public string RPER_NOMBRES { get; set; }

        [MaxLength(255)]
        public string RPER_DOMICILIO { get; set; }

        [MaxLength(255)]
        public string RPER_CIUDAD { get; set; }

        [MaxLength(255)]
        public string RPER_TEL1 { get; set; }
    }
}