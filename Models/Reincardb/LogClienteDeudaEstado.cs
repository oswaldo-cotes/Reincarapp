using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("log_cliente_deuda_estado")]
    public partial class LogClienteDeudaEstado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_log_cliente_deuda_estado { get; set; }

        [Required]
        public long id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        [Required]
        public long id_estado_cliente_deuda_ant { get; set; }

        public EstadoClienteDeuda EstadoClienteDeuda1 { get; set; }

        [Required]
        public long id_estado_cliente_deuda_act { get; set; }

        public EstadoClienteDeuda EstadoClienteDeuda { get; set; }

        public DateTime fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }

        [MaxLength(50)]
        public string usuario_base_de_datos { get; set; }

        public long? Id_Usuario_Modificador { get; set; }
    }
}