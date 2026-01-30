using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tbl_delete")]
    public partial class TblDelete
    {
        [Key]
        [Required]
        public long id_saludcoop { get; set; }

        public long? id_cliente_deuda { get; set; }
    }
}