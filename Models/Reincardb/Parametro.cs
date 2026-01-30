using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("parametro")]
    public partial class Parametro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Parametro { get; set; }

        [MaxLength(255)]
        public string Nombre_Parametro { get; set; }

        public ICollection<ParametroValor> ParametroValor { get; set; }
    }
}