using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("coopetrol")]
    public partial class Coopetrol
    {
        public double? CEDULA { get; set; }

        [MaxLength(255)]
        public string NOMBRE { get; set; }

        [MaxLength(255)]
        public string DIRECCION { get; set; }

        [MaxLength(255)]
        public string TELEFONO { get; set; }

        [MaxLength(255)]
        public string CIUDAD { get; set; }

        [MaxLength(255)]
        public string EMPRESA { get; set; }

        [MaxLength(255)]
        public string CORREO_ELECTRONICO { get; set; }

        public decimal? SALDO_CAPITAL { get; set; }

        public decimal? CAPITAL_VENCIDO { get; set; }

        public decimal? INT_CORRIENTES { get; set; }

        public decimal? INT_MORA { get; set; }

        public decimal? SEGUROS { get; set; }

        public decimal? SUB_TOTAL_VENCIDO { get; set; }

        public decimal? SALDO_TOTAL { get; set; }

        [MaxLength(255)]
        public string TASA_DE_INT_NAMV { get; set; }

        [MaxLength(255)]
        public string LINEA_DE_CREDITO { get; set; }

        [MaxLength(255)]
        public string N_OBLIGACION { get; set; }

        [MaxLength(255)]
        public string VR_CUOTA { get; set; }

        [MaxLength(255)]
        public string FORMA_DE_PAGO { get; set; }

        [MaxLength(6)]
        public DateTime? FECHA_LIQUIDACION { get; set; }

        [MaxLength(1000)]
        public string GARANTIAS { get; set; }

        [MaxLength(6)]
        public DateTime? FECHA_MORA { get; set; }

        [MaxLength(255)]
        public string CEDULA_CODEUDOR1 { get; set; }

        [MaxLength(255)]
        public string NOMBRE_CODEUDOR1 { get; set; }

        [MaxLength(255)]
        public string DIRECCION_CODEUDOR1 { get; set; }

        [MaxLength(255)]
        public string TELEFONO_CODEUDOR1 { get; set; }

        [MaxLength(255)]
        public string CIUDAD_CODEUDOR1 { get; set; }

        [MaxLength(255)]
        public string EMPRESA_CODEUDOR1 { get; set; }

        [MaxLength(255)]
        public string CORREO_ELECTRONICO_CODEUDOR1 { get; set; }

        [MaxLength(255)]
        public string CEDULA_CODEUDOR2 { get; set; }

        [MaxLength(255)]
        public string NOMBRE_CODEUDOR2 { get; set; }

        [MaxLength(255)]
        public string DIRECCION_CODEUDOR2 { get; set; }

        [MaxLength(255)]
        public string TELEFONO_CODEUDOR2 { get; set; }

        [MaxLength(255)]
        public string CIUDAD_CODEUDOR2 { get; set; }

        [MaxLength(255)]
        public string EMPRESA_CODEUDOR2 { get; set; }

        [MaxLength(255)]
        public string CORREO_ELECTRONICO_CODEUDOR2 { get; set; }

        [MaxLength(255)]
        public string Hipoteca { get; set; }

        [MaxLength(255)]
        public string Prenda { get; set; }

        [MaxLength(255)]
        public string AGENCIA { get; set; }

        public double? DIAS_MORA_AGO_28 { get; set; }

        public double? DIAS_MORA_LEY_ARRASTRE_AGO_28 { get; set; }

        [MaxLength(1000)]
        public string Investigacion_Patrimonial { get; set; }

        [MaxLength(1000)]
        public string Observacion_Invest_Patrimonial { get; set; }

        [MaxLength(1000)]
        public string PAGARES { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idcoopetrol { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }
    }
}