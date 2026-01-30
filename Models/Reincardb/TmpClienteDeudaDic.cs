using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tmp_cliente_deuda_dic")]
    public partial class TmpClienteDeudaDic
    {
        public long? id_cliente_deuda { get; set; }

        [Required]
        public long cuantos { get; set; }

        [MaxLength(255)]
        public string nropro { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
    }
}