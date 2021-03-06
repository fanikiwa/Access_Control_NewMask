namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Client
    {
        public Client()
        {
            Pers_Client = new HashSet<Pers_Client>();
            VisitorAccessTimes = new HashSet<VisitorAccessTime>();
        }

        public long ID { get; set; }

        public long Client_Nr { get; set; }

        public string Name { get; set; }

        public string Function { get; set; }

        public string InfoText { get; set; }

        public string Street { get; set; }

        public string Plz { get; set; }

        public string HouseNr { get; set; }

        public string Telephone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Ort { get; set; }

        public string PersonInCharge { get; set; }

        public long? State { get; set; }

        public virtual LocationsFederalState LocationsFederalState { get; set; }

        public virtual ICollection<Pers_Client> Pers_Client { get; set; }

        public virtual ICollection<VisitorAccessTime> VisitorAccessTimes { get; set; }
    }
}
