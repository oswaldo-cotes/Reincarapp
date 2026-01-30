using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("emp_saludcoop")]
    public partial class EmpSaludcoop
    {
        [MaxLength(5)]
        public string Tipo_Ident_Empresa { get; set; }

        [MaxLength(20)]
        public string Numero_Ident_Empresa { get; set; }

        [MaxLength(255)]
        public string Razon_Social { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Empresa { get; set; }
    }
}