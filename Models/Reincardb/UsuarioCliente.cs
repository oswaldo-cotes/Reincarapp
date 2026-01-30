using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("usuario_cliente")]
    public partial class UsuarioCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Usuario_Cliente { get; set; }

        public long? Id_Cliente { get; set; }

        public Cliente Cliente { get; set; }

        public long? Id_Usuario { get; set; }

        public Usuario Usuario { get; set; }

        [MaxLength(95)]
        public string AspNetUserId { get; set; }

        public Aspnetusers Aspnetusers { get; set; }
    }
}