using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("logapp")]
    public partial class Logapp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdLogApp { get; set; }

        public long? IdUsuario { get; set; }

        [MaxLength(500)]
        public string Proc { get; set; }

        public string Texto { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [MaxLength(95)]
        public string CreatedBy { get; set; }
    }
}