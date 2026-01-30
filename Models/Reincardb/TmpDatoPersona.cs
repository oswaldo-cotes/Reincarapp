using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tmp_dato_persona")]
    public partial class TmpDatoPersona
    {
        [Key]
        [Required]
        public long id_dato_persona { get; set; }

        public long? veces { get; set; }

        public long? id_tipo_dato_persona { get; set; }

        [MaxLength(250)]
        public string dato { get; set; }

        public long? id_persona { get; set; }
    }
}