namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ERP_KAnsprechp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KAnsprechpCode { get; set; }

        public int? KundenCode { get; set; }

        public int? AnredeCode { get; set; }

        [StringLength(30)]
        public string Vorname { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Telefon { get; set; }

        [StringLength(30)]
        public string Telefon2 { get; set; }

        [StringLength(30)]
        public string Telefon3 { get; set; }

        [StringLength(30)]
        public string Telefax { get; set; }

        [StringLength(50)]
        public string Briefanrede { get; set; }

        [StringLength(50)]
        public string Funktion { get; set; }

        public int? AbteilungCode { get; set; }

        [StringLength(100)]
        public string Straße { get; set; }

        [StringLength(20)]
        public string Staat { get; set; }

        [StringLength(20)]
        public string Plz { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

        [StringLength(30)]
        public string Mobilfunk { get; set; }

        [StringLength(50)]
        public string AdreßErweiterung { get; set; }

        [Column(TypeName = "ntext")]
        public string Notiz { get; set; }

        [Column("E-Mail")]
        [StringLength(50)]
        public string E_Mail { get; set; }

        public int? MailanPrivat { get; set; }

        [StringLength(30)]
        public string TelPrivat { get; set; }

        [StringLength(30)]
        public string FaxPrivat { get; set; }

        public DateTime? Geburtsdatum { get; set; }

        public int? OutlookAdresse { get; set; }

        [StringLength(50)]
        public string SenderName { get; set; }

        public int? Entlassen { get; set; }

        public DateTime? LetzteÄnderung { get; set; }

        [StringLength(50)]
        public string eMailPrivat { get; set; }

        public int? BCodeErstkontakt { get; set; }

        public int? BCodeLetzteÄnderung { get; set; }

        [StringLength(50)]
        public string I_LogName { get; set; }

        public int? GeburtstagTag { get; set; }

        public int? GeburtstagMonat { get; set; }

        public int? GeburtstagJahr { get; set; }

        public int? VIP { get; set; }

        public int? Serienbriefsperre { get; set; }

        public int? Mailsperre { get; set; }

        [StringLength(50)]
        public string Titelerweiterung { get; set; }

        [StringLength(30)]
        public string Namenserweiterung { get; set; }

        public DateTime? Erstkontakt { get; set; }

        public int? PrimäreAdresse { get; set; }

        public int? FirmenAdresse { get; set; }

        public int? AbteilungInAdresseZeigen { get; set; }

        public int? FunktionInAdresseZeigen { get; set; }

        [StringLength(50)]
        public string Skypename { get; set; }

        [StringLength(30)]
        public string MobilPrivat { get; set; }

        [StringLength(4000)]
        public string NotizRTF { get; set; }

        public string Memo { get; set; }

        public virtual ERP_Anrede ERP_Anrede { get; set; }
    }
}
