using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("bancoomeva")]
    public partial class Bancoomeva
    {
        [MaxLength(255)]
        public string ID_CLIENTE { get; set; }

        [MaxLength(255)]
        public string NOMBRE_DEUDOR { get; set; }

        [MaxLength(255)]
        public string TIPIFICACION { get; set; }

        [MaxLength(255)]
        public string CIUDAD { get; set; }

        public float? OFIC { get; set; }

        public float? CAPITAL { get; set; }

        public DateTime? FECHA_DE_CASTIGO { get; set; }

        [MaxLength(255)]
        public string ABOGADO { get; set; }

        [MaxLength(255)]
        public string ABOGADO_SUPERVISOR { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_bancoomeva { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }
    }
}