using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("campo_honorario")]
    public partial class CampoHonorario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_campo_honorario { get; set; }

        [MaxLength(45)]
        public string nombre { get; set; }

        [MaxLength(500)]
        public string descripcion { get; set; }

        public long? id_cliente { get; set; }

        public Cliente Cliente { get; set; }

        public ICollection<HonorarioAvvillas> HonorarioAvvillas { get; set; }
    }
}