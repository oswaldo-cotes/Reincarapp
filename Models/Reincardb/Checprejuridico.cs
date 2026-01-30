using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("checprejuridico")]
    public partial class Checprejuridico
    {
        [MaxLength(255)]
        public string NumeroSuscripcion { get; set; }

        [MaxLength(255)]
        public string Direccion { get; set; }

        [MaxLength(255)]
        public string Telefono { get; set; }

        [MaxLength(255)]
        public string Celular { get; set; }

        [MaxLength(255)]
        public string CodigoDeProducto { get; set; }

        [MaxLength(255)]
        public string DescripcionBarrio { get; set; }

        [MaxLength(255)]
        public string DescripcionCategoria { get; set; }

        [MaxLength(255)]
        public string DescripcionCiudad { get; set; }

        [MaxLength(255)]
        public string DescripcionEstadoDeCorte { get; set; }

        [MaxLength(255)]
        public string DescripcionProducto { get; set; }

        [MaxLength(255)]
        public string DescripcionRegion { get; set; }

        [MaxLength(255)]
        public string UsuarioDuenoTarea { get; set; }

        public double? DiasDeMora { get; set; }

        [MaxLength(255)]
        public string FechaActualizacion { get; set; }

        [MaxLength(255)]
        public string FechaDeVencimientoSinRecargoMasAntigua { get; set; }

        [MaxLength(255)]
        public string FechaVencimientoSinRecargo { get; set; }

        [MaxLength(255)]
        public string Financiado { get; set; }

        [MaxLength(255)]
        public string IdentificacionDelCliente { get; set; }

        [MaxLength(255)]
        public string NombreCliente { get; set; }

        public double? NumeroServicioSuscrito { get; set; }

        public double? ValorPendiente { get; set; }

        public double? ValorTotalPendiente { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdChecPrejuridico { get; set; }

        public long? IdClienteDeuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? FechaInicial { get; set; }

        public DateTime? FechaFinal { get; set; }
    }
}