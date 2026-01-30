using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("coomultrasan_temprana")]
    public partial class CoomultrasanTemprana
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Coomultrasan { get; set; }

        public double? NROPRO { get; set; }

        [MaxLength(510)]
        public string FRANJAS { get; set; }

        [MaxLength(510)]
        public string BLOQUEO_CONTAC_CENTER { get; set; }

        [MaxLength(510)]
        public string OFICINA { get; set; }

        [MaxLength(30)]
        public string IDENTIFICACION { get; set; }

        [MaxLength(510)]
        public string NOMBRES_DEUDOR { get; set; }

        public decimal? SALDOCREDITO { get; set; }

        public double? DIAS_ACTUAL_COBRO { get; set; }

        public decimal? SALDO_VENC { get; set; }

        [MaxLength(510)]
        public string CAIDAS { get; set; }

        public double? FECHAULTPAGO { get; set; }

        public double? PLAZO { get; set; }

        public decimal? VALORCUOTA { get; set; }

        public double? VALORULTPAGO { get; set; }

        public double? CUOTASCANCELADAS { get; set; }

        [MaxLength(510)]
        public string EMAIL_DEUDOR { get; set; }

        [MaxLength(510)]
        public string EMPRESAPAGADURIA { get; set; }

        public double? TELCASA { get; set; }

        public double? TELCEL { get; set; }

        public double? TELTRABAJO { get; set; }

        [MaxLength(510)]
        public string EMP_DEUDOR { get; set; }

        [MaxLength(510)]
        public string CIUDAD_TRAB_DEUDOR { get; set; }

        [MaxLength(510)]
        public string DIR_TRAB_DEUDOR { get; set; }

        [MaxLength(510)]
        public string DIR_RESIDE_DEUDOR { get; set; }

        [MaxLength(510)]
        public string CIU_RESIDE_DEUDOR { get; set; }

        [MaxLength(510)]
        public string BARRIO_RES_DEUDOR { get; set; }

        [MaxLength(510)]
        public string BARRIO_TRAB_DEUDOR { get; set; }

        [MaxLength(510)]
        public string OCUPACION_DEUDOR { get; set; }

        [MaxLength(40)]
        public string RFAM_IDENTIFICACION { get; set; }

        [MaxLength(510)]
        public string RFAM_NOMBRES { get; set; }

        public double? RFAM_TEL1 { get; set; }

        [MaxLength(40)]
        public string RPER_IDENTIFICACION { get; set; }

        [MaxLength(510)]
        public string RPER_NOMBRES { get; set; }

        public double? RPER_TEL1 { get; set; }

        public double? C1_IDENTIFICACION { get; set; }

        [MaxLength(510)]
        public string C1_NOMBRES { get; set; }

        public double? C1_TEL1 { get; set; }

        public double? C1_TEL2 { get; set; }

        [MaxLength(510)]
        public string C1_TEL3 { get; set; }

        public double? C1_TEL4 { get; set; }

        [MaxLength(510)]
        public string C1MAIL { get; set; }

        [MaxLength(40)]
        public string RFAMC1_IDENTIFICACION { get; set; }

        [MaxLength(510)]
        public string RFAMC1_NOMBRES { get; set; }

        public double? RFAMC1_TEL1 { get; set; }

        [MaxLength(40)]
        public string RPERC1_IDENTIFICACION { get; set; }

        [MaxLength(510)]
        public string RPERC1_NOMBRES { get; set; }

        public double? RPERC1_TEL1 { get; set; }

        public double? C2_IDENTIFICACION { get; set; }

        [MaxLength(510)]
        public string C2_NOMBRES { get; set; }

        public double? C2_TEL1 { get; set; }

        public double? C2_TEL2 { get; set; }

        [MaxLength(510)]
        public string C2_TEL3 { get; set; }

        public double? C2_TEL4 { get; set; }

        [MaxLength(510)]
        public string C2MAIL { get; set; }

        [MaxLength(40)]
        public string RFAMC2_IDENTIFICACION { get; set; }

        [MaxLength(510)]
        public string RFAMC2_NOMBRES { get; set; }

        [MaxLength(40)]
        public string RFAMC2_TEL1 { get; set; }

        [MaxLength(40)]
        public string RPERC2_IDENTIFICACION { get; set; }

        [MaxLength(510)]
        public string RPERC2_NOMBRES { get; set; }

        [MaxLength(40)]
        public string RPERC2_TEL1 { get; set; }

        public double? C3_IDENTIFICACION { get; set; }

        [MaxLength(40)]
        public string C3_NOMBRES { get; set; }

        public double? C3_TEL1 { get; set; }

        public double? C3_TEL2 { get; set; }

        [MaxLength(40)]
        public string C3_TEL3 { get; set; }

        public double? C3_TEL4 { get; set; }

        [MaxLength(510)]
        public string C3MAIL { get; set; }

        [MaxLength(40)]
        public string RFAMC3_IDENTIFICACION { get; set; }

        [MaxLength(510)]
        public string RFAMC3_NOMBRES { get; set; }

        [MaxLength(40)]
        public string RFAMC3_TEL1 { get; set; }

        [MaxLength(40)]
        public string RPERC3_IDENTIFICACION { get; set; }

        [MaxLength(510)]
        public string RPERC3_NOMBRES { get; set; }

        [MaxLength(40)]
        public string RPERC3_TEL1 { get; set; }

        public long? Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? FECHA_IMPORTACION { get; set; }
    }
}