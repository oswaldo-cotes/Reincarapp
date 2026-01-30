using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("bancobogota")]
    public partial class Bancobogota
    {
        [MaxLength(255)]
        public string CIUDAD { get; set; }

        [MaxLength(255)]
        public string OFI { get; set; }

        [MaxLength(255)]
        public string ENTIDAD { get; set; }

        public double? CED_SIN_DIG { get; set; }

        [MaxLength(255)]
        public string GESTOR { get; set; }

        [MaxLength(255)]
        public string CLIENTE { get; set; }

        [MaxLength(255)]
        public string PRODUCTO { get; set; }

        [MaxLength(255)]
        public string OBLIGACION { get; set; }

        [MaxLength(255)]
        public string FECHA_CAST { get; set; }

        public double? SALDO_OBLIG { get; set; }

        public double? DIAS_OBLIG { get; set; }

        [MaxLength(255)]
        public string GRUPO { get; set; }

        public double? CAPITAL_TOTAL { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idbancobogota { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }
    }
}