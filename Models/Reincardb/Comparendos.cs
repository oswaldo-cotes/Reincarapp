using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("comparendos")]
    public partial class Comparendos
    {
        public double? Cedula { get; set; }

        public double? TELEFONO1 { get; set; }

        public double? TELEFONO2 { get; set; }

        public double? TELEFONO3 { get; set; }

        [MaxLength(255)]
        public string direccion1 { get; set; }

        public double? DIRECCION2 { get; set; }

        public double? DIRECCION3 { get; set; }

        [MaxLength(255)]
        public string CORREO { get; set; }

        [MaxLength(255)]
        public string correo2 { get; set; }
    }
}