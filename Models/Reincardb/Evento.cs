using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("evento")]
    public partial class Evento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Evento { get; set; }

        [Required]
        public long Id_Tipo_Comunicacion { get; set; }

        public TipoComunicacion TipoComunicacion { get; set; }

        [Required]
        public long Id_Resultado_Evento { get; set; }

        public ResultadoEvento ResultadoEvento { get; set; }

        [Required]
        public long Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public long? Id_Dato_Persona { get; set; }

        public DatoPersona DatoPersona { get; set; }

        [Required]
        public long Id_Usuario_Evento { get; set; }

        public Usuario Usuario1 { get; set; }

        public DateTime? Fecha_Realizacion_Evento { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Texto_Evento { get; set; }

        public decimal? Monto { get; set; }

        public DateTime Fecha_Creacion_Evento { get; set; }

        public long? Id_Usuario { get; set; }

        public Usuario Usuario { get; set; }

        public long? Id_Tarea { get; set; }

        public Tarea Tarea { get; set; }

        public long? Id_Clasificacion_Adicional { get; set; }

        public ClasificacionAdicional ClasificacionAdicional { get; set; }

        [MaxLength(25)]
        public string Id_Negocio_Cliente { get; set; }

        public long? Id_Clasificacion_Adicional_1 { get; set; }

        public ClasificacionAdicional ClasificacionAdicional1 { get; set; }

        public long? Id_Clasificacion_Adicional_2 { get; set; }

        public ClasificacionAdicional ClasificacionAdicional2 { get; set; }

        public long? Id_Razon_Mora { get; set; }

        public ClasificacionAdicional ClasificacionAdicional5 { get; set; }

        public long? Id_Marca { get; set; }

        public ClasificacionAdicional ClasificacionAdicional3 { get; set; }

        public long? Id_Dato_Persona_Nuevo { get; set; }

        [MaxLength(9)]
        public string Telefono_Fijo { get; set; }

        [MaxLength(10)]
        public string Telefono_Celular { get; set; }

        public int? Id_Tipo_via { get; set; }

        public int? Id_Zona_Ubicacion_1 { get; set; }

        [MaxLength(45)]
        public string Zona_Ubic { get; set; }

        [MaxLength(45)]
        public string Zona_Ubic_1 { get; set; }

        public int? Id_Zona_Ubicacion_2 { get; set; }

        [MaxLength(45)]
        public string Zona_Ubic_2 { get; set; }

        public int? Id_Zona_Ubicacion_3 { get; set; }

        [MaxLength(45)]
        public string Zona_Ubic_3 { get; set; }

        [MaxLength(45)]
        public string Tipo_Via_Num_1 { get; set; }

        [MaxLength(45)]
        public string Tipo_Via_Num_2 { get; set; }

        [MaxLength(100)]
        public string Barrio { get; set; }

        public long? Id_Tipo_Vivienda { get; set; }

        public long? Id_Municipio { get; set; }

        public long? Id_Actividad_Laboral { get; set; }

        [MaxLength(10)]
        public string Telefono_Laboral { get; set; }

        [MaxLength(500)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Otro { get; set; }

        public long? Id_Tipo_Vivienda2 { get; set; }

        public long? Id_Medio_De_Pago { get; set; }

        public ClasificacionAdicional ClasificacionAdicional4 { get; set; }

        public long? Id_Razones_Posible_Extracto { get; set; }

        public ClasificacionAdicional ClasificacionAdicional6 { get; set; }

        public DateTime? Fecha_Creacion_Registro { get; set; }

        [MaxLength(45)]
        public string Tipo_Creacion_Registro { get; set; }

        public string Texto_Evento_Largo { get; set; }

        [MaxLength(95)]
        public string CreatedBy { get; set; }

        public Aspnetusers Aspnetusers { get; set; }

        [MaxLength(95)]
        public string UpdatedBy { get; set; }

        public Aspnetusers Aspnetusers1 { get; set; }

        public ICollection<Bloqueocontacto> Bloqueocontacto { get; set; }

        public ICollection<ClienteDeudaCons> ClienteDeudaCons { get; set; }

        public ICollection<ClienteDeudaCons> ClienteDeudaCons1 { get; set; }

        public ICollection<ClienteDeudaHonorario> ClienteDeudaHonorario { get; set; }

        public ICollection<Correspondencia> Correspondencia { get; set; }

        public ICollection<EventoArchivo> EventoArchivo { get; set; }

        public ICollection<EventoDet> EventoDet { get; set; }

        public ICollection<Sms> Sms { get; set; }

        public ICollection<Tarea> Tarea1 { get; set; }
    }
}