using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("m_estado_cita")]
    public partial class MEstadoCita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Nombre { get; set; }

        public ICollection<MCita> MCita { get; set; }
    }
}