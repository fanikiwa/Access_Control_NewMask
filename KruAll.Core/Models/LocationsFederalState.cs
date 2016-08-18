namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LocationsFederalState
    {
        public LocationsFederalState()
        {
            Clients = new HashSet<Client>();
        }

        public long ID { get; set; }

        public int? StateNo { get; set; }

        public string StateName { get; set; }

        public string Memo { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
