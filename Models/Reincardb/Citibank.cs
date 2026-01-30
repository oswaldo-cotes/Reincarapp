using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("citibank")]
    public partial class Citibank
    {
        public double? CEDULA { get; set; }

        public double? SALDO_TOTAL { get; set; }

        public double? NRO_OBLIGACIONES { get; set; }

        [MaxLength(510)]
        public string NOMBRE { get; set; }

        [MaxLength(510)]
        public string DIRECCION_CORRESPONDENCIA { get; set; }

        [MaxLength(510)]
        public string CIUDAD_MUNICIPIO { get; set; }

        [MaxLength(510)]
        public string DEPARTAMENTO { get; set; }

        public double? TELEFONO_1 { get; set; }

        public double? TELEFONO_2 { get; set; }

        [MaxLength(510)]
        public string EMAIL { get; set; }

        public double? EDAD { get; set; }

        [MaxLength(510)]
        public string GENERO { get; set; }

        [MaxLength(510)]
        public string AUTORIZACION_CENTRALES_DE_RIESGO { get; set; }

        public DateTime? FECHA_ULTIMO_CONTACTO { get; set; }

        [MaxLength(510)]
        public string SUPERVIVENCIA { get; set; }

        public double? EXISTENCIA_DE_PAGARE { get; set; }

        [MaxLength(510)]
        public string CONDICION_DEL_PAGARE { get; set; }

        [MaxLength(510)]
        public string ESTADO_DEL_PAGARE { get; set; }

        [MaxLength(510)]
        public string JUDICIALIZADO { get; set; }

        [MaxLength(510)]
        public string MASTER_SERVICE { get; set; }

        [MaxLength(510)]
        public string NRO_CONTRATO_O_DE_OBLIGACION { get; set; }

        [MaxLength(510)]
        public string LOCALIZACION { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_CitiBank { get; set; }

        public long? Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }
    }
}