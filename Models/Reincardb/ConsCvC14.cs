using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cons_cv_c1_4")]
    public partial class ConsCvC14
    {
        public long? id_cliente_deuda { get; set; }

        public long? Mes_Creacion_Evento { get; set; }

        public long? valor_exito { get; set; }

        public string texto_evento { get; set; }

        public DateTime? max_fecha_creacion { get; set; }

        public long? id_evento_max { get; set; }
    }
}