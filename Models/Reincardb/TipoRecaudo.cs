using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tipo_recaudo")]
    public partial class TipoRecaudo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_tipo_recaudo { get; set; }

        [MaxLength(80)]
        public string nombre { get; set; }

        public ICollection<HonorarioAvvillas> HonorarioAvvillas { get; set; }
    }
}