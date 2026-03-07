using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cliente")]
    public partial class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Cliente { get; set; }

        [MaxLength(150)]
        public string Nombre_Cliente { get; set; }

        [Required]
        [MaxLength(45)]
        public string Activo { get; set; }

        public long? id_tipo_cliente { get; set; }

        public TipoCliente TipoCliente { get; set; }

        [MaxLength(255)]
        public string sp_ins { get; set; }

        [MaxLength(100)]
        public string tabla { get; set; }

        public ICollection<Base> Base { get; set; }

        public ICollection<CampoHonorario> CampoHonorario { get; set; }

        public ICollection<ClasificacionAdicional> ClasificacionAdicional { get; set; }

        public ICollection<ClienteDeuda> ClienteDeuda { get; set; }

        public ICollection<ClienteDeudaDato> ClienteDeudaDato { get; set; }

        public ICollection<DecisionEstado> DecisionEstado { get; set; }

        public ICollection<HonorarioAvvillas> HonorarioAvvillas { get; set; }

        public ICollection<ResultadoEvento> ResultadoEvento { get; set; }

        public ICollection<TipoComunicacion> TipoComunicacion { get; set; }

        public ICollection<TipoComunicacionResultadoEvento> TipoComunicacionResultadoEvento { get; set; }

        public ICollection<TipoDatoPersona> TipoDatoPersona { get; set; }

        public ICollection<UsuarioCliente> UsuarioCliente { get; set; }
    }
}