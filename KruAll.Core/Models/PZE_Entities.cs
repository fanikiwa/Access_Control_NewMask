namespace KruAll.Core.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PZE_Entities : DbContext
    {
        public PZE_Entities()
            : base("name=PZE_Entities")
        {
        }

        public virtual DbSet<Absence> Absences { get; set; }
        public virtual DbSet<AC_PermissionMapping> AC_PermissionMapping { get; set; }
        public virtual DbSet<AC_PermissionProfile> AC_PermissionProfile { get; set; }
        public virtual DbSet<AC_Permissions> AC_Permissions { get; set; }
        public virtual DbSet<AC_PersPasswords> AC_PersPasswords { get; set; }
        public virtual DbSet<AC_PersProfileADMapping> AC_PersProfileADMapping { get; set; }
        public virtual DbSet<AC_PersProfileMapping> AC_PersProfileMapping { get; set; }
        public virtual DbSet<AC_ReportList> AC_ReportList { get; set; }
        public virtual DbSet<AC_ReportListChecks> AC_ReportListChecks { get; set; }
        public virtual DbSet<AC_Reports> AC_Reports { get; set; }
        public virtual DbSet<AC_ReportSettings> AC_ReportSettings { get; set; }
        public virtual DbSet<AccessCalendar> AccessCalendars { get; set; }
        public virtual DbSet<AccessCalendarMonth> AccessCalendarMonths { get; set; }
        public virtual DbSet<AccessCalendarProfile> AccessCalendarProfiles { get; set; }
        public virtual DbSet<AccessControlLog> AccessControlLogs { get; set; }
        public virtual DbSet<AccessGroup> AccessGroups { get; set; }
        public virtual DbSet<AccessGroupEmployee> AccessGroupEmployees { get; set; }
        public virtual DbSet<AccessPlanGroupDoorMapping> AccessPlanGroupDoorMappings { get; set; }
        public virtual DbSet<AccessProfileAccessGroupMapping> AccessProfileAccessGroupMappings { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Accounts_Day> Accounts_Day { get; set; }
        public virtual DbSet<Accounts_Month> Accounts_Month { get; set; }
        public virtual DbSet<Accounts_Week> Accounts_Week { get; set; }
        public virtual DbSet<Accounts_Year> Accounts_Year { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<BookingPair> BookingPairs { get; set; }
        public virtual DbSet<Break> Breaks { get; set; }
        public virtual DbSet<BreaksMapped> BreaksMappeds { get; set; }
        public virtual DbSet<BreaksType> BreaksTypes { get; set; }
        public virtual DbSet<BuildingPlan> BuildingPlans { get; set; }
        public virtual DbSet<CCAccount> CCAccounts { get; set; }
        public virtual DbSet<CellPhoneMaster> CellPhoneMasters { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<CostCenter> CostCenters { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DailyAccountTime> DailyAccountTimes { get; set; }
        public virtual DbSet<DailyBooking> DailyBookings { get; set; }
        public virtual DbSet<DailyBookingsReport> DailyBookingsReports { get; set; }
        public virtual DbSet<DailyCalendar> DailyCalendars { get; set; }
        public virtual DbSet<DailyCalendarMapped> DailyCalendarMappeds { get; set; }
        public virtual DbSet<DailyProgramMapped> DailyProgramMappeds { get; set; }
        public virtual DbSet<DailyProgram> DailyPrograms { get; set; }
        public virtual DbSet<DatafoxTerminalInstance> DatafoxTerminalInstances { get; set; }
        public virtual DbSet<DatafoxTerminalReader> DatafoxTerminalReaders { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DP_Shifts> DP_Shifts { get; set; }
        public virtual DbSet<DynamicColumn> DynamicColumns { get; set; }
        public virtual DbSet<DynamicField> DynamicFields { get; set; }
        public virtual DbSet<DynamicFieldsMember> DynamicFieldsMembers { get; set; }
        public virtual DbSet<EmpAdditionalInfo> EmpAdditionalInfoes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeAbsence> EmployeeAbsences { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfoes { get; set; }
        public virtual DbSet<EmployeePhoto> EmployeePhotos { get; set; }
        public virtual DbSet<EmployeeTariff> EmployeeTariffs { get; set; }
        public virtual DbSet<ERP_Anrede> ERP_Anrede { get; set; }
        public virtual DbSet<ERP_KAnsprechp> ERP_KAnsprechp { get; set; }
        public virtual DbSet<ERP_Kunden> ERP_Kunden { get; set; }
        public virtual DbSet<ERP_KundenGr> ERP_KundenGr { get; set; }
        public virtual DbSet<ERP_KundenGrMark> ERP_KundenGrMark { get; set; }
        public virtual DbSet<ERP_KundenMark> ERP_KundenMark { get; set; }
        public virtual DbSet<ERP_Länder> ERP_Länder { get; set; }
        public virtual DbSet<ERP_SoftwareContractStatus> ERP_SoftwareContractStatus { get; set; }
        public virtual DbSet<ERP_SoftwareModules> ERP_SoftwareModules { get; set; }
        public virtual DbSet<ERP_SoftwareUpdateService> ERP_SoftwareUpdateService { get; set; }
        public virtual DbSet<FingerprintPassword> FingerprintPasswords { get; set; }
        public virtual DbSet<FingerPrint> FingerPrints { get; set; }
        public virtual DbSet<Global_Settings> Global_Settings { get; set; }
        public virtual DbSet<GroupAccessProfile> GroupAccessProfiles { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<HolidayCalendar> HolidayCalendars { get; set; }
        public virtual DbSet<HolidayCalendarMonth> HolidayCalendarMonths { get; set; }
        public virtual DbSet<HolidayPlanAccessProfileMonth> HolidayPlanAccessProfileMonths { get; set; }
        public virtual DbSet<HolidayPlanCalendar> HolidayPlanCalendars { get; set; }
        public virtual DbSet<HolidayPlanCalendarMapped> HolidayPlanCalendarMappeds { get; set; }
        public virtual DbSet<HolidayPlanCalendarMonth> HolidayPlanCalendarMonths { get; set; }
        public virtual DbSet<HolidayPlanCalendarMonthMapped> HolidayPlanCalendarMonthMappeds { get; set; }
        public virtual DbSet<JC_Activities> JC_Activities { get; set; }
        public virtual DbSet<JC_Currency> JC_Currency { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationsFederalState> LocationsFederalStates { get; set; }
        public virtual DbSet<MapCalendar> MapCalendars { get; set; }
        public virtual DbSet<MapCalendarMapped> MapCalendarMappeds { get; set; }
        public virtual DbSet<MapCalendarMonth> MapCalendarMonths { get; set; }
        public virtual DbSet<MapCalendarMonthMapped> MapCalendarMonthMappeds { get; set; }
        public virtual DbSet<MemberAccessGroup> MemberAccessGroups { get; set; }
        public virtual DbSet<MemberCommonInfo> MemberCommonInfoes { get; set; }
        public virtual DbSet<MemberDrivingLicense> MemberDrivingLicenses { get; set; }
        public virtual DbSet<MemberDuration> MemberDurations { get; set; }
        public virtual DbSet<MemberDynamicField> MemberDynamicFields { get; set; }
        public virtual DbSet<MemberGroup> MemberGroups { get; set; }
        public virtual DbSet<MemberHealthCard> MemberHealthCards { get; set; }
        public virtual DbSet<MemberIdentityCard> MemberIdentityCards { get; set; }
        public virtual DbSet<MemberPassport> MemberPassports { get; set; }
        public virtual DbSet<MembersAccessPlanMapping> MembersAccessPlanMappings { get; set; }
        public virtual DbSet<MembersData> MembersDatas { get; set; }
        public virtual DbSet<MembersTransponder> MembersTransponders { get; set; }
        public virtual DbSet<MenuTable> MenuTables { get; set; }
        public virtual DbSet<MonthlyCalendar> MonthlyCalendars { get; set; }
        public virtual DbSet<MonthlyCalendarMapped> MonthlyCalendarMappeds { get; set; }
        public virtual DbSet<Pers_AccessGroups> Pers_AccessGroups { get; set; }
        public virtual DbSet<Pers_AccessPlanDuration> Pers_AccessPlanDuration { get; set; }
        public virtual DbSet<Pers_AdditionalInfo> Pers_AdditionalInfo { get; set; }
        public virtual DbSet<Pers_Areas> Pers_Areas { get; set; }
        public virtual DbSet<Pers_Client> Pers_Client { get; set; }
        public virtual DbSet<Pers_Contact> Pers_Contact { get; set; }
        public virtual DbSet<Pers_CostCenters> Pers_CostCenters { get; set; }
        public virtual DbSet<Pers_Departments> Pers_Departments { get; set; }
        public virtual DbSet<Pers_DrivingLicense> Pers_DrivingLicense { get; set; }
        public virtual DbSet<Pers_DynamicFields> Pers_DynamicFields { get; set; }
        public virtual DbSet<Pers_HealthCard> Pers_HealthCard { get; set; }
        public virtual DbSet<Pers_IdentityCard> Pers_IdentityCard { get; set; }
        public virtual DbSet<Pers_Locations> Pers_Locations { get; set; }
        public virtual DbSet<Pers_Passport> Pers_Passport { get; set; }
        public virtual DbSet<Pers_Photo> Pers_Photo { get; set; }
        public virtual DbSet<Pers_PinCode> Pers_PinCode { get; set; }
        public virtual DbSet<Pers_Transponders> Pers_Transponders { get; set; }
        public virtual DbSet<Pers_Type> Pers_Type { get; set; }
        public virtual DbSet<Pers_Vehicles> Pers_Vehicles { get; set; }
        public virtual DbSet<Pers_Visitors> Pers_Visitors { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<PersonnelTariff> PersonnelTariffs { get; set; }
        public virtual DbSet<PlannedCalendar> PlannedCalendars { get; set; }
        public virtual DbSet<PlannedCalendarMapped> PlannedCalendarMappeds { get; set; }
        public virtual DbSet<PlannedCalendarTime> PlannedCalendarTimes { get; set; }
        public virtual DbSet<PlannedCalendarTimeMapped> PlannedCalendarTimeMappeds { get; set; }
        public virtual DbSet<Portal_Audit> Portal_Audit { get; set; }
        public virtual DbSet<Portal_PermissionMapping> Portal_PermissionMapping { get; set; }
        public virtual DbSet<Portal_PermissionProfile> Portal_PermissionProfile { get; set; }
        public virtual DbSet<Portal_Permissions> Portal_Permissions { get; set; }
        public virtual DbSet<Portal_ProfileUSerMapping> Portal_ProfileUSerMapping { get; set; }
        public virtual DbSet<Portal_Users> Portal_Users { get; set; }
        public virtual DbSet<RawBooking> RawBookings { get; set; }
        public virtual DbSet<ReaderAccessPlan> ReaderAccessPlans { get; set; }
        public virtual DbSet<ReaderAssigned> ReaderAssigneds { get; set; }
        public virtual DbSet<ReaderVisitorPlan> ReaderVisitorPlans { get; set; }
        public virtual DbSet<ResourceEvent> ResourceEvents { get; set; }
        public virtual DbSet<ResourceEventMapped> ResourceEventMappeds { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Shift_Breaks> Shift_Breaks { get; set; }
        public virtual DbSet<ShiftResource> ShiftResources { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Specialday> Specialdays { get; set; }
        public virtual DbSet<Status_Static> Status_Static { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SurchargeDay> SurchargeDays { get; set; }
        public virtual DbSet<SurchargeMapped> SurchargeMappeds { get; set; }
        public virtual DbSet<Surcharge> Surcharges { get; set; }
        public virtual DbSet<SurchargesAccountsMapping> SurchargesAccountsMappings { get; set; }
        public virtual DbSet<SwitchCalendar> SwitchCalendars { get; set; }
        public virtual DbSet<SwitchCalendarMapped> SwitchCalendarMappeds { get; set; }
        public virtual DbSet<SwitchCalendarMonth> SwitchCalendarMonths { get; set; }
        public virtual DbSet<SwitchCalendarMonthMapped> SwitchCalendarMonthMappeds { get; set; }
        public virtual DbSet<SwitchPlan> SwitchPlans { get; set; }
        public virtual DbSet<SwitchProfilePair> SwitchProfilePairs { get; set; }
        public virtual DbSet<SwitchProfile> SwitchProfiles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TA_BookingsReport> TA_BookingsReport { get; set; }
        public virtual DbSet<TA_BookingsReportAbsences> TA_BookingsReportAbsences { get; set; }
        public virtual DbSet<TA_BookingsReportAccounts> TA_BookingsReportAccounts { get; set; }
        public virtual DbSet<TA_BookingsReportTitles> TA_BookingsReportTitles { get; set; }
        public virtual DbSet<TA_BookingsReportTypes> TA_BookingsReportTypes { get; set; }
        public virtual DbSet<TA_PersonalGroupMapping> TA_PersonalGroupMapping { get; set; }
        public virtual DbSet<TA_TerminalGroupMapping> TA_TerminalGroupMapping { get; set; }
        public virtual DbSet<TA_TerminalGroups> TA_TerminalGroups { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }
        public virtual DbSet<TariffCalendar> TariffCalendars { get; set; }
        public virtual DbSet<TbAccessPlan> TbAccessPlans { get; set; }
        public virtual DbSet<TbAccessPlanGroup> TbAccessPlanGroups { get; set; }
        public virtual DbSet<TbAccessPlanMembersMapping> TbAccessPlanMembersMappings { get; set; }
        public virtual DbSet<TbAccessPlanPersMapping> TbAccessPlanPersMappings { get; set; }
        public virtual DbSet<TbAcessPlanReaderMapping> TbAcessPlanReaderMappings { get; set; }
        public virtual DbSet<TbVisitorPlan> TbVisitorPlans { get; set; }
        public virtual DbSet<TerminalBookingRawData> TerminalBookingRawDatas { get; set; }
        public virtual DbSet<TerminalConfig> TerminalConfigs { get; set; }
        public virtual DbSet<TerminalConnect> TerminalConnects { get; set; }
        public virtual DbSet<TerminalConnectionType> TerminalConnectionTypes { get; set; }
        public virtual DbSet<TerminalDatafoxFunction> TerminalDatafoxFunctions { get; set; }
        public virtual DbSet<TerminalFunctionKey> TerminalFunctionKeys { get; set; }
        public virtual DbSet<TerminalGroupMapping> TerminalGroupMappings { get; set; }
        public virtual DbSet<TerminalGroup> TerminalGroups { get; set; }
        public virtual DbSet<TerminalInfo> TerminalInfoes { get; set; }
        public virtual DbSet<TerminalInfoText> TerminalInfoTexts { get; set; }
        public virtual DbSet<TerminalOEM> TerminalOEMs { get; set; }
        public virtual DbSet<TerminalReader> TerminalReaders { get; set; }
        public virtual DbSet<TerminalReadersStatic> TerminalReadersStatics { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }
        public virtual DbSet<TerminalSignalBreak> TerminalSignalBreaks { get; set; }
        public virtual DbSet<TerminalUtility> TerminalUtilities { get; set; }
        public virtual DbSet<TimeRanx> TimeRanges { get; set; }
        public virtual DbSet<Transponder> Transponders { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<VirtualPersonalGroupsMapping> VirtualPersonalGroupsMappings { get; set; }
        public virtual DbSet<VirtualTerminal> VirtualTerminals { get; set; }
        public virtual DbSet<VirtualTerminalCommunicationSetting> VirtualTerminalCommunicationSettings { get; set; }
        public virtual DbSet<VirtualTerminalFunctionKey> VirtualTerminalFunctionKeys { get; set; }
        public virtual DbSet<VirtualTerminalGroup> VirtualTerminalGroups { get; set; }
        public virtual DbSet<VirtualTerminalGroupsMapping> VirtualTerminalGroupsMappings { get; set; }
        public virtual DbSet<VirtualTerminalInputSetting> VirtualTerminalInputSettings { get; set; }
        public virtual DbSet<Visitor_Vehicle> Visitor_Vehicle { get; set; }
        public virtual DbSet<VisitorAccessTime> VisitorAccessTimes { get; set; }
        public virtual DbSet<VisitorAdditionalInfo> VisitorAdditionalInfoes { get; set; }
        public virtual DbSet<VisitorApplication> VisitorApplications { get; set; }
        public virtual DbSet<VisitorCompanyTb> VisitorCompanyTbs { get; set; }
        public virtual DbSet<VisitorContact> VisitorContacts { get; set; }
        public virtual DbSet<VisitorPlanGroup> VisitorPlanGroups { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<VisitorTransponder> VisitorTransponders { get; set; }
        public virtual DbSet<VisitorType> VisitorTypes { get; set; }
        public virtual DbSet<WorkedHoursAcc> WorkedHoursAccs { get; set; }
        public virtual DbSet<ZuttritProfile> ZuttritProfiles { get; set; }
        public virtual DbSet<ZuttritProfilesTimeFrame> ZuttritProfilesTimeFrames { get; set; }
        public virtual DbSet<AuditHist> AuditHists { get; set; }
        public virtual DbSet<JC_Projects> JC_Projects { get; set; }
        public virtual DbSet<Pers_Archive> Pers_Archive { get; set; }
        public virtual DbSet<ShiftResourceBac> ShiftResourceBacs { get; set; }
        public virtual DbSet<Status_Dynamic> Status_Dynamic { get; set; }
        public virtual DbSet<TerminalOEMNew> TerminalOEMNews { get; set; }
        public virtual DbSet<TerminalsNew> TerminalsNews { get; set; }
        public virtual DbSet<AC_PersPasswordsProfile> AC_PersPasswordsProfile { get; set; }
        public virtual DbSet<AC_vwPersonelAccessPlan> AC_vwPersonelAccessPlan { get; set; }
        public virtual DbSet<DF_TIME> DF_TIME { get; set; }
        public virtual DbSet<HolidayAccessPlam_with_DateTime> HolidayAccessPlam_with_DateTime { get; set; }
        public virtual DbSet<HolidayCalendar_with_DateTime> HolidayCalendar_with_DateTime { get; set; }
        public virtual DbSet<MV_AccessControlLogs> MV_AccessControlLogs { get; set; }
        public virtual DbSet<MV_AccessControlTransactionPersonel> MV_AccessControlTransactionPersonel { get; set; }
        public virtual DbSet<MV_TerminalReaderBuildingPlans> MV_TerminalReaderBuildingPlans { get; set; }
        public virtual DbSet<RV_AccessPlanAccessCalendar> RV_AccessPlanAccessCalendar { get; set; }
        public virtual DbSet<RV_AccessPlanPersonnel> RV_AccessPlanPersonnel { get; set; }
        public virtual DbSet<RV_AccessProfilesPerTerminal> RV_AccessProfilesPerTerminal { get; set; }
        public virtual DbSet<RV_HolidayCalendar> RV_HolidayCalendar { get; set; }
        public virtual DbSet<RV_HolidayCalendarAccessPlan> RV_HolidayCalendarAccessPlan { get; set; }
        public virtual DbSet<RV_HolidayCalendarNames> RV_HolidayCalendarNames { get; set; }
        public virtual DbSet<RV_HolidayPlanAccessPlan> RV_HolidayPlanAccessPlan { get; set; }
        public virtual DbSet<RV_HolidayPlanAccessProfilesPerTerminal> RV_HolidayPlanAccessProfilesPerTerminal { get; set; }
        public virtual DbSet<RV_HolidayPlanPerTerminal> RV_HolidayPlanPerTerminal { get; set; }
        public virtual DbSet<RV_HolidayPlanSwitchPlan> RV_HolidayPlanSwitchPlan { get; set; }
        public virtual DbSet<RV_SwitchPlanSwitchCalendar> RV_SwitchPlanSwitchCalendar { get; set; }
        public virtual DbSet<RV_SwitchProfileGroupedPerTerminal> RV_SwitchProfileGroupedPerTerminal { get; set; }
        public virtual DbSet<RV_VisitorPlanAccessCalendar> RV_VisitorPlanAccessCalendar { get; set; }
        public virtual DbSet<RV_VisitorPlanVisitors> RV_VisitorPlanVisitors { get; set; }
        public virtual DbSet<SCP> SCPs { get; set; }
        public virtual DbSet<SwitchCalendarProfile> SwitchCalendarProfiles { get; set; }
        public virtual DbSet<View_AccessCalendarProfiles> View_AccessCalendarProfiles { get; set; }
        public virtual DbSet<View_AccessLogs> View_AccessLogs { get; set; }
        public virtual DbSet<View_CardAllocationOverview> View_CardAllocationOverview { get; set; }
        public virtual DbSet<View_DFHoliday> View_DFHoliday { get; set; }
        public virtual DbSet<View_ERPSoftwareUpdateService> View_ERPSoftwareUpdateService { get; set; }
        public virtual DbSet<View_MemberAccessLog> View_MemberAccessLog { get; set; }
        public virtual DbSet<View_ReaderBuildingPlan> View_ReaderBuildingPlan { get; set; }
        public virtual DbSet<View_SwitchTimes> View_SwitchTimes { get; set; }
        public virtual DbSet<View_SwitchTimesCalendarProfiles> View_SwitchTimesCalendarProfiles { get; set; }
        public virtual DbSet<View_TeminalInformation> View_TeminalInformation { get; set; }
        public virtual DbSet<View_TerminalAccessProfiles> View_TerminalAccessProfiles { get; set; }
        public virtual DbSet<View_TerminalFunction> View_TerminalFunction { get; set; }
        public virtual DbSet<View_TerminalHolidays> View_TerminalHolidays { get; set; }
        public virtual DbSet<View_TerminalReader> View_TerminalReader { get; set; }
        public virtual DbSet<View_Transponders> View_Transponders { get; set; }
        public virtual DbSet<View_VisitorAccessLog> View_VisitorAccessLog { get; set; }
        public virtual DbSet<View_VisitorEntryLog> View_VisitorEntryLog { get; set; }
        public virtual DbSet<ViewMemberCardsInfo> ViewMemberCardsInfoes { get; set; }
        public virtual DbSet<ViewTA_TerminalGroupMapping> ViewTA_TerminalGroupMapping { get; set; }
        public virtual DbSet<ViewTerminalGroupMapping> ViewTerminalGroupMappings { get; set; }
        public virtual DbSet<VIS_PersPasswordsProfile> VIS_PersPasswordsProfile { get; set; }
        public virtual DbSet<vw_PermissionMapping> vw_PermissionMapping { get; set; }
        public virtual DbSet<vw_PortalKunden> vw_PortalKunden { get; set; }
        public virtual DbSet<vw_PortalUserProfile> vw_PortalUserProfile { get; set; }
        public virtual DbSet<vw_PortalUsersProfilePermissionMapping> vw_PortalUsersProfilePermissionMapping { get; set; }
        public virtual DbSet<vw_users> vw_users { get; set; }
        public virtual DbSet<VwHolidayCalender> VwHolidayCalenders { get; set; }
        public virtual DbSet<VwPersDataZUT> VwPersDataZUTs { get; set; }
        public virtual DbSet<VwPersonnelData> VwPersonnelDatas { get; set; }
        public virtual DbSet<vwPersPinCode> vwPersPinCodes { get; set; }
        public virtual DbSet<vwSwitchProfile> vwSwitchProfiles { get; set; }
        public virtual DbSet<vwVisitorCompany> vwVisitorCompanies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absence>()
                .Property(e => e.AbsenceNo)
                .IsFixedLength();

            modelBuilder.Entity<Absence>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Absence>()
                .Property(e => e.DistComment)
                .IsUnicode(false);

            modelBuilder.Entity<Absence>()
                .HasMany(e => e.EmployeeAbsences)
                .WithRequired(e => e.Absence)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Absence>()
                .HasMany(e => e.Specialdays)
                .WithOptional(e => e.Absence)
                .HasForeignKey(e => e.Absence_Reason);

            modelBuilder.Entity<AC_PermissionProfile>()
                .HasMany(e => e.AC_PermissionMapping)
                .WithRequired(e => e.AC_PermissionProfile)
                .HasForeignKey(e => e.ProfileId);

            modelBuilder.Entity<AC_PermissionProfile>()
                .HasMany(e => e.AC_PersProfileADMapping)
                .WithOptional(e => e.AC_PermissionProfile)
                .HasForeignKey(e => e.ProfileID);

            modelBuilder.Entity<AC_PermissionProfile>()
                .HasMany(e => e.AC_PersProfileMapping)
                .WithRequired(e => e.AC_PermissionProfile)
                .HasForeignKey(e => e.ProfileID);

            modelBuilder.Entity<AC_Permissions>()
                .HasMany(e => e.AC_PermissionMapping)
                .WithRequired(e => e.AC_Permissions)
                .HasForeignKey(e => e.PermissionKey);

            modelBuilder.Entity<AC_ReportList>()
                .HasMany(e => e.AC_ReportListChecks)
                .WithOptional(e => e.AC_ReportList)
                .HasForeignKey(e => e.ReportListID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AC_Reports>()
                .HasMany(e => e.AC_ReportSettings)
                .WithOptional(e => e.AC_Reports)
                .HasForeignKey(e => e.ReportID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AccessCalendar>()
                .HasMany(e => e.AccessCalendarMonths)
                .WithRequired(e => e.AccessCalendar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccessCalendar>()
                .HasMany(e => e.TbAccessPlanGroups)
                .WithOptional(e => e.AccessCalendar)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AccessControlLog>()
                .Property(e => e.TerminalSerial)
                .IsFixedLength();

            modelBuilder.Entity<AccessControlLog>()
                .Property(e => e.ReaderID)
                .IsFixedLength();

            modelBuilder.Entity<AccessGroup>()
                .HasMany(e => e.AccessProfileAccessGroupMappings)
                .WithRequired(e => e.AccessGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccessGroup>()
                .HasMany(e => e.AccessGroupEmployees)
                .WithRequired(e => e.AccessGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccessGroup>()
                .HasMany(e => e.ZuttritProfiles)
                .WithOptional(e => e.AccessGroup)
                .HasForeignKey(e => e.GroupID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Account>()
                .Property(e => e.AccountNo)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.AccInfo)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.DailyAccountTimes)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.SurchargesAccountsMappings)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Accounts_Day>()
                .HasOptional(e => e.Accounts_Month)
                .WithRequired(e => e.Accounts_Day);

            modelBuilder.Entity<Accounts_Day>()
                .HasOptional(e => e.Accounts_Week)
                .WithRequired(e => e.Accounts_Day);

            modelBuilder.Entity<Accounts_Day>()
                .HasOptional(e => e.Accounts_Year)
                .WithRequired(e => e.Accounts_Day);

            modelBuilder.Entity<Area>()
                .HasMany(e => e.Pers_Areas)
                .WithRequired(e => e.Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Break>()
                .Property(e => e.MinDiff)
                .IsFixedLength();

            modelBuilder.Entity<Break>()
                .HasMany(e => e.Shift_Breaks)
                .WithRequired(e => e.Break)
                .HasForeignKey(e => e.Break_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BreaksMapped>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<BreaksMapped>()
                .Property(e => e.MinDiff)
                .IsFixedLength();

            modelBuilder.Entity<BuildingPlan>()
                .HasMany(e => e.AccessPlanGroupDoorMappings)
                .WithOptional(e => e.BuildingPlan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BuildingPlan>()
                .HasMany(e => e.SwitchPlans)
                .WithOptional(e => e.BuildingPlan)
                .HasForeignKey(e => e.BuidingPlanID);

            modelBuilder.Entity<CellPhoneMaster>()
                .Property(e => e.CellID)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.VisitorAccessTimes)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.CompanyTo);

            modelBuilder.Entity<CostCenter>()
                .HasMany(e => e.Pers_CostCenters)
                .WithOptional(e => e.CostCenter)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DailyBooking>()
                .Property(e => e.Terminal)
                .IsUnicode(false);

            modelBuilder.Entity<DailyBooking>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<DailyCalendar>()
                .HasMany(e => e.PlannedCalendars)
                .WithOptional(e => e.DailyCalendar)
                .HasForeignKey(e => e.DailyCalendarId);

            modelBuilder.Entity<DailyCalendarMapped>()
                .HasMany(e => e.PlannedCalendarMappeds)
                .WithOptional(e => e.DailyCalendarMapped)
                .HasForeignKey(e => e.DailyCalendarId);

            modelBuilder.Entity<DailyProgramMapped>()
                .HasMany(e => e.ResourceEventMappeds)
                .WithRequired(e => e.DailyProgramMapped)
                .HasForeignKey(e => e.DailyProgramId);

            modelBuilder.Entity<DailyProgram>()
                .HasMany(e => e.DP_Shifts)
                .WithRequired(e => e.DailyProgram)
                .HasForeignKey(e => e.DP_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DatafoxTerminalInstance>()
                .HasMany(e => e.DatafoxTerminalReaders)
                .WithOptional(e => e.DatafoxTerminalInstance)
                .HasForeignKey(e => e.DatafoxTerminalID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Areas)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DeptId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Pers_Departments)
                .WithOptional(e => e.Department)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DP_Shifts>()
                .HasMany(e => e.Shift_Breaks)
                .WithRequired(e => e.DP_Shifts)
                .HasForeignKey(e => e.Shift_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DynamicColumn>()
                .HasMany(e => e.EmpAdditionalInfoes)
                .WithRequired(e => e.DynamicColumn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.AccessGroupEmployees)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Addresses)
                .WithOptional(e => e.Employee)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.DailyAccountTimes)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeAbsences)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeTariffs)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkedHoursAccs)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.EmpID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeInfo>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.EmployeeInfo)
                .HasForeignKey(e => e.InfoId);

            modelBuilder.Entity<ERP_Anrede>()
                .HasMany(e => e.MembersDatas)
                .WithOptional(e => e.ERP_Anrede)
                .HasForeignKey(e => e.Salutation);

            modelBuilder.Entity<HolidayCalendar>()
                .HasMany(e => e.HolidayCalendarMonths)
                .WithRequired(e => e.HolidayCalendar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HolidayCalendar>()
                .HasMany(e => e.HolidayPlanCalendars)
                .WithRequired(e => e.HolidayCalendar)
                .HasForeignKey(e => e.HolidayCalenderId);

            modelBuilder.Entity<HolidayPlanCalendar>()
                .HasMany(e => e.HolidayPlanCalendarMonths)
                .WithRequired(e => e.HolidayPlanCalendar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HolidayPlanCalendarMapped>()
                .HasMany(e => e.HolidayPlanCalendarMonthMappeds)
                .WithRequired(e => e.HolidayPlanCalendarMapped)
                .HasForeignKey(e => e.HolidayPlanCalendarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day1ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day2ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day3ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day4ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day5ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day6ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day7ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day8ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day9ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day10ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day11ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day12ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day13ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day14ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day15ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day16ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day17ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day18ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day19ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day20ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day21ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day22ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day23ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day24ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day25ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day26ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day27ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day28ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day29ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day30ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonth>()
                .Property(e => e.Day31ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day1ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day2ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day3ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day4ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day5ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day6ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day7ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day8ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day9ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day10ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day11ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day12ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day13ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day14ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day15ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day16ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day17ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day18ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day19ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day20ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day21ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day22ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day23ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day24ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day25ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day26ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day27ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day28ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day29ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day30ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<HolidayPlanCalendarMonthMapped>()
                .Property(e => e.Day31ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<JC_Currency>()
                .HasMany(e => e.JC_Activities)
                .WithRequired(e => e.JC_Currency)
                .HasForeignKey(e => e.CurrencyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LocationsFederalState>()
                .HasMany(e => e.Clients)
                .WithOptional(e => e.LocationsFederalState)
                .HasForeignKey(e => e.State);

            modelBuilder.Entity<MapCalendar>()
                .Property(e => e.MapCalendarIdNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MapCalendarMapped>()
                .Property(e => e.MapCalendarIdNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MapCalendarMapped>()
                .HasMany(e => e.MapCalendarMonthMappeds)
                .WithRequired(e => e.MapCalendarMapped)
                .HasForeignKey(e => e.MapCalendarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MapCalendarMapped>()
                .HasMany(e => e.Tariffs)
                .WithOptional(e => e.MapCalendarMapped)
                .HasForeignKey(e => e.MapCalendarId);

            modelBuilder.Entity<MemberDuration>()
                .HasMany(e => e.MembersDatas)
                .WithOptional(e => e.MemberDuration)
                .HasForeignKey(e => e.ContractDuration);

            modelBuilder.Entity<MembersData>()
                .HasMany(e => e.MemberAccessGroups)
                .WithRequired(e => e.MembersData)
                .HasForeignKey(e => e.MemberID);

            modelBuilder.Entity<MembersData>()
                .HasMany(e => e.MemberCommonInfoes)
                .WithOptional(e => e.MembersData)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MembersData>()
                .HasMany(e => e.MemberDrivingLicenses)
                .WithOptional(e => e.MembersData)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MembersData>()
                .HasMany(e => e.MemberDynamicFields)
                .WithOptional(e => e.MembersData)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MembersData>()
                .HasMany(e => e.MemberHealthCards)
                .WithOptional(e => e.MembersData)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MembersData>()
                .HasMany(e => e.MemberIdentityCards)
                .WithOptional(e => e.MembersData)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MembersData>()
                .HasMany(e => e.MemberPassports)
                .WithOptional(e => e.MembersData)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MembersData>()
                .HasMany(e => e.MembersAccessPlanMappings)
                .WithOptional(e => e.MembersData)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MembersData>()
                .HasMany(e => e.MembersTransponders)
                .WithRequired(e => e.MembersData)
                .HasForeignKey(e => e.MemberID);

            modelBuilder.Entity<MembersData>()
                .HasMany(e => e.TbAccessPlanMembersMappings)
                .WithRequired(e => e.MembersData)
                .HasForeignKey(e => e.MemberID);

            modelBuilder.Entity<MonthlyCalendar>()
                .HasMany(e => e.PlannedCalendars)
                .WithOptional(e => e.MonthlyCalendar)
                .HasForeignKey(e => e.MonthlyCalendarId);

            modelBuilder.Entity<MonthlyCalendarMapped>()
                .HasMany(e => e.PlannedCalendarMappeds)
                .WithOptional(e => e.MonthlyCalendarMapped)
                .HasForeignKey(e => e.MonthlyCalendarId);

            modelBuilder.Entity<Pers_Type>()
                .HasMany(e => e.Personals)
                .WithOptional(e => e.Pers_Type)
                .HasForeignKey(e => e.PersType);

            modelBuilder.Entity<Personal>()
                .HasMany(e => e.PersonnelTariffs)
                .WithRequired(e => e.Personal)
                .HasForeignKey(e => e.PersonnelID);

            modelBuilder.Entity<PlannedCalendar>()
                .Property(e => e.CalendarIdNumber)
                .IsUnicode(false);

            modelBuilder.Entity<PlannedCalendar>()
                .HasMany(e => e.DailyCalendars)
                .WithRequired(e => e.PlannedCalendar)
                .HasForeignKey(e => e.CalendarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlannedCalendar>()
                .HasMany(e => e.MonthlyCalendars)
                .WithRequired(e => e.PlannedCalendar)
                .HasForeignKey(e => e.CalendarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlannedCalendar>()
                .HasMany(e => e.PlannedCalendarTimes)
                .WithRequired(e => e.PlannedCalendar)
                .HasForeignKey(e => e.CalendarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlannedCalendarMapped>()
                .Property(e => e.CalendarType)
                .IsUnicode(false);

            modelBuilder.Entity<PlannedCalendarMapped>()
                .Property(e => e.CalendarIdNumber)
                .IsUnicode(false);

            modelBuilder.Entity<PlannedCalendarMapped>()
                .HasMany(e => e.DailyCalendarMappeds)
                .WithRequired(e => e.PlannedCalendarMapped)
                .HasForeignKey(e => e.CalendarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlannedCalendarMapped>()
                .HasMany(e => e.MonthlyCalendarMappeds)
                .WithRequired(e => e.PlannedCalendarMapped)
                .HasForeignKey(e => e.CalendarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlannedCalendarMapped>()
                .HasMany(e => e.PlannedCalendarTimeMappeds)
                .WithRequired(e => e.PlannedCalendarMapped)
                .HasForeignKey(e => e.CalendarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlannedCalendarMapped>()
                .HasMany(e => e.Tariffs)
                .WithOptional(e => e.PlannedCalendarMapped)
                .HasForeignKey(e => e.PlannedCalendarId);

            modelBuilder.Entity<Portal_PermissionProfile>()
                .HasMany(e => e.Portal_PermissionMapping)
                .WithRequired(e => e.Portal_PermissionProfile)
                .HasForeignKey(e => e.ProfileID);

            modelBuilder.Entity<Portal_PermissionProfile>()
                .HasMany(e => e.Portal_ProfileUSerMapping)
                .WithRequired(e => e.Portal_PermissionProfile)
                .HasForeignKey(e => e.ProfileID);

            modelBuilder.Entity<Portal_Permissions>()
                .HasMany(e => e.Portal_PermissionMapping)
                .WithRequired(e => e.Portal_Permissions)
                .HasForeignKey(e => e.PermissionKey);

            modelBuilder.Entity<Portal_Users>()
                .HasMany(e => e.Portal_ProfileUSerMapping)
                .WithRequired(e => e.Portal_Users)
                .HasForeignKey(e => e.USerID);

            modelBuilder.Entity<ResourceEvent>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ResourceEventMapped>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ShiftResource>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ShiftResource>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ShiftResource>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<ShiftResource>()
                .HasMany(e => e.ResourceEvents)
                .WithRequired(e => e.ShiftResource)
                .HasForeignKey(e => e.ResourceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShiftResource>()
                .HasMany(e => e.ResourceEventMappeds)
                .WithRequired(e => e.ShiftResource)
                .HasForeignKey(e => e.ResourceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shift>()
                .HasMany(e => e.ResourceEvents)
                .WithOptional(e => e.Shift)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SurchargeDay>()
                .HasMany(e => e.Surcharges)
                .WithOptional(e => e.SurchargeDay)
                .HasForeignKey(e => e.WeekDays_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SurchargeMapped>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SurchargeMapped>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<SurchargeMapped>()
                .HasMany(e => e.Tariffs)
                .WithOptional(e => e.SurchargeMapped)
                .HasForeignKey(e => e.SurchargeId);

            modelBuilder.Entity<SwitchCalendar>()
                .Property(e => e.SwitchCalendarNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SwitchCalendar>()
                .Property(e => e.SwitchCalendarName)
                .IsUnicode(false);

            modelBuilder.Entity<SwitchCalendar>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<SwitchCalendar>()
                .HasMany(e => e.SwitchCalendarMonths)
                .WithRequired(e => e.SwitchCalendar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SwitchCalendarMapped>()
                .Property(e => e.SwitchCalendarNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SwitchCalendarMapped>()
                .Property(e => e.SwitchCalendarName)
                .IsUnicode(false);

            modelBuilder.Entity<SwitchCalendarMapped>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<SwitchCalendarMapped>()
                .HasMany(e => e.SwitchCalendarMonthMappeds)
                .WithRequired(e => e.SwitchCalendarMapped)
                .HasForeignKey(e => e.SwitchCalendarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TA_BookingsReport>()
                .HasMany(e => e.TA_BookingsReportAbsences)
                .WithRequired(e => e.TA_BookingsReport)
                .HasForeignKey(e => e.ReportID);

            modelBuilder.Entity<TA_BookingsReport>()
                .HasMany(e => e.TA_BookingsReportAccounts)
                .WithRequired(e => e.TA_BookingsReport)
                .HasForeignKey(e => e.ReportID);

            modelBuilder.Entity<TA_BookingsReport>()
                .HasMany(e => e.TA_BookingsReportTitles)
                .WithRequired(e => e.TA_BookingsReport)
                .HasForeignKey(e => e.ReportID);

            modelBuilder.Entity<TA_TerminalGroups>()
                .HasMany(e => e.TA_PersonalGroupMapping)
                .WithOptional(e => e.TA_TerminalGroups)
                .HasForeignKey(e => e.TerminalGroupId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TA_TerminalGroups>()
                .HasMany(e => e.TA_TerminalGroupMapping)
                .WithOptional(e => e.TA_TerminalGroups)
                .HasForeignKey(e => e.TerminalGroupId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Tariff>()
                .Property(e => e.TariffIdNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Tariff>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<Tariff>()
                .HasMany(e => e.EmployeeTariffs)
                .WithRequired(e => e.Tariff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tariff>()
                .HasMany(e => e.TariffCalendars)
                .WithRequired(e => e.Tariff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TbAccessPlan>()
                .HasMany(e => e.MembersAccessPlanMappings)
                .WithOptional(e => e.TbAccessPlan)
                .HasForeignKey(e => e.AccessPlan_Nr)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TbAccessPlan>()
                .HasMany(e => e.ReaderAccessPlans)
                .WithOptional(e => e.TbAccessPlan)
                .HasForeignKey(e => e.AccessPlanId);

            modelBuilder.Entity<TbAccessPlan>()
                .HasMany(e => e.TbAccessPlanMembersMappings)
                .WithRequired(e => e.TbAccessPlan)
                .HasForeignKey(e => e.AccessPlan_ID);

            modelBuilder.Entity<TbAccessPlan>()
                .HasMany(e => e.TbAccessPlanPersMappings)
                .WithRequired(e => e.TbAccessPlan)
                .HasForeignKey(e => e.AccessPlan_Nr);

            modelBuilder.Entity<TbAccessPlanGroup>()
                .HasMany(e => e.AccessPlanGroupDoorMappings)
                .WithOptional(e => e.TbAccessPlanGroup)
                .HasForeignKey(e => e.AccessPlanGroupID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TbAccessPlanGroup>()
                .HasMany(e => e.MemberAccessGroups)
                .WithRequired(e => e.TbAccessPlanGroup)
                .HasForeignKey(e => e.GroupID);

            modelBuilder.Entity<TbAccessPlanGroup>()
                .HasMany(e => e.Pers_AccessGroups)
                .WithRequired(e => e.TbAccessPlanGroup)
                .HasForeignKey(e => e.GroupID);

            modelBuilder.Entity<TbVisitorPlan>()
                .HasMany(e => e.ReaderVisitorPlans)
                .WithOptional(e => e.TbVisitorPlan)
                .HasForeignKey(e => e.VisitorPlanId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TbVisitorPlan>()
                .HasMany(e => e.VisitorAccessTimes)
                .WithOptional(e => e.TbVisitorPlan)
                .HasForeignKey(e => e.VisitPlanId);

            modelBuilder.Entity<TerminalConfig>()
                .HasMany(e => e.TA_TerminalGroupMapping)
                .WithOptional(e => e.TerminalConfig)
                .HasForeignKey(e => e.TerminalInstanceId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TerminalConfig>()
                .HasMany(e => e.TerminalDatafoxFunctions)
                .WithRequired(e => e.TerminalConfig)
                .HasForeignKey(e => e.TerminalID);

            modelBuilder.Entity<TerminalConfig>()
                .HasMany(e => e.TerminalGroupMappings)
                .WithRequired(e => e.TerminalConfig)
                .HasForeignKey(e => e.TerminalInstanceId);

            modelBuilder.Entity<TerminalConfig>()
                .HasMany(e => e.TerminalReaders)
                .WithOptional(e => e.TerminalConfig)
                .HasForeignKey(e => e.TermID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TerminalConfig>()
                .HasMany(e => e.TerminalSignalBreaks)
                .WithOptional(e => e.TerminalConfig)
                .HasForeignKey(e => e.TerminalID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TerminalOEM>()
                .HasMany(e => e.Terminals)
                .WithOptional(e => e.TerminalOEM)
                .HasForeignKey(e => e.TermOEMID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TerminalReader>()
                .Property(e => e.Category)
                .IsFixedLength();

            modelBuilder.Entity<TerminalReader>()
                .HasMany(e => e.ReaderAccessPlans)
                .WithOptional(e => e.TerminalReader)
                .HasForeignKey(e => e.ReaderId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TerminalReader>()
                .HasMany(e => e.ReaderAssigneds)
                .WithRequired(e => e.TerminalReader)
                .HasForeignKey(e => e.ReaderID);

            modelBuilder.Entity<TerminalReader>()
                .HasMany(e => e.ReaderVisitorPlans)
                .WithOptional(e => e.TerminalReader)
                .HasForeignKey(e => e.ReaderId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TerminalReadersStatic>()
                .HasMany(e => e.TerminalReaders)
                .WithOptional(e => e.TerminalReadersStatic)
                .HasForeignKey(e => e.ReaderNr);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.Portal_Users)
                .WithRequired(e => e.UserRole)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VehicleType>()
                .HasMany(e => e.Pers_Vehicles)
                .WithOptional(e => e.VehicleType)
                .HasForeignKey(e => e.VehicleID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<VehicleType>()
                .HasMany(e => e.Visitor_Vehicle)
                .WithOptional(e => e.VehicleType)
                .HasForeignKey(e => e.VehicleID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<VehicleType>()
                .HasMany(e => e.Visitors)
                .WithOptional(e => e.VehicleType)
                .HasForeignKey(e => e.VisitorVehicleType);

            modelBuilder.Entity<VirtualTerminal>()
                .Property(e => e.TerminalCostCenter)
                .IsFixedLength();

            modelBuilder.Entity<VirtualTerminalGroup>()
                .HasMany(e => e.VirtualPersonalGroupsMappings)
                .WithOptional(e => e.VirtualTerminalGroup)
                .HasForeignKey(e => e.VtermID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<VisitorApplication>()
                .Property(e => e.DOB)
                .HasPrecision(3);

            modelBuilder.Entity<VisitorApplication>()
                .Property(e => e.EntryDate)
                .HasPrecision(3);

            modelBuilder.Entity<VisitorApplication>()
                .Property(e => e.ExitDate)
                .HasPrecision(3);

            modelBuilder.Entity<VisitorApplication>()
                .HasMany(e => e.VisitorAdditionalInfoes)
                .WithRequired(e => e.VisitorApplication)
                .HasForeignKey(e => e.VisitorID);

            modelBuilder.Entity<VisitorApplication>()
                .HasMany(e => e.VisitorContacts)
                .WithRequired(e => e.VisitorApplication)
                .HasForeignKey(e => e.VisitorID);

            modelBuilder.Entity<VisitorCompanyTb>()
                .HasMany(e => e.Visitors)
                .WithOptional(e => e.VisitorCompanyTb)
                .HasForeignKey(e => e.Company);

            modelBuilder.Entity<WorkedHoursAcc>()
                .Property(e => e.HoursWorked)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ZuttritProfile>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<ZuttritProfile>()
                .HasMany(e => e.AccessProfileAccessGroupMappings)
                .WithRequired(e => e.ZuttritProfile)
                .HasForeignKey(e => e.AccessProfileID);

            modelBuilder.Entity<ZuttritProfile>()
                .HasMany(e => e.ZuttritProfilesTimeFrames)
                .WithOptional(e => e.ZuttritProfile)
                .HasForeignKey(e => e.AccessProfID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ShiftResourceBac>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ShiftResourceBac>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ShiftResourceBac>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<DF_TIME>()
                .Property(e => e.TimeFrom)
                .IsUnicode(false);

            modelBuilder.Entity<DF_TIME>()
                .Property(e => e.TimeTo)
                .IsUnicode(false);

            modelBuilder.Entity<MV_AccessControlTransactionPersonel>()
                .Property(e => e.ReaderID)
                .IsFixedLength();

            modelBuilder.Entity<MV_TerminalReaderBuildingPlans>()
                .Property(e => e.TerminalReaderID)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day1ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day2ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day3ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day4ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day5ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day6ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day7ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day8ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day9ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day10ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day11ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day12ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day13ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day14ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day15ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day16ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day17ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day18ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day19ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day20ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day21ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day22ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day23ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day24ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day25ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day26ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day27ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day28ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day29ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day30ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendar>()
                .Property(e => e.Day31ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day1ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day2ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day3ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day4ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day5ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day6ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day7ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day8ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day9ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day10ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day11ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day12ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day13ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day14ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day15ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day16ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day17ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day18ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day19ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day20ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day21ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day22ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day23ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day24ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day25ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day26ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day27ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day28ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day29ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day30ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarAccessPlan>()
                .Property(e => e.Day31ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarNames>()
                .Property(e => e.HolidayCalendarID)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayCalendarNames>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanAccessProfilesPerTerminal>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day1ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day2ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day3ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day4ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day5ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day6ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day7ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day8ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day9ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day10ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day11ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day12ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day13ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day14ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day15ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day16ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day17ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day18ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day19ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day20ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day21ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day22ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day23ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day24ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day25ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day26ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day27ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day28ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day29ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day30ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_HolidayPlanSwitchPlan>()
                .Property(e => e.Day31ProfileName)
                .IsUnicode(false);

            modelBuilder.Entity<RV_SwitchPlanSwitchCalendar>()
                .Property(e => e.SwitchCalendarNumber)
                .IsUnicode(false);

            modelBuilder.Entity<RV_SwitchPlanSwitchCalendar>()
                .Property(e => e.SwitchCalendarName)
                .IsUnicode(false);

            modelBuilder.Entity<View_DFHoliday>()
                .Property(e => e.HolidayDate)
                .IsUnicode(false);

            modelBuilder.Entity<View_MemberAccessLog>()
                .Property(e => e.TerminalSerial)
                .IsFixedLength();

            modelBuilder.Entity<View_MemberAccessLog>()
                .Property(e => e.ReaderID)
                .IsFixedLength();

            modelBuilder.Entity<View_SwitchTimes>()
                .Property(e => e.Weekdays)
                .IsUnicode(false);

            modelBuilder.Entity<View_TeminalInformation>()
                .Property(e => e.unique_id)
                .IsUnicode(false);

            modelBuilder.Entity<View_TerminalFunction>()
                .Property(e => e.AccountNo)
                .IsUnicode(false);

            modelBuilder.Entity<View_TerminalReader>()
                .Property(e => e.unique_id)
                .IsUnicode(false);

            modelBuilder.Entity<View_VisitorAccessLog>()
                .Property(e => e.TerminalSerial)
                .IsFixedLength();

            modelBuilder.Entity<View_VisitorAccessLog>()
                .Property(e => e.ReaderID)
                .IsFixedLength();

            modelBuilder.Entity<View_VisitorEntryLog>()
                .Property(e => e.TerminalSerial)
                .IsFixedLength();

            modelBuilder.Entity<View_VisitorEntryLog>()
                .Property(e => e.ReaderID)
                .IsFixedLength();

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day1ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day2ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day3ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day4ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day5ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day6ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day7ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day8ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day9ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day10ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day11ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day12ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day13ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day14ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day15ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day16ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day17ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day18ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day19ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day20ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day21ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day22ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day23ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day24ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day25ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day26ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day27ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day28ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day29ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day30ProfileHolidayId)
                .IsUnicode(false);

            modelBuilder.Entity<VwHolidayCalender>()
                .Property(e => e.Day31ProfileHolidayId)
                .IsUnicode(false);
        }
    }
}
