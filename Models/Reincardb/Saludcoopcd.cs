using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("saludcoopcd")]
    public partial class Saludcoopcd
    {
        [Key]
        [Required]
        public long id_saludcoop { get; set; }

        [Required]
        public long id_cliente_deuda { get; set; }
    }
}