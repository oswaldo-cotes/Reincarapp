using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("maf")]
    public partial class Maf
    {
        public float? Operacion { get; set; }

        [MaxLength(255)]
        public string Numero_Documento { get; set; }

        [MaxLength(255)]
        public string Cliente { get; set; }

        [MaxLength(255)]
        public string Departamento { get; set; }

        [MaxLength(255)]
        public string Zona_Cliente { get; set; }

        [MaxLength(255)]
        public string Tipo_Cliente { get; set; }

        [MaxLength(255)]
        public string Actividad { get; set; }

        [MaxLength(255)]
        public string Tipo_Independiente { get; set; }

        public float? ciclo { get; set; }

        public float? Plazo { get; set; }

        public float? Cuotas_Pagadas { get; set; }

        public float? Cuotas_x_pagar { get; set; }

        public float? Cuotas_vencidas { get; set; }

        [MaxLength(255)]
        public string Marca { get; set; }

        [MaxLength(255)]
        public string Marca_Riesgos { get; set; }

        [MaxLength(255)]
        public string Linea { get; set; }

        [MaxLength(255)]
        public string Familia { get; set; }

        [MaxLength(255)]
        public string Uso { get; set; }

        [MaxLength(255)]
        public string Servicio { get; set; }

        [MaxLength(255)]
        public string Placa { get; set; }

        public float? Saldo_Capital { get; set; }

        [MaxLength(255)]
        public string Franja_Mora { get; set; }

        public float? Días_de_atraso { get; set; }

        public float? Monto_Cuota_Vencida { get; set; }

        public float? Capital_Vencido { get; set; }

        public float? Int_Corr_Vencidos { get; set; }

        public float? Int_Mora_Vencidos { get; set; }

        public float? Seguro_Vida_Vencido { get; set; }

        public float? Poliza_TR_Vencido { get; set; }

        public float? Cuota_protegida { get; set; }

        public float? GAC { get; set; }

        [MaxLength(255)]
        public string Descripcion_del_Traslado { get; set; }

        [MaxLength(255)]
        public string Clase_Gestion { get; set; }

        [MaxLength(255)]
        public string Fecha_Compromiso { get; set; }

        [MaxLength(255)]
        public string Fecha_Ultima_Gestion { get; set; }

        [MaxLength(255)]
        public string Ult_Codigo_de_Gestion { get; set; }

        [MaxLength(255)]
        public string Causal { get; set; }

        [MaxLength(255)]
        public string Fecha_de_Ultimo_Pago { get; set; }

        [MaxLength(255)]
        public string Mejor_Gestion { get; set; }

        [MaxLength(255)]
        public string Grabador { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_maf { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }
    }
}