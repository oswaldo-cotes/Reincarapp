using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("dato_cliente_deuda")]
    public partial class DatoClienteDeuda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Dato_Cliente_Deuda { get; set; }

        [MaxLength(30)]
        public string Cedula { get; set; }

        [MaxLength(255)]
        public string Nombre { get; set; }

        [MaxLength(30)]
        public string Fijo1 { get; set; }

        [MaxLength(30)]
        public string Fijo2 { get; set; }

        [MaxLength(30)]
        public string Celular1 { get; set; }

        [MaxLength(30)]
        public string Celular2 { get; set; }

        [MaxLength(255)]
        public string Direccion_Residencia { get; set; }

        [MaxLength(255)]
        public string Ciudad_Residencia { get; set; }

        [MaxLength(255)]
        public string Pais_Residencia { get; set; }

        [MaxLength(255)]
        public string Correo_Electronico { get; set; }

        [MaxLength(30)]
        public string Telefono_Empresa { get; set; }

        [MaxLength(30)]
        public string Celular_Empresa { get; set; }

        [MaxLength(255)]
        public string Direccion_Empresa { get; set; }

        [MaxLength(45)]
        public string Ciudad_Empresa { get; set; }

        [MaxLength(45)]
        public string Pais_Empresa { get; set; }

        [MaxLength(255)]
        public string Correo_Electronico_Empresa { get; set; }

        public long? Id_Cliente_Deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        [MaxLength(80)]
        public string Sub_Cliente { get; set; }
    }
}