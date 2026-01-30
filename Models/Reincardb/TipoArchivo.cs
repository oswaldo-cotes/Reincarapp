using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tipo_archivo")]
    public partial class TipoArchivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_tipo_archivo { get; set; }

        [MaxLength(80)]
        public string nombre_tipo_archivo { get; set; }

        public ICollection<EventoArchivo> EventoArchivo { get; set; }
    }
}