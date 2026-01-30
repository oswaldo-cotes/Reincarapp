using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tipo_tarea")]
    public partial class TipoTarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_tipo_tarea { get; set; }

        [MaxLength(45)]
        public string nombre { get; set; }

        public ICollection<Tarea> Tarea { get; set; }
    }
}