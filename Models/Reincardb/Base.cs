using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("base")]
    public partial class Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? IdCliente { get; set; }

        public Cliente Cliente { get; set; }

        public long? IdTipoBase { get; set; }

        public Tipobase Tipobase { get; set; }

        public long? IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        public long? IdUsuarioAct { get; set; }

        public Usuario Usuario1 { get; set; }

        [MaxLength(45)]
        public string Nombre { get; set; }

        public byte[] Archivo { get; set; }

        public DateTime? FechaCre { get; set; }

        public DateTime? FechaAct { get; set; }

        [MaxLength(500)]
        public string NombreArchivo { get; set; }

        public ICollection<Basecampo> Basecampo { get; set; }
    }
}