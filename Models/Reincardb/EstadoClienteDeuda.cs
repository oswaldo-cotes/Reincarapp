using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("estado_cliente_deuda")]
    public partial class EstadoClienteDeuda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Estado_Cliente_Deuda { get; set; }

        [MaxLength(100)]
        public string Nombre_Estado { get; set; }

        public int? Valor_Exito { get; set; }

        public ICollection<ClienteDeuda> ClienteDeuda { get; set; }

        public ICollection<DecisionEstado> DecisionEstado { get; set; }

        public ICollection<LogClienteDeudaEstado> LogClienteDeudaEstado { get; set; }

        public ICollection<LogClienteDeudaEstado> LogClienteDeudaEstado1 { get; set; }
    }
}