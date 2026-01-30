using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("res_eve")]
    public partial class ResEve
    {
        [MaxLength(255)]
        public string Nombre_Resultado_Evento { get; set; }

        public double? Inactiva_Tipo_Comunicacion { get; set; }

        public double? Crea_Tarea_Automatica { get; set; }

        public double? Valor_Exito { get; set; }

        [MaxLength(255)]
        public string Cliente { get; set; }

        [MaxLength(255)]
        public string Negocio_Cliente { get; set; }

        public double? Conexion_Informe_Diario { get; set; }

        public double? Contacto_Informe_Diario { get; set; }

        public double? Contacto_Directo_Informe_Diario { get; set; }

        public double? Promesa_Levantada { get; set; }

        public double? Promesa_Efectiva { get; set; }

        public double? Codificacion_Tipificacion { get; set; }
    }
}