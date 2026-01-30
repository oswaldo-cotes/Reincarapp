using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("estado_usuario")]
    public partial class EstadoUsuario
    {
        [Key]
        public bool id_estado_usuario { get; set; }

        [MaxLength(45)]
        public string estado { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}