using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("saludcoop")]
    public partial class Saludcoop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_SaludCoop { get; set; }

        public long? Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        [MaxLength(30)]
        public string Eps { get; set; }

        [MaxLength(100)]
        public string Regional { get; set; }

        [MaxLength(100)]
        public string Seccional { get; set; }

        [MaxLength(20)]
        public string Numero_Ident_Empresa { get; set; }

        [MaxLength(5)]
        public string Tipo_Ident_Empresa { get; set; }

        [MaxLength(255)]
        public string Razon_Social { get; set; }

        [MaxLength(255)]
        public string Direccion_Empresa { get; set; }

        [MaxLength(255)]
        public string Telefonos_Empresa { get; set; }

        [MaxLength(100)]
        public string Clase_Empresa { get; set; }

        [MaxLength(100)]
        public string Municipio_Empresa { get; set; }

        [MaxLength(100)]
        public string Depto_Empresa { get; set; }

        [MaxLength(25)]
        public string Numero_Ident_Afiliado { get; set; }

        [MaxLength(5)]
        public string Tipo_Ident_Afiliado { get; set; }

        [MaxLength(255)]
        public string Nombre_Afiliado { get; set; }

        [MaxLength(100)]
        public string Estado_Afiliado { get; set; }

        [MaxLength(255)]
        public string Direccion_Afiliado { get; set; }

        [MaxLength(100)]
        public string Municipio_Afiliado { get; set; }

        [MaxLength(100)]
        public string Depto_Afiliado { get; set; }

        [MaxLength(100)]
        public string Tipo_Cotizante { get; set; }

        [MaxLength(20)]
        public string Periodos_Mora { get; set; }

        public decimal? Edad_Mora { get; set; }

        public decimal? Maxima_Edad { get; set; }

        public decimal? Valor_Cotizacion { get; set; }

        [MaxLength(100)]
        public string Telefono_1 { get; set; }

        [MaxLength(100)]
        public string Telefono_2 { get; set; }

        [MaxLength(100)]
        public string Telefono_3 { get; set; }

        [MaxLength(25)]
        public string Cedula_Gestor { get; set; }
    }
}