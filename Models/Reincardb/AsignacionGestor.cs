using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("asignacion_gestor")]
    public partial class AsignacionGestor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Asignacion_Gestor { get; set; }

        [Required]
        public long Id_Usuario_Asignado { get; set; }

        public Usuario Usuario1 { get; set; }

        [Required]
        public long Id_Persona { get; set; }

        public Persona Persona { get; set; }

        public DateTime Fecha_Inicio_Asignacion { get; set; }

        public DateTime? Fecha_Fin_Asignacion { get; set; }

        [Required]
        public long Id_Usuario { get; set; }

        public Usuario Usuario { get; set; }

        public decimal? Porcentaje_Honorarios { get; set; }
    }
}