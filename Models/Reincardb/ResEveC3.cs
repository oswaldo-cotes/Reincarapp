using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("res_eve_c3")]
    public partial class ResEveC3
    {
        [Required]
        public long Id_Resultado_Evento { get; set; }

        [MaxLength(250)]
        public string Nombre_Resultado_Evento { get; set; }

        public bool? Inactiva_Tipo_Comunicacion { get; set; }

        public bool? Crea_Tarea_Automatica { get; set; }

        public int? Valor_Exito { get; set; }

        public long? id_cliente { get; set; }

        [MaxLength(30)]
        public string Id_Negocio_Cliente { get; set; }

        public bool? Conexion_Informe_Diario { get; set; }

        public bool? Contacto_Informe_Diario { get; set; }

        public bool? Contacto_Directo_Informe_Diario { get; set; }

        public bool? Promesa_Levantada { get; set; }

        public bool? Promesa_Efectiva { get; set; }

        public int? Codificacion_Tipificacion { get; set; }

        public bool? Envio_Actualizador { get; set; }

        public bool? es_compromiso { get; set; }

        public bool? es_recaudo { get; set; }
    }
}