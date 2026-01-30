using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("act_campo_coomultrasan")]
    public partial class ActCampoCoomultrasan
    {
        [MaxLength(255)]
        public string NROPRO { get; set; }

        [MaxLength(30)]
        public string IDENTIFICACION { get; set; }

        [MaxLength(255)]
        public string SALDOCREDITO { get; set; }
    }
}