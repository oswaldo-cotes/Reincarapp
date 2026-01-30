using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cli_deu_proc_2")]
    public partial class CliDeuProc2
    {
        [Key]
        [Required]
        public long id_cli_deu_proc { get; set; }
    }
}