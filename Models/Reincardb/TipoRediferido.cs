using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tipo_rediferido")]
    public partial class TipoRediferido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_tipo_rediferido { get; set; }

        [MaxLength(150)]
        public string nombre { get; set; }

        public ICollection<Rediferido> Rediferido { get; set; }
    }
}