using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("asignacion")]
    public partial class Asignacion
    {
        [Key]
        [Required]
        [MaxLength(30)]
        public string Id_Asignacion { get; set; }

        [MaxLength(250)]
        public string Descripcion { get; set; }

        public ICollection<ClienteDeuda> ClienteDeuda { get; set; }
    }
}