using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("temp_idcoomulstrasan")]
    public partial class TempIdcoomulstrasan
    {
        public long? id_coomultrasan_juridica { get; set; }
    }
}