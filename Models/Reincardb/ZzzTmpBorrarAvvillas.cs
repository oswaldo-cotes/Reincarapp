using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("zzz_tmp_borrar_avvillas")]
    public partial class ZzzTmpBorrarAvvillas
    {
        [MaxLength(45)]
        public string cedula { get; set; }
    }
}