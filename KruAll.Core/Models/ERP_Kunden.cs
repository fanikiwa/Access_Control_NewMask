namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ERP_Kunden
    {
        public int ID { get; set; }

        public int Code { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        public int? GrCode { get; set; }

        public int? Nummer { get; set; }

        [StringLength(100)]
        public string Firma1 { get; set; }

        [StringLength(100)]
        public string Firma2 { get; set; }

        [StringLength(100)]
        public string Firma3 { get; set; }

        [StringLength(100)]
        public string Straße { get; set; }

        [StringLength(20)]
        public string Staat { get; set; }

        [StringLength(50)]
        public string Plz { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

        [StringLength(50)]
        public string Telefon { get; set; }

        [StringLength(50)]
        public string Telefax { get; set; }

        public int? Privatkunde { get; set; }

        public int? Bruttorechnung { get; set; }

        public int? Gesperrt { get; set; }

        public int? Zahlungsfrist { get; set; }

        public float? Skonto { get; set; }

        public float? Skontofrist { get; set; }

        public double? Skonto2 { get; set; }

        public int? Skonto2Frist { get; set; }

        public double? Mahntoleranz { get; set; }

        public float? Rabattvorschlag { get; set; }

        public int? Preisgruppe { get; set; }

        [Column(TypeName = "ntext")]
        public string Notiz { get; set; }

        public int? KAnsprechpCode { get; set; }

        public int? NebenAdrCode1 { get; set; }

        public int? NebenAdrCode2 { get; set; }

        public int? NebenAdrCode3 { get; set; }

        public int? NebenAdrType1 { get; set; }

        public int? NebenAdrType2 { get; set; }

        public int? NebenAdrType3 { get; set; }

        public int? KKontaktCode { get; set; }

        public DateTime? Erstkontakt { get; set; }

        public DateTime? Letzterkontakt { get; set; }

        [StringLength(50)]
        public string PersonErstkontakt { get; set; }

        [StringLength(50)]
        public string PersonLetzterkontakt { get; set; }

        [StringLength(50)]
        public string Waswurdezuletztgetan { get; set; }

        public float? Entfernung { get; set; }

        [StringLength(20)]
        public string Postfach { get; set; }

        [StringLength(8)]
        public string PLZPostfach { get; set; }

        [StringLength(50)]
        public string OrtPostfach { get; set; }

        [StringLength(50)]
        public string Vorwahl { get; set; }

        [StringLength(50)]
        public string AnsprechPartner { get; set; }

        [StringLength(50)]
        public string BriefAnrede { get; set; }

        public int? AnredeCode { get; set; }

        [StringLength(20)]
        public string Autotelefon { get; set; }

        [StringLength(40)]
        public string InterNet { get; set; }

        public int? VertreterCode { get; set; }

        public double? Provision { get; set; }

        [StringLength(1)]
        public string Mark { get; set; }

        public int? Standardkonto { get; set; }

        public int? Steuer { get; set; }

        [StringLength(30)]
        public string Kontonummer { get; set; }

        [StringLength(30)]
        public string Bankverbindung { get; set; }

        [StringLength(30)]
        public string Bankleitzahl { get; set; }

        [StringLength(50)]
        public string Kontoinhaber { get; set; }

        public int? Bankeinzug { get; set; }

        [StringLength(50)]
        public string USTIDNR { get; set; }

        [StringLength(20)]
        public string Kundennr { get; set; }

        [StringLength(10)]
        public string Kürzel { get; set; }

        public int? HausbankCode { get; set; }

        public int? SprachCode { get; set; }

        [Column("E-Mail")]
        [StringLength(100)]
        public string E_Mail { get; set; }

        public int? WährungCode { get; set; }

        public double? Kreditlimit { get; set; }

        public int? ZahlungsCode { get; set; }

        public int? DB { get; set; }

        public int? SteuerschluesselCode { get; set; }

        [StringLength(50)]
        public string SenderName { get; set; }

        public int? OutlookAdresse { get; set; }

        public DateTime? Geburtsdatum { get; set; }

        public int? Vertreter2Code { get; set; }

        public DateTime? LetzteÄnderung { get; set; }

        [StringLength(30)]
        public string Titelerweiterung { get; set; }

        public int? GeburtstagTag { get; set; }

        public int? GeburtstagMonat { get; set; }

        public int? GeburtstagJahr { get; set; }

        [StringLength(50)]
        public string Namenserweiterung { get; set; }

        public int? Erloschen { get; set; }

        [StringLength(50)]
        public string Funktion { get; set; }

        [StringLength(255)]
        public string FirmenAnrede { get; set; }

        public int? Intern { get; set; }

        public int? DoublettenCheck_NichtMehrAnzeigen { get; set; }

        [Column(TypeName = "ntext")]
        public string Adreßerweiterung { get; set; }

        [Column("E-Mail2")]
        [StringLength(150)]
        public string E_Mail2 { get; set; }

        [StringLength(4000)]
        public string NotizRTF { get; set; }

        [StringLength(34)]
        public string IBAN { get; set; }

        [StringLength(11)]
        public string BIC { get; set; }

        [StringLength(30)]
        public string Telefon2 { get; set; }

        public int? Lieferadresse { get; set; }

        public int? DTANichtZusammenfassen { get; set; }

        public int? MailSperre { get; set; }

        public int? SerienbriefSperre { get; set; }

        public int? LieferungsArtCode { get; set; }

        public int? LieferungsArtZiel { get; set; }

        [StringLength(100)]
        public string MiteID { get; set; }

        [StringLength(50)]
        public string Konzernkennzeichen { get; set; }

        public int? Mahnsperre { get; set; }

        public int? TeilrechnungslogikCode { get; set; }

        [StringLength(1000)]
        public string Ordner { get; set; }

        public int? VertreterSDObjMemberCode { get; set; }

        public int? VertreterSDObjType { get; set; }

        public int? NebenadrAPCode1 { get; set; }

        public int? NebenadrAPCode2 { get; set; }

        public int? NebenadrAPCode3 { get; set; }

        public int? ERPFreigabepflichtDeaktivieren { get; set; }

        public int? AdresseWirdGepflegtBeiLieferantCode { get; set; }

        public double? Rabatt2 { get; set; }

        public double? Rabatt3 { get; set; }

        public double? Rabatt4 { get; set; }

        public int? AdresseWirdGepflegtBeiKundeCode { get; set; }

        public int? KeineStaffelrabatte { get; set; }

        public string Memo { get; set; }

        public int? KundenType { get; set; }
    }
}
