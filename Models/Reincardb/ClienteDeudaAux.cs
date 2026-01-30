using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cliente_deuda_aux")]
    public partial class ClienteDeudaAux
    {
        [Key]
        [Required]
        public long Id_Cliente_Deuda { get; set; }

        [MaxLength(250)]
        public string Nombre_Cliente_Deuda { get; set; }

        public long? Id_Estado_Cliente_Deuda { get; set; }

        [Required]
        public long Id_Cliente { get; set; }

        [Required]
        public long Id_Persona { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public DateTime? Fecha_Inicio_Deuda { get; set; }

        public DateTime? Fecha_Cierre_Deuda { get; set; }

        public DateTime? Fecha_Creacion { get; set; }

        [Required]
        public long Id_Usuario { get; set; }

        public long? Id_Usuario_Asignado { get; set; }

        [MaxLength(30)]
        public string Id_Negocio { get; set; }
    }
}