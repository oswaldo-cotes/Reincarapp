using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("log_dato_persona")]
    public partial class LogDatoPersona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_log_dato_persona { get; set; }

        public long? id_dato_persona { get; set; }

        public DatoPersona DatoPersona { get; set; }

        public long? id_tarea { get; set; }

        public Tarea Tarea { get; set; }

        public long? id_usuario { get; set; }

        public Usuario Usuario { get; set; }

        [MaxLength(250)]
        public string dato_old { get; set; }

        [MaxLength(250)]
        public string dato_new { get; set; }

        [MaxLength(1)]
        public string activo_old { get; set; }

        [MaxLength(1)]
        public string activo_new { get; set; }

        public long? id_tipo_dato_persona_old { get; set; }

        public TipoDatoPersona TipoDatoPersona1 { get; set; }

        public long? id_tipo_dato_persona_new { get; set; }

        public TipoDatoPersona TipoDatoPersona { get; set; }

        public DateTime? fecha_creacion { get; set; }
    }
}