using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tmp_dato_per_bor")]
    public partial class TmpDatoPerBor
    {
        public long? id_persona { get; set; }

        public long? id_tipo_dato_persona { get; set; }

        [MaxLength(250)]
        public string dato { get; set; }

        [Required]
        public long nro_rep { get; set; }
    }
}