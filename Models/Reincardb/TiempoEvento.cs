using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tiempo_evento")]
    public partial class TiempoEvento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_tiempo_evento { get; set; }

        public DateTime? Fecha_Inicial { get; set; }

        public DateTime? Fecha_Final { get; set; }

        public long? Id_Evento { get; set; }
    }
}