using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("gestiones_coomu_temp")]
    public partial class GestionesCoomuTemp
    {
        public int? IdTipoCom { get; set; }

        public int? IdResEvento { get; set; }

        [Required]
        public long Id_Cliente_Deuda { get; set; }

        public long? id_dato_persona { get; set; }

        [Required]
        public int id_usuario_evento { get; set; }

        [MaxLength(0)]
        public byte[] fecha_realizacion_evento { get; set; }

        [MaxLength(2000)]
        public string NOTGESTION { get; set; }

        [MaxLength(0)]
        public byte[] monto { get; set; }

        public DateTime? fecha_creacion_evento { get; set; }

        [Required]
        public int id_usuario { get; set; }

        [MaxLength(0)]
        public byte[] id_tarea { get; set; }
    }
}