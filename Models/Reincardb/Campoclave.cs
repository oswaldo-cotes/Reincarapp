using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("campoclave")]
    public partial class Campoclave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(250)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string NombreInterno { get; set; }

        public ICollection<Basecampo> Basecampo { get; set; }
    }
}