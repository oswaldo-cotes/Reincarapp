using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reincarapp.Models.reincardb
{
    [Table("coomultrasan_castigo")]
    public partial class CoomultrasanCastigo
    {
        [MaxLength(255)]
        public string PERIODO { get; set; }

        public string IDENTIFICACION { get; set; }

        [MaxLength(255)]
        public string F_EXP_TIT { get; set; }

        [MaxLength(255)]
        public string NOMBRES { get; set; }

        [MaxLength(255)]
        public string AGENCIA { get; set; }

        public string NROPRO { get; set; }

        [MaxLength(255)]
        public string LINEACREDITO { get; set; }

        [MaxLength(255)]
        public string COD_ABOGADO { get; set; }

        [MaxLength(255)]
        public string FECHA_NOVEDAD { get; set; }

        [MaxLength(255)]
        public string DIASMORA { get; set; }

        [MaxLength(255)]
        public string SALDOCREDITO { get; set; }

        [MaxLength(255)]
        public string TOTALINTCTEVEN { get; set; }

        [MaxLength(255)]
        public string TOTALINTMORA { get; set; }

        [MaxLength(255)]
        public string TOTALSEGUROVEN { get; set; }

        [MaxLength(255)]
        public string TOTALVENCIDO { get; set; }

        [MaxLength(255)]
        public string ESTADOCRED { get; set; }

        [MaxLength(255)]
        public string IND_CASTIGO { get; set; }

        [MaxLength(255)]
        public string EMPRESAPAGADURIA { get; set; }

        [MaxLength(255)]
        public string TELCASA { get; set; }

        [MaxLength(255)]
        public string TELCEL { get; set; }

        [MaxLength(255)]
        public string TELTRABAJO { get; set; }

        [MaxLength(255)]
        public string EMP_DEUDOR { get; set; }

        [MaxLength(255)]
        public string CIUDAD_TRAB_DEUDOR { get; set; }

        [MaxLength(255)]
        public string DIR_TRAB_DEUDOR { get; set; }

        [MaxLength(255)]
        public string DIR_RESIDE_DEUDOR { get; set; }

        [MaxLength(255)]
        public string CIU_RESIDE_DEUDOR { get; set; }

        [MaxLength(255)]
        public string BARRIO_RES_DEUDOR { get; set; }

        [MaxLength(255)]
        public string C1_IDENTIFICACION { get; set; }

        [MaxLength(255)]
        public string F_EXP_C1 { get; set; }

        [MaxLength(255)]
        public string C1_NOMBRES { get; set; }

        [MaxLength(255)]
        public string C1_DOMICILIO { get; set; }

        [MaxLength(255)]
        public string C1_CIUDAD { get; set; }

        [MaxLength(255)]
        public string BARRIO_CODEUDOR1 { get; set; }

        [MaxLength(255)]
        public string C1_TEL1 { get; set; }

        [MaxLength(255)]
        public string C1_TEL2 { get; set; }

        [MaxLength(255)]
        public string C1_EMPRESA { get; set; }

        [MaxLength(255)]
        public string C1_DIREMPRESA { get; set; }

        [MaxLength(255)]
        public string C1_CIUDADEMPRESA { get; set; }

        [MaxLength(255)]
        public string C1_TEL4 { get; set; }

        [MaxLength(255)]
        public string C1_OCUPACION { get; set; }

        [MaxLength(255)]
        public string C2_IDENTIFICACION { get; set; }

        [MaxLength(255)]
        public string F_EXP_C2 { get; set; }

        [MaxLength(255)]
        public string C2_NOMBRES { get; set; }

        [MaxLength(255)]
        public string C2_DOMICILIO { get; set; }

        [MaxLength(255)]
        public string C2_CIUDAD { get; set; }

        [MaxLength(255)]
        public string BARRIO_CODEUDOR2 { get; set; }

        [MaxLength(255)]
        public string C2_TEL1 { get; set; }

        [MaxLength(255)]
        public string C2_TEL2 { get; set; }

        [MaxLength(255)]
        public string C2_EMPRESA { get; set; }

        [MaxLength(255)]
        public string C2_DIREMPRESA { get; set; }

        [MaxLength(255)]
        public string C2_CIUDADEMPRESA { get; set; }

        [MaxLength(255)]
        public string C2_TEL4 { get; set; }

        [MaxLength(255)]
        public string C2_OCUPACION { get; set; }

        [MaxLength(255)]
        public string C3_IDENTIFICACION { get; set; }

        [MaxLength(255)]
        public string F_EXP_C3 { get; set; }

        [MaxLength(255)]
        public string C3_NOMBRES { get; set; }

        [MaxLength(255)]
        public string C3_DOMICILIO { get; set; }

        [MaxLength(255)]
        public string C3_CIUDAD { get; set; }

        [MaxLength(255)]
        public string BARRIO_CODEUDOR3 { get; set; }

        [MaxLength(255)]
        public string C3_TEL1 { get; set; }

        [MaxLength(255)]
        public string C3_TEL2 { get; set; }

        [MaxLength(255)]
        public string C3_EMPRESA { get; set; }

        [MaxLength(255)]
        public string C3_DIREMPRESA { get; set; }

        [MaxLength(255)]
        public string C3_CIUDADEMPRESA { get; set; }

        [MaxLength(255)]
        public string C3_TEL4 { get; set; }

        [MaxLength(255)]
        public string C3_OCUPACION { get; set; }

        [MaxLength(255)]
        public string RFAM_NOMBRES { get; set; }

        [MaxLength(255)]
        public string RFAM_DOMICILIO { get; set; }

        [MaxLength(255)]
        public string RFAM_CIUDAD { get; set; }

        [MaxLength(255)]
        public string RFAM_TEL1 { get; set; }

        [MaxLength(255)]
        public string REFAM_PARENTEZCO { get; set; }

        [MaxLength(255)]
        public string RPER_NOMBRES { get; set; }

        [MaxLength(255)]
        public string RPER_DOMICILIO { get; set; }

        [MaxLength(255)]
        public string RPER_CIUDAD { get; set; }

        [MaxLength(255)]
        public string RPER_TEL1 { get; set; }

        [MaxLength(255)]
        public string RFAMC1_NOMBRES { get; set; }

        [MaxLength(255)]
        public string RFAMC1_DOMICILIO { get; set; }

        [MaxLength(255)]
        public string RFAMC1_CIUDAD { get; set; }

        [MaxLength(255)]
        public string RFAMC1_TEL1 { get; set; }

        [MaxLength(255)]
        public string REFAMC1_PARENTEZCO { get; set; }

        [MaxLength(255)]
        public string RPERC1_NOMBRES { get; set; }

        [MaxLength(255)]
        public string RPERC1_DOMICILIO { get; set; }

        [MaxLength(255)]
        public string RPERC1_CIUDAD { get; set; }

        [MaxLength(255)]
        public string RPERC1_TEL1 { get; set; }

        [MaxLength(255)]
        public string RFAMC2_NOMBRES { get; set; }

        [MaxLength(255)]
        public string RFAMC2_DOMICILIO { get; set; }

        [MaxLength(255)]
        public string RFAMC2_CIUDAD { get; set; }

        [MaxLength(255)]
        public string RFAMC2_TEL1 { get; set; }

        [MaxLength(255)]
        public string REFAMC2_PARENTEZCO { get; set; }

        [MaxLength(255)]
        public string RPERC2_NOMBRES { get; set; }

        [MaxLength(255)]
        public string RPERC2_DOMICILIO { get; set; }

        [MaxLength(255)]
        public string RPERC2_CIUDAD { get; set; }

        [MaxLength(255)]
        public string RPERC2_TEL1 { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_coomultrasan_castigo { get; set; }

        public long? id_cliente_deuda { get; set; }

        public ClienteDeuda ClienteDeuda { get; set; }

        public DateTime? fecha_inicial { get; set; }

        public DateTime? fecha_final { get; set; }
    }
}