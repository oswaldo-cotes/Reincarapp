using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("transito")]
    public partial class Transito
    {
        [MaxLength(255)]
        public string APELLIDOS { get; set; }

        [MaxLength(50)]
        public string CC { get; set; }

        [MaxLength(50)]
        public string GESTOR { get; set; }

        public DateTime? FECHA_MODIFICACION { get; set; }

        [MaxLength(255)]
        public string DIRECCION { get; set; }

        [MaxLength(56)]
        public string CIUDAD { get; set; }

        [MaxLength(69)]
        public string CLIENTE { get; set; }

        public DateTime? FECHA_ALTA { get; set; }

        [MaxLength(50)]
        public string CUENTA { get; set; }

        [MaxLength(150)]
        public string CONTACTO_CODEUDOR { get; set; }

        [MaxLength(55)]
        public string ESTADO_DEUDOR { get; set; }

        [MaxLength(150)]
        public string RONDA { get; set; }

        [MaxLength(150)]
        public string COMPARENDO { get; set; }

        [MaxLength(150)]
        public string ORGANISMO { get; set; }

        [MaxLength(20)]
        public string VALOR_A_COBRAR { get; set; }

        [Column("TIPO DOC")]
        [MaxLength(150)]
        public string TIPODOC { get; set; }

        [MaxLength(150)]
        public string FIJO { get; set; }

        [MaxLength(150)]
        public string CELULAR { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID_TRANSITO { get; set; }

        public long? ID_CLIENTE_DEUDA { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }
    }
}