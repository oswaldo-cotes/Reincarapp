using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cliente_deuda_agrup")]
    public partial class ClienteDeudaAgrup
    {
        [Required]
        public int estado { get; set; }

        [Required]
        public int cliente { get; set; }

        [Required]
        public long id_persona { get; set; }

        public decimal? monto { get; set; }

        public DateTime? fecha_inicio { get; set; }

        [MaxLength(0)]
        public byte[] fecha_cierre { get; set; }

        public DateTime fecha_creacion { get; set; }

        [Required]
        public int id_usuario { get; set; }

        public long? usuario_asig { get; set; }

        [MaxLength(0)]
        public byte[] id_negocio { get; set; }
    }
}