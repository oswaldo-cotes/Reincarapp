using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("temp_idcoomulstrasan2")]
    public partial class TempIdcoomulstrasan2
    {
        public long? id_coomultrasan_juridica { get; set; }
    }
}