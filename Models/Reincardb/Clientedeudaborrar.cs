using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("clientedeudaborrar")]
    public partial class Clientedeudaborrar
    {
        [Key]
        [Required]
        public long id_Cliente_Deuda { get; set; }
    }
}