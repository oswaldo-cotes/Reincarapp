using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("persona")]
    public partial class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id_Persona { get; set; }

        public long? Id_Tipo_Documento { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        [MaxLength(25)]
        public string Numero_Documento { get; set; }

        [MaxLength(250)]
        public string Nombre_Persona { get; set; }

        public ICollection<AsignacionGestor> AsignacionGestor { get; set; }

        public ICollection<ClienteDeuda> ClienteDeuda { get; set; }

        public ICollection<DatoPersona> DatoPersona { get; set; }

        public ICollection<MCita> MCita { get; set; }
    }
}