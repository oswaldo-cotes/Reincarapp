using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("aspnetusers")]
    public partial class Aspnetusers
    {
        [Key]
        [Required]
        [MaxLength(95)]
        public string Id { get; set; }

        [Required]
        public int AccessFailedCount { get; set; }

        public string ConcurrencyStamp { get; set; }

        [MaxLength(256)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool LockoutEnabled { get; set; }

        [MaxLength(6)]
        public DateTime? LockoutEnd { get; set; }

        [MaxLength(256)]
        public string NormalizedEmail { get; set; }

        [MaxLength(256)]
        public string NormalizedUserName { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string SecurityStamp { get; set; }

        public bool TwoFactorEnabled { get; set; }

        [MaxLength(256)]
        public string UserName { get; set; }

        public ICollection<Evento> Evento { get; set; }

        public ICollection<Evento> Evento1 { get; set; }

        public ICollection<Logapp> Logapp { get; set; }

        public ICollection<Tarea> Tarea { get; set; }

        public ICollection<Tarea> Tarea1 { get; set; }

        public ICollection<Tarea> Tarea2 { get; set; }

        public ICollection<UsuarioCliente> UsuarioCliente { get; set; }
    }
}