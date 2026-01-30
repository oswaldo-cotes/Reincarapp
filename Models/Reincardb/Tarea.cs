using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tarea")]
    public partial class Tarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Tarea { get; set; }

        public long? Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        [Required]
        public long Id_Usuario_Tarea { get; set; }

        public Usuario Usuario1 { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Texto_Tarea { get; set; }

        public long? Id_Tipo_Comunicacion { get; set; }

        public TipoComunicacion TipoComunicacion { get; set; }

        [Required]
        public DateTime Fecha_Realizacion_Tarea { get; set; }

        public DateTime Fecha_Creacion_Tarea { get; set; }

        [Required]
        public long Id_Usuario { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime? Fecha_Ejecucion_Tarea { get; set; }

        public long? Id_Evento { get; set; }

        public Evento Evento1 { get; set; }

        public decimal? monto { get; set; }

        public long? id_tipo_tarea { get; set; }

        public TipoTarea TipoTarea { get; set; }

        [MaxLength(95)]
        public string CreatedBy { get; set; }

        public Aspnetusers Aspnetusers { get; set; }

        [MaxLength(95)]
        public string UpdatedBy { get; set; }

        public Aspnetusers Aspnetusers2 { get; set; }

        [MaxLength(95)]
        public string ProcessedBy { get; set; }

        public Aspnetusers Aspnetusers1 { get; set; }

        public ICollection<Evento> Evento { get; set; }

        public ICollection<LogDatoPersona> LogDatoPersona { get; set; }
    }
}