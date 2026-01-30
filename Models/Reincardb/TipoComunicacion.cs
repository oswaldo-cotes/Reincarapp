using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tipo_comunicacion")]
    public partial class TipoComunicacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Tipo_Comunicacion { get; set; }

        [MaxLength(50)]
        public string Nombre_Tipo_Comunicacion { get; set; }

        public long? Id_Cliente { get; set; }

        public Cliente Cliente { get; set; }

        [MaxLength(30)]
        public string Id_Negocio_Cliente { get; set; }

        public ICollection<DecisionEstado> DecisionEstado { get; set; }

        public ICollection<Evento> Evento { get; set; }

        public ICollection<Tarea> Tarea { get; set; }

        public ICollection<TipoComunicacionResultadoEvento> TipoComunicacionResultadoEvento { get; set; }
    }
}