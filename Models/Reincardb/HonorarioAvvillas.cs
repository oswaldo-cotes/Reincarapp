using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("honorario_avvillas")]
    public partial class HonorarioAvvillas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_honorario_avvillas { get; set; }

        [MaxLength(100)]
        public string campana_reparto { get; set; }

        public long? id_clasificacion_honorario { get; set; }

        public ClasificacionAdicional ClasificacionAdicional { get; set; }

        public double? porcentaje { get; set; }

        public long? id_usuario { get; set; }

        public Usuario Usuario { get; set; }

        public long? id_cliente { get; set; }

        public Cliente Cliente { get; set; }

        public long? id_tipo_recaudo { get; set; }

        public TipoRecaudo TipoRecaudo { get; set; }

        public long? id_campo_honorario { get; set; }

        public CampoHonorario CampoHonorario { get; set; }
    }
}