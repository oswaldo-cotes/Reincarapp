using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("jamar")]
    public partial class Jamar
    {
        public double? agencia { get; set; }

        public double? codigo_del_cliente { get; set; }

        [MaxLength(255)]
        public string direccion_del_cliente { get; set; }

        [MaxLength(255)]
        public string celular { get; set; }

        [MaxLength(255)]
        public string telefono { get; set; }

        [MaxLength(255)]
        public string nombre_del_cliente { get; set; }

        [MaxLength(255)]
        public string ocupacion { get; set; }

        [MaxLength(6)]
        public DateTime? proroga { get; set; }

        [MaxLength(255)]
        public string tiene_bien_raiz { get; set; }

        public double? mes { get; set; }

        public double? numero_de_cuotas_pendientes { get; set; }

        [MaxLength(255)]
        public string descripcion_rango_saldo { get; set; }

        [MaxLength(255)]
        public string tipo_cuenta_cartera { get; set; }

        [MaxLength(255)]
        public string primera_as { get; set; }

        public double? score_estratega { get; set; }

        [MaxLength(255)]
        public string rango_saldo_pendiente { get; set; }

        [MaxLength(255)]
        public string porcentaje_saldo_pendiente { get; set; }

        [MaxLength(255)]
        public string cadena_de_cuenta_plan_al_dia { get; set; }

        public double? numero_de_planes { get; set; }

        public decimal? salario { get; set; }

        [MaxLength(255)]
        public string nombre_departamento { get; set; }

        [MaxLength(255)]
        public string nombre_ciudad { get; set; }

        [MaxLength(255)]
        public string nombre_del_barrio { get; set; }

        [MaxLength(255)]
        public string segmento_cuento { get; set; }

        public double? cobrador { get; set; }

        public double? numero_cuenta { get; set; }

        [MaxLength(255)]
        public string llave { get; set; }

        [MaxLength(255)]
        public string cruce { get; set; }

        [MaxLength(6)]
        public DateTime? fecha_de_emision { get; set; }

        [MaxLength(255)]
        public string estado { get; set; }

        [MaxLength(255)]
        public string estado_inicial { get; set; }

        [MaxLength(6)]
        public DateTime? fecha_ultimo_pago { get; set; }

        [MaxLength(255)]
        public string anyo { get; set; }

        public double? dia_de_vencimiento { get; set; }

        [MaxLength(6)]
        public DateTime? fecha_vencimiento_mes { get; set; }

        [MaxLength(255)]
        public string tipo_credito { get; set; }

        [MaxLength(255)]
        public string tramo_inicial { get; set; }

        public double? numero_cuotas_vencidas { get; set; }

        public double? cantidad_cuentas { get; set; }

        public double? recaudo_periodo { get; set; }

        public double? valor_cuota_mes { get; set; }

        public double? valor_cuota { get; set; }

        public decimal? Saldo { get; set; }

        public double? saldo_provision { get; set; }

        public decimal? saldo_vencido_inicial { get; set; }

        public double? valor_total_credito { get; set; }

        public decimal? Intereses { get; set; }

        public decimal? gasto_cobranza { get; set; }

        public decimal? saldo_capital { get; set; }

        public decimal? total_saldo_vencido { get; set; }

        public decimal? total_credito { get; set; }

        public decimal? honorarios { get; set; }

        public decimal? valor_honorarios { get; set; }

        public decimal? valor_total_a_pagar { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_jamar { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }
    }
}