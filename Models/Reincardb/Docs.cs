using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("docs")]
    public partial class Docs
    {
        [MaxLength(255)]
        public string documento { get; set; }
    }
}