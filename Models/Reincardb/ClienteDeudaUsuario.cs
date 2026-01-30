using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cliente_deuda_usuario")]
    public partial class ClienteDeudaUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Cliente_Deuda_Usuario { get; set; }

        [Required]
        public long Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        [Required]
        public long Id_Usuario_Asignado { get; set; }

        public Usuario Usuario1 { get; set; }

        [Required]
        public decimal Porcentaje_Honorarios { get; set; }

        [Required]
        public DateTime Fecha_Inicio_Asignacion { get; set; }

        [Required]
        public long Id_Usuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}