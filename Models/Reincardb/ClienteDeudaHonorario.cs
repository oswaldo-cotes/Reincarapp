using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cliente_deuda_honorario")]
    public partial class ClienteDeudaHonorario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_cliente_deuda_honorario { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public long? id_base { get; set; }

        public long? id_honorario { get; set; }

        public double? valor_honorario { get; set; }

        public long? id_usuario { get; set; }

        public Usuario Usuario { get; set; }

        public long? id_evento { get; set; }

        public DateTime? fecha_creacion { get; set; }

        public long? id_evento_fin { get; set; }

        public Evento Evento { get; set; }
    }
}