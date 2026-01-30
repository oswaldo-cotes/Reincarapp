using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("temp_eve_to_delete")]
    public partial class TempEveToDelete
    {
        [Required]
        public long id_evento { get; set; }
    }
}