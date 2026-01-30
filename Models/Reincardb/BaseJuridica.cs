using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("base_juridica")]
    public partial class BaseJuridica
    {
        [MaxLength(45)]
        public string cedula { get; set; }

        [MaxLength(1000)]
        public string nombre { get; set; }

        [MaxLength(45)]
        public string usuario { get; set; }

        [MaxLength(45)]
        public string competencia { get; set; }

        [MaxLength(100)]
        public string tarifa { get; set; }

        public double? capital { get; set; }

        public double? interes { get; set; }

        public double? total { get; set; }

        public double? saldo { get; set; }

        [MaxLength(100)]
        public string juzgado { get; set; }

        [MaxLength(100)]
        public string radicado { get; set; }

        [MaxLength(45)]
        public string fecha_recepcion { get; set; }

        [MaxLength(500)]
        public string existencia_del_pagare { get; set; }

        [MaxLength(500)]
        public string condicion_del_pagare { get; set; }

        [MaxLength(500)]
        public string estado_del_pagare { get; set; }

        [MaxLength(100)]
        public string entidad_originadora { get; set; }

        [MaxLength(100)]
        public string tipo_de_proceso { get; set; }

        [MaxLength(45)]
        public string numero_de_obligacion { get; set; }

        [MaxLength(100)]
        public string nombre_abogado { get; set; }

        [MaxLength(45)]
        public string sub_cliente { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_base_juridica { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }
    }
}