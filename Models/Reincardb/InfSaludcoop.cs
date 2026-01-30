using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("inf_saludcoop")]
    public partial class InfSaludcoop
    {
        [MaxLength(255)]
        public string EPS { get; set; }

        [MaxLength(255)]
        public string Regional { get; set; }

        [MaxLength(255)]
        public string Seccional { get; set; }

        [MaxLength(255)]
        public string Numero_Ident_Empresa { get; set; }

        [MaxLength(255)]
        public string Tipo_Ident_Empresa { get; set; }

        [MaxLength(255)]
        public string Razon_Social { get; set; }

        [MaxLength(255)]
        public string Direccion_Empresa { get; set; }

        [MaxLength(255)]
        public string Telefonos_Empresa { get; set; }

        [MaxLength(255)]
        public string Clase_Empresa { get; set; }

        [MaxLength(255)]
        public string Municipio_Empresa { get; set; }

        [MaxLength(255)]
        public string Depto_Empresa { get; set; }

        public double? Numero_Ident_Afiliado { get; set; }

        [MaxLength(255)]
        public string Tipo_Ident_Afiliado { get; set; }

        [MaxLength(255)]
        public string Nombre_Afiliado { get; set; }

        [MaxLength(255)]
        public string EstadoAfiliado { get; set; }

        [MaxLength(255)]
        public string Direccion_Afiliado { get; set; }

        [MaxLength(255)]
        public string Telefonos_Afiliado { get; set; }

        [MaxLength(255)]
        public string Municipio_Afiliado { get; set; }

        [MaxLength(255)]
        public string Depto_Afiliado { get; set; }

        [MaxLength(255)]
        public string TipoCotizante { get; set; }

        public double? PeriodosMora { get; set; }

        public double? EdadMora { get; set; }

        public double? MaximaEdad { get; set; }

        public double? ValorCotizacion { get; set; }
    }
}