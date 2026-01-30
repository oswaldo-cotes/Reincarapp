using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cd_repetidas_persona")]
    public partial class CdRepetidasPersona
    {
        [Required]
        public long numero_de_veces { get; set; }

        [MaxLength(25)]
        public string numero_documento { get; set; }
    }
}