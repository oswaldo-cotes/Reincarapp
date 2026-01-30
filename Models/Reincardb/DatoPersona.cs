using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("dato_persona")]
    public partial class DatoPersona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Dato_Persona { get; set; }

        public long? Id_Tipo_Dato_Persona { get; set; }

        public TipoDatoPersona TipoDatoPersona { get; set; }

        public long? Id_Persona { get; set; }

        public Persona Persona { get; set; }

        public long? Id_Departamento { get; set; }

        public Departamento Departamento { get; set; }

        public long? Id_Municipio { get; set; }

        public Municipio Municipio { get; set; }

        [MaxLength(250)]
        public string Dato { get; set; }

        public bool? Dato_Activo { get; set; }

        public int? Id_Zona_Ubicacion { get; set; }

        public ZonaUbicacion ZonaUbicacion { get; set; }

        public int? Id_Tipo_Via { get; set; }

        public TipoVia TipoVia { get; set; }

        public int? Id_Zona_Ubicacion_1 { get; set; }

        public ZonaUbicacion ZonaUbicacion1 { get; set; }

        [MaxLength(45)]
        public string Zona_Ubic { get; set; }

        [MaxLength(45)]
        public string Zona_Ubic_1 { get; set; }

        public int? Id_Zona_Ubicacion_2 { get; set; }

        public ZonaUbicacion ZonaUbicacion2 { get; set; }

        [MaxLength(45)]
        public string Zona_Ubic_2 { get; set; }

        public int? Id_Zona_Ubicacion_3 { get; set; }

        public ZonaUbicacion ZonaUbicacion3 { get; set; }

        [MaxLength(45)]
        public string Zona_Ubic_3 { get; set; }

        [MaxLength(45)]
        public string Tipo_Via_Num_1 { get; set; }

        [MaxLength(45)]
        public string Tipo_Via_Num_2 { get; set; }

        public long? Id_Evento { get; set; }

        public long? id_usuario { get; set; }

        public long? id_tarea { get; set; }

        public ICollection<Evento> Evento { get; set; }

        public ICollection<LogDatoPersona> LogDatoPersona { get; set; }
    }
}