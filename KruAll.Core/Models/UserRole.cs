namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRole
    {
        public UserRole()
        {
            Portal_Users = new HashSet<Portal_Users>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Role { get; set; }

        public virtual ICollection<Portal_Users> Portal_Users { get; set; }
    }
}
