using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("m_especialidad")]
    public partial class MEspecialidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }

        public ICollection<MCita> MCita { get; set; }

        public ICollection<MEspecialidadMedico> MEspecialidadMedico { get; set; }
    }
}