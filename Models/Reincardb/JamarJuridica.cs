using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("jamar_juridica")]
    public partial class JamarJuridica
    {
        public double? agencia { get; set; }

        public double? codigo_del_cliente { get; set; }

        [MaxLength(255)]
        public string direccion_del_cliente { get; set; }

        [MaxLength(255)]
        public string celular { get; set; }

        [MaxLength(255)]
        public string telefono { get; set; }

        [MaxLength(255)]
        public string nombre_del_cliente { get; set; }

        [MaxLength(255)]
        public string nombre_departamento { get; set; }

        [MaxLength(255)]
        public string nombre_ciudad { get; set; }

        [MaxLength(255)]
        public string nombre_barrio { get; set; }

        [MaxLength(255)]
        public string llave { get; set; }

        [MaxLength(255)]
        public string estado { get; set; }

        public double? salario { get; set; }

        public decimal? intereses { get; set; }

        public decimal? honorarios { get; set; }

        public decimal? valor_honorarios { get; set; }

        public decimal? valor_total_a_pagar { get; set; }
    }
}