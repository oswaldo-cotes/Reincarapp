using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("usuario_rol")]
    public partial class UsuarioRol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Usuario_Rol { get; set; }

        public long? Id_Usuario { get; set; }

        public Usuario Usuario { get; set; }

        public long? Id_Rol { get; set; }

        public Rol Rol { get; set; }
    }
}