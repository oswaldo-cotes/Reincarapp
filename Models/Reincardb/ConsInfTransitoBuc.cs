using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("cons_inf_transito_buc")]
    public partial class ConsInfTransitoBuc
    {
        [MaxLength(25)]
        public string numero_documento { get; set; }

        public string comparendo { get; set; }

        public string placa { get; set; }

        public string tipo_gestion { get; set; }

        public string resultado_gestion { get; set; }

        public string nota_de_gestion { get; set; }

        public string fecha_gestion { get; set; }

        public string gestor { get; set; }

        public string id_evento { get; set; }

        [Key]
        [Required]
        public long id_transito_buc { get; set; }
    }
}