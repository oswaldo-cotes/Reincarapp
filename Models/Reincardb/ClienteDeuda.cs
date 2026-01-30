using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cliente_deuda")]
    public partial class ClienteDeuda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Cliente_Deuda { get; set; }

        [MaxLength(250)]
        public string Nombre_Cliente_Deuda { get; set; }

        public long? Id_Estado_Cliente_Deuda { get; set; }

        public EstadoClienteDeuda EstadoClienteDeuda { get; set; }

        [Required]
        public long Id_Cliente { get; set; }

        public Cliente Cliente { get; set; }

        [Required]
        public long Id_Persona { get; set; }

        public Persona Persona { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public DateTime? Fecha_Inicio_Deuda { get; set; }

        public DateTime? Fecha_Cierre_Deuda { get; set; }

        public DateTime? Fecha_Creacion { get; set; }

        [Required]
        public long Id_Usuario { get; set; }

        public Usuario Usuario { get; set; }

        public long? Id_Usuario_Asignado { get; set; }

        public Usuario Usuario1 { get; set; }

        [MaxLength(30)]
        public string Id_Negocio { get; set; }

        [MaxLength(30)]
        public string Id_Asignacion { get; set; }

        public Asignacion Asignacion { get; set; }

        [MaxLength(45)]
        public string Numero_Documento { get; set; }

        public long? Id_Sub_Cliente { get; set; }

        public long? Id_Ultima_Gestion { get; set; }

        public ResultadoEvento ResultadoEvento1 { get; set; }

        public long? Id_Mejor_Gestion { get; set; }

        public ResultadoEvento ResultadoEvento { get; set; }

        [MaxLength(45)]
        public string campana_reparto { get; set; }

        public ICollection<Acueducto> Acueducto { get; set; }

        public ICollection<Avvillas> Avvillas { get; set; }

        public ICollection<Avvillasbuc> Avvillasbuc { get; set; }

        public ICollection<Bancobogota> Bancobogota { get; set; }

        public ICollection<Bancoomeva> Bancoomeva { get; set; }

        public ICollection<BaseJuridica> BaseJuridica { get; set; }

        public ICollection<Bloqueocontacto> Bloqueocontacto { get; set; }

        public ICollection<Censprejuridico> Censprejuridico { get; set; }

        public ICollection<Checprejuridico> Checprejuridico { get; set; }

        public ICollection<Citibank> Citibank { get; set; }

        public ICollection<Citibank2> Citibank2 { get; set; }

        public ICollection<ClienteDeudaCons> ClienteDeudaCons { get; set; }

        public ICollection<ClienteDeudaDato> ClienteDeudaDato { get; set; }

        public ICollection<ClienteDeudaHonorario> ClienteDeudaHonorario { get; set; }

        public ICollection<ClienteDeudaUsuario> ClienteDeudaUsuario { get; set; }

        public ICollection<CoomultrasanCastigo> CoomultrasanCastigo { get; set; }

        public ICollection<CoomultrasanJuridica> CoomultrasanJuridica { get; set; }

        public ICollection<CoomultrasanLey79> CoomultrasanLey79 { get; set; }

        public ICollection<CoomultrasanTemprana> CoomultrasanTemprana { get; set; }

        public ICollection<Coopetrol> Coopetrol { get; set; }

        public ICollection<Credidos> Credidos { get; set; }

        public ICollection<Credivalores> Credivalores { get; set; }

        public ICollection<Credivalores2> Credivalores2 { get; set; }

        public ICollection<Credivaloresalt> Credivaloresalt { get; set; }

        public ICollection<DatoClienteDeuda> DatoClienteDeuda { get; set; }

        public ICollection<Evento> Evento { get; set; }

        public ICollection<Jamar> Jamar { get; set; }

        public ICollection<LogClienteDeudaEstado> LogClienteDeudaEstado { get; set; }

        public ICollection<Maf> Maf { get; set; }

        public ICollection<Menco> Menco { get; set; }

        public ICollection<Promotora> Promotora { get; set; }

        public ICollection<Rediferido> Rediferido { get; set; }

        public ICollection<Saludcoop> Saludcoop { get; set; }

        public ICollection<Tarea> Tarea { get; set; }

        public ICollection<Transito> Transito { get; set; }

        public ICollection<Transitobuc> Transitobuc { get; set; }

        public ICollection<Transitoflo> Transitoflo { get; set; }
    }
}