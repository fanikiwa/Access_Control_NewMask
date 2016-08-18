namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Session
    {
        [StringLength(88)]
        public string SessionId { get; set; }

        public DateTime Created { get; set; }

        public DateTime Expires { get; set; }

        public DateTime LockDate { get; set; }

        public int LockCookie { get; set; }

        public bool Locked { get; set; }

        public byte[] SessionItem { get; set; }

        public int Flags { get; set; }

        public int Timeout { get; set; }
    }
}
