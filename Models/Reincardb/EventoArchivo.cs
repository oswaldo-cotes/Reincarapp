using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("evento_archivo")]
    public partial class EventoArchivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_evento_archivo { get; set; }

        public long? id_evento { get; set; }

        public Evento Evento { get; set; }

        public long? id_tipo_archivo { get; set; }

        public TipoArchivo TipoArchivo { get; set; }

        [MaxLength(500)]
        public string nomb_archivo_ext { get; set; }

        [MaxLength(2000)]
        public string nomb_archivo_int { get; set; }

        public byte[] archivo { get; set; }
    }
}