using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("bloqueocontacto")]
    public partial class Bloqueocontacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdBloqueoContacto { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public long IdEvento { get; set; }

        public Evento Evento { get; set; }

        [Required]
        public long IdClienteDeuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        [Required]
        public long IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}