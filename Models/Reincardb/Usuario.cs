using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("usuario")]
    public partial class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Usuario { get; set; }

        [MaxLength(150)]
        public string Nombre_Usuario { get; set; }

        [Column("Usuario")]
        [MaxLength(25)]
        public string Usuario1 { get; set; }

        [MaxLength(25)]
        public string Password { get; set; }

        [MaxLength(250)]
        public string Correo_Electronico { get; set; }

        [MaxLength(25)]
        public string Cedula { get; set; }

        public DateTime? Fecha_Ingreso { get; set; }

        public DateTime? Fecha_Retiro { get; set; }

        public bool? Estado { get; set; }

        public EstadoUsuario EstadoUsuario { get; set; }

        [MaxLength(255)]
        public string Direccion { get; set; }

        public DateTime? Fecha_Nacimiento { get; set; }

        [MaxLength(25)]
        public string Telefono { get; set; }

        [MaxLength(80)]
        public string Cargo { get; set; }

        public ICollection<AsignacionGestor> AsignacionGestor { get; set; }

        public ICollection<AsignacionGestor> AsignacionGestor1 { get; set; }

        public ICollection<Base> Base { get; set; }

        public ICollection<Base> Base1 { get; set; }

        public ICollection<Bloqueocontacto> Bloqueocontacto { get; set; }

        public ICollection<ClienteDeuda> ClienteDeuda { get; set; }

        public ICollection<ClienteDeuda> ClienteDeuda1 { get; set; }

        public ICollection<ClienteDeudaHonorario> ClienteDeudaHonorario { get; set; }

        public ICollection<ClienteDeudaUsuario> ClienteDeudaUsuario { get; set; }

        public ICollection<ClienteDeudaUsuario> ClienteDeudaUsuario1 { get; set; }

        public ICollection<DecisionEstado> DecisionEstado { get; set; }

        public ICollection<Evento> Evento { get; set; }

        public ICollection<Evento> Evento1 { get; set; }

        public ICollection<HonorarioAvvillas> HonorarioAvvillas { get; set; }

        public ICollection<LogDatoPersona> LogDatoPersona { get; set; }

        public ICollection<Rediferido> Rediferido { get; set; }

        public ICollection<SubrepartoUsuario> SubrepartoUsuario { get; set; }

        public ICollection<SubrepartoUsuario> SubrepartoUsuario1 { get; set; }

        public ICollection<SubrepartoUsuario> SubrepartoUsuario2 { get; set; }

        public ICollection<Tarea> Tarea { get; set; }

        public ICollection<Tarea> Tarea1 { get; set; }

        public ICollection<Tiempofuera> Tiempofuera { get; set; }

        public ICollection<UsuarioCliente> UsuarioCliente { get; set; }

        public ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}