using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("informe")]
    public partial class Informe
    {
        [Key]
        [Required]
        public int idInforme { get; set; }

        [MaxLength(45)]
        public string nombre_informe { get; set; }
    }
}