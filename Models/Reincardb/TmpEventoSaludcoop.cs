using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tmp_evento_saludcoop")]
    public partial class TmpEventoSaludcoop
    {
        public int? IdTipoCom { get; set; }

        public int? IdResEvento { get; set; }

        [Required]
        public long id_cliente_deuda { get; set; }

        public long? id_dato_persona { get; set; }

        public long? us_1 { get; set; }

        public DateTime? fecha_1 { get; set; }

        [MaxLength(2000)]
        public string observacion { get; set; }

        [Required]
        public int monto { get; set; }

        public DateTime? fecha_2 { get; set; }

        public long? us_2 { get; set; }

        [MaxLength(0)]
        public byte[] id_tarea { get; set; }
    }
}