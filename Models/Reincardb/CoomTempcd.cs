using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("coom_tempcd")]
    public partial class CoomTempcd
    {
        [Required]
        public long id_coomultrasan_juridica { get; set; }

        [Required]
        public long id_cliente_deuda { get; set; }
    }
}