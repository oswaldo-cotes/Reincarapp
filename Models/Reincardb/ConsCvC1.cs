using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cons_cv_c1")]
    public partial class ConsCvC1
    {
        public long? id_cliente_deuda { get; set; }

        public int? mes_creacion_evento { get; set; }

        public int? valor_exito { get; set; }

        public string texto_evento { get; set; }

        public DateTime? max_fecha_creacion { get; set; }

        public long? id_evento_max { get; set; }
    }
}