using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tipo_cliente")]
    public partial class TipoCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_tipo_cliente { get; set; }

        [MaxLength(80)]
        public string nombre { get; set; }

        public ICollection<Cliente> Cliente { get; set; }
    }
}