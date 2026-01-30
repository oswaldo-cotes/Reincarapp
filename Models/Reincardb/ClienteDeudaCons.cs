using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cliente_deuda_cons")]
    public partial class ClienteDeudaCons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_cliente_deuda_cons { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public long? id_evento_mejor_gestion { get; set; }

        public Evento Evento { get; set; }

        public long? id_evento_ultima_gestion { get; set; }

        public Evento Evento1 { get; set; }
    }
}