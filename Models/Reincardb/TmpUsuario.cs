using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tmp_usuario")]
    public partial class TmpUsuario
    {
        [MaxLength(255)]
        public string CEDULA { get; set; }

        [MaxLength(255)]
        public string dia { get; set; }

        [MaxLength(255)]
        public string MES { get; set; }

        [MaxLength(255)]
        public string AÑO { get; set; }

        [MaxLength(255)]
        public string INGRESO { get; set; }

        [MaxLength(255)]
        public string RETIRO { get; set; }

        [MaxLength(255)]
        public string ESTADO { get; set; }

        [MaxLength(255)]
        public string NOMBRE { get; set; }

        [MaxLength(255)]
        public string direccin { get; set; }

        [Column("fecah de nacimiento")]
        [MaxLength(255)]
        public string fecahdenacimiento { get; set; }

        [MaxLength(255)]
        public string celular { get; set; }

        [MaxLength(255)]
        public string cargo { get; set; }
    }
}