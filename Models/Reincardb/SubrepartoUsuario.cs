using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("subreparto_usuario")]
    public partial class SubrepartoUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdSubRepartoUsuario { get; set; }

        [MaxLength(80)]
        public string Subreparto { get; set; }

        public long? IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public long? UsuarioCreacion { get; set; }

        public Usuario Usuario2 { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public long? UsuarioActualizacion { get; set; }

        public Usuario Usuario1 { get; set; }
    }
}