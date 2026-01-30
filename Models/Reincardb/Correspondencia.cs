using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("correspondencia")]
    public partial class Correspondencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Correspondencia { get; set; }

        [MaxLength(25)]
        public string pic { get; set; }

        [MaxLength(25)]
        public string sticker { get; set; }

        [MaxLength(255)]
        public string nombre { get; set; }

        [MaxLength(255)]
        public string direccion { get; set; }

        [MaxLength(100)]
        public string novedad { get; set; }

        [MaxLength(100)]
        public string destino { get; set; }

        [MaxLength(100)]
        public string origen { get; set; }

        public long? Id_Evento { get; set; }

        public Evento Evento { get; set; }
    }
}