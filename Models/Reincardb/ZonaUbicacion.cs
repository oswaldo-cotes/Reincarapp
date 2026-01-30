using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("zona_ubicacion")]
    public partial class ZonaUbicacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Zona_Ubicacion { get; set; }

        [MaxLength(255)]
        public string Nombre { get; set; }

        [MaxLength(30)]
        public string Traduccion { get; set; }

        public ICollection<DatoPersona> DatoPersona { get; set; }

        public ICollection<DatoPersona> DatoPersona1 { get; set; }

        public ICollection<DatoPersona> DatoPersona2 { get; set; }

        public ICollection<DatoPersona> DatoPersona3 { get; set; }
    }
}