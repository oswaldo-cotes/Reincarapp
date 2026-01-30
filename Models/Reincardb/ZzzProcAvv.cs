using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("zzz_proc_avv")]
    public partial class ZzzProcAvv
    {
        [Required]
        public long id_evento { get; set; }

        [Required]
        public long id_cliente_deuda { get; set; }

        [Required]
        public long id_usuario_evento { get; set; }

        public long? id_base { get; set; }
    }
}