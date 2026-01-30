using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("coomultrasan_ley79")]
    public partial class CoomultrasanLey79
    {
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
        public string OFICINA { get; set; }

        [MaxLength(30)]
        public string IDENTIFICACION { get; set; }

        [MaxLength(255)]
        public string NOMBRES_DEUDOR { get; set; }

        [MaxLength(255)]
        public string SALDOCREDITO { get; set; }

        [MaxLength(255)]
        public string DIAS_ACTUAL_COBRO { get; set; }

        [MaxLength(255)]
        public string SALDO_VENC { get; set; }

        [MaxLength(255)]
        public string CAIDAS { get; set; }

        [MaxLength(255)]
        public string TIPODEPAGO { get; set; }

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
        public string TIPOGARANTIA { get; set; }

        [Column("EMAIL DEUDOR")]
        [MaxLength(255)]
        public string EMAILDEUDOR { get; set; }

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
        public string BARRIO_TRAB_DEUDOR { get; set; }

        [MaxLength(255)]
        public string OCUPA_DEU { get; set; }

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

        [MaxLength(255)]
        public string ASESOR { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_Coomultrasan_ley79 { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? FECHA_IMPORTACION { get; set; }

        public DateTime? Fecha_Final { get; set; }
    }
}