using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tmpcambiotip")]
    public partial class Tmpcambiotip
    {
        public int? IDENTIFICACION { get; set; }

        public string FECHAGESTION { get; set; }

        public string TIPIFICACION { get; set; }

        public int? ASESOR { get; set; }

        public string NTIPIFICACION { get; set; }
    }
}