using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tasa")]
    public partial class Tasa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_tasa { get; set; }

        public double? tasa { get; set; }

        public ICollection<Rediferido> Rediferido { get; set; }
    }
}