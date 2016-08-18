namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personalstamm")]
    public partial class Personalstamm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pers_Nr { get; set; }

        public int? Pers_Ausweis_Nr { get; set; }

        [StringLength(30)]
        public string Pers_Name1 { get; set; }

        [StringLength(50)]
        public string Pers_Name2 { get; set; }

        [StringLength(50)]
        public string Pers_Str { get; set; }

        public int? Pers_Plz { get; set; }

        [StringLength(50)]
        public string Pers_Ort { get; set; }

        [StringLength(30)]
        public string Pers_Tel { get; set; }

        [StringLength(30)]
        public string Pers_Fax { get; set; }

        [StringLength(30)]
        public string Pers_Mobil { get; set; }

        [StringLength(255)]
        public string Pers_Email { get; set; }

        [StringLength(1000)]
        public string Pers_Info { get; set; }

        [StringLength(35)]
        public string Pers_Bank { get; set; }

        [StringLength(50)]
        public string Pers_Blz { get; set; }

        [StringLength(50)]
        public string Pers_Kto { get; set; }

        public DateTime? Pers_Geburtsdatum { get; set; }

        public int? Pers_Werk { get; set; }

        public int? Pers_Kostenstelle { get; set; }

        public int? Pers_Abteilung { get; set; }

        public int? Pers_Lohngruppe { get; set; }

        public int? Pers_Tarif { get; set; }

        public DateTime? Pers_Eintritt { get; set; }

        public DateTime? Pers_Austritt { get; set; }

        [StringLength(50)]
        public string Pers_Finanzamt { get; set; }

        [StringLength(50)]
        public string Pers_Nation { get; set; }

        [StringLength(50)]
        public string Pers_Familienstand { get; set; }

        [StringLength(50)]
        public string Pers_Religion { get; set; }

        [StringLength(50)]
        public string Pers_SozVersNr { get; set; }

        [StringLength(50)]
        public string Pers_Qualifikation { get; set; }

        [Column(TypeName = "text")]
        public string Pers_Foto { get; set; }

        public int? Pers_Wabr { get; set; }

        public short? Pers_Wabr_tag { get; set; }

        public int? Pers_Mabr { get; set; }

        public short? Pers_Mabr_tag { get; set; }

        public double? Pers_Jahresurlaub { get; set; }

        [StringLength(50)]
        public string Pers_Krankenkasse { get; set; }

        [StringLength(50)]
        public string Pers_KassenVersNr { get; set; }

        public int? Pers_Standardkalender { get; set; }

        [StringLength(50)]
        public string Pers_Geschlecht { get; set; }

        public DateTime? Pers_Tageswechsel { get; set; }

        [StringLength(12)]
        public string Pers_Status { get; set; }

        public DateTime? Pers_DatumStartStatus { get; set; }

        public bool? Pers_Ohne_Abrechnung { get; set; }

        public bool? Pers_Fahrer { get; set; }

        [StringLength(255)]
        public string Pers_PinCode { get; set; }

        public int? Pers_Zutritt { get; set; }

        public bool? Pers_Anzug { get; set; }

        public int? Pers_PremLohnart { get; set; }

        public int? Pers_ZulagLohnart { get; set; }

        public DateTime? LastAccess { get; set; }

        public bool? Datev { get; set; }

        public int? Pers_QualNr { get; set; }

        public int? Pers_QualGrpNr { get; set; }

        public int? Pers_PCTGruppe { get; set; }

        public int? Pers_PCTKonto { get; set; }

        public int? LetzterAuftrag { get; set; }

        public int? LetzteTaetigkeit { get; set; }

        public int? Pers_Sollzeitkalender { get; set; }

        [StringLength(5)]
        public string Pers_TagesschieneNr { get; set; }

        public int? Pers_Wbelast_Tag { get; set; }

        public int? Pers_Mbelast_Tag { get; set; }

        public double? Pers_SonderUrlaub1 { get; set; }

        public double? Pers_SonderUrlaub2 { get; set; }

        public double? Pers_SonderUrlaub3 { get; set; }

        public double? Pers_SonderUrlaub4 { get; set; }

        public double? Pers_SonderUrlaub5 { get; set; }

        public double? Pers_SonderUrlaub6 { get; set; }

        public double? Pers_SonderUrlaub7 { get; set; }

        public double? Pers_SonderUrlaub8 { get; set; }

        public int? Pers_Ausweis_nr2 { get; set; }

        public int? NoPZE { get; set; }

        public int? TabStatus { get; set; }

        [StringLength(20)]
        public string TabAbw { get; set; }

        public DateTime? TabAbwEnd { get; set; }

        public double? Pers_BerechnungsFaktor { get; set; }

        [StringLength(50)]
        public string PERS_Z1 { get; set; }

        [StringLength(50)]
        public string PERS_Z2 { get; set; }

        [StringLength(50)]
        public string PERS_Z3 { get; set; }

        [StringLength(50)]
        public string PERS_Z4 { get; set; }

        [StringLength(50)]
        public string PERS_Z5 { get; set; }

        [StringLength(50)]
        public string PERS_Z6 { get; set; }

        [StringLength(50)]
        public string PERS_Z7 { get; set; }

        [StringLength(50)]
        public string PERS_Z8 { get; set; }

        [StringLength(50)]
        public string PERS_Z9 { get; set; }

        [StringLength(50)]
        public string PERS_Z10 { get; set; }

        [StringLength(16)]
        public string INFO1 { get; set; }

        [StringLength(16)]
        public string INFO2 { get; set; }

        [StringLength(16)]
        public string INFO3 { get; set; }

        [StringLength(16)]
        public string INFO4 { get; set; }

        public bool? PERS_WPP_GETMAIL { get; set; }

        public bool? PERS_WPP_KORR { get; set; }

        [Column(TypeName = "text")]
        public string PERS_TEMPLATE { get; set; }

        public int? PERS_VISNR { get; set; }

        public int? PERS_COUNTER { get; set; }

        [StringLength(50)]
        public string pers_position { get; set; }

        public DateTime? pers_ablauf { get; set; }

        [StringLength(1)]
        public string MES_Flag { get; set; }

        [StringLength(20)]
        public string MES_ANNummer { get; set; }

        public double? PERS_MAXGZ { get; set; }

        public int? PERS_MONATSWECHSEL { get; set; }

        public int? PERS_MOWEGUTMODUS { get; set; }

        public double? PERS_MOWEGUTSTD { get; set; }

        [StringLength(100)]
        public string PERS_HZO2 { get; set; }

        [StringLength(50)]
        public string Pers_Anrede { get; set; }

        [StringLength(50)]
        public string Pers_GebOrt { get; set; }

        [StringLength(50)]
        public string Pers_Kinder { get; set; }

        [StringLength(50)]
        public string Pers_Beruf { get; set; }

        public DateTime? Pers_VertrBis { get; set; }

        [StringLength(50)]
        public string Pers_StdZahl { get; set; }

        public DateTime? Pers_VertrAb { get; set; }

        [StringLength(50)]
        public string Pers_Z11 { get; set; }

        [StringLength(50)]
        public string Pers_Z12 { get; set; }

        [StringLength(50)]
        public string Pers_Z13 { get; set; }

        [StringLength(50)]
        public string Pers_Z14 { get; set; }

        [StringLength(50)]
        public string Pers_Z15 { get; set; }

        [StringLength(50)]
        public string Pers_Z16 { get; set; }

        [StringLength(50)]
        public string Pers_Z17 { get; set; }

        [StringLength(50)]
        public string Pers_Z18 { get; set; }

        [StringLength(50)]
        public string Pers_Z19 { get; set; }

        [StringLength(50)]
        public string Pers_Z20 { get; set; }

        [StringLength(50)]
        public string Pers_FSchein { get; set; }

        [StringLength(50)]
        public string Pers_StKlasse { get; set; }

        public DateTime? Pers_AngelegtAm { get; set; }

        public DateTime? Pers_AusgeschiedenAm { get; set; }

        public int? Pers_AutoAusb { get; set; }

        public int? Pers_Durchschnitt { get; set; }

        [StringLength(50)]
        public string Pers_Pre_Ausweis_Nr { get; set; }

        [StringLength(50)]
        public string Pers_Pre_Ausweis_Nr2 { get; set; }

        public int? Pers_WF { get; set; }

        public int? Pers_WF_ITerm { get; set; }

        public bool? Pers_WF_Admin { get; set; }

        public int? Pers_KstAnzeigeGrp { get; set; }

        [StringLength(20)]
        public string Pers_Prefix { get; set; }

        public bool? Pers_BDEPlanung { get; set; }

        public int? Pers_ZutrittsKalender { get; set; }

        public int? Pers_Bereich { get; set; }

        public bool? Pers_PEPMB { get; set; }

        public int? Pers_FlexKstGr { get; set; }

        public bool? Pers_Ausw_Gesperrt { get; set; }

        [StringLength(50)]
        public string Pers_ParkplatzFirma { get; set; }

        [StringLength(50)]
        public string Pers_ParkplatzKennzeichen { get; set; }

        [StringLength(50)]
        public string Pers_ParkplatzAutomarke { get; set; }

        [StringLength(50)]
        public string Pers_ParkplatzTyp { get; set; }

        [StringLength(50)]
        public string Pers_ParkplatzFarbe { get; set; }

        public DateTime? Pers_ParkplatzVon { get; set; }

        public DateTime? Pers_ParkplatzBis { get; set; }

        public int? Pers_TaetGrpNr { get; set; }

        public int? Pers_Mandant { get; set; }

        [StringLength(50)]
        public string Pers_WoProg { get; set; }

        public DateTime? Pers_WoProg_Start { get; set; }

        [StringLength(20)]
        public string Pers_LKenner { get; set; }

        public int? Pers_MAStatus { get; set; }

        public int? Pers_Zuordnung1 { get; set; }

        public int? Pers_Zuordnung2 { get; set; }

        [StringLength(50)]
        public string Pers_Titel { get; set; }

        [StringLength(50)]
        public string Pers_Name12 { get; set; }

        [StringLength(20)]
        public string Pers_Bic { get; set; }

        [StringLength(35)]
        public string Pers_Iban { get; set; }

        public int? Pers_Zutritt2 { get; set; }

        public int? Pers_ZutrittAktiv { get; set; }

        [StringLength(10)]
        public string Berufsschule { get; set; }

        public bool? Df_Message_anzeigen { get; set; }
    }
}
