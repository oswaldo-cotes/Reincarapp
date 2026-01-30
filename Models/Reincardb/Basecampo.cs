using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("basecampo")]
    public partial class Basecampo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        public long? CampoClaveId { get; set; }

        public Campoclave Campoclave { get; set; }

        public long? BaseId { get; set; }

        public Base Base { get; set; }
    }
}