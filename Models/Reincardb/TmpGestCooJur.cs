using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tmp_gest_coo_jur")]
    public partial class TmpGestCooJur
    {
        [MaxLength(255)]
        public string ccnum { get; set; }

        [MaxLength(255)]
        public string tipoComunicacion { get; set; }

        [MaxLength(255)]
        public string resultadoEvento { get; set; }

        [MaxLength(255)]
        public string valor { get; set; }

        [MaxLength(2000)]
        public string texto { get; set; }

        [MaxLength(255)]
        public string fechaGest { get; set; }

        [MaxLength(255)]
        public string fechComp { get; set; }
    }
}