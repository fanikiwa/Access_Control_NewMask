namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AC_PersPasswordsProfile
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pers_Nr { get; set; }

        [Key]
        [Column(Order = 1)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string CurrentPassword { get; set; }

        public string OldPassword { get; set; }

        public int? ProfileID { get; set; }

        [Key]
        [Column(Order = 3)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 4)]
        public string LastName { get; set; }
    }
}
