using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("m_cita")]
    public partial class MCita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? IdSede { get; set; }

        public MSede MSede { get; set; }

        public long? IdMedico { get; set; }

        public MMedico MMedico { get; set; }

        public long? IdEspecialidad { get; set; }

        public MEspecialidad MEspecialidad { get; set; }

        public long? IdPersona { get; set; }

        public Persona Persona { get; set; }

        public DateTime? Fecha_Inicio { get; set; }

        public DateTime? Fecha_Fin { get; set; }

        public long? IdEstado { get; set; }

        public MEstadoCita MEstadoCita { get; set; }

        [MaxLength(2000)]
        public string Observacion { get; set; }
    }
}