using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tiempofuera")]
    public partial class Tiempofuera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public long? SegundosFuera { get; set; }

        [MaxLength(150)]
        public string TerminadoPor { get; set; }

        public long? IdRazonTiempoFuera { get; set; }

        public Razontiempofuera Razontiempofuera { get; set; }

        [MaxLength(150)]
        public string Contexto { get; set; }
    }
}