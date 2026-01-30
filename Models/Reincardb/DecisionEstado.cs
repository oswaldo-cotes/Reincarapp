using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("decision_estado")]
    public partial class DecisionEstado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Decision_Estado { get; set; }

        public long? Id_Estado_Cliente_Deuda { get; set; }

        public EstadoClienteDeuda EstadoClienteDeuda { get; set; }

        public long? Id_Resultado_Evento { get; set; }

        public ResultadoEvento ResultadoEvento { get; set; }

        public long? Id_Tipo_Comunicacion { get; set; }

        public TipoComunicacion TipoComunicacion { get; set; }

        public DateTime? Fecha_Inicial { get; set; }

        public DateTime? Fecha_Final { get; set; }

        public long? Id_Usuario_Creador { get; set; }

        public Usuario Usuario { get; set; }

        public long? Id_Cliente { get; set; }

        public Cliente Cliente { get; set; }
    }
}