using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tipo_dato_persona")]
    public partial class TipoDatoPersona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Tipo_Dato_Persona { get; set; }

        [MaxLength(100)]
        public string Nombre_Tipo_Dato_Persona { get; set; }

        public long? Id_Cliente { get; set; }

        public Cliente Cliente { get; set; }

        public int? Orden { get; set; }

        public ICollection<DatoPersona> DatoPersona { get; set; }

        public ICollection<LogDatoPersona> LogDatoPersona { get; set; }

        public ICollection<LogDatoPersona> LogDatoPersona1 { get; set; }
    }
}