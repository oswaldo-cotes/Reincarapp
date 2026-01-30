using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("rol")]
    public partial class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Rol { get; set; }

        [MaxLength(50)]
        public string Nombre_Rol { get; set; }

        public ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}