using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("departamento")]
    public partial class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Departamento { get; set; }

        [MaxLength(2)]
        public string Codigo_Departamento { get; set; }

        [MaxLength(100)]
        public string Nombre_Departamento { get; set; }

        public ICollection<DatoPersona> DatoPersona { get; set; }

        public ICollection<Municipio> Municipio { get; set; }
    }
}