using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("acueducto")]
    public partial class Acueducto
    {
        [MaxLength(30)]
        public string CODIGO { get; set; }

        [MaxLength(510)]
        public string CICLO { get; set; }

        [MaxLength(510)]
        public string NOMBRE { get; set; }

        public double? VALOR_ADEUDADO { get; set; }

        public double? MESES_DE_ATRASO { get; set; }

        [MaxLength(510)]
        public string DIRECCION { get; set; }

        [MaxLength(510)]
        public string BARRIO { get; set; }

        [MaxLength(510)]
        public string MUNICIPIO { get; set; }

        [MaxLength(510)]
        public string GESTION_REALIZADA { get; set; }

        public DateTime? F_VISITA { get; set; }

        public DateTime? CAMPANA { get; set; }

        [MaxLength(510)]
        public string GESTION_REALIZADA1 { get; set; }

        [MaxLength(510)]
        public string MES_PAGO { get; set; }

        public DateTime? FECHA_ACUERDO_PAGO { get; set; }

        [MaxLength(30)]
        public string Telefono_1 { get; set; }

        [MaxLength(30)]
        public string Telefono_2 { get; set; }

        [MaxLength(30)]
        public string Telefono_3 { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Acueducto { get; set; }

        public long? Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }
    }
}