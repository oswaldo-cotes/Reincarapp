using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("bktarea")]
    public partial class Bktarea
    {
        [Required]
        public long Id_Tarea { get; set; }

        public long? Id_Cliente_Deuda { get; set; }

        [Required]
        public long Id_Usuario_Tarea { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Texto_Tarea { get; set; }

        public long? Id_Tipo_Comunicacion { get; set; }

        [Required]
        public DateTime Fecha_Realizacion_Tarea { get; set; }

        public DateTime Fecha_Creacion_Tarea { get; set; }

        [Required]
        public long Id_Usuario { get; set; }

        public DateTime? Fecha_Ejecucion_Tarea { get; set; }

        public long? Id_Evento { get; set; }

        public decimal? monto { get; set; }
    }
}