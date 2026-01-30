using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("razontiempofuera")]
    public partial class Razontiempofuera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(150)]
        public string Nombre { get; set; }

        public ICollection<Tiempofuera> Tiempofuera { get; set; }
    }
}