using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("transitoflo")]
    public partial class Transitoflo
    {
        public string COMPARENDO { get; set; }

        [MaxLength(255)]
        public string CLASE { get; set; }

        [MaxLength(255)]
        public string FECHA_DE_COMPARENDO { get; set; }

        [MaxLength(255)]
        public string HORA_DE_ELAB { get; set; }

        [MaxLength(255)]
        public string DIRECCION_DE_INFRACCION { get; set; }

        [MaxLength(255)]
        public string TIPO_DE_DOCUMENTO { get; set; }

        public string DOCUMENTO { get; set; }

        [MaxLength(255)]
        public string PRIMER_APELLIDO { get; set; }

        [MaxLength(255)]
        public string SEGUNDO_APELLIDO { get; set; }

        [MaxLength(255)]
        public string NOMBRES { get; set; }

        [MaxLength(255)]
        public string APELLIDOS { get; set; }

        [MaxLength(255)]
        public string DIRECCION { get; set; }

        [MaxLength(50)]
        public string TELEFONO { get; set; }

        [MaxLength(255)]
        public string FAX { get; set; }

        [MaxLength(255)]
        public string CODIG_INFRACCION { get; set; }

        [MaxLength(255)]
        public string ESTADO { get; set; }

        [MaxLength(255)]
        public string TIPO_DE_SERVICIO { get; set; }

        [MaxLength(255)]
        public string TIPO_DE_AGENTE { get; set; }

        [MaxLength(255)]
        public string VALOR_COMPARENDO { get; set; }

        [MaxLength(255)]
        public string CIUDAD { get; set; }

        [MaxLength(255)]
        public string ALERTA_CADUCIDAD_Y_PRESCRIPCION { get; set; }

        [MaxLength(255)]
        public string VALOR_ADICIONAL { get; set; }

        [MaxLength(255)]
        public string VALOR_TOTAL { get; set; }

        [MaxLength(255)]
        public string PLACA_DEL_VEHICULO { get; set; }

        [MaxLength(255)]
        public string PLACA_AGENTE { get; set; }

        [MaxLength(255)]
        public string FECHA_DE_RESOLUCION { get; set; }

        [MaxLength(255)]
        public string INSPECCION { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_transito_flo { get; set; }

        public DateTime? fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }
    }
}