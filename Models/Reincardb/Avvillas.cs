using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("avvillas")]
    public partial class Avvillas
    {
        public double? NRO_DOCUMENTO_1 { get; set; }

        public string CREDITO { get; set; }

        [MaxLength(255)]
        public string asesora { get; set; }

        [MaxLength(255)]
        public string PRODUCTO { get; set; }

        [MaxLength(255)]
        public string NOMBRE_DEUDOR_1 { get; set; }

        [MaxLength(255)]
        public string ESTADO_INI_CALIF { get; set; }

        public double? CAP_PARETO { get; set; }

        public double? MORA_MAXIMA_INI { get; set; }

        public string SUBREPARTO { get; set; }

        public double? NRO_DOCUMENTO_11 { get; set; }

        [Column("No CLIENTES")]
        [MaxLength(255)]
        public string NoCLIENTES { get; set; }

        [MaxLength(255)]
        public string FECHA_DESEM { get; set; }

        [MaxLength(255)]
        public string CANTIDAD_PRODUCTOS { get; set; }

        public decimal? CAP_LIBROS_INI { get; set; }

        public double? VRMORA_INI { get; set; }

        public double? VRTOTAL_INI { get; set; }

        public double? PROVISION_INI { get; set; }

        public double? CUOTAS_MORA_INI { get; set; }

        public double? DIAS_MORA_INI { get; set; }

        public double? DIA_VENCIMIENTO { get; set; }

        [MaxLength(255)]
        public string CALIF_INI { get; set; }

        [MaxLength(255)]
        public string MOT_CALIF_INI { get; set; }

        [MaxLength(255)]
        public string GRUPO_CARTERA { get; set; }

        [MaxLength(255)]
        public string REGIONAL_COBRANZAS { get; set; }

        [MaxLength(255)]
        public string CENTRO { get; set; }

        [MaxLength(255)]
        public string FRANJA_INI { get; set; }

        [MaxLength(255)]
        public string ASESOR { get; set; }

        [MaxLength(255)]
        public string JEFE { get; set; }

        [MaxLength(255)]
        public string ITEMKEY { get; set; }

        [MaxLength(255)]
        public string FRANJA_INI_CLIENTE { get; set; }

        [MaxLength(255)]
        public string GESTION { get; set; }

        [MaxLength(255)]
        public string FECHA_COMPROMISO { get; set; }

        [MaxLength(255)]
        public string ACTIVIDAD_ECONOMICA { get; set; }

        [MaxLength(255)]
        public string CAUSAL_MORA { get; set; }

        [MaxLength(255)]
        public string EMPRESA { get; set; }

        [MaxLength(255)]
        public string NOMBRE_ABOGADO { get; set; }

        [MaxLength(255)]
        public string MACRO_ETP_JURIDICA { get; set; }

        public double? OFICI_RADICA { get; set; }

        public double? CAPITAL_LIBROS_ACTUAL { get; set; }

        public double? CUOTAS_MORA_ACTUAL { get; set; }

        public double? DIAS_MORA_ACTUAL { get; set; }

        public double? VRMORA_ACTUAL { get; set; }

        public double? VRTOTAL_ACTUAL { get; set; }

        public double? PROVISION_ACTUAL { get; set; }

        [MaxLength(255)]
        public string FECHA_REFIN { get; set; }

        [MaxLength(255)]
        public string CALIF_ACTUAL { get; set; }

        [MaxLength(255)]
        public string MOT_CALIF_ACTUAL { get; set; }

        [MaxLength(255)]
        public string CALIF_SUBJETIVA { get; set; }

        [MaxLength(255)]
        public string FECHA_CASTIGO { get; set; }

        [Column("RANGO CASTIGO")]
        [MaxLength(255)]
        public string RANGOCASTIGO { get; set; }

        public double? VRCASTIGO { get; set; }

        [MaxLength(255)]
        public string FECHA_ULT_PAGO { get; set; }

        [MaxLength(255)]
        public string VR_ULT_PAGO { get; set; }

        [MaxLength(255)]
        public string FRANJA_FIN { get; set; }

        [MaxLength(255)]
        public string FRANJA_FIN_CLIENTE { get; set; }

        [MaxLength(255)]
        public string FUNCIONARIO_RADICA { get; set; }

        [MaxLength(255)]
        public string ZONA_ANALISIS { get; set; }

        [MaxLength(255)]
        public string COMPORTAMIENTO_CREDITO { get; set; }

        [MaxLength(255)]
        public string TEMPORALIDAD { get; set; }

        [MaxLength(255)]
        public string COMPORTAMIENTO_CREDITO2 { get; set; }

        [MaxLength(255)]
        public string COMPORTAMIENTO_CLIENTE { get; set; }

        [MaxLength(255)]
        public string FECHA_REPARTO { get; set; }

        [MaxLength(255)]
        public string ESTADO_FIN_CALIF { get; set; }

        [MaxLength(255)]
        public string COMPORTAMIENTO_CALIF { get; set; }

        [MaxLength(255)]
        public string FECHA_RETANQUEO { get; set; }

        public double? VRPAGOS_MES { get; set; }

        public double? PUNTAJE_INICIAL { get; set; }

        public double? PUNTAJE_REAL { get; set; }

        [Column("CICLO FACTURACION")]
        [MaxLength(255)]
        public string CICLOFACTURACION { get; set; }

        [MaxLength(255)]
        public string AREA { get; set; }

        [MaxLength(255)]
        public string PLAZO_ACUERDO_PAGO { get; set; }

        public double? VALOR_ACUERDO_PAGO { get; set; }

        [MaxLength(255)]
        public string CEDULA_ASESOR_CASA { get; set; }

        [MaxLength(255)]
        public string NOMBRE_ASESOR_CASA { get; set; }

        public double? VRCUOTA { get; set; }

        public double? MORA_MAXIMA_ACTUAL { get; set; }

        [MaxLength(255)]
        public string CAUSAL_EXCLUSION_REPARTO { get; set; }

        public double? VENCIMIENTO_ARRASTRE { get; set; }

        public double? CUOTAS_PAGADAS { get; set; }

        [MaxLength(6)]
        public DateTime? FECHA_COMPROM_CONTACT { get; set; }

        [MaxLength(255)]
        public string CAMPANA_REPARTO { get; set; }

        [MaxLength(6)]
        public DateTime? FECHA_CORTE { get; set; }

        [MaxLength(255)]
        public string MOTIVO_SUBJETIVA { get; set; }

        [MaxLength(255)]
        public string TIPO_PRODUCTO_TC { get; set; }

        [Column("IND FNG")]
        [MaxLength(255)]
        public string INDFNG { get; set; }

        [MaxLength(255)]
        public string SEGMENTO { get; set; }

        [MaxLength(255)]
        public string SUBSEGMENTO { get; set; }

        [MaxLength(255)]
        public string SCORE { get; set; }

        [MaxLength(255)]
        public string ORIGEN { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_AvVillas { get; set; }

        public long? Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        [MaxLength(45)]
        public string asignacion { get; set; }

        public DateTime? Fecha_Inicial { get; set; }

        public DateTime? Fecha_Final { get; set; }
    }
}