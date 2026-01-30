using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tipo_documento")]
    public partial class TipoDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Tipo_Documento { get; set; }

        [MaxLength(10)]
        public string Tipo_Documento { get; set; }

        public ICollection<Persona> Persona { get; set; }
    }
}