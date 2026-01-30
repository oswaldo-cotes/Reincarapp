using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("sms")]
    public partial class Sms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Sms { get; set; }

        [Required]
        public DateTime Fecha_Creacion { get; set; }

        [Required]
        [MaxLength(25)]
        public string Telefono { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Mensaje { get; set; }

        [Required]
        public DateTime Fecha_Envio { get; set; }

        [Required]
        [MaxLength(255)]
        public string Respuesta { get; set; }

        public long? Id_Evento { get; set; }

        public Evento Evento { get; set; }
    }
}