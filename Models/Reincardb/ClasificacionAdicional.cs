using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("clasificacion_adicional")]
    public partial class ClasificacionAdicional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Clasificacion_Adicional { get; set; }

        [MaxLength(100)]
        public string Nombre_Clasificacion_Adicional { get; set; }

        public long? Id_Cliente { get; set; }

        public Cliente Cliente { get; set; }

        [MaxLength(45)]
        public string Tipo { get; set; }

        [MaxLength(45)]
        public string Identificador_Cliente { get; set; }

        public int? Id_Tipo_Clasificacion_Adicional { get; set; }

        public TipoClasificacionAdicional TipoClasificacionAdicional { get; set; }

        [MaxLength(45)]
        public string dato_adicional_1 { get; set; }

        [MaxLength(45)]
        public string dato_adicional_2 { get; set; }

        [MaxLength(45)]
        public string dato_adicional_3 { get; set; }

        public ICollection<Evento> Evento { get; set; }

        public ICollection<Evento> Evento1 { get; set; }

        public ICollection<Evento> Evento2 { get; set; }

        public ICollection<Evento> Evento3 { get; set; }

        public ICollection<Evento> Evento4 { get; set; }

        public ICollection<Evento> Evento5 { get; set; }

        public ICollection<Evento> Evento6 { get; set; }

        public ICollection<EventoDet> EventoDet { get; set; }

        public ICollection<HonorarioAvvillas> HonorarioAvvillas { get; set; }
    }
}