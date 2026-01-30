using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tipo_comunicacion_resultado_evento")]
    public partial class TipoComunicacionResultadoEvento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_tipo_comunicacion_resultado_evento { get; set; }

        public long? id_tipo_comunicacion { get; set; }

        public TipoComunicacion TipoComunicacion { get; set; }

        public long? id_resultado_evento { get; set; }

        public ResultadoEvento ResultadoEvento { get; set; }

        public long? id_cliente { get; set; }

        public Cliente Cliente { get; set; }
    }
}