using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("municipio")]
    public partial class Municipio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Municipio { get; set; }

        public long? Id_Departamento { get; set; }

        public Departamento Departamento { get; set; }

        [MaxLength(5)]
        public string Codigo_Municipio { get; set; }

        [MaxLength(100)]
        public string Nombre_Municipio { get; set; }

        public ICollection<DatoPersona> DatoPersona { get; set; }

        public ICollection<Rediferido> Rediferido { get; set; }
    }
}