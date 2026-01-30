using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tipo_clasificacion_adicional")]
    public partial class TipoClasificacionAdicional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Tipo_Clasificacion_Adicional { get; set; }

        [MaxLength(45)]
        public string Nombre { get; set; }

        public ICollection<ClasificacionAdicional> ClasificacionAdicional { get; set; }
    }
}