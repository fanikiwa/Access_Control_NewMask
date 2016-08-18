namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ERP_Anrede
    {
        public ERP_Anrede()
        {
            ERP_KAnsprechp = new HashSet<ERP_KAnsprechp>();
            MembersDatas = new HashSet<MembersData>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnredeCode { get; set; }

        [StringLength(50)]
        public string AnredeName { get; set; }

        [StringLength(50)]
        public string StdBriefAnrede { get; set; }

        public int? NameorVorname { get; set; }

        [StringLength(50)]
        public string Titel { get; set; }

        public int? Nummer { get; set; }

        public int? Weiblich { get; set; }

        public int? Männlich { get; set; }

        public int? AnredeCodeAlternativ { get; set; }

        public virtual ICollection<ERP_KAnsprechp> ERP_KAnsprechp { get; set; }

        public virtual ICollection<MembersData> MembersDatas { get; set; }
    }
}
