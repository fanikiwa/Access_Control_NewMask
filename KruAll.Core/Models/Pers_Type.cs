namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pers_Type
    {
        public Pers_Type()
        {
            Personals = new HashSet<Personal>();
        }

        public long ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Memo { get; set; }

        public string PersTypeColor { get; set; }

        public virtual ICollection<Personal> Personals { get; set; }
    }
}
