namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tariff")]
    public partial class Tariff
    {
        public Tariff()
        {
            EmployeeTariffs = new HashSet<EmployeeTariff>();
            PersonnelTariffs = new HashSet<PersonnelTariff>();
            TariffCalendars = new HashSet<TariffCalendar>();
        }

        public long Id { get; set; }

        public int TariffNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string TariffIdNumber { get; set; }

        [Required]
        public string TariffName { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public string Memo { get; set; }

        public long? MapCalendarId { get; set; }

        public long? PlannedCalendarId { get; set; }

        public int? SurchargeId { get; set; }

        public virtual ICollection<EmployeeTariff> EmployeeTariffs { get; set; }

        public virtual MapCalendarMapped MapCalendarMapped { get; set; }

        public virtual ICollection<PersonnelTariff> PersonnelTariffs { get; set; }

        public virtual PlannedCalendarMapped PlannedCalendarMapped { get; set; }

        public virtual SurchargeMapped SurchargeMapped { get; set; }

        public virtual ICollection<TariffCalendar> TariffCalendars { get; set; }
    }
}
