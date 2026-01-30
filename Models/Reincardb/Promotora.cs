using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("promotora")]
    public partial class Promotora
    {
        [MaxLength(255)]
        public string IDENTIFICACION { get; set; }

        [MaxLength(255)]
        public string NOMBRE { get; set; }

        [MaxLength(255)]
        public string ID { get; set; }

        [MaxLength(255)]
        public string OBLIGACION { get; set; }

        [MaxLength(255)]
        public string CARTERA { get; set; }

        public double? ANO_DE_CASTIGO { get; set; }

        [MaxLength(255)]
        public string TIPO_DEUDOR { get; set; }

        public double? GARANTIA { get; set; }

        [MaxLength(255)]
        public string JUDICIALIZADA { get; set; }

        [MaxLength(255)]
        public string PARETO_SALDO_CAPITAL { get; set; }

        [MaxLength(255)]
        public string TIPO_ASIGNACION { get; set; }

        [MaxLength(255)]
        public string SCORE { get; set; }

        [MaxLength(255)]
        public string ACUERDO_VIGENTE { get; set; }

        [MaxLength(255)]
        public string CALIFICACION_ACUERDO { get; set; }

        public double? SALDO_CAPITAL { get; set; }

        [Column("TOTAL_CAP_+_GAC")]
        public double? TOTAL_CAP__GAC { get; set; }

        [MaxLength(255)]
        public string TELEFONO { get; set; }

        [MaxLength(255)]
        public string EXTENSION { get; set; }

        [MaxLength(255)]
        public string INDICATIVO { get; set; }

        [MaxLength(255)]
        public string TIPO_TELEFONO { get; set; }

        [MaxLength(255)]
        public string CIUDAD { get; set; }

        [MaxLength(255)]
        public string DEPARTAMENTO { get; set; }

        [MaxLength(255)]
        public string ESTADO { get; set; }

        [MaxLength(255)]
        public string CORREO { get; set; }

        [MaxLength(255)]
        public string ASIGNADO { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_promotora { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }
    }
}