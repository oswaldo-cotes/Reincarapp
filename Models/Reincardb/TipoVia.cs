using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tipo_via")]
    public partial class TipoVia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Tipo_Via { get; set; }

        [MaxLength(255)]
        public string Nombre { get; set; }

        [MaxLength(30)]
        public string Tipo_Via { get; set; }

        public ICollection<DatoPersona> DatoPersona { get; set; }
    }
}