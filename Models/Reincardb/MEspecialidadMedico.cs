using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("m_especialidad_medico")]
    public partial class MEspecialidadMedico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long IdMedico { get; set; }

        public MMedico MMedico { get; set; }

        [Required]
        public long IdEspecialidad { get; set; }

        public MEspecialidad MEspecialidad { get; set; }
    }
}