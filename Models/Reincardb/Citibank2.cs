using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("citibank2")]
    public partial class Citibank2
    {
        [MaxLength(510)]
        public string Compra { get; set; }

        [MaxLength(510)]
        public string Entidad_Originadora { get; set; }

        [MaxLength(30)]
        public string CC { get; set; }

        [MaxLength(510)]
        public string Nombre { get; set; }

        public double? Numero_de_obligaciones { get; set; }

        public decimal? Saldo_capital { get; set; }

        [MaxLength(510)]
        public string direccion { get; set; }

        [MaxLength(510)]
        public string ciudad { get; set; }

        [MaxLength(510)]
        public string telefono_fijo { get; set; }

        [MaxLength(510)]
        public string celular { get; set; }

        [MaxLength(510)]
        public string correo_electronico { get; set; }

        [MaxLength(510)]
        public string nombre_del_abogado { get; set; }

        [MaxLength(510)]
        public string radicado { get; set; }

        [MaxLength(510)]
        public string juzgado { get; set; }

        [MaxLength(510)]
        public string ciudad1 { get; set; }

        [MaxLength(510)]
        public string estado_en_eps { get; set; }

        [MaxLength(510)]
        public string tipo_de_proceso { get; set; }

        [MaxLength(510)]
        public string carpeta_comercial { get; set; }

        [MaxLength(510)]
        public string pagares { get; set; }

        public long? Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Citibank2 { get; set; }
    }
}