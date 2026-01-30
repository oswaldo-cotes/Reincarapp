using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("tmp_dec_est")]
    public partial class TmpDecEst
    {
        public double? Clasificacion { get; set; }

        [Column("Resultado gestion")]
        public double? Resultadogestion { get; set; }

        [Column("Mensaje de texto")]
        [MaxLength(510)]
        public string Mensajedetexto { get; set; }

        public double? Llamada { get; set; }

        [Column("resultado carta prejuridica")]
        public double? resultadocartaprejuridica { get; set; }

        [Column("Mensaje de voz")]
        public double? Mensajedevoz { get; set; }

        [Column("Acude a oficina")]
        public double? Acudeaoficina { get; set; }

        [Column("visita domiciliaria")]
        public double? visitadomiciliaria { get; set; }

        [MaxLength(510)]
        public string Compromiso { get; set; }

        [Column("incumple compromiso")]
        public double? incumplecompromiso { get; set; }
    }
}