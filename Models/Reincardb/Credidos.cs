using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("credidos")]
    public partial class Credidos
    {
        public string IDENTIFICACION { get; set; }

        [MaxLength(255)]
        public string NOMBRE_PLASTICO { get; set; }

        [MaxLength(255)]
        public string CODIGO_NIE { get; set; }

        public double? SALDO_CAPITAL { get; set; }

        public double? PAGO_MINIMO { get; set; }

        public double? DIAS_MORA_SC { get; set; }

        [MaxLength(255)]
        public string FRANJA_SC { get; set; }

        [MaxLength(255)]
        public string PLANO_ESP_AGRUPADO { get; set; }

        [MaxLength(255)]
        public string NOMBRE_CICLO_FACTURACION_CORE { get; set; }

        [MaxLength(255)]
        public string ASIGNACION { get; set; }

        [MaxLength(255)]
        public string CONSOLIDADO_CIFRAS { get; set; }

        [MaxLength(255)]
        public string SEGMENTO_PORTAFOLIO { get; set; }

        [MaxLength(255)]
        public string SEGMENTO_CARTERA { get; set; }

        [MaxLength(255)]
        public string SEGMENTO_CONSUL { get; set; }

        [MaxLength(255)]
        public string SEGMENTO_RIESGO { get; set; }

        [MaxLength(255)]
        public string TIPIFICACION { get; set; }

        [MaxLength(255)]
        public string GESTION { get; set; }

        [MaxLength(255)]
        public string RAZON_MORA { get; set; }

        [MaxLength(255)]
        public string CEL_1 { get; set; }

        [MaxLength(255)]
        public string CEL_2 { get; set; }

        [MaxLength(255)]
        public string CEL_3 { get; set; }

        [MaxLength(255)]
        public string CEL_4 { get; set; }

        [MaxLength(255)]
        public string DIR_1 { get; set; }

        [MaxLength(255)]
        public string CIUDAD_1 { get; set; }

        [MaxLength(255)]
        public string DIR_2 { get; set; }

        [MaxLength(255)]
        public string CIUDAD_2 { get; set; }

        [MaxLength(255)]
        public string DIR_3 { get; set; }

        [MaxLength(255)]
        public string CIUDAD_3 { get; set; }

        [MaxLength(255)]
        public string DIR_4 { get; set; }

        [MaxLength(255)]
        public string CIUDAD_4 { get; set; }

        [MaxLength(255)]
        public string TEL_1 { get; set; }

        [MaxLength(255)]
        public string CIUDADT_1 { get; set; }

        [MaxLength(255)]
        public string TEL_2 { get; set; }

        [MaxLength(255)]
        public string CIUDADT_2 { get; set; }

        [MaxLength(255)]
        public string TEL_3 { get; set; }

        [MaxLength(255)]
        public string CIUDADT_3 { get; set; }

        [MaxLength(255)]
        public string TEL_4 { get; set; }

        [MaxLength(255)]
        public string CIUDADT_4 { get; set; }

        [MaxLength(255)]
        public string COR_1 { get; set; }

        [MaxLength(255)]
        public string COR_2 { get; set; }

        [MaxLength(255)]
        public string COR_3 { get; set; }

        [MaxLength(255)]
        public string COR_4 { get; set; }

        [MaxLength(255)]
        public string NOMBRE_REFERENCIA_1 { get; set; }

        [MaxLength(255)]
        public string TELEFONO_1 { get; set; }

        [MaxLength(255)]
        public string DIRECCION_1 { get; set; }

        [MaxLength(255)]
        public string CIUDADR_1 { get; set; }

        [MaxLength(255)]
        public string CELR_1 { get; set; }

        [MaxLength(255)]
        public string PARENTESCO_1 { get; set; }

        [MaxLength(255)]
        public string NOMBRE_REFERENCIA_2 { get; set; }

        [MaxLength(255)]
        public string TELEFONO_2 { get; set; }

        [MaxLength(255)]
        public string DIRECCION_2 { get; set; }

        [MaxLength(255)]
        public string CIUDADR_2 { get; set; }

        [MaxLength(255)]
        public string CELR_2 { get; set; }

        [MaxLength(255)]
        public string PARENTESCO_2 { get; set; }

        [MaxLength(255)]
        public string NOMBRE_REFERENCIA3 { get; set; }

        [MaxLength(255)]
        public string TELEFONO_3 { get; set; }

        [MaxLength(255)]
        public string DIRECCION_3 { get; set; }

        [MaxLength(255)]
        public string CIUDADR_3 { get; set; }

        [MaxLength(255)]
        public string CELR_3 { get; set; }

        [MaxLength(255)]
        public string PARENTESCO_3 { get; set; }

        [MaxLength(255)]
        public string NOMBRE_REFERENCIA4 { get; set; }

        [MaxLength(255)]
        public string TELEFONO_4 { get; set; }

        [MaxLength(255)]
        public string DIRECCION_4 { get; set; }

        [MaxLength(255)]
        public string CIUDADR_4 { get; set; }

        [MaxLength(255)]
        public string CELR_4 { get; set; }

        [MaxLength(255)]
        public string PARENTESCO_4 { get; set; }

        public long? Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Credidos { get; set; }

        public DateTime? Fecha_Inicial { get; set; }

        public DateTime? Fecha_Final { get; set; }

        [MaxLength(100)]
        public string PRODUCTO { get; set; }
    }
}