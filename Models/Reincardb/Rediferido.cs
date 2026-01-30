using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("rediferido")]
    public partial class Rediferido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_rediferido { get; set; }

        public long? id_credivalores { get; set; }

        public Credivalores Credivalores { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public double? saldo_total { get; set; }

        public double? capital_al_dia { get; set; }

        public long? id_franja { get; set; }

        public Franja Franja { get; set; }

        public long? tasa { get; set; }

        public Tasa Tasa1 { get; set; }

        public double? nueva_cuota { get; set; }

        public int? nuevo_plazo { get; set; }

        public DateTime? fecha_envio { get; set; }

        public long? id_usuario { get; set; }

        public Usuario Usuario { get; set; }

        [MaxLength(45)]
        public string telefono { get; set; }

        public long? id_ciudad { get; set; }

        public Municipio Municipio { get; set; }

        public long? id_tipo_rediferido { get; set; }

        public TipoRediferido TipoRediferido { get; set; }

        [MaxLength(1000)]
        public string correo_electronico { get; set; }

        public DateTime? fecha_creacion { get; set; }
    }
}