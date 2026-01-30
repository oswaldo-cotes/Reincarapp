using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cedulaborrar")]
    public partial class Cedulaborrar
    {
        [Key]
        [Required]
        [MaxLength(30)]
        public string num_Documento { get; set; }
    }
}