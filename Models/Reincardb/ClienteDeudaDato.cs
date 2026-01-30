using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cliente_deuda_dato")]
    public partial class ClienteDeudaDato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        [Required]
        public DateTime Fecha_Inicial { get; set; }

        public DateTime? Fecha_Final { get; set; }

        public string Dato { get; set; }

        [MaxLength(100)]
        public string Identificacion { get; set; }

        public float? Valor { get; set; }

        public string DatoAdic { get; set; }

        public long? Id_Cliente { get; set; }

        public Cliente Cliente { get; set; }
    }
}