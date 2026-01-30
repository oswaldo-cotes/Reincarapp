using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tmp_cliente_deuda_estado")]
    public partial class TmpClienteDeudaEstado
    {
        [Required]
        public long id_cliente_deuda { get; set; }

        public long? id_estado_cliente_deuda { get; set; }
    }
}