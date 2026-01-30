using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("franja")]
    public partial class Franja
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_franja { get; set; }

        [MaxLength(45)]
        public string nombre { get; set; }

        public ICollection<Rediferido> Rediferido { get; set; }
    }
}