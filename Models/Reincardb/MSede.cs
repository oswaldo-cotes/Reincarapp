using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("m_sede")]
    public partial class MSede
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(2000)]
        public string CorreoElectronico { get; set; }

        public ICollection<MCita> MCita { get; set; }
    }
}