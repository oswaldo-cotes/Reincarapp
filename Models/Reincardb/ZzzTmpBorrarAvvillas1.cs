using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("zzz_tmp_borrar_avvillas_1")]
    public partial class ZzzTmpBorrarAvvillas1
    {
        [Key]
        [Required]
        public long id_cliente_deuda { get; set; }
    }
}