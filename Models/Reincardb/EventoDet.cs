using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("evento_det")]
    public partial class EventoDet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_evento_det { get; set; }

        public long? id_evento { get; set; }

        public Evento Evento { get; set; }

        public string texto { get; set; }

        public long? Id_Contactado_Por { get; set; }

        public ClasificacionAdicional ClasificacionAdicional { get; set; }

        public bool? AutorizaContacto { get; set; }

        public long? Id_Canal_Alterno { get; set; }
    }
}