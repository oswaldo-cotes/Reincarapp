using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("menco")]
    public partial class Menco
    {
        public long? CUS_NO { get; set; }

        [MaxLength(500)]
        public string NOMBRE { get; set; }

        [MaxLength(80)]
        public string CEDULA { get; set; }

        [MaxLength(80)]
        public string SOCIEDAD { get; set; }

        [MaxLength(80)]
        public string ESTADO_ACTUAL { get; set; }

        public double? SALDO { get; set; }

        public double? INTERESES { get; set; }

        public double? VALOR_ADEUDADO { get; set; }

        [MaxLength(80)]
        public string FUP { get; set; }

        public double? ULTIMO_ABONO { get; set; }

        [MaxLength(250)]
        public string OBSERVACION_JEFE_JURIDICO { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_menco { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }
    }
}