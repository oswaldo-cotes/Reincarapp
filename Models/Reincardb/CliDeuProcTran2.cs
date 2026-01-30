using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cli_deu_proc_tran2")]
    public partial class CliDeuProcTran2
    {
        [Key]
        [Required]
        public long id_cli_deu_proc { get; set; }
    }
}