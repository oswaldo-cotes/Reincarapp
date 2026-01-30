using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("parametro_valor")]
    public partial class ParametroValor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Parametro_Valor { get; set; }

        [Required]
        public long Id_Parametro { get; set; }

        public Parametro Parametro { get; set; }

        [MaxLength(4000)]
        public string Valor_Parametro_Texto { get; set; }

        public decimal? Valor_Parametro_Numero { get; set; }

        [Required]
        public DateTime Fecha_Inicio_Vigencia { get; set; }

        public DateTime? Fecha_Fin_Vigencia { get; set; }
    }
}