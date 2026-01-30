using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("zzz_tmp_to_del_transito")]
    public partial class ZzzTmpToDelTransito
    {
        [Key]
        [Required]
        public long id_evento { get; set; }
    }
}