namespace KruAll.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class command : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AbsenceNo = c.String(maxLength: 10, fixedLength: true),
                        Indicator = c.String(maxLength: 50),
                        Name = c.String(),
                        Type = c.String(),
                        Comment = c.String(unicode: false, storeType: "text"),
                        BookingStatus = c.Boolean(),
                        ForeColor = c.Int(),
                        BackColor = c.Int(),
                        Priority = c.Double(),
                        Factor = c.Double(),
                        DistComment = c.String(unicode: false, storeType: "text"),
                        DistFactor = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeeAbsence",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        AbsenceId = c.Int(nullable: false),
                        AbsenceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Absences", t => t.AbsenceId)
                .Index(t => t.EmployeeId)
                .Index(t => t.AbsenceId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmpNumber = c.Int(nullable: false),
                        PassportID = c.String(nullable: false),
                        Identification = c.Int(nullable: false),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        Status = c.Boolean(nullable: false),
                        Identification2 = c.Int(),
                        Identification3 = c.Int(),
                        MiFareID = c.String(),
                        JoiningDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CustomerID = c.Int(),
                        InfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeeInfo", t => t.InfoId, cascadeDelete: true)
                .Index(t => t.InfoId);
            
            CreateTable(
                "dbo.AccessGroupEmployee",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AccessGroupId = c.Long(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccessGroup", t => t.AccessGroupId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.AccessGroupId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AccessGroup",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AccessGroupNumber = c.Int(nullable: false),
                        AccessGroupName = c.String(nullable: false),
                        AccessGroupType = c.Int(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccessProfileAccessGroupMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccessProfileID = c.Long(nullable: false),
                        AccessGroupID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ZuttritProfiles", t => t.AccessProfileID, cascadeDelete: true)
                .ForeignKey("dbo.AccessGroup", t => t.AccessGroupID)
                .Index(t => t.AccessProfileID)
                .Index(t => t.AccessGroupID);
            
            CreateTable(
                "dbo.ZuttritProfiles",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        GroupID = c.Long(),
                        AccessProfileNo = c.Int(nullable: false),
                        AccessProfileID = c.String(nullable: false, maxLength: 100),
                        AccessDescription = c.String(nullable: false),
                        DisplayProfiles = c.Boolean(nullable: false),
                        Memo = c.String(unicode: false, storeType: "text"),
                        ForeColour = c.String(),
                        BackColour = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccessGroup", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.ZuttritProfilesTimeFrames",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccessProfID = c.Long(),
                        ProfilAktiv = c.Boolean(nullable: false),
                        Level = c.Int(nullable: false),
                        MonFrom = c.DateTime(nullable: false),
                        MonTo = c.DateTime(nullable: false),
                        TueFrom = c.DateTime(nullable: false),
                        TueTo = c.DateTime(nullable: false),
                        WedFrom = c.DateTime(nullable: false),
                        WedTo = c.DateTime(nullable: false),
                        ThurFrom = c.DateTime(nullable: false),
                        ThurTo = c.DateTime(nullable: false),
                        FriFrom = c.DateTime(nullable: false),
                        FriTo = c.DateTime(nullable: false),
                        SatFrom = c.DateTime(nullable: false),
                        SatTo = c.DateTime(nullable: false),
                        SunFrom = c.DateTime(nullable: false),
                        SunTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ZuttritProfiles", t => t.AccessProfID, cascadeDelete: true)
                .Index(t => t.AccessProfID);
            
            CreateTable(
                "dbo.TbAccessPlan",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccessPlanNr = c.Long(nullable: false),
                        AccessPlanDescription = c.String(),
                        AccessGroupID = c.Long(nullable: false),
                        AccessCalendarId = c.Long(),
                        BuildingPlanID = c.Long(),
                        HolidayPlanCalendarId = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccessGroup", t => t.AccessGroupID, cascadeDelete: true)
                .ForeignKey("dbo.HolidayPlanCalendar", t => t.HolidayPlanCalendarId)
                .ForeignKey("dbo.BuildingPlan", t => t.BuildingPlanID)
                .Index(t => t.AccessGroupID)
                .Index(t => t.BuildingPlanID)
                .Index(t => t.HolidayPlanCalendarId);
            
            CreateTable(
                "dbo.BuildingPlan",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PlanNr = c.Int(nullable: false),
                        PlanName = c.String(nullable: false),
                        PlanDefinition = c.String(nullable: false),
                        Memo = c.String(),
                        LastNodeKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AccessPlanGroupDoorMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccessPlanGroupID = c.Long(),
                        BuildingPlanID = c.Long(),
                        LocationID = c.Long(),
                        BuildingID = c.Long(),
                        FloorID = c.Long(),
                        RoomID = c.Long(),
                        DoorID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TbAccessPlanGroup", t => t.AccessPlanGroupID, cascadeDelete: true)
                .ForeignKey("dbo.BuildingPlan", t => t.BuildingPlanID, cascadeDelete: true)
                .Index(t => t.AccessPlanGroupID)
                .Index(t => t.BuildingPlanID);
            
            CreateTable(
                "dbo.TbAccessPlanGroup",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccessPlanGroupNr = c.Long(nullable: false),
                        AccessPlanGroupName = c.String(),
                        BuildingPlanID = c.Long(),
                        AccessCalendarId = c.Long(),
                        HolidayPlanCalendarId = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccessCalendar", t => t.AccessCalendarId, cascadeDelete: true)
                .ForeignKey("dbo.HolidayPlanCalendar", t => t.HolidayPlanCalendarId)
                .ForeignKey("dbo.BuildingPlan", t => t.BuildingPlanID)
                .Index(t => t.BuildingPlanID)
                .Index(t => t.AccessCalendarId)
                .Index(t => t.HolidayPlanCalendarId);
            
            CreateTable(
                "dbo.AccessCalendar",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Calendar_Nr = c.Int(nullable: false),
                        Calendar_Name = c.String(),
                        AccessProfileID = c.Long(nullable: false),
                        Memo = c.String(),
                        CheckMon = c.Boolean(nullable: false),
                        CheckTue = c.Boolean(nullable: false),
                        CheckWed = c.Boolean(nullable: false),
                        CheckThur = c.Boolean(nullable: false),
                        CheckFri = c.Boolean(nullable: false),
                        CheckSat = c.Boolean(nullable: false),
                        CheckSun = c.Boolean(nullable: false),
                        CalendarDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AccessCalendarMonth",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccessCalendarID = c.Long(nullable: false),
                        AccessCalendarMonthNr = c.Int(nullable: false),
                        Day1AccessProfileID = c.Int(nullable: false),
                        Day2AccessProfileID = c.Int(nullable: false),
                        Day3AccessProfileID = c.Int(nullable: false),
                        Day4AccessProfileID = c.Int(nullable: false),
                        Day5AccessProfileID = c.Int(nullable: false),
                        Day6AccessProfileID = c.Int(nullable: false),
                        Day7AccessProfileID = c.Int(nullable: false),
                        Day8AccessProfileID = c.Int(nullable: false),
                        Day9AccessProfileID = c.Int(nullable: false),
                        Day10AccessProfileID = c.Int(nullable: false),
                        Day11AccessProfileID = c.Int(nullable: false),
                        Day12AccessProfileID = c.Int(nullable: false),
                        Day13AccessProfileID = c.Int(nullable: false),
                        Day14AccessProfileID = c.Int(nullable: false),
                        Day15AccessProfileID = c.Int(nullable: false),
                        Day16AccessProfileID = c.Int(nullable: false),
                        Day17AccessProfileID = c.Int(nullable: false),
                        Day18AccessProfileID = c.Int(nullable: false),
                        Day19AccessProfileID = c.Int(nullable: false),
                        Day20AccessProfileID = c.Int(nullable: false),
                        Day21AccessProfileID = c.Int(nullable: false),
                        Day22AccessProfileID = c.Int(nullable: false),
                        Day23AccessProfileID = c.Int(nullable: false),
                        Day24AccessProfileID = c.Int(nullable: false),
                        Day25AccessProfileID = c.Int(nullable: false),
                        Day26AccessProfileID = c.Int(nullable: false),
                        Day27AccessProfileID = c.Int(nullable: false),
                        Day28AccessProfileID = c.Int(nullable: false),
                        Day29AccessProfileID = c.Int(nullable: false),
                        Day30AccessProfileID = c.Int(nullable: false),
                        Day31AccessProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccessCalendar", t => t.AccessCalendarID)
                .Index(t => t.AccessCalendarID);
            
            CreateTable(
                "dbo.TbVisitorPlan",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VisitorPlanNr = c.Long(nullable: false),
                        VisitorPlanDescription = c.String(),
                        AccessCalendarId = c.Long(),
                        BuildingPlanID = c.Long(),
                        HolidayPlanCalendarId = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccessCalendar", t => t.AccessCalendarId)
                .ForeignKey("dbo.BuildingPlan", t => t.BuildingPlanID)
                .ForeignKey("dbo.HolidayPlanCalendar", t => t.HolidayPlanCalendarId)
                .Index(t => t.AccessCalendarId)
                .Index(t => t.BuildingPlanID)
                .Index(t => t.HolidayPlanCalendarId);
            
            CreateTable(
                "dbo.HolidayPlanCalendar",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        HolidayCalenderId = c.Long(nullable: false),
                        CalendarYear = c.Int(nullable: false),
                        HolidayPlanCalendarNumber = c.Long(nullable: false),
                        HolidayPlanCalendarName = c.String(nullable: false),
                        Memo = c.String(),
                        AllowAccess = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HolidayCalendar", t => t.HolidayCalenderId, cascadeDelete: true)
                .Index(t => t.HolidayCalenderId);
            
            CreateTable(
                "dbo.HolidayCalendar",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarYear = c.Int(nullable: false),
                        HolidayCalendarNumber = c.Long(nullable: false),
                        HolidayCalendarName = c.String(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HolidayCalendarMonth",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        HolidayCalendarId = c.Long(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1HolidayId = c.Long(nullable: false),
                        Day2HolidayId = c.Long(nullable: false),
                        Day3HolidayId = c.Long(nullable: false),
                        Day4HolidayId = c.Long(nullable: false),
                        Day5HolidayId = c.Long(nullable: false),
                        Day6HolidayId = c.Long(nullable: false),
                        Day7HolidayId = c.Long(nullable: false),
                        Day8HolidayId = c.Long(nullable: false),
                        Day9HolidayId = c.Long(nullable: false),
                        Day10HolidayId = c.Long(nullable: false),
                        Day11HolidayId = c.Long(nullable: false),
                        Day12HolidayId = c.Long(nullable: false),
                        Day13HolidayId = c.Long(nullable: false),
                        Day14HolidayId = c.Long(nullable: false),
                        Day15HolidayId = c.Long(nullable: false),
                        Day16HolidayId = c.Long(nullable: false),
                        Day17HolidayId = c.Long(nullable: false),
                        Day18HolidayId = c.Long(nullable: false),
                        Day19HolidayId = c.Long(nullable: false),
                        Day20HolidayId = c.Long(nullable: false),
                        Day21HolidayId = c.Long(nullable: false),
                        Day22HolidayId = c.Long(nullable: false),
                        Day23HolidayId = c.Long(nullable: false),
                        Day24HolidayId = c.Long(nullable: false),
                        Day25HolidayId = c.Long(nullable: false),
                        Day26HolidayId = c.Long(nullable: false),
                        Day27HolidayId = c.Long(nullable: false),
                        Day28HolidayId = c.Long(nullable: false),
                        Day29HolidayId = c.Long(nullable: false),
                        Day30HolidayId = c.Long(nullable: false),
                        Day31HolidayId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HolidayCalendar", t => t.HolidayCalendarId)
                .Index(t => t.HolidayCalendarId);
            
            CreateTable(
                "dbo.HolidayPlanAccessProfileMonth",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        HolidayPlanCalendarId = c.Long(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1AccessProfileId = c.Long(nullable: false),
                        Day2AccessProfileId = c.Long(nullable: false),
                        Day3AccessProfileId = c.Long(nullable: false),
                        Day4AccessProfileId = c.Long(nullable: false),
                        Day5AccessProfileId = c.Long(nullable: false),
                        Day6AccessProfileId = c.Long(nullable: false),
                        Day7AccessProfileId = c.Long(nullable: false),
                        Day8AccessProfileId = c.Long(nullable: false),
                        Day9AccessProfileId = c.Long(nullable: false),
                        Day10AccessProfileId = c.Long(nullable: false),
                        Day11AccessProfileId = c.Long(nullable: false),
                        Day12AccessProfileId = c.Long(nullable: false),
                        Day13AccessProfileId = c.Long(nullable: false),
                        Day14AccessProfileId = c.Long(nullable: false),
                        Day15AccessProfileId = c.Long(nullable: false),
                        Day16AccessProfileId = c.Long(nullable: false),
                        Day17AccessProfileId = c.Long(nullable: false),
                        Day18AccessProfileId = c.Long(nullable: false),
                        Day19AccessProfileId = c.Long(nullable: false),
                        Day20AccessProfileId = c.Long(nullable: false),
                        Day21AccessProfileId = c.Long(nullable: false),
                        Day22AccessProfileId = c.Long(nullable: false),
                        Day23AccessProfileId = c.Long(nullable: false),
                        Day24AccessProfileId = c.Long(nullable: false),
                        Day25AccessProfileId = c.Long(nullable: false),
                        Day26AccessProfileId = c.Long(nullable: false),
                        Day27AccessProfileId = c.Long(nullable: false),
                        Day28AccessProfileId = c.Long(nullable: false),
                        Day29AccessProfileId = c.Long(nullable: false),
                        Day30AccessProfileId = c.Long(nullable: false),
                        Day31AccessProfileId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HolidayPlanCalendar", t => t.HolidayPlanCalendarId, cascadeDelete: true)
                .Index(t => t.HolidayPlanCalendarId);
            
            CreateTable(
                "dbo.HolidayPlanCalendarMonth",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        HolidayPlanCalendarId = c.Long(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day2ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day3ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day4ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day5ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day6ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day7ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day8ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day9ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day10ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day11ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day12ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day13ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day14ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day15ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day16ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day17ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day18ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day19ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day20ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day21ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day22ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day23ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day24ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day25ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day26ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day27ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day28ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day29ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day30ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day31ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HolidayPlanCalendar", t => t.HolidayPlanCalendarId)
                .Index(t => t.HolidayPlanCalendarId);
            
            CreateTable(
                "dbo.SwitchPlan",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SwitchPlanNumber = c.Long(nullable: false),
                        SwitchPlanName = c.String(nullable: false),
                        SwitchCalendarId = c.Long(),
                        BuidingPlanID = c.Long(),
                        HolidayPlanCalendarId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HolidayPlanCalendar", t => t.HolidayPlanCalendarId)
                .ForeignKey("dbo.SwitchCalendar", t => t.SwitchCalendarId)
                .ForeignKey("dbo.BuildingPlan", t => t.BuidingPlanID)
                .Index(t => t.SwitchCalendarId)
                .Index(t => t.BuidingPlanID)
                .Index(t => t.HolidayPlanCalendarId);
            
            CreateTable(
                "dbo.SwitchCalendar",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarYear = c.Int(nullable: false),
                        SwitchCalendarNumber = c.String(nullable: false, maxLength: 50, unicode: false),
                        SwitchCalendarName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Memo = c.String(maxLength: 400, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SwitchCalendarMonth",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SwitchCalendarId = c.Long(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1SwitchProfileId = c.Int(nullable: false),
                        Day2SwitchProfileId = c.Int(nullable: false),
                        Day3SwitchProfileId = c.Int(nullable: false),
                        Day4SwitchProfileId = c.Int(nullable: false),
                        Day5SwitchProfileId = c.Int(nullable: false),
                        Day6SwitchProfileId = c.Int(nullable: false),
                        Day7SwitchProfileId = c.Int(nullable: false),
                        Day8SwitchProfileId = c.Int(nullable: false),
                        Day9SwitchProfileId = c.Int(nullable: false),
                        Day10SwitchProfileId = c.Int(nullable: false),
                        Day11SwitchProfileId = c.Int(nullable: false),
                        Day12SwitchProfileId = c.Int(nullable: false),
                        Day13SwitchProfileId = c.Int(nullable: false),
                        Day14SwitchProfileId = c.Int(nullable: false),
                        Day15SwitchProfileId = c.Int(nullable: false),
                        Day16SwitchProfileId = c.Int(nullable: false),
                        Day17SwitchProfileId = c.Int(nullable: false),
                        Day18SwitchProfileId = c.Int(nullable: false),
                        Day19SwitchProfileId = c.Int(nullable: false),
                        Day20SwitchProfileId = c.Int(nullable: false),
                        Day21SwitchProfileId = c.Int(nullable: false),
                        Day22SwitchProfileId = c.Int(nullable: false),
                        Day23SwitchProfileId = c.Int(nullable: false),
                        Day24SwitchProfileId = c.Int(nullable: false),
                        Day25SwitchProfileId = c.Int(nullable: false),
                        Day26SwitchProfileId = c.Int(nullable: false),
                        Day27SwitchProfileId = c.Int(nullable: false),
                        Day28SwitchProfileId = c.Int(nullable: false),
                        Day29SwitchProfileId = c.Int(nullable: false),
                        Day30SwitchProfileId = c.Int(nullable: false),
                        Day31SwitchProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SwitchCalendar", t => t.SwitchCalendarId)
                .Index(t => t.SwitchCalendarId);
            
            CreateTable(
                "dbo.ReaderVisitorPlan",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ReaderId = c.Long(),
                        VisitorPlanId = c.Long(),
                        AccessPlanReaderStatus = c.Boolean(),
                        BuildingPlanID = c.Long(),
                        DoorID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TerminalReaders", t => t.ReaderId, cascadeDelete: true)
                .ForeignKey("dbo.TbVisitorPlan", t => t.VisitorPlanId, cascadeDelete: true)
                .Index(t => t.ReaderId)
                .Index(t => t.VisitorPlanId);
            
            CreateTable(
                "dbo.TerminalReaders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TermID = c.Long(),
                        ReaderID = c.Int(nullable: false),
                        ReaderNr = c.Int(),
                        Direction = c.Int(),
                        Status = c.Int(),
                        RelayTime = c.Int(),
                        ReaderInfo = c.String(),
                        Category = c.String(maxLength: 10, fixedLength: true),
                        BeforeAlarm = c.Long(),
                        AlarmFrom = c.Long(),
                        ReaderType = c.String(),
                        Name = c.String(),
                        Memo = c.String(),
                        Lock = c.Int(),
                        Delay = c.Int(),
                        ReaderImage = c.String(),
                        TerminalReaderID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TerminalConfig", t => t.TermID, cascadeDelete: true)
                .ForeignKey("dbo.TerminalReadersStatic", t => t.ReaderNr)
                .Index(t => t.TermID)
                .Index(t => t.ReaderNr);
            
            CreateTable(
                "dbo.ReaderAccessPlan",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ReaderId = c.Long(),
                        AccessPlanId = c.Long(),
                        AccessPlanReaderStatus = c.Boolean(),
                        BuildingPlanID = c.Long(),
                        DoorID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TerminalReaders", t => t.ReaderId, cascadeDelete: true)
                .ForeignKey("dbo.TbAccessPlan", t => t.AccessPlanId)
                .Index(t => t.ReaderId)
                .Index(t => t.AccessPlanId);
            
            CreateTable(
                "dbo.ReaderAssigned",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BuildingPlanID = c.Long(nullable: false),
                        LocationID = c.Int(),
                        BuildingID = c.Int(),
                        FloorID = c.Int(),
                        RoomID = c.Int(),
                        DoorID = c.Int(nullable: false),
                        TerminalID = c.Long(nullable: false),
                        ReaderID = c.Long(nullable: false),
                        ConnectionID = c.Int(nullable: false),
                        Assigned = c.Boolean(nullable: false),
                        Active = c.Boolean(),
                        AccessProfileActive = c.Boolean(),
                        SwitchProfileActive = c.Boolean(),
                        ManualOpeningActive = c.Boolean(),
                        PassBackNr = c.Int(),
                        TA_Come = c.Boolean(),
                        TA_Go = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BuildingPlan", t => t.BuildingPlanID, cascadeDelete: true)
                .ForeignKey("dbo.TerminalReaders", t => t.ReaderID, cascadeDelete: true)
                .Index(t => t.BuildingPlanID)
                .Index(t => t.ReaderID);
            
            CreateTable(
                "dbo.TerminalConfig",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TermID = c.Int(nullable: false),
                        TermType = c.String(nullable: false),
                        Description = c.String(),
                        TerminalConnectId = c.Int(),
                        TerminalInfoId = c.Int(),
                        TerminalOEMId = c.Int(),
                        Status = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        SerialNumber = c.String(),
                        ConnectionType = c.String(),
                        IpAddress = c.String(),
                        Port = c.Int(),
                        Memo = c.String(),
                        TerminalId = c.Int(),
                        ZkRelayTime = c.Int(),
                        ZkExternalReaders = c.Int(),
                        BreaksRelay = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Terminals", t => t.TerminalId)
                .ForeignKey("dbo.TerminalOEM", t => t.TerminalOEMId)
                .ForeignKey("dbo.TerminalConnect", t => t.TerminalConnectId)
                .ForeignKey("dbo.TerminalInfo", t => t.TerminalInfoId)
                .Index(t => t.TerminalConnectId)
                .Index(t => t.TerminalInfoId)
                .Index(t => t.TerminalOEMId)
                .Index(t => t.TerminalId);
            
            CreateTable(
                "dbo.TA_TerminalGroupMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TerminalGroupId = c.Long(),
                        TerminalInstanceId = c.Long(),
                        Pers_Nr = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TA_TerminalGroups", t => t.TerminalGroupId, cascadeDelete: true)
                .ForeignKey("dbo.TerminalConfig", t => t.TerminalInstanceId, cascadeDelete: true)
                .Index(t => t.TerminalGroupId)
                .Index(t => t.TerminalInstanceId);
            
            CreateTable(
                "dbo.TA_TerminalGroups",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        GroupNr = c.Long(nullable: false),
                        GroupDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TA_PersonalGroupMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TerminalGroupId = c.Long(),
                        Pers_Nr = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TA_TerminalGroups", t => t.TerminalGroupId, cascadeDelete: true)
                .Index(t => t.TerminalGroupId);
            
            CreateTable(
                "dbo.Terminals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TermType = c.String(),
                        Description = c.String(),
                        Connection = c.String(maxLength: 50),
                        Reader = c.String(),
                        Access = c.String(),
                        Image = c.String(),
                        TermOEM = c.String(),
                        TermOEMID = c.Int(),
                        TerminalPage = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TerminalOEM", t => t.TermOEMID, cascadeDelete: true)
                .Index(t => t.TermOEMID);
            
            CreateTable(
                "dbo.TerminalOEM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TermOEMId = c.Int(),
                        TermOEMDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TerminalConnect",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Connection = c.String(maxLength: 50),
                        IPAddress = c.String(nullable: false),
                        IPPort = c.String(nullable: false),
                        ActiveTerminal = c.Boolean(nullable: false),
                        PersnoPIN = c.Boolean(nullable: false),
                        FPRead = c.Boolean(nullable: false),
                        APPosting = c.Boolean(nullable: false),
                        TAPPosting = c.Boolean(nullable: false),
                        SerialNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TerminalDatafoxFunction",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TerminalID = c.Long(nullable: false),
                        BookingSpan = c.Int(nullable: false),
                        AccessControl = c.Boolean(),
                        Project = c.Boolean(),
                        ReaderList = c.Boolean(),
                        ActionList = c.Boolean(),
                        TimeList = c.Boolean(),
                        LocationList = c.Boolean(),
                        HolidayList = c.Boolean(),
                        IdentificationList = c.Boolean(),
                        EventList = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TerminalConfig", t => t.TerminalID, cascadeDelete: true)
                .Index(t => t.TerminalID);
            
            CreateTable(
                "dbo.TerminalFunctionKeys",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TerminalConfigID = c.Long(nullable: false),
                        FunctionKeyNr = c.Int(),
                        FunctionKeyText = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TerminalConfig", t => t.TerminalConfigID, cascadeDelete: true)
                .Index(t => t.TerminalConfigID);
            
            CreateTable(
                "dbo.TerminalGroupMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TerminalGroupId = c.Long(nullable: false),
                        TerminalInstanceId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TerminalGroups", t => t.TerminalGroupId, cascadeDelete: true)
                .ForeignKey("dbo.TerminalConfig", t => t.TerminalInstanceId, cascadeDelete: true)
                .Index(t => t.TerminalGroupId)
                .Index(t => t.TerminalInstanceId);
            
            CreateTable(
                "dbo.TerminalGroups",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        GroupNr = c.Long(nullable: false),
                        GroupDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TerminalInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InfoText1 = c.String(),
                        InfoText2 = c.String(),
                        InfoText3 = c.String(),
                        InfoText4 = c.String(),
                        Functionkey1 = c.String(nullable: false),
                        Functionkey2 = c.String(nullable: false),
                        Functionkey3 = c.String(nullable: false),
                        Functionkey4 = c.String(nullable: false),
                        Functionkey5 = c.String(nullable: false),
                        Functionkey6 = c.String(nullable: false),
                        Functionkey7 = c.String(nullable: false),
                        Functionkey8 = c.String(nullable: false),
                        DoorAssign = c.String(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TerminalInfoText",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TerminalConfigID = c.Long(nullable: false),
                        InfoTextNr = c.Int(),
                        InfoText = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TerminalConfig", t => t.TerminalConfigID, cascadeDelete: true)
                .Index(t => t.TerminalConfigID);
            
            CreateTable(
                "dbo.TerminalSignalBreaks",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TerminalID = c.Long(),
                        SignalBreakNr = c.Int(),
                        Monday = c.DateTime(precision: 7, storeType: "datetime2"),
                        Tuesday = c.DateTime(precision: 7, storeType: "datetime2"),
                        Wednesday = c.DateTime(precision: 7, storeType: "datetime2"),
                        Thursday = c.DateTime(precision: 7, storeType: "datetime2"),
                        Friday = c.DateTime(precision: 7, storeType: "datetime2"),
                        Saturday = c.DateTime(precision: 7, storeType: "datetime2"),
                        Sunday = c.DateTime(precision: 7, storeType: "datetime2"),
                        FreeDay = c.DateTime(precision: 7, storeType: "datetime2"),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TerminalConfig", t => t.TerminalID, cascadeDelete: true)
                .Index(t => t.TerminalID);
            
            CreateTable(
                "dbo.TerminalUtilities",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TerminalConfigID = c.Long(nullable: false),
                        HasFPRead = c.Boolean(nullable: false),
                        HasAPPosting = c.Boolean(nullable: false),
                        HasTAPPosting = c.Boolean(nullable: false),
                        HasPersNoPin = c.Boolean(nullable: false),
                        RFIDCardPin = c.Boolean(nullable: false),
                        RFIDActive = c.Boolean(nullable: false),
                        AllowTransponder = c.Boolean(nullable: false),
                        AllowTransponderAndPin = c.Boolean(nullable: false),
                        HasProfFirmware = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TerminalConfig", t => t.TerminalConfigID, cascadeDelete: true)
                .Index(t => t.TerminalConfigID);
            
            CreateTable(
                "dbo.TerminalReadersStatic",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReaderType = c.String(),
                        Description = c.String(),
                        Installation = c.String(),
                        Image = c.String(),
                        ReaderIdentifier = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitorAccessTime",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VisitorId = c.Long(nullable: false),
                        VisitInstanceId = c.Long(nullable: false),
                        CardNr = c.String(),
                        PinCode = c.String(),
                        VisitPlanId = c.Long(),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        AutoEndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        AutoEndDateStd = c.String(),
                        Memo = c.String(),
                        RegistrationDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        AccessPlanActive = c.Boolean(),
                        VisitAccessStartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        VisitAccessEndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        VisitReason = c.String(),
                        DateActivated = c.DateTime(precision: 7, storeType: "datetime2"),
                        PersNr = c.Long(),
                        CompanyTo = c.Long(),
                        IsCanceled = c.Boolean(),
                        AutoLogout = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.CompanyTo)
                .ForeignKey("dbo.Visitors", t => t.VisitorId, cascadeDelete: true)
                .ForeignKey("dbo.TbVisitorPlan", t => t.VisitPlanId)
                .Index(t => t.VisitorId)
                .Index(t => t.VisitPlanId)
                .Index(t => t.CompanyTo);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Client_Nr = c.Long(nullable: false),
                        Name = c.String(),
                        Function = c.String(),
                        InfoText = c.String(),
                        Street = c.String(),
                        Plz = c.String(),
                        HouseNr = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Ort = c.String(),
                        PersonInCharge = c.String(),
                        State = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LocationsFederalStates", t => t.State)
                .Index(t => t.State);
            
            CreateTable(
                "dbo.LocationsFederalStates",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        StateNo = c.Int(),
                        StateName = c.String(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_Client",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        ClientID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VisitorID = c.Long(nullable: false),
                        PersonalID = c.Long(),
                        SurName = c.String(),
                        Fullname = c.String(),
                        Company = c.Long(),
                        Street = c.String(),
                        VisitorNr = c.String(),
                        Location = c.String(),
                        Telephone = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        PostalCode = c.String(),
                        VisitorType = c.Int(),
                        StreetNr = c.String(),
                        DateActivated = c.DateTime(precision: 7, storeType: "datetime2"),
                        PersNr = c.Long(),
                        CompanyTo = c.Int(),
                        VisitorPhoto = c.String(),
                        CardActive = c.Boolean(),
                        VehicleRegNr = c.String(),
                        VisitorVehicleType = c.Long(),
                        VisitReason = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Personal", t => t.PersonalID)
                .ForeignKey("dbo.VehicleTypes", t => t.VisitorVehicleType)
                .ForeignKey("dbo.VisitorCompanyTb", t => t.Company)
                .Index(t => t.PersonalID)
                .Index(t => t.Company)
                .Index(t => t.VisitorVehicleType);
            
            CreateTable(
                "dbo.Personal",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        Title = c.String(),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        Card_Nr = c.Long(),
                        CardActive = c.Boolean(nullable: false),
                        ActiveCardType = c.Int(),
                        EntryDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExitDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        PersType = c.Long(),
                        Active = c.Boolean(nullable: false),
                        Memo = c.String(),
                        Imported = c.Boolean(nullable: false),
                        StreetNr = c.String(),
                        PostalCode = c.String(),
                        DeductionIsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pers_Type", t => t.PersType)
                .Index(t => t.PersType);
            
            CreateTable(
                "dbo.Pers_Type",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Memo = c.String(),
                        PersTypeColor = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PersonnelTariff",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PersonnelID = c.Long(nullable: false),
                        TariffID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tariff", t => t.TariffID, cascadeDelete: true)
                .ForeignKey("dbo.Personal", t => t.PersonnelID, cascadeDelete: true)
                .Index(t => t.PersonnelID)
                .Index(t => t.TariffID);
            
            CreateTable(
                "dbo.Tariff",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TariffNumber = c.Int(nullable: false),
                        TariffIdNumber = c.String(nullable: false, maxLength: 4, unicode: false),
                        TariffName = c.String(nullable: false),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidTo = c.DateTime(nullable: false),
                        Memo = c.String(unicode: false),
                        MapCalendarId = c.Long(),
                        PlannedCalendarId = c.Long(),
                        SurchargeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MapCalendarMapped", t => t.MapCalendarId)
                .ForeignKey("dbo.PlannedCalendarMapped", t => t.PlannedCalendarId)
                .ForeignKey("dbo.SurchargeMapped", t => t.SurchargeId)
                .Index(t => t.MapCalendarId)
                .Index(t => t.PlannedCalendarId)
                .Index(t => t.SurchargeId);
            
            CreateTable(
                "dbo.EmployeeTariff",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        TariffId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tariff", t => t.TariffId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.TariffId);
            
            CreateTable(
                "dbo.MapCalendarMapped",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarYear = c.Int(nullable: false),
                        MapCalendarNumber = c.Int(nullable: false),
                        MapCalendarIdNumber = c.String(nullable: false, maxLength: 4, unicode: false),
                        MapCalendarName = c.String(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MapCalendarMonthMapped",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MapCalendarId = c.Long(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1DailyProgramId = c.Int(nullable: false),
                        Day2DailyProgramId = c.Int(nullable: false),
                        Day3DailyProgramId = c.Int(nullable: false),
                        Day4DailyProgramId = c.Int(nullable: false),
                        Day5DailyProgramId = c.Int(nullable: false),
                        Day6DailyProgramId = c.Int(nullable: false),
                        Day7DailyProgramId = c.Int(nullable: false),
                        Day8DailyProgramId = c.Int(nullable: false),
                        Day9DailyProgramId = c.Int(nullable: false),
                        Day10DailyProgramId = c.Int(nullable: false),
                        Day11DailyProgramId = c.Int(nullable: false),
                        Day12DailyProgramId = c.Int(nullable: false),
                        Day13DailyProgramId = c.Int(nullable: false),
                        Day14DailyProgramId = c.Int(nullable: false),
                        Day15DailyProgramId = c.Int(nullable: false),
                        Day16DailyProgramId = c.Int(nullable: false),
                        Day17DailyProgramId = c.Int(nullable: false),
                        Day18DailyProgramId = c.Int(nullable: false),
                        Day19DailyProgramId = c.Int(nullable: false),
                        Day20DailyProgramId = c.Int(nullable: false),
                        Day21DailyProgramId = c.Int(nullable: false),
                        Day22DailyProgramId = c.Int(nullable: false),
                        Day23DailyProgramId = c.Int(nullable: false),
                        Day24DailyProgramId = c.Int(nullable: false),
                        Day25DailyProgramId = c.Int(nullable: false),
                        Day26DailyProgramId = c.Int(nullable: false),
                        Day27DailyProgramId = c.Int(nullable: false),
                        Day28DailyProgramId = c.Int(nullable: false),
                        Day29DailyProgramId = c.Int(nullable: false),
                        Day30DailyProgramId = c.Int(nullable: false),
                        Day31DailyProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MapCalendarMapped", t => t.MapCalendarId)
                .Index(t => t.MapCalendarId);
            
            CreateTable(
                "dbo.PlannedCalendarMapped",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarYear = c.Int(nullable: false),
                        CalendarType = c.String(nullable: false, maxLength: 10, unicode: false),
                        CalendarNumber = c.Int(nullable: false),
                        CalendarIdNumber = c.String(nullable: false, maxLength: 4, unicode: false),
                        CalendarName = c.String(nullable: false),
                        Monday = c.Boolean(nullable: false),
                        Tuesday = c.Boolean(nullable: false),
                        Wednesday = c.Boolean(nullable: false),
                        Thursday = c.Boolean(nullable: false),
                        Friday = c.Boolean(nullable: false),
                        Saturday = c.Boolean(nullable: false),
                        Sunday = c.Boolean(nullable: false),
                        Memo = c.String(),
                        DailyCalendarId = c.Long(),
                        MonthlyCalendarId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DailyCalendarMapped", t => t.DailyCalendarId)
                .ForeignKey("dbo.MonthlyCalendarMapped", t => t.MonthlyCalendarId)
                .Index(t => t.DailyCalendarId)
                .Index(t => t.MonthlyCalendarId);
            
            CreateTable(
                "dbo.DailyCalendarMapped",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarId = c.Long(nullable: false),
                        Monday = c.Time(nullable: false, precision: 7),
                        Tuesday = c.Time(nullable: false, precision: 7),
                        Wednesday = c.Time(nullable: false, precision: 7),
                        Thursday = c.Time(nullable: false, precision: 7),
                        Friday = c.Time(nullable: false, precision: 7),
                        Saturday = c.Time(nullable: false, precision: 7),
                        Sunday = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlannedCalendarMapped", t => t.CalendarId)
                .Index(t => t.CalendarId);
            
            CreateTable(
                "dbo.MonthlyCalendarMapped",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarId = c.Long(nullable: false),
                        January = c.Double(nullable: false),
                        February = c.Double(nullable: false),
                        March = c.Double(nullable: false),
                        April = c.Double(nullable: false),
                        May = c.Double(nullable: false),
                        June = c.Double(nullable: false),
                        July = c.Double(nullable: false),
                        August = c.Double(nullable: false),
                        September = c.Double(nullable: false),
                        October = c.Double(nullable: false),
                        November = c.Double(nullable: false),
                        December = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlannedCalendarMapped", t => t.CalendarId)
                .Index(t => t.CalendarId);
            
            CreateTable(
                "dbo.PlannedCalendarTimeMapped",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarId = c.Long(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1Hours = c.Time(nullable: false, precision: 7),
                        Day2Hours = c.Time(nullable: false, precision: 7),
                        Day3Hours = c.Time(nullable: false, precision: 7),
                        Day4Hours = c.Time(nullable: false, precision: 7),
                        Day5Hours = c.Time(nullable: false, precision: 7),
                        Day6Hours = c.Time(nullable: false, precision: 7),
                        Day7Hours = c.Time(nullable: false, precision: 7),
                        Day8Hours = c.Time(nullable: false, precision: 7),
                        Day9Hours = c.Time(nullable: false, precision: 7),
                        Day10Hours = c.Time(nullable: false, precision: 7),
                        Day11Hours = c.Time(nullable: false, precision: 7),
                        Day12Hours = c.Time(nullable: false, precision: 7),
                        Day13Hours = c.Time(nullable: false, precision: 7),
                        Day14Hours = c.Time(nullable: false, precision: 7),
                        Day15Hours = c.Time(nullable: false, precision: 7),
                        Day16Hours = c.Time(nullable: false, precision: 7),
                        Day17Hours = c.Time(nullable: false, precision: 7),
                        Day18Hours = c.Time(nullable: false, precision: 7),
                        Day19Hours = c.Time(nullable: false, precision: 7),
                        Day20Hours = c.Time(nullable: false, precision: 7),
                        Day21Hours = c.Time(nullable: false, precision: 7),
                        Day22Hours = c.Time(nullable: false, precision: 7),
                        Day23Hours = c.Time(nullable: false, precision: 7),
                        Day24Hours = c.Time(nullable: false, precision: 7),
                        Day25Hours = c.Time(nullable: false, precision: 7),
                        Day26Hours = c.Time(nullable: false, precision: 7),
                        Day27Hours = c.Time(nullable: false, precision: 7),
                        Day28Hours = c.Time(nullable: false, precision: 7),
                        Day29Hours = c.Time(nullable: false, precision: 7),
                        Day30Hours = c.Time(nullable: false, precision: 7),
                        Day31Hours = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlannedCalendarMapped", t => t.CalendarId)
                .Index(t => t.CalendarId);
            
            CreateTable(
                "dbo.SurchargeMapped",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Surchage_Nr = c.Int(nullable: false),
                        Name = c.String(nullable: false, unicode: false),
                        TimeFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        TimeTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        Memo = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TariffCalendar",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TariffId = c.Long(nullable: false),
                        CalendarYear = c.Int(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1TariffId = c.Long(nullable: false),
                        Day2TariffId = c.Long(nullable: false),
                        Day3TariffId = c.Long(nullable: false),
                        Day4TariffId = c.Long(nullable: false),
                        Day5TariffId = c.Long(nullable: false),
                        Day6TariffId = c.Long(nullable: false),
                        Day7TariffId = c.Long(nullable: false),
                        Day8TariffId = c.Long(nullable: false),
                        Day9TariffId = c.Long(nullable: false),
                        Day10TariffId = c.Long(nullable: false),
                        Day11TariffId = c.Long(nullable: false),
                        Day12TariffId = c.Long(nullable: false),
                        Day13TariffId = c.Long(nullable: false),
                        Day14TariffId = c.Long(nullable: false),
                        Day15TariffId = c.Long(nullable: false),
                        Day16TariffId = c.Long(nullable: false),
                        Day17TariffId = c.Long(nullable: false),
                        Day18TariffId = c.Long(nullable: false),
                        Day19TariffId = c.Long(nullable: false),
                        Day20TariffId = c.Long(nullable: false),
                        Day21TariffId = c.Long(nullable: false),
                        Day22TariffId = c.Long(nullable: false),
                        Day23TariffId = c.Long(nullable: false),
                        Day24TariffId = c.Long(nullable: false),
                        Day25TariffId = c.Long(nullable: false),
                        Day26TariffId = c.Long(nullable: false),
                        Day27TariffId = c.Long(nullable: false),
                        Day28TariffId = c.Long(nullable: false),
                        Day29TariffId = c.Long(nullable: false),
                        Day30TariffId = c.Long(nullable: false),
                        Day31TariffId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tariff", t => t.TariffId)
                .Index(t => t.TariffId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(),
                        Memo = c.String(),
                        VehicleNr = c.Int(),
                        VehiclePhoto = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_Vehicles",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        VehicleID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.Visitor_Vehicle",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VisitorID = c.Long(),
                        VehicleID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.VisitorCompanyTb",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CompanyNr = c.Long(nullable: false),
                        CompanyName = c.String(),
                        ZipCode = c.String(),
                        HouseNr = c.String(),
                        Place = c.String(),
                        Street = c.String(),
                        FederalState = c.Long(),
                        Name = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Memo = c.String(),
                        PersFunction = c.String(),
                        StreetNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitorTransponders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VisitorID = c.Long(nullable: false),
                        TransponderNr = c.Long(nullable: false),
                        TransponderStatus = c.Boolean(),
                        DateIssued = c.DateTime(precision: 7, storeType: "datetime2"),
                        ValidFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        ValidTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        TransponderDeactivatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        Action = c.Int(),
                        Memo = c.String(),
                        TransponderType = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Visitors", t => t.VisitorID, cascadeDelete: true)
                .Index(t => t.VisitorID);
            
            CreateTable(
                "dbo.MemberAccessGroups",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Long(nullable: false),
                        GroupID = c.Long(nullable: false),
                        Active = c.Boolean(nullable: false),
                        StartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MembersData", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.TbAccessPlanGroup", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.MemberID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.MembersData",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SurName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MemberGroupId = c.Long(),
                        Salutation = c.Int(),
                        Street = c.String(),
                        StreetNumber = c.String(),
                        PostalCode = c.String(),
                        Place = c.String(),
                        MemberNumber = c.Long(),
                        AgreementNr = c.String(),
                        ContractDuration = c.Long(),
                        DateOfBirth = c.DateTime(precision: 7, storeType: "datetime2"),
                        Nationality = c.String(),
                        Profession = c.String(),
                        Telephone = c.String(),
                        MobilePhone = c.String(),
                        Email = c.String(),
                        MemberPhoto = c.String(),
                        Memo = c.String(),
                        EntryDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExitDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ActiveCard = c.Int(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ERP_Anrede", t => t.Salutation)
                .ForeignKey("dbo.MemberDuration", t => t.ContractDuration)
                .ForeignKey("dbo.MemberGroups", t => t.MemberGroupId)
                .Index(t => t.MemberGroupId)
                .Index(t => t.Salutation)
                .Index(t => t.ContractDuration);
            
            CreateTable(
                "dbo.ERP_Anrede",
                c => new
                    {
                        AnredeCode = c.Int(nullable: false),
                        AnredeName = c.String(maxLength: 50),
                        StdBriefAnrede = c.String(maxLength: 50),
                        NameorVorname = c.Int(),
                        Titel = c.String(maxLength: 50),
                        Nummer = c.Int(),
                        Weiblich = c.Int(),
                        Männlich = c.Int(),
                        AnredeCodeAlternativ = c.Int(),
                    })
                .PrimaryKey(t => t.AnredeCode);
            
            CreateTable(
                "dbo.ERP_KAnsprechp",
                c => new
                    {
                        KAnsprechpCode = c.Int(nullable: false),
                        KundenCode = c.Int(),
                        AnredeCode = c.Int(),
                        Vorname = c.String(maxLength: 30),
                        Name = c.String(maxLength: 30),
                        Telefon = c.String(maxLength: 30),
                        Telefon2 = c.String(maxLength: 30),
                        Telefon3 = c.String(maxLength: 30),
                        Telefax = c.String(maxLength: 30),
                        Briefanrede = c.String(maxLength: 50),
                        Funktion = c.String(maxLength: 50),
                        AbteilungCode = c.Int(),
                        Straße = c.String(maxLength: 100),
                        Staat = c.String(maxLength: 20),
                        Plz = c.String(maxLength: 20),
                        Ort = c.String(maxLength: 50),
                        Mobilfunk = c.String(maxLength: 30),
                        AdreßErweiterung = c.String(maxLength: 50),
                        Notiz = c.String(storeType: "ntext"),
                        EMail = c.String(name: "E-Mail", maxLength: 50),
                        MailanPrivat = c.Int(),
                        TelPrivat = c.String(maxLength: 30),
                        FaxPrivat = c.String(maxLength: 30),
                        Geburtsdatum = c.DateTime(),
                        OutlookAdresse = c.Int(),
                        SenderName = c.String(maxLength: 50),
                        Entlassen = c.Int(),
                        LetzteÄnderung = c.DateTime(),
                        eMailPrivat = c.String(maxLength: 50),
                        BCodeErstkontakt = c.Int(),
                        BCodeLetzteÄnderung = c.Int(),
                        I_LogName = c.String(maxLength: 50),
                        GeburtstagTag = c.Int(),
                        GeburtstagMonat = c.Int(),
                        GeburtstagJahr = c.Int(),
                        VIP = c.Int(),
                        Serienbriefsperre = c.Int(),
                        Mailsperre = c.Int(),
                        Titelerweiterung = c.String(maxLength: 50),
                        Namenserweiterung = c.String(maxLength: 30),
                        Erstkontakt = c.DateTime(),
                        PrimäreAdresse = c.Int(),
                        FirmenAdresse = c.Int(),
                        AbteilungInAdresseZeigen = c.Int(),
                        FunktionInAdresseZeigen = c.Int(),
                        Skypename = c.String(maxLength: 50),
                        MobilPrivat = c.String(maxLength: 30),
                        NotizRTF = c.String(maxLength: 4000),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.KAnsprechpCode)
                .ForeignKey("dbo.ERP_Anrede", t => t.AnredeCode)
                .Index(t => t.AnredeCode);
            
            CreateTable(
                "dbo.MemberCommonInfo",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Long(),
                        EyeColor = c.String(),
                        Height = c.String(),
                        PlaceOfBirth = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MembersData", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.MemberDrivingLicense",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Long(),
                        CreatedIn = c.String(),
                        DLNumber = c.String(),
                        DateOfIssue = c.DateTime(precision: 7, storeType: "datetime2"),
                        DLClass = c.String(),
                        IssuingAuthority = c.String(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MembersData", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.MemberDuration",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        DurationNr = c.Long(),
                        Duration = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MemberDynamicFields",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Long(),
                        FieldIndex = c.Int(),
                        FieldValue = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MembersData", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.MemberGroups",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        GroupNr = c.Long(nullable: false),
                        GroupName = c.String(),
                        PersonHead = c.String(),
                        TrainerOne = c.String(),
                        TrainerTwo = c.String(),
                        TrainerThree = c.String(),
                        TrainerFour = c.String(),
                        TrainerFive = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberHealthCard",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Long(),
                        BoxNumber = c.String(),
                        CreatedIn = c.String(),
                        ItemNumber = c.String(),
                        SecurityNumber = c.String(),
                        CardNumber = c.String(),
                        ExpiryDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MembersData", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.MemberIdentityCard",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Long(),
                        CreatedIn = c.String(),
                        IDNumber = c.String(),
                        AdditionalNumber = c.String(),
                        DateOfIssue = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExpiryDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Address = c.String(),
                        IssuingAuthority = c.String(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MembersData", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.MemberPassport",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Long(),
                        CreatedIn = c.String(),
                        PPNumber = c.String(),
                        Gender = c.String(maxLength: 50),
                        DateOfIssue = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExpiryDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IssuingAuthority = c.String(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MembersData", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.MembersAccessPlanMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccessPlan_Nr = c.Long(),
                        MemberID = c.Long(),
                        DateFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        DateTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        AutomaticLogout = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MembersData", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.TbAccessPlan", t => t.AccessPlan_Nr, cascadeDelete: true)
                .Index(t => t.AccessPlan_Nr)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.MembersTransponders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Long(nullable: false),
                        TransponderNr = c.Long(nullable: false),
                        TransponderStatus = c.Boolean(),
                        ValidFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        ValidTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        TransponderDeactivatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        Action = c.Int(),
                        Memo = c.String(),
                        TransponderType = c.Int(),
                        ExtendedTo = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MembersData", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.TbAccessPlanMembersMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccessPlan_ID = c.Long(nullable: false),
                        MemberID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MembersData", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.TbAccessPlan", t => t.AccessPlan_ID, cascadeDelete: true)
                .Index(t => t.AccessPlan_ID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Pers_AccessGroups",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        GroupID = c.Long(nullable: false),
                        Active = c.Boolean(nullable: false),
                        StartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TbAccessPlanGroup", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.TbAccessPlanPersMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccessPlan_Nr = c.Long(nullable: false),
                        Pers_Nr = c.Long(nullable: false),
                        Location_ID = c.Int(),
                        DateFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        DateTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        AutomaticLogout = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TbAccessPlan", t => t.AccessPlan_Nr, cascadeDelete: true)
                .Index(t => t.AccessPlan_Nr);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Telephone = c.String(),
                        MobilePhone = c.String(),
                        Street = c.String(),
                        PostalCode = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                        State = c.String(),
                        Residence = c.String(),
                        House_Nr = c.String(),
                        EmployeeID = c.Int(),
                        ClientID = c.Int(),
                        CustomerID = c.Int(),
                        SupplierID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.DailyAccountTime",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AccountId = c.Long(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        WorkingDate = c.DateTime(nullable: false),
                        AccountHours = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.AccountId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccountNo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(),
                        Abbr = c.String(),
                        StandardAccount = c.Boolean(),
                        TransferAcc = c.String(),
                        DisplayFormat = c.String(),
                        BillingMacro = c.String(),
                        BIllingDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        AccInfo = c.String(unicode: false, storeType: "text"),
                        Day_Booking_Mask = c.Boolean(),
                        Workflow = c.Boolean(),
                        Project_Management = c.Boolean(),
                        Main_Account = c.Boolean(),
                        Clearing_Account = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SurchargesAccountsMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SurchargeID = c.Long(nullable: false),
                        AccountID = c.Long(nullable: false),
                        Active = c.Boolean(nullable: false),
                        AccountPosition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Surcharges", t => t.SurchargeID, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.AccountID)
                .Index(t => t.SurchargeID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Surcharges",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Surchage_Nr = c.Long(nullable: false),
                        Name = c.String(nullable: false),
                        SurchargeFactor = c.String(),
                        TimeFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        TimeTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        DurationFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        DurationTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExtraDurationFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExtraDurationTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        Memo = c.String(),
                        WeekDays_ID = c.Long(),
                        DailyProgramID = c.Long(),
                        OverTimeStart = c.String(),
                        OverTimeEnd = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DailyPrograms", t => t.DailyProgramID)
                .ForeignKey("dbo.SurchargeDays", t => t.WeekDays_ID, cascadeDelete: true)
                .Index(t => t.WeekDays_ID)
                .Index(t => t.DailyProgramID);
            
            CreateTable(
                "dbo.DailyPrograms",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        DP_Id = c.Long(nullable: false),
                        DP_Nr = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false),
                        HourFrom = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HourTo = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DP_Shifts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Shift_Nr = c.Int(nullable: false),
                        DP_ID = c.Long(nullable: false),
                        CountFrom = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CountTo = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CountDesc = c.String(),
                        EvalFrom = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EvalTo = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EvalDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DailyPrograms", t => t.DP_ID)
                .Index(t => t.DP_ID);
            
            CreateTable(
                "dbo.Shift_Breaks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Shift_ID = c.Int(nullable: false),
                        Break_ID = c.Long(nullable: false),
                        TimeFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        TimeTo = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Breaks", t => t.Break_ID)
                .ForeignKey("dbo.DP_Shifts", t => t.Shift_ID)
                .Index(t => t.Shift_ID)
                .Index(t => t.Break_ID);
            
            CreateTable(
                "dbo.Breaks",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Break_Nr = c.Long(nullable: false),
                        Name = c.String(nullable: false),
                        Type = c.Long(nullable: false),
                        TimeFrom = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeTo = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Memo = c.String(),
                        MinDiff = c.String(maxLength: 10, fixedLength: true),
                        MinimumDeduction = c.String(nullable: false),
                        StartAfter = c.String(nullable: false),
                        Beginning1stBreakFrom = c.String(nullable: false),
                        FirstDeduction = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Beginning2ndBreakFrom = c.String(nullable: false),
                        SecondDeduction = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BeginningThirdBreakFrom = c.String(nullable: false),
                        ThirdDeduction = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MaximumDeduction = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ShiftName = c.String(),
                        ShiftDescription = c.String(),
                        DailyProgramId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DailyPrograms", t => t.DailyProgramId, cascadeDelete: true)
                .Index(t => t.DailyProgramId);
            
            CreateTable(
                "dbo.ResourceEventMapped",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ResourceId = c.Int(nullable: false),
                        DailyProgramId = c.Int(nullable: false),
                        ShiftId = c.Long(),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Description = c.String(unicode: false),
                        BreakId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DailyProgramMapped", t => t.DailyProgramId, cascadeDelete: true)
                .ForeignKey("dbo.Shifts", t => t.ShiftId)
                .ForeignKey("dbo.ShiftResource", t => t.ResourceId)
                .Index(t => t.ResourceId)
                .Index(t => t.DailyProgramId)
                .Index(t => t.ShiftId);
            
            CreateTable(
                "dbo.DailyProgramMapped",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DP_Id = c.Long(nullable: false),
                        DP_Nr = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false),
                        HourFrom = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HourTo = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ShiftResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Code = c.String(maxLength: 50, unicode: false),
                        Description = c.String(),
                        IsDefaultLoaded = c.Boolean(nullable: false),
                        Color = c.String(maxLength: 50, unicode: false),
                        OrderCase = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResourceEvent",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ResourceId = c.Int(nullable: false),
                        ShiftId = c.Long(),
                        StartTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Description = c.String(unicode: false),
                        BreakId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ShiftResource", t => t.ResourceId)
                .ForeignKey("dbo.Shifts", t => t.ShiftId, cascadeDelete: true)
                .Index(t => t.ResourceId)
                .Index(t => t.ShiftId);
            
            CreateTable(
                "dbo.SurchargeDays",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Mon = c.Boolean(),
                        Tue = c.Boolean(),
                        Wed = c.Boolean(),
                        Thur = c.Boolean(),
                        Fri = c.Boolean(),
                        Sat = c.Boolean(),
                        Sun = c.Boolean(),
                        Holiday = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeeInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DoB = c.DateTime(precision: 7, storeType: "datetime2"),
                        PlaceOfBirth = c.String(),
                        DrivingLicense = c.String(),
                        BankAccNo = c.String(),
                        Bank = c.String(),
                        Gender = c.String(),
                        MaritalStatus = c.String(),
                        Children = c.Int(),
                        Nationality = c.String(),
                        Denomination = c.String(),
                        SSN = c.String(maxLength: 50),
                        FinanceAuthority = c.String(),
                        TaxClass = c.String(),
                        HealthInsurance = c.String(),
                        HINumber = c.Double(),
                        Job = c.String(),
                        NoOfHours = c.Double(),
                        CreatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        ContPeriodFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        ContPeriodTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        ResignedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        CostCenterId = c.Long(),
                        DepartmentId = c.Long(nullable: false),
                        LocationId = c.Long(nullable: false),
                        Street = c.String(),
                        CarType = c.String(),
                        CarReg = c.String(),
                        CompanyName = c.String(),
                        Town = c.String(),
                        PhoneNumber = c.String(),
                        Memo = c.String(),
                        Position = c.String(),
                        CompanyPhone = c.String(),
                        CompanyMobile = c.String(),
                        PersonalPhone = c.String(),
                        PersonalMobile = c.String(),
                        CompanyEmail = c.String(),
                        PersonalEmail = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CostCenters", t => t.CostCenterId)
                .Index(t => t.CostCenterId);
            
            CreateTable(
                "dbo.CostCenters",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CostCenter_Nr = c.Long(),
                        Ort = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Street = c.String(),
                        HouseNumber = c.String(),
                        LocationId = c.Long(nullable: false),
                        LocationHeadName = c.String(),
                        LocationHeadFunction = c.String(),
                        LocationHeadPhone = c.String(),
                        LocationHeadMobile = c.String(),
                        LocationHeadEmail = c.String(),
                        InfoText = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_CostCenters",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        CostCenterID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CostCenters", t => t.CostCenterID, cascadeDelete: true)
                .Index(t => t.CostCenterID);
            
            CreateTable(
                "dbo.WorkedHoursAcc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountID = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HoursWorked = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Account = c.String(nullable: false),
                        EmpID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.EmpID)
                .Index(t => t.EmpID);
            
            CreateTable(
                "dbo.Specialdays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Absence_Reason = c.Int(),
                        LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Absences", t => t.Absence_Reason)
                .Index(t => t.Absence_Reason);
            
            CreateTable(
                "dbo.AC_PermissionMapping",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PermissionKey = c.Int(nullable: false),
                        PermissionType = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AC_PermissionProfile", t => t.ProfileId, cascadeDelete: true)
                .ForeignKey("dbo.AC_Permissions", t => t.PermissionKey, cascadeDelete: true)
                .Index(t => t.PermissionKey)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.AC_PermissionProfile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProfileNr = c.Int(nullable: false),
                        ProfileDescription = c.String(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AC_PersProfileADMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PersNr = c.Long(nullable: false),
                        ProfileID = c.Int(),
                        AD_Username = c.String(nullable: false),
                        AD_Path = c.String(nullable: false),
                        AD_Controller = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AC_PermissionProfile", t => t.ProfileID)
                .Index(t => t.ProfileID);
            
            CreateTable(
                "dbo.AC_PersProfileMapping",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Pers_Nr = c.Int(nullable: false),
                        ProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AC_PermissionProfile", t => t.ProfileID, cascadeDelete: true)
                .Index(t => t.ProfileID);
            
            CreateTable(
                "dbo.AC_Permissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Permission = c.String(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AC_PersPasswords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Pers_Nr = c.Int(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AC_PersPasswordsProfile",
                c => new
                    {
                        Pers_Nr = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 128),
                        CurrentPassword = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        OldPassword = c.String(),
                        ProfileID = c.Int(),
                    })
                .PrimaryKey(t => new { t.Pers_Nr, t.UserName, t.CurrentPassword, t.FirstName, t.LastName });
            
            CreateTable(
                "dbo.AC_ReportList",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ListNr = c.Long(nullable: false),
                        ListDescription = c.String(),
                        ListType = c.Int(),
                        PersonType = c.Int(),
                        StartClient = c.Int(),
                        EndClient = c.Int(),
                        StartLocation = c.Int(),
                        EndLocation = c.Int(),
                        StartDepartmet = c.Int(),
                        EndDepartment = c.Int(),
                        StartName = c.Int(),
                        EndName = c.Int(),
                        StartIdNr = c.Int(),
                        EndIdNr = c.Int(),
                        MemberType = c.Int(),
                        StartPlace = c.Int(),
                        EndPlace = c.Int(),
                        StartPostalCode = c.Int(),
                        EndPostalCode = c.Int(),
                        VariableType = c.Int(),
                        StartStudioGroup = c.Int(),
                        EndStudioGroup = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AC_ReportListChecks",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ReportListID = c.Long(),
                        ShowClientCompany = c.Boolean(),
                        ShowLocation = c.Boolean(),
                        ShowDepartment = c.Boolean(),
                        ShowName = c.Boolean(),
                        ShowIDNr = c.Boolean(),
                        ShowPlace = c.Boolean(),
                        ShowPostalCode = c.Boolean(),
                        ShowStreetAndNr = c.Boolean(),
                        ShowDOB = c.Boolean(),
                        ShowEntryDate = c.Boolean(),
                        ShowExitDate = c.Boolean(),
                        ShowEmploymentPosition = c.Boolean(),
                        ShowNationality = c.Boolean(),
                        ShowCompanyTelephone = c.Boolean(),
                        ShowCompanyMobile = c.Boolean(),
                        ShowPrivateTelephone = c.Boolean(),
                        ShowPrivateMobile = c.Boolean(),
                        ShowLongTermCard = c.Boolean(),
                        ShowShortTermCard = c.Boolean(),
                        ShowAccessFromTo = c.Boolean(),
                        ShowAccessPlanNr = c.Boolean(),
                        ShowAccessPlanDesc = c.Boolean(),
                        ListType = c.Int(),
                        ShowSalutation = c.Boolean(),
                        ShowContractNr = c.Boolean(),
                        ShowProfession = c.Boolean(),
                        ShowEmail = c.Boolean(),
                        ShowMemberGroup = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AC_ReportList", t => t.ReportListID, cascadeDelete: true)
                .Index(t => t.ReportListID);
            
            CreateTable(
                "dbo.AC_Reports",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Nr = c.Long(nullable: false),
                        Name = c.String(),
                        Type = c.Int(),
                        StartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        StartTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        StartLocationB = c.String(),
                        EndLocationB = c.String(),
                        StartBuilding = c.String(),
                        EndBuilding = c.String(),
                        StartLevel = c.String(),
                        EndLevel = c.String(),
                        StartRoom = c.String(),
                        EndRoom = c.String(),
                        StartDoor = c.String(),
                        EndDoor = c.String(),
                        StartClient = c.Int(),
                        EndClient = c.Int(),
                        StartLocation = c.Int(),
                        EndLocation = c.Int(),
                        StartDept = c.Int(),
                        EndDept = c.Int(),
                        StartCostCenter = c.Int(),
                        EndCostCenter = c.Int(),
                        StartPersonal = c.Int(),
                        EndPersonal = c.Int(),
                        StartShortTransponder = c.Int(),
                        EndShortTranspoder = c.Int(),
                        StartLongTranspoder = c.Int(),
                        EndLongTransponder = c.Int(),
                        StartMemberGroup = c.Int(),
                        EndMemberGroup = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AC_ReportSettings",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ReportID = c.Long(),
                        ShowDate = c.Boolean(),
                        ShowTime = c.Boolean(),
                        ShowBuildingLocation = c.Boolean(),
                        ShowBuilding = c.Boolean(),
                        ShowFloor = c.Boolean(),
                        ShowRoom = c.Boolean(),
                        ShowReader = c.Boolean(),
                        ShowCompany = c.Boolean(),
                        ShowPersLocation = c.Boolean(),
                        ShowPersDepartment = c.Boolean(),
                        ShowPersCC = c.Boolean(),
                        ShowPersName = c.Boolean(),
                        ShowPersCardNrLong = c.Boolean(),
                        ShowPersCardNrShort = c.Boolean(),
                        PrintSelection = c.Int(),
                        Type = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AC_Reports", t => t.ReportID, cascadeDelete: true)
                .Index(t => t.ReportID);
            
            CreateTable(
                "dbo.AC_vwPersonelAccessPlan",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false, maxLength: 128),
                        EntryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Active = c.Boolean(nullable: false),
                        Pers_Nr = c.Long(nullable: false),
                        CardActive = c.Boolean(nullable: false),
                        AccessPlanNr = c.Long(nullable: false),
                        MiddleName = c.String(),
                        Title = c.String(),
                        ExitDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        PersType = c.Long(),
                        Memo = c.String(),
                        Card_Nr = c.Long(),
                        Imported = c.Boolean(),
                        AccessPlanID = c.Long(),
                        StartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Passport_Nr = c.String(),
                        PhysicalAddress = c.String(),
                        Street = c.String(),
                        PlaceOfBirth = c.String(),
                        DOB = c.DateTime(precision: 7, storeType: "datetime2"),
                        Gender = c.String(),
                        MaritalStatus = c.String(),
                        Position = c.String(),
                        Profession = c.String(),
                        Nationality = c.String(),
                        VehicleModel = c.String(),
                        VehicleReg = c.String(),
                        CompanyName = c.String(),
                        CompanyTel = c.String(),
                        PrivateTel = c.String(),
                        CompanyMobile = c.String(),
                        PrivateMobile = c.String(),
                        CompanyFax = c.String(),
                        PrivateFax = c.String(),
                        CompanyEmail = c.String(),
                        PrivateEmail = c.String(),
                        PostalAddress = c.String(),
                        PostalCode = c.String(),
                        LocationID = c.Long(),
                        Location = c.String(),
                        DepartmentID = c.Long(),
                        Department = c.String(),
                        VisitorID = c.Long(),
                        CostCenterID = c.Long(),
                        CostCenter = c.String(),
                        VehicleID = c.Long(),
                        Pers_Passport = c.Binary(),
                    })
                .PrimaryKey(t => new { t.ID, t.FirstName, t.LastName, t.FullName, t.EntryDate, t.Active, t.Pers_Nr, t.CardActive, t.AccessPlanNr });
            
            CreateTable(
                "dbo.AccessCalendarProfiles",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AccessCalendarID = c.Long(),
                        Date = c.DateTime(),
                        AccessProfile = c.Long(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AccessControlLogs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TerminalSerial = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        ReaderID = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Card_Nr = c.Long(nullable: false),
                        Pers_Nr = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        AccessTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        VisitorID = c.Long(),
                        MemberID = c.Long(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Accounts_Day",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        PersNr = c.Int(nullable: false),
                        AccntNr = c.Int(nullable: false),
                        D1 = c.Double(nullable: false),
                        D2 = c.Double(nullable: false),
                        D3 = c.Double(nullable: false),
                        D4 = c.Double(nullable: false),
                        D5 = c.Double(nullable: false),
                        D6 = c.Double(nullable: false),
                        D7 = c.Double(nullable: false),
                        D8 = c.Double(nullable: false),
                        D9 = c.Double(nullable: false),
                        D10 = c.Double(nullable: false),
                        D11 = c.Double(nullable: false),
                        D12 = c.Double(nullable: false),
                        D13 = c.Double(nullable: false),
                        D14 = c.Double(nullable: false),
                        D15 = c.Double(nullable: false),
                        D16 = c.Double(nullable: false),
                        D17 = c.Double(nullable: false),
                        D18 = c.Double(nullable: false),
                        D19 = c.Double(nullable: false),
                        D20 = c.Double(nullable: false),
                        D21 = c.Double(nullable: false),
                        D22 = c.Double(nullable: false),
                        D23 = c.Double(nullable: false),
                        D24 = c.Double(nullable: false),
                        D25 = c.Double(nullable: false),
                        D26 = c.Double(nullable: false),
                        D27 = c.Double(nullable: false),
                        D28 = c.Double(nullable: false),
                        D29 = c.Double(nullable: false),
                        D30 = c.Double(nullable: false),
                        D31 = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Accounts_Month",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        M1 = c.Double(nullable: false),
                        M2 = c.Double(nullable: false),
                        M3 = c.Double(nullable: false),
                        M4 = c.Double(nullable: false),
                        M5 = c.Double(nullable: false),
                        M6 = c.Double(nullable: false),
                        M7 = c.Double(nullable: false),
                        M8 = c.Double(nullable: false),
                        M9 = c.Double(nullable: false),
                        M10 = c.Double(nullable: false),
                        M11 = c.Double(nullable: false),
                        M12 = c.Double(nullable: false),
                        M13 = c.Double(nullable: false),
                        M14 = c.Double(nullable: false),
                        M15 = c.Double(nullable: false),
                        M16 = c.Double(nullable: false),
                        M17 = c.Double(nullable: false),
                        M18 = c.Double(nullable: false),
                        M19 = c.Double(nullable: false),
                        M20 = c.Double(nullable: false),
                        M21 = c.Double(nullable: false),
                        M22 = c.Double(nullable: false),
                        M23 = c.Double(nullable: false),
                        M24 = c.Double(nullable: false),
                        M25 = c.Double(nullable: false),
                        M26 = c.Double(nullable: false),
                        M27 = c.Double(nullable: false),
                        M28 = c.Double(nullable: false),
                        M29 = c.Double(nullable: false),
                        M30 = c.Double(nullable: false),
                        M31 = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts_Day", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Accounts_Week",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        W1 = c.Double(nullable: false),
                        W2 = c.Double(nullable: false),
                        W3 = c.Double(nullable: false),
                        W4 = c.Double(nullable: false),
                        W5 = c.Double(nullable: false),
                        W6 = c.Double(nullable: false),
                        W7 = c.Double(nullable: false),
                        W8 = c.Double(nullable: false),
                        W9 = c.Double(nullable: false),
                        W10 = c.Double(nullable: false),
                        W11 = c.Double(nullable: false),
                        W12 = c.Double(nullable: false),
                        W13 = c.Double(nullable: false),
                        W14 = c.Double(nullable: false),
                        W15 = c.Double(nullable: false),
                        W16 = c.Double(nullable: false),
                        W17 = c.Double(nullable: false),
                        W18 = c.Double(nullable: false),
                        W19 = c.Double(nullable: false),
                        W20 = c.Double(nullable: false),
                        W21 = c.Double(nullable: false),
                        W22 = c.Double(nullable: false),
                        W23 = c.Double(nullable: false),
                        W24 = c.Double(nullable: false),
                        W25 = c.Double(nullable: false),
                        W26 = c.Double(nullable: false),
                        W27 = c.Double(nullable: false),
                        W28 = c.Double(nullable: false),
                        W29 = c.Double(nullable: false),
                        W30 = c.Double(nullable: false),
                        W31 = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts_Day", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Accounts_Year",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Y1 = c.Double(nullable: false),
                        Y2 = c.Double(nullable: false),
                        Y3 = c.Double(nullable: false),
                        Y4 = c.Double(nullable: false),
                        Y5 = c.Double(nullable: false),
                        Y6 = c.Double(nullable: false),
                        Y7 = c.Double(nullable: false),
                        Y8 = c.Double(nullable: false),
                        Y9 = c.Double(nullable: false),
                        Y10 = c.Double(nullable: false),
                        Y11 = c.Double(nullable: false),
                        Y12 = c.Double(nullable: false),
                        Y13 = c.Double(nullable: false),
                        Y14 = c.Double(nullable: false),
                        Y15 = c.Double(nullable: false),
                        Y16 = c.Double(nullable: false),
                        Y17 = c.Double(nullable: false),
                        Y18 = c.Double(nullable: false),
                        Y19 = c.Double(nullable: false),
                        Y20 = c.Double(nullable: false),
                        Y21 = c.Double(nullable: false),
                        Y22 = c.Double(nullable: false),
                        Y23 = c.Double(nullable: false),
                        Y24 = c.Double(nullable: false),
                        Y25 = c.Double(nullable: false),
                        Y26 = c.Double(nullable: false),
                        Y27 = c.Double(nullable: false),
                        Y28 = c.Double(nullable: false),
                        Y29 = c.Double(nullable: false),
                        Y30 = c.Double(nullable: false),
                        Y31 = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts_Day", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Area_Nr = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        LocationFederalStateId = c.Long(),
                        ZipCode = c.String(),
                        Street = c.String(),
                        Ort = c.String(),
                        HouseNumber = c.String(),
                        LocationHeadName = c.String(),
                        LocationHeadFunction = c.String(),
                        LocationHeadPhone = c.String(),
                        LocationHeadMobile = c.String(),
                        LocationHeadEmail = c.String(),
                        InfoText = c.String(),
                        DeptId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DeptId)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Department_Nr = c.Long(nullable: false),
                        State = c.String(),
                        ZipCode = c.String(maxLength: 50),
                        Street = c.String(),
                        HouseNumber = c.String(),
                        LocationId = c.Long(),
                        LocationHeadName = c.String(),
                        LocationHeadFunction = c.String(),
                        LocationHeadPhone = c.String(),
                        LocationHeadMobile = c.String(),
                        LocationHeadEmail = c.String(),
                        InfoText = c.String(),
                        Place = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_Departments",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        DepartmentID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Pers_Areas",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        AreaID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Areas", t => t.AreaID)
                .Index(t => t.AreaID);
            
            CreateTable(
                "dbo.AuditHist",
                c => new
                    {
                        usr_id = c.Long(nullable: false),
                        u_action = c.String(nullable: false, maxLength: 100),
                        audit_date = c.DateTime(nullable: false),
                        comment = c.String(),
                        ID = c.Long(),
                    })
                .PrimaryKey(t => new { t.usr_id, t.u_action, t.audit_date });
            
            CreateTable(
                "dbo.BookingPairs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Duration = c.Int(),
                        Date = c.DateTime(storeType: "date"),
                        EmpID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BreaksMapped",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DP_Nr = c.Int(nullable: false),
                        Break_Nr = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false, maxLength: 50),
                        TimeFrom = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TimeTo = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Memo = c.String(unicode: false, storeType: "text"),
                        MinDiff = c.String(maxLength: 10, fixedLength: true),
                        Break_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BreaksType",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TpyeNr = c.Long(nullable: false),
                        Abbriviation = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CCAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(),
                        EmpCost = c.Int(),
                        FlexCost = c.Int(),
                        OperatingCost = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CellPhoneMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CellID = c.String(maxLength: 50, unicode: false),
                        Name = c.String(),
                        MobileNumber = c.Int(),
                        MobileIdentification = c.String(),
                        EmployeeID = c.Int(),
                        Username = c.String(),
                        DepartmentID = c.Int(),
                        OutputOn = c.DateTime(storeType: "date"),
                        ContractingParty = c.String(),
                        Inception = c.DateTime(storeType: "date"),
                        ContractEnd = c.DateTime(storeType: "date"),
                        LeaseTerm = c.String(),
                        Tariff = c.String(),
                        TariffPricePerMonth = c.String(),
                        TimeTracking = c.Boolean(),
                        CostCenter = c.Boolean(),
                        CostandFlexCostCenter = c.Boolean(),
                        ProjectTracking = c.Boolean(),
                        Customer = c.Boolean(),
                        Project = c.Boolean(),
                        IsOrder = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ColorName = c.String(nullable: false, maxLength: 50),
                        ColorCode = c.String(nullable: false, maxLength: 50),
                        ColorComment = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 2),
                        DE_Name = c.String(),
                        EN_Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        EmployeeID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DailyBooking",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RawBookingId = c.Long(nullable: false),
                        EmployeeId = c.Long(nullable: false),
                        EmployeeNumber = c.Int(nullable: false),
                        BookingTime = c.DateTime(nullable: false),
                        DateProcessed = c.DateTime(nullable: false),
                        BookingStatus = c.Int(nullable: false),
                        Terminal = c.String(nullable: false, maxLength: 50, unicode: false),
                        Memo = c.String(maxLength: 400, unicode: false),
                        ProcessingStatus = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DailyBookingsReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InfoNumber = c.Int(nullable: false),
                        InfoName = c.String(maxLength: 50),
                        Accounts = c.String(maxLength: 50),
                        BookingsCount = c.Int(),
                        ReportPosition = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DailyCalendar",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarId = c.Long(nullable: false),
                        Monday = c.Time(nullable: false, precision: 7),
                        Tuesday = c.Time(nullable: false, precision: 7),
                        Wednesday = c.Time(nullable: false, precision: 7),
                        Thursday = c.Time(nullable: false, precision: 7),
                        Friday = c.Time(nullable: false, precision: 7),
                        Saturday = c.Time(nullable: false, precision: 7),
                        Sunday = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlannedCalendar", t => t.CalendarId)
                .Index(t => t.CalendarId);
            
            CreateTable(
                "dbo.PlannedCalendar",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarYear = c.Int(nullable: false),
                        CalendarType = c.Int(nullable: false),
                        CalendarNumber = c.Int(nullable: false),
                        CalendarIdNumber = c.String(maxLength: 4, unicode: false),
                        CalendarName = c.String(),
                        Monday = c.Boolean(nullable: false),
                        Tuesday = c.Boolean(nullable: false),
                        Wednesday = c.Boolean(nullable: false),
                        Thursday = c.Boolean(nullable: false),
                        Friday = c.Boolean(nullable: false),
                        Saturday = c.Boolean(nullable: false),
                        Sunday = c.Boolean(nullable: false),
                        Memo = c.String(),
                        DailyCalendarId = c.Long(),
                        MonthlyCalendarId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MonthlyCalendar", t => t.MonthlyCalendarId)
                .ForeignKey("dbo.DailyCalendar", t => t.DailyCalendarId)
                .Index(t => t.DailyCalendarId)
                .Index(t => t.MonthlyCalendarId);
            
            CreateTable(
                "dbo.MonthlyCalendar",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarId = c.Long(nullable: false),
                        January = c.Double(nullable: false),
                        February = c.Double(nullable: false),
                        March = c.Double(nullable: false),
                        April = c.Double(nullable: false),
                        May = c.Double(nullable: false),
                        June = c.Double(nullable: false),
                        July = c.Double(nullable: false),
                        August = c.Double(nullable: false),
                        September = c.Double(nullable: false),
                        October = c.Double(nullable: false),
                        November = c.Double(nullable: false),
                        December = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlannedCalendar", t => t.CalendarId)
                .Index(t => t.CalendarId);
            
            CreateTable(
                "dbo.PlannedCalendarTime",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarId = c.Long(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1Hours = c.Time(nullable: false, precision: 7),
                        Day2Hours = c.Time(nullable: false, precision: 7),
                        Day3Hours = c.Time(nullable: false, precision: 7),
                        Day4Hours = c.Time(nullable: false, precision: 7),
                        Day5Hours = c.Time(nullable: false, precision: 7),
                        Day6Hours = c.Time(nullable: false, precision: 7),
                        Day7Hours = c.Time(nullable: false, precision: 7),
                        Day8Hours = c.Time(nullable: false, precision: 7),
                        Day9Hours = c.Time(nullable: false, precision: 7),
                        Day10Hours = c.Time(nullable: false, precision: 7),
                        Day11Hours = c.Time(nullable: false, precision: 7),
                        Day12Hours = c.Time(nullable: false, precision: 7),
                        Day13Hours = c.Time(nullable: false, precision: 7),
                        Day14Hours = c.Time(nullable: false, precision: 7),
                        Day15Hours = c.Time(nullable: false, precision: 7),
                        Day16Hours = c.Time(nullable: false, precision: 7),
                        Day17Hours = c.Time(nullable: false, precision: 7),
                        Day18Hours = c.Time(nullable: false, precision: 7),
                        Day19Hours = c.Time(nullable: false, precision: 7),
                        Day20Hours = c.Time(nullable: false, precision: 7),
                        Day21Hours = c.Time(nullable: false, precision: 7),
                        Day22Hours = c.Time(nullable: false, precision: 7),
                        Day23Hours = c.Time(nullable: false, precision: 7),
                        Day24Hours = c.Time(nullable: false, precision: 7),
                        Day25Hours = c.Time(nullable: false, precision: 7),
                        Day26Hours = c.Time(nullable: false, precision: 7),
                        Day27Hours = c.Time(nullable: false, precision: 7),
                        Day28Hours = c.Time(nullable: false, precision: 7),
                        Day29Hours = c.Time(nullable: false, precision: 7),
                        Day30Hours = c.Time(nullable: false, precision: 7),
                        Day31Hours = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlannedCalendar", t => t.CalendarId)
                .Index(t => t.CalendarId);
            
            CreateTable(
                "dbo.DatafoxTerminalInstances",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TermType = c.String(nullable: false),
                        TermID = c.Int(nullable: false),
                        Description = c.String(),
                        IsActive = c.Boolean(),
                        SerialNumber = c.String(),
                        ConnectionType = c.String(),
                        IpAddress = c.String(maxLength: 50),
                        Port = c.Int(),
                        Memo = c.String(),
                        TerminalOEMId = c.Long(),
                        TerminalNewId = c.Long(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DatafoxTerminalReaders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        DatafoxTerminalID = c.Long(),
                        ReaderID = c.Int(nullable: false),
                        ReaderType = c.String(),
                        ReaderDescription = c.String(),
                        Direction = c.String(),
                        Status = c.String(),
                        RelayTime = c.Int(),
                        ReaderMemo = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DatafoxTerminalInstances", t => t.DatafoxTerminalID, cascadeDelete: true)
                .Index(t => t.DatafoxTerminalID);
            
            CreateTable(
                "dbo.DF_TIME",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Weekdays = c.Int(nullable: false),
                        DF_KEY = c.Long(),
                        AccessProfID = c.Long(),
                        TimeFrom = c.String(maxLength: 5, unicode: false),
                        TimeTo = c.String(maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => new { t.ID, t.Weekdays });
            
            CreateTable(
                "dbo.DynamicColumns",
                c => new
                    {
                        ColumnID = c.Int(nullable: false, identity: true),
                        ColumnName = c.String(),
                        ColumnValue = c.String(),
                    })
                .PrimaryKey(t => t.ColumnID);
            
            CreateTable(
                "dbo.EmpAdditionalInfo",
                c => new
                    {
                        AdditionalInfoID = c.Int(nullable: false, identity: true),
                        EmpNumber = c.Int(),
                        ColumnID = c.Int(nullable: false),
                        EntryValue = c.String(),
                    })
                .PrimaryKey(t => t.AdditionalInfoID)
                .ForeignKey("dbo.DynamicColumns", t => t.ColumnID)
                .Index(t => t.ColumnID);
            
            CreateTable(
                "dbo.DynamicFields",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FieldIndex = c.Int(),
                        FieldText = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DynamicFieldsMember",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FieldIndex = c.Int(),
                        FieldText = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeePhotos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Photo = c.Binary(),
                        EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ERP_Kunden",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(maxLength: 70),
                        GrCode = c.Int(),
                        Nummer = c.Int(),
                        Firma1 = c.String(maxLength: 100),
                        Firma2 = c.String(maxLength: 100),
                        Firma3 = c.String(maxLength: 100),
                        Straße = c.String(maxLength: 100),
                        Staat = c.String(maxLength: 20),
                        Plz = c.String(maxLength: 50),
                        Ort = c.String(maxLength: 50),
                        Telefon = c.String(maxLength: 50),
                        Telefax = c.String(maxLength: 50),
                        Privatkunde = c.Int(),
                        Bruttorechnung = c.Int(),
                        Gesperrt = c.Int(),
                        Zahlungsfrist = c.Int(),
                        Skonto = c.Single(),
                        Skontofrist = c.Single(),
                        Skonto2 = c.Double(),
                        Skonto2Frist = c.Int(),
                        Mahntoleranz = c.Double(),
                        Rabattvorschlag = c.Single(),
                        Preisgruppe = c.Int(),
                        Notiz = c.String(storeType: "ntext"),
                        KAnsprechpCode = c.Int(),
                        NebenAdrCode1 = c.Int(),
                        NebenAdrCode2 = c.Int(),
                        NebenAdrCode3 = c.Int(),
                        NebenAdrType1 = c.Int(),
                        NebenAdrType2 = c.Int(),
                        NebenAdrType3 = c.Int(),
                        KKontaktCode = c.Int(),
                        Erstkontakt = c.DateTime(),
                        Letzterkontakt = c.DateTime(),
                        PersonErstkontakt = c.String(maxLength: 50),
                        PersonLetzterkontakt = c.String(maxLength: 50),
                        Waswurdezuletztgetan = c.String(maxLength: 50),
                        Entfernung = c.Single(),
                        Postfach = c.String(maxLength: 20),
                        PLZPostfach = c.String(maxLength: 8),
                        OrtPostfach = c.String(maxLength: 50),
                        Vorwahl = c.String(maxLength: 50),
                        AnsprechPartner = c.String(maxLength: 50),
                        BriefAnrede = c.String(maxLength: 50),
                        AnredeCode = c.Int(),
                        Autotelefon = c.String(maxLength: 20),
                        InterNet = c.String(maxLength: 40),
                        VertreterCode = c.Int(),
                        Provision = c.Double(),
                        Mark = c.String(maxLength: 1),
                        Standardkonto = c.Int(),
                        Steuer = c.Int(),
                        Kontonummer = c.String(maxLength: 30),
                        Bankverbindung = c.String(maxLength: 30),
                        Bankleitzahl = c.String(maxLength: 30),
                        Kontoinhaber = c.String(maxLength: 50),
                        Bankeinzug = c.Int(),
                        USTIDNR = c.String(maxLength: 50),
                        Kundennr = c.String(maxLength: 20),
                        Kürzel = c.String(maxLength: 10),
                        HausbankCode = c.Int(),
                        SprachCode = c.Int(),
                        EMail = c.String(name: "E-Mail", maxLength: 100),
                        WährungCode = c.Int(),
                        Kreditlimit = c.Double(),
                        ZahlungsCode = c.Int(),
                        DB = c.Int(),
                        SteuerschluesselCode = c.Int(),
                        SenderName = c.String(maxLength: 50),
                        OutlookAdresse = c.Int(),
                        Geburtsdatum = c.DateTime(),
                        Vertreter2Code = c.Int(),
                        LetzteÄnderung = c.DateTime(),
                        Titelerweiterung = c.String(maxLength: 30),
                        GeburtstagTag = c.Int(),
                        GeburtstagMonat = c.Int(),
                        GeburtstagJahr = c.Int(),
                        Namenserweiterung = c.String(maxLength: 50),
                        Erloschen = c.Int(),
                        Funktion = c.String(maxLength: 50),
                        FirmenAnrede = c.String(maxLength: 255),
                        Intern = c.Int(),
                        DoublettenCheck_NichtMehrAnzeigen = c.Int(),
                        Adreßerweiterung = c.String(storeType: "ntext"),
                        EMail2 = c.String(name: "E-Mail2", maxLength: 150),
                        NotizRTF = c.String(maxLength: 4000),
                        IBAN = c.String(maxLength: 34),
                        BIC = c.String(maxLength: 11),
                        Telefon2 = c.String(maxLength: 30),
                        Lieferadresse = c.Int(),
                        DTANichtZusammenfassen = c.Int(),
                        MailSperre = c.Int(),
                        SerienbriefSperre = c.Int(),
                        LieferungsArtCode = c.Int(),
                        LieferungsArtZiel = c.Int(),
                        MiteID = c.String(maxLength: 100),
                        Konzernkennzeichen = c.String(maxLength: 50),
                        Mahnsperre = c.Int(),
                        TeilrechnungslogikCode = c.Int(),
                        Ordner = c.String(maxLength: 1000),
                        VertreterSDObjMemberCode = c.Int(),
                        VertreterSDObjType = c.Int(),
                        NebenadrAPCode1 = c.Int(),
                        NebenadrAPCode2 = c.Int(),
                        NebenadrAPCode3 = c.Int(),
                        ERPFreigabepflichtDeaktivieren = c.Int(),
                        AdresseWirdGepflegtBeiLieferantCode = c.Int(),
                        Rabatt2 = c.Double(),
                        Rabatt3 = c.Double(),
                        Rabatt4 = c.Double(),
                        AdresseWirdGepflegtBeiKundeCode = c.Int(),
                        KeineStaffelrabatte = c.Int(),
                        Memo = c.String(),
                        KundenType = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ERP_KundenGr",
                c => new
                    {
                        GrCode = c.Int(nullable: false),
                        GrIndex = c.Int(),
                        GrLevel = c.Int(),
                        GrName = c.String(maxLength: 40),
                        Info = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.GrCode);
            
            CreateTable(
                "dbo.ERP_KundenGrMark",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        GrCode = c.Int(),
                        BCode = c.Int(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.ERP_KundenMark",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        BenutzerCode = c.Int(),
                        ObjCode = c.Int(),
                        KAnsprechpCode = c.Int(),
                        Markierung = c.Int(),
                        OriginalCode = c.Int(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.ERP_Länder",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Kennzeichen = c.String(maxLength: 10),
                        Kennzeichen2 = c.String(maxLength: 50),
                        Kennzeichen3 = c.String(maxLength: 50),
                        Steuer = c.Int(),
                        Langtext = c.String(maxLength: 50),
                        KorrekturLKZ = c.String(name: "Korrektur LKZ", maxLength: 7),
                        Angelsächsisch = c.Int(),
                        ReisekostenÜber24h = c.Double(),
                        ReisekostenÜber14h = c.Double(),
                        ReisekostenÜber8h = c.Double(),
                        ÜbernachtungsPauschale = c.Double(),
                        Frühstück = c.Double(),
                        Telefonvorwahl = c.String(maxLength: 5),
                        Steuerschlüssel1 = c.Int(),
                        Steuerschlüssel2 = c.Int(),
                        Steuerschlüssel3 = c.Int(),
                        ReisekostenUnter24h = c.Double(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.ERP_SoftwareContractStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContractStatusNr = c.String(),
                        ContractStatus = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ERP_SoftwareModules",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ModuleNumber = c.Int(),
                        ModuleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ERP_SoftwareUpdateService",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ModuleNumber = c.Long(nullable: false),
                        CustomerID = c.Int(),
                        InstallationDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        PurchaseVersion = c.String(),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        LastVersionAfterUpdate = c.String(),
                        UpdateAfterBuying = c.DateTime(precision: 7, storeType: "datetime2"),
                        SoftwareUpdateContract = c.Boolean(),
                        SoftwareContractFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        ContractStatusNr = c.Int(),
                        EndOfContract = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateInfoByMail = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FingerprintPassword",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PersNr = c.Int(),
                        Username = c.String(maxLength: 50),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FingerPrints",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PersType = c.Int(nullable: false),
                        PersIDNr = c.Long(nullable: false),
                        FingerNr = c.Int(),
                        Template9 = c.String(),
                        Template10 = c.String(),
                        Valid = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 50),
                        Quality1 = c.Int(),
                        Quality2 = c.Int(),
                        Quality3 = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Global_Settings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AppName = c.String(),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GroupAccessProfiles",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        GroupProfileNo = c.Int(nullable: false),
                        GroupProfileDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HolidayAccessPlam_with_DateTime",
                c => new
                    {
                        AccessProfileID = c.Long(nullable: false),
                        ID = c.Long(nullable: false),
                        HolidayPlanCalendarId = c.Long(nullable: false),
                        ZPID = c.Long(nullable: false),
                        ZPAccessProfileID = c.String(nullable: false, maxLength: 100),
                        ZPAccessProfileNo = c.Int(nullable: false),
                        ZPAccessDescription = c.String(nullable: false, maxLength: 128),
                        HPCId = c.Long(nullable: false),
                        HPCHolidayCalenderId = c.Long(nullable: false),
                        HPCHolidayPlanCalendarNumber = c.Long(nullable: false),
                        HPCHolidayPlanCalendarName = c.String(nullable: false, maxLength: 128),
                        Datum = c.DateTime(storeType: "date"),
                        ZPGroupID = c.Long(),
                    })
                .PrimaryKey(t => new { t.AccessProfileID, t.ID, t.HolidayPlanCalendarId, t.ZPID, t.ZPAccessProfileID, t.ZPAccessProfileNo, t.ZPAccessDescription, t.HPCId, t.HPCHolidayCalenderId, t.HPCHolidayPlanCalendarNumber, t.HPCHolidayPlanCalendarName });
            
            CreateTable(
                "dbo.HolidayCalendar_with_DateTime",
                c => new
                    {
                        HolidayId = c.Long(nullable: false),
                        CalendarId = c.Long(nullable: false),
                        Datum = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => new { t.HolidayId, t.CalendarId });
            
            CreateTable(
                "dbo.HolidayPlanCalendarMapped",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarYear = c.Int(nullable: false),
                        HolidayPlanCalendarNumber = c.Long(nullable: false),
                        HolidayPlanCalendarName = c.String(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HolidayPlanCalendarMonthMapped",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        HolidayPlanCalendarId = c.Long(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day2ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day3ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day4ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day5ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day6ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day7ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day8ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day9ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day10ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day11ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day12ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day13ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day14ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day15ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day16ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day17ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day18ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day19ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day20ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day21ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day22ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day23ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day24ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day25ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day26ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day27ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day28ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day29ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day30ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day31ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HolidayPlanCalendarMapped", t => t.HolidayPlanCalendarId)
                .Index(t => t.HolidayPlanCalendarId);
            
            CreateTable(
                "dbo.Holiday",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        HolidayName = c.String(nullable: false),
                        HolidayDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        RegionID = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JC_Activities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ActivityNo = c.String(nullable: false),
                        ActivityDescription = c.String(nullable: false),
                        ActivityContent = c.String(nullable: false, maxLength: 50),
                        FlexCosts = c.String(nullable: false, maxLength: 50),
                        RunningCosts = c.String(nullable: false, maxLength: 50),
                        Surcharge = c.String(nullable: false, maxLength: 50),
                        Profit = c.String(nullable: false, maxLength: 50),
                        FlexCostPercent = c.String(maxLength: 50),
                        RunningCostPercent = c.String(maxLength: 50),
                        TotalCost = c.String(maxLength: 50),
                        SurchargePercent = c.String(maxLength: 50),
                        ProfitPercent = c.String(maxLength: 50),
                        CurrencyID = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.JC_Currency", t => t.CurrencyID)
                .Index(t => t.CurrencyID);
            
            CreateTable(
                "dbo.JC_Currency",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CurrencySymbol = c.String(nullable: false, maxLength: 50),
                        CurrencyCode = c.String(nullable: false, maxLength: 50),
                        CurrencyName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JC_Projects",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ProjectNr = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 128),
                        ProjectLeader = c.String(nullable: false, maxLength: 128),
                        TelephoneNo = c.String(maxLength: 50),
                        MobileNo = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        CreatedOn = c.DateTime(),
                        FreeFrom = c.DateTime(),
                        DeliveryTime = c.DateTime(),
                        DeliveryReadyTime = c.DateTime(),
                        CustomerNo = c.String(),
                        Company = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.ProjectNr, t.Description, t.ProjectLeader });
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Location_Nr = c.Long(nullable: false),
                        State = c.String(),
                        ZipCode = c.String(),
                        Street = c.String(),
                        HouseNumber = c.String(),
                        HolidayCalendarId = c.Long(),
                        LocationFederalStateId = c.Long(),
                        LocationHeadName = c.String(),
                        LocationHeadFunction = c.String(),
                        LocationHeadPhone = c.String(),
                        LocationHeadMobile = c.String(),
                        LocationHeadEmail = c.String(),
                        InfoText = c.String(),
                        Place = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MapCalendarMonth",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MapCalendarID = c.Long(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1DailyProgramId = c.Int(nullable: false),
                        Day2DailyProgramId = c.Int(nullable: false),
                        Day3DailyProgramId = c.Int(nullable: false),
                        Day4DailyProgramId = c.Int(nullable: false),
                        Day5DailyProgramId = c.Int(nullable: false),
                        Day6DailyProgramId = c.Int(nullable: false),
                        Day7DailyProgramId = c.Int(nullable: false),
                        Day8DailyProgramId = c.Int(nullable: false),
                        Day9DailyProgramId = c.Int(nullable: false),
                        Day10DailyProgramId = c.Int(nullable: false),
                        Day11DailyProgramId = c.Int(nullable: false),
                        Day12DailyProgramId = c.Int(nullable: false),
                        Day13DailyProgramId = c.Int(nullable: false),
                        Day14DailyProgramId = c.Int(nullable: false),
                        Day15DailyProgramId = c.Int(nullable: false),
                        Day16DailyProgramId = c.Int(nullable: false),
                        Day17DailyProgramId = c.Int(nullable: false),
                        Day18DailyProgramId = c.Int(nullable: false),
                        Day19DailyProgramId = c.Int(nullable: false),
                        Day20DailyProgramId = c.Int(nullable: false),
                        Day21DailyProgramId = c.Int(nullable: false),
                        Day22DailyProgramId = c.Int(nullable: false),
                        Day23DailyProgramId = c.Int(nullable: false),
                        Day24DailyProgramId = c.Int(nullable: false),
                        Day25DailyProgramId = c.Int(nullable: false),
                        Day26DailyProgramId = c.Int(nullable: false),
                        Day27DailyProgramId = c.Int(nullable: false),
                        Day28DailyProgramId = c.Int(nullable: false),
                        Day29DailyProgramId = c.Int(nullable: false),
                        Day30DailyProgramId = c.Int(nullable: false),
                        Day31DailyProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MapCalendar", t => t.MapCalendarID, cascadeDelete: true)
                .Index(t => t.MapCalendarID);
            
            CreateTable(
                "dbo.MapCalendar",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CalendarYear = c.Int(nullable: false),
                        MapCalendarNumber = c.Int(nullable: false),
                        MapCalendarIdNumber = c.String(maxLength: 4, unicode: false),
                        MapCalendarName = c.String(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuTable",
                c => new
                    {
                        AutoID = c.Int(nullable: false, identity: true),
                        TreeLevel = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Parent = c.String(nullable: false, maxLength: 50),
                        Root = c.String(nullable: false, maxLength: 50),
                        TreeDisplayPosition = c.Int(nullable: false),
                        Version = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AutoID);
            
            CreateTable(
                "dbo.MV_AccessControlLogs",
                c => new
                    {
                        Pers_Nr = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        Card_Nr = c.Long(nullable: false),
                        AccessTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DoorID = c.Int(nullable: false),
                        PlanDefinition = c.String(nullable: false, maxLength: 128),
                        LocationID = c.Int(),
                        BuildingID = c.Int(),
                        FloorID = c.Int(),
                        RoomID = c.Int(),
                        LocationName = c.String(),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => new { t.Pers_Nr, t.Name, t.Card_Nr, t.AccessTime, t.DoorID, t.PlanDefinition });
            
            CreateTable(
                "dbo.MV_AccessControlTransactionPersonel",
                c => new
                    {
                        AccessTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Card_Nr = c.Long(nullable: false),
                        Pers_Nr = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        ReaderID = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        LocationName = c.String(),
                        DepartmentName = c.String(),
                        SerialNumber = c.String(),
                    })
                .PrimaryKey(t => new { t.AccessTime, t.Card_Nr, t.Pers_Nr, t.Name, t.ReaderID });
            
            CreateTable(
                "dbo.MV_TerminalReaderBuildingPlans",
                c => new
                    {
                        ModelReaderID = c.Long(nullable: false),
                        ReaderID = c.Int(nullable: false),
                        DoorID = c.Int(nullable: false),
                        PlanDefinition = c.String(nullable: false, maxLength: 128),
                        SerialNumber = c.String(),
                        TerminalReaderID = c.String(maxLength: 8000, unicode: false),
                        LocationID = c.Int(),
                        BuildingID = c.Int(),
                        FloorID = c.Int(),
                        RoomID = c.Int(),
                    })
                .PrimaryKey(t => new { t.ModelReaderID, t.ReaderID, t.DoorID, t.PlanDefinition });
            
            CreateTable(
                "dbo.Pers_AccessPlanDuration",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        AccessPlanID = c.Long(nullable: false),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_AdditionalInfo",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        Passport_Nr = c.String(),
                        PhysicalAddress = c.String(),
                        Street = c.String(),
                        PlaceOfBirth = c.String(),
                        DOB = c.DateTime(precision: 7, storeType: "datetime2"),
                        Gender = c.String(),
                        MaritalStatus = c.String(),
                        Position = c.String(),
                        Profession = c.String(),
                        Nationality = c.String(),
                        VehicleModel = c.String(),
                        VehicleReg = c.String(),
                        CompanyName = c.String(),
                        EyeColor = c.String(maxLength: 50),
                        Height = c.String(maxLength: 50),
                        PostalCode = c.String(),
                        Salutation = c.String(),
                        Additonal = c.String(),
                        Bankname = c.String(),
                        AccountOwner = c.String(),
                        BankCode = c.String(),
                        AccountNo = c.String(),
                        BIC = c.String(),
                        IBAN = c.String(),
                        DriversLicense = c.String(),
                        Since = c.DateTime(precision: 7, storeType: "datetime2"),
                        Children = c.String(),
                        TaxOfficee = c.String(),
                        TaxClass = c.String(),
                        HealthInsuarance = c.String(),
                        HealInsuaranceNo = c.String(),
                        PensionInsuarance = c.String(),
                        SozVerzNo = c.String(),
                        Contract = c.String(),
                        EmployedFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        LearnedOccupation = c.String(),
                        EmployedAs = c.String(),
                        EmploymentType = c.String(),
                        ResidencePermit = c.String(),
                        AuthorisedBy = c.String(),
                        ApprovedBy = c.String(),
                        NoOfHours = c.String(),
                        EndOfContract = c.DateTime(precision: 7, storeType: "datetime2"),
                        EliminatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        Reason = c.String(),
                        CertificateOfEmployment = c.String(),
                        StreetNr = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_Archive",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Pers_Nr = c.Long(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        CardActive = c.Boolean(nullable: false),
                        EntryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Active = c.Boolean(nullable: false),
                        ArchivedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ArchivedBy = c.Long(nullable: false),
                        Title = c.String(),
                        MiddleName = c.String(),
                        Card_Nr = c.Long(),
                        ExitDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        PersType = c.Long(),
                        Memo = c.String(),
                        Imported = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.ID, t.Pers_Nr, t.FirstName, t.LastName, t.CardActive, t.EntryDate, t.Active, t.ArchivedDate, t.ArchivedBy });
            
            CreateTable(
                "dbo.Pers_Contact",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        CompanyTel = c.String(),
                        PrivateTel = c.String(),
                        CompanyMobile = c.String(),
                        PrivateMobile = c.String(),
                        CompanyFax = c.String(),
                        PrivateFax = c.String(),
                        CompanyEmail = c.String(),
                        PrivateEmail = c.String(),
                        PostalAddress = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_DrivingLicense",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(),
                        CreatedIn = c.String(),
                        DLNumber = c.String(),
                        DateOfIssue = c.DateTime(precision: 7, storeType: "datetime2"),
                        DLClass = c.String(),
                        IssuingAuthority = c.String(),
                        Memo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_DynamicFields",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(),
                        FieldIndex = c.Int(),
                        FieldValue = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_HealthCard",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(),
                        BoxNumber = c.String(),
                        CreatedIn = c.String(),
                        ItemNumber = c.String(),
                        SecurityNumber = c.String(),
                        CardNumber = c.String(),
                        ExpiryDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_IdentityCard",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(),
                        CreatedIn = c.String(),
                        IDNumber = c.String(),
                        AdditionalNumber = c.String(),
                        DateOfIssue = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExpiryDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Address = c.String(),
                        IssuingAuthority = c.String(),
                        Memo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_Locations",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(),
                        LocationID = c.Long(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_Passport",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(),
                        CreatedIn = c.String(),
                        PPNumber = c.String(),
                        Gender = c.String(maxLength: 50),
                        DateOfIssue = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExpiryDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IssuingAuthority = c.String(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_Photo",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        Pers_Passport = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_PinCode",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        PinCode = c.String(),
                        PinCodeType = c.Int(),
                        PinCodeStatus = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_Transponders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PersNr = c.Long(nullable: false),
                        TransponderNr = c.Long(nullable: false),
                        TransponderStatus = c.Boolean(),
                        ValidFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        ValidTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        TransponderDeactivatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        Action = c.Int(),
                        Memo = c.String(),
                        TransponderType = c.Int(),
                        ExtendedTo = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pers_Visitors",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Pers_Nr = c.Long(nullable: false),
                        VisitorID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Portal_Audit",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        usr_id = c.Long(nullable: false),
                        u_action = c.String(nullable: false, maxLength: 100),
                        comment = c.String(),
                        audit_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Portal_PermissionMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PermissionKey = c.Long(nullable: false),
                        PermissionType = c.Long(nullable: false),
                        ProfileID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Portal_PermissionProfile", t => t.ProfileID, cascadeDelete: true)
                .ForeignKey("dbo.Portal_Permissions", t => t.PermissionKey, cascadeDelete: true)
                .Index(t => t.PermissionKey)
                .Index(t => t.ProfileID);
            
            CreateTable(
                "dbo.Portal_PermissionProfile",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ProfileNr = c.Int(nullable: false),
                        ProfileDescription = c.String(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Portal_ProfileUSerMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        USerID = c.Long(nullable: false),
                        ProfileID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Portal_Users", t => t.USerID, cascadeDelete: true)
                .ForeignKey("dbo.Portal_PermissionProfile", t => t.ProfileID, cascadeDelete: true)
                .Index(t => t.USerID)
                .Index(t => t.ProfileID);
            
            CreateTable(
                "dbo.Portal_Users",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        PortalNo = c.Long(nullable: false, identity: true),
                        Salutation = c.String(nullable: false, maxLength: 50),
                        Firstname = c.String(nullable: false),
                        Surname = c.String(),
                        MobileNo = c.String(maxLength: 50),
                        TelephoneNo = c.String(maxLength: 50),
                        TaxId = c.String(),
                        CompanyName = c.String(nullable: false),
                        StreetNo = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        Location = c.String(),
                        Country = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                        StreetName = c.String(),
                        Code = c.String(nullable: false),
                        Isactive = c.Boolean(nullable: false),
                        FirstPassChanged = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserRoles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Role = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Portal_Permissions",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Permission = c.String(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RawBookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmpID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        EmpIDDate = c.String(nullable: false),
                        TermID = c.Int(),
                        TermSlot = c.String(nullable: false),
                        TimeSlot = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Occupant = c.String(nullable: false),
                        DoorID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RV_AccessPlanAccessCalendar",
                c => new
                    {
                        AccessPlanNr = c.Long(nullable: false),
                        Calendar_Nr = c.Int(nullable: false),
                        Calendar_Name = c.String(nullable: false, maxLength: 128),
                        AccessProfileID = c.Long(nullable: false),
                        AccessCalendarMonthNr = c.Int(nullable: false),
                        AccessPlanDescription = c.String(),
                        Day1ProfileAccessProfileID = c.String(maxLength: 100),
                        Day2ProfileAccessProfileID = c.String(maxLength: 100),
                        Day3ProfileAccessProfileID = c.String(maxLength: 100),
                        Day4ProfileAccessProfileID = c.String(maxLength: 100),
                        Day5ProfileAccessProfileID = c.String(maxLength: 100),
                        Day6ProfileAccessProfileID = c.String(maxLength: 100),
                        Day7ProfileAccessProfileID = c.String(maxLength: 100),
                        Day8ProfileAccessProfileID = c.String(maxLength: 100),
                        Day9ProfileAccessProfileID = c.String(maxLength: 100),
                        Day10ProfileAccessProfileID = c.String(maxLength: 100),
                        Day11ProfileAccessProfileID = c.String(maxLength: 100),
                        Day12ProfileAccessProfileID = c.String(maxLength: 100),
                        Day13ProfileAccessProfileID = c.String(maxLength: 100),
                        Day14ProfileAccessProfileID = c.String(maxLength: 100),
                        Day15ProfileAccessProfileID = c.String(maxLength: 100),
                        Day16ProfileAccessProfileID = c.String(maxLength: 100),
                        Day17ProfileAccessProfileID = c.String(maxLength: 100),
                        Day18ProfileAccessProfileID = c.String(maxLength: 100),
                        Day19ProfileAccessProfileID = c.String(maxLength: 100),
                        Day20ProfileAccessProfileID = c.String(maxLength: 100),
                        Day21ProfileAccessProfileID = c.String(maxLength: 100),
                        Day22ProfileAccessProfileID = c.String(maxLength: 100),
                        Day23ProfileAccessProfileID = c.String(maxLength: 100),
                        Day24ProfileAccessProfileID = c.String(maxLength: 100),
                        Day25ProfileAccessProfileID = c.String(maxLength: 100),
                        Day26ProfileAccessProfileID = c.String(maxLength: 100),
                        Day27ProfileAccessProfileID = c.String(maxLength: 100),
                        Day28ProfileAccessProfileID = c.String(maxLength: 100),
                        Day29ProfileAccessProfileID = c.String(maxLength: 100),
                        Day30ProfileAccessProfileID = c.String(maxLength: 100),
                        Day31ProfileAccessProfileID = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.AccessPlanNr, t.Calendar_Nr, t.Calendar_Name, t.AccessProfileID, t.AccessCalendarMonthNr });
            
            CreateTable(
                "dbo.RV_AccessPlanPersonnel",
                c => new
                    {
                        Pers_Nr = c.Long(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        AccessPlanNr = c.Long(),
                        AccessPlanDescription = c.String(),
                        Card_Nr = c.Long(),
                        CostCenterName = c.String(),
                        LocationName = c.String(),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => new { t.Pers_Nr, t.FirstName, t.LastName });
            
            CreateTable(
                "dbo.RV_AccessProfilesPerTerminal",
                c => new
                    {
                        BuildingPlanID = c.Long(nullable: false),
                        TermID = c.Int(nullable: false),
                        TerminalID = c.Long(nullable: false),
                        AccesCalenderNo = c.Long(nullable: false),
                        ProfileID = c.Int(nullable: false),
                        AccessProfileID = c.String(nullable: false, maxLength: 100),
                        AccessProfileNo = c.Int(nullable: false),
                        AccessDescription = c.String(nullable: false, maxLength: 128),
                        ProfilAktiv = c.Boolean(nullable: false),
                        MonFrom = c.DateTime(nullable: false),
                        MonTo = c.DateTime(nullable: false),
                        TueFrom = c.DateTime(nullable: false),
                        TueTo = c.DateTime(nullable: false),
                        WedFrom = c.DateTime(nullable: false),
                        WedTo = c.DateTime(nullable: false),
                        ThurFrom = c.DateTime(nullable: false),
                        ThurTo = c.DateTime(nullable: false),
                        FriFrom = c.DateTime(nullable: false),
                        FriTo = c.DateTime(nullable: false),
                        SatFrom = c.DateTime(nullable: false),
                        SatTo = c.DateTime(nullable: false),
                        SunFrom = c.DateTime(nullable: false),
                        SunTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BuildingPlanID, t.TermID, t.TerminalID, t.AccesCalenderNo, t.ProfileID, t.AccessProfileID, t.AccessProfileNo, t.AccessDescription, t.ProfilAktiv, t.MonFrom, t.MonTo, t.TueFrom, t.TueTo, t.WedFrom, t.WedTo, t.ThurFrom, t.ThurTo, t.FriFrom, t.FriTo, t.SatFrom, t.SatTo, t.SunFrom, t.SunTo });
            
            CreateTable(
                "dbo.RV_HolidayCalendar",
                c => new
                    {
                        TermID = c.Int(nullable: false),
                        TermType = c.String(nullable: false, maxLength: 128),
                        HolidayPlanCalendarNumber = c.Long(nullable: false),
                        HolidayPlanCalendarName = c.String(nullable: false, maxLength: 128),
                        CalendarMonth = c.Int(nullable: false),
                        Day1ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day2ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day3ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day4ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day5ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day6ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day7ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day8ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day9ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day10ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day11ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day12ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day13ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day14ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day15ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day16ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day17ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day18ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day19ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day20ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day21ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day22ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day23ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day24ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day25ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day26ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day27ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day28ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day29ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day30ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day31ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.TermID, t.TermType, t.HolidayPlanCalendarNumber, t.HolidayPlanCalendarName, t.CalendarMonth, t.Day1ProfileName, t.Day2ProfileName, t.Day3ProfileName, t.Day4ProfileName, t.Day5ProfileName, t.Day6ProfileName, t.Day7ProfileName, t.Day8ProfileName, t.Day9ProfileName, t.Day10ProfileName, t.Day11ProfileName, t.Day12ProfileName, t.Day13ProfileName, t.Day14ProfileName, t.Day15ProfileName, t.Day16ProfileName, t.Day17ProfileName, t.Day18ProfileName, t.Day19ProfileName, t.Day20ProfileName, t.Day21ProfileName, t.Day22ProfileName, t.Day23ProfileName, t.Day24ProfileName, t.Day25ProfileName, t.Day26ProfileName, t.Day27ProfileName, t.Day28ProfileName, t.Day29ProfileName, t.Day30ProfileName, t.Day31ProfileName });
            
            CreateTable(
                "dbo.RV_HolidayCalendarAccessPlan",
                c => new
                    {
                        AccessPlanNr = c.Long(nullable: false),
                        HolidayPlanCalendarNumber = c.Long(nullable: false),
                        HolidayPlanCalendarName = c.String(nullable: false, maxLength: 128),
                        CalendarMonth = c.Int(nullable: false),
                        Day1ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day2ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day3ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day4ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day5ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day6ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day7ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day8ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day9ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day10ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day11ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day12ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day13ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day14ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day15ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day16ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day17ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day18ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day19ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day20ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day21ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day22ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day23ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day24ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day25ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day26ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day27ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day28ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day29ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day30ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day31ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => new { t.AccessPlanNr, t.HolidayPlanCalendarNumber, t.HolidayPlanCalendarName, t.CalendarMonth, t.Day1ProfileName, t.Day2ProfileName, t.Day3ProfileName, t.Day4ProfileName, t.Day5ProfileName, t.Day6ProfileName, t.Day7ProfileName, t.Day8ProfileName, t.Day9ProfileName, t.Day10ProfileName, t.Day11ProfileName, t.Day12ProfileName, t.Day13ProfileName, t.Day14ProfileName, t.Day15ProfileName, t.Day16ProfileName, t.Day17ProfileName, t.Day18ProfileName, t.Day19ProfileName, t.Day20ProfileName, t.Day21ProfileName, t.Day22ProfileName, t.Day23ProfileName, t.Day24ProfileName, t.Day25ProfileName, t.Day26ProfileName, t.Day27ProfileName, t.Day28ProfileName, t.Day29ProfileName, t.Day30ProfileName, t.Day31ProfileName });
            
            CreateTable(
                "dbo.RV_HolidayCalendarNames",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 2, unicode: false),
                        HolidayCalendarID = c.String(maxLength: 7, unicode: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.RV_HolidayPlanAccessPlan",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        TermID = c.Int(nullable: false),
                        TermType = c.String(nullable: false, maxLength: 128),
                        AccessPlanID = c.Long(nullable: false),
                        AccessPlanNumber = c.Long(nullable: false),
                        HolidayPlanID = c.Long(nullable: false),
                        HolidayPlanNumber = c.Long(nullable: false),
                        HolidayPlanName = c.String(nullable: false, maxLength: 128),
                        CalendarYear = c.Int(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Description = c.String(),
                        AccessPlanDescription = c.String(),
                        Day1Holiday = c.String(maxLength: 100),
                        Day2Holiday = c.String(maxLength: 100),
                        Day3Holiday = c.String(maxLength: 100),
                        Day4Holiday = c.String(maxLength: 100),
                        Day5Holiday = c.String(maxLength: 100),
                        Day6Holiday = c.String(maxLength: 100),
                        Day7Holiday = c.String(maxLength: 100),
                        Day8Holiday = c.String(maxLength: 100),
                        Day9Holiday = c.String(maxLength: 100),
                        Day10Holiday = c.String(maxLength: 100),
                        Day11Holiday = c.String(maxLength: 100),
                        Day12Holiday = c.String(maxLength: 100),
                        Day13Holiday = c.String(maxLength: 100),
                        Day14Holiday = c.String(maxLength: 100),
                        Day15Holiday = c.String(maxLength: 100),
                        Day16Holiday = c.String(maxLength: 100),
                        Day17Holiday = c.String(maxLength: 100),
                        Day18Holiday = c.String(maxLength: 100),
                        Day19Holiday = c.String(maxLength: 100),
                        Day20Holiday = c.String(maxLength: 100),
                        Day21Holiday = c.String(maxLength: 100),
                        Day22Holiday = c.String(maxLength: 100),
                        Day23Holiday = c.String(maxLength: 100),
                        Day24Holiday = c.String(maxLength: 100),
                        Day25Holiday = c.String(maxLength: 100),
                        Day26Holiday = c.String(maxLength: 100),
                        Day27Holiday = c.String(maxLength: 100),
                        Day28Holiday = c.String(maxLength: 100),
                        Day29Holiday = c.String(maxLength: 100),
                        Day30Holiday = c.String(maxLength: 100),
                        Day31Holiday = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.ID, t.TermID, t.TermType, t.AccessPlanID, t.AccessPlanNumber, t.HolidayPlanID, t.HolidayPlanNumber, t.HolidayPlanName, t.CalendarYear, t.CalendarMonth });
            
            CreateTable(
                "dbo.RV_HolidayPlanAccessProfilesPerTerminal",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        TermID = c.Int(nullable: false),
                        TermType = c.String(nullable: false, maxLength: 128),
                        AccessPlanID = c.Long(nullable: false),
                        AccessPlanNumber = c.Long(nullable: false),
                        HolidayPlanID = c.Long(nullable: false),
                        HolidayPlanNumber = c.Long(nullable: false),
                        HolidayPlanName = c.String(nullable: false, maxLength: 128),
                        CalendarYear = c.Int(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        AccessProfileNo = c.Int(nullable: false),
                        ProfilAktiv = c.Boolean(nullable: false),
                        MonFrom = c.DateTime(nullable: false),
                        MonTo = c.DateTime(nullable: false),
                        TueFrom = c.DateTime(nullable: false),
                        TueTo = c.DateTime(nullable: false),
                        WedFrom = c.DateTime(nullable: false),
                        WedTo = c.DateTime(nullable: false),
                        ThurFrom = c.DateTime(nullable: false),
                        ThurTo = c.DateTime(nullable: false),
                        FriFrom = c.DateTime(nullable: false),
                        FriTo = c.DateTime(nullable: false),
                        SatFrom = c.DateTime(nullable: false),
                        SatTo = c.DateTime(nullable: false),
                        SunFrom = c.DateTime(nullable: false),
                        SunTo = c.DateTime(nullable: false),
                        Description = c.String(),
                        AccessPlanDescription = c.String(),
                        AccessProfileID = c.Long(),
                        Memo = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => new { t.ID, t.TermID, t.TermType, t.AccessPlanID, t.AccessPlanNumber, t.HolidayPlanID, t.HolidayPlanNumber, t.HolidayPlanName, t.CalendarYear, t.CalendarMonth, t.AccessProfileNo, t.ProfilAktiv, t.MonFrom, t.MonTo, t.TueFrom, t.TueTo, t.WedFrom, t.WedTo, t.ThurFrom, t.ThurTo, t.FriFrom, t.FriTo, t.SatFrom, t.SatTo, t.SunFrom, t.SunTo });
            
            CreateTable(
                "dbo.RV_HolidayPlanPerTerminal",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        TermID = c.Int(nullable: false),
                        TermType = c.String(nullable: false, maxLength: 128),
                        AccessPlanID = c.Long(nullable: false),
                        AccessPlanNumber = c.Long(nullable: false),
                        HolidayPlanID = c.Long(nullable: false),
                        HolidayPlanNumber = c.Long(nullable: false),
                        HolidayPlanName = c.String(nullable: false, maxLength: 128),
                        CalendarYear = c.Int(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Description = c.String(),
                        AccessPlanDescription = c.String(),
                        Day1Holiday = c.String(maxLength: 100),
                        Day2Holiday = c.String(maxLength: 100),
                        Day3Holiday = c.String(maxLength: 100),
                        Day4Holiday = c.String(maxLength: 100),
                        Day5Holiday = c.String(maxLength: 100),
                        Day6Holiday = c.String(maxLength: 100),
                        Day7Holiday = c.String(maxLength: 100),
                        Day8Holiday = c.String(maxLength: 100),
                        Day9Holiday = c.String(maxLength: 100),
                        Day10Holiday = c.String(maxLength: 100),
                        Day11Holiday = c.String(maxLength: 100),
                        Day12Holiday = c.String(maxLength: 100),
                        Day13Holiday = c.String(maxLength: 100),
                        Day14Holiday = c.String(maxLength: 100),
                        Day15Holiday = c.String(maxLength: 100),
                        Day16Holiday = c.String(maxLength: 100),
                        Day17Holiday = c.String(maxLength: 100),
                        Day18Holiday = c.String(maxLength: 100),
                        Day19Holiday = c.String(maxLength: 100),
                        Day20Holiday = c.String(maxLength: 100),
                        Day21Holiday = c.String(maxLength: 100),
                        Day22Holiday = c.String(maxLength: 100),
                        Day23Holiday = c.String(maxLength: 100),
                        Day24Holiday = c.String(maxLength: 100),
                        Day25Holiday = c.String(maxLength: 100),
                        Day26Holiday = c.String(maxLength: 100),
                        Day27Holiday = c.String(maxLength: 100),
                        Day28Holiday = c.String(maxLength: 100),
                        Day29Holiday = c.String(maxLength: 100),
                        Day30Holiday = c.String(maxLength: 100),
                        Day31Holiday = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.ID, t.TermID, t.TermType, t.AccessPlanID, t.AccessPlanNumber, t.HolidayPlanID, t.HolidayPlanNumber, t.HolidayPlanName, t.CalendarYear, t.CalendarMonth });
            
            CreateTable(
                "dbo.RV_HolidayPlanSwitchPlan",
                c => new
                    {
                        SwitchPlanNumber = c.Long(nullable: false),
                        HolidayPlanCalendarNumber = c.Long(nullable: false),
                        HolidayPlanCalendarName = c.String(nullable: false, maxLength: 128),
                        CalendarMonth = c.Int(nullable: false),
                        Day1ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day2ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day3ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day4ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day5ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day6ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day7ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day8ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day9ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day10ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day11ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day12ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day13ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day14ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day15ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day16ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day17ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day18ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day19ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day20ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day21ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day22ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day23ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day24ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day25ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day26ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day27ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day28ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day29ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day30ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                        Day31ProfileName = c.String(nullable: false, maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => new { t.SwitchPlanNumber, t.HolidayPlanCalendarNumber, t.HolidayPlanCalendarName, t.CalendarMonth, t.Day1ProfileName, t.Day2ProfileName, t.Day3ProfileName, t.Day4ProfileName, t.Day5ProfileName, t.Day6ProfileName, t.Day7ProfileName, t.Day8ProfileName, t.Day9ProfileName, t.Day10ProfileName, t.Day11ProfileName, t.Day12ProfileName, t.Day13ProfileName, t.Day14ProfileName, t.Day15ProfileName, t.Day16ProfileName, t.Day17ProfileName, t.Day18ProfileName, t.Day19ProfileName, t.Day20ProfileName, t.Day21ProfileName, t.Day22ProfileName, t.Day23ProfileName, t.Day24ProfileName, t.Day25ProfileName, t.Day26ProfileName, t.Day27ProfileName, t.Day28ProfileName, t.Day29ProfileName, t.Day30ProfileName, t.Day31ProfileName });
            
            CreateTable(
                "dbo.RV_SwitchPlanSwitchCalendar",
                c => new
                    {
                        SwitchPlanNumber = c.Long(nullable: false),
                        SwitchPlanName = c.String(nullable: false, maxLength: 128),
                        SwitchCalendarNumber = c.String(nullable: false, maxLength: 50, unicode: false),
                        SwitchCalendarName = c.String(nullable: false, maxLength: 50, unicode: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1SwitchProfileID = c.String(maxLength: 4),
                        Day2SwitchProfileID = c.String(maxLength: 4),
                        Day3SwitchProfileID = c.String(maxLength: 4),
                        Day4SwitchProfileID = c.String(maxLength: 4),
                        Day5SwitchProfileID = c.String(maxLength: 4),
                        Day6SwitchProfileID = c.String(maxLength: 4),
                        Day7SwitchProfileID = c.String(maxLength: 4),
                        Day8SwitchProfileID = c.String(maxLength: 4),
                        Day9SwitchProfileID = c.String(maxLength: 4),
                        Day10SwitchProfileID = c.String(maxLength: 4),
                        Day11SwitchProfileID = c.String(maxLength: 4),
                        Day12SwitchProfileID = c.String(maxLength: 4),
                        Day13SwitchProfileID = c.String(maxLength: 4),
                        Day14SwitchProfileID = c.String(maxLength: 4),
                        Day15SwitchProfileID = c.String(maxLength: 4),
                        Day16SwitchProfileID = c.String(maxLength: 4),
                        Day17SwitchProfileID = c.String(maxLength: 4),
                        Day18SwitchProfileID = c.String(maxLength: 4),
                        Day19SwitchProfileID = c.String(maxLength: 4),
                        Day20SwitchProfileID = c.String(maxLength: 4),
                        Day21SwitchProfileID = c.String(maxLength: 4),
                        Day22SwitchProfileID = c.String(maxLength: 4),
                        Day23SwitchProfileID = c.String(maxLength: 4),
                        Day24SwitchProfileID = c.String(maxLength: 4),
                        Day25SwitchProfileID = c.String(maxLength: 4),
                        Day26SwitchProfileID = c.String(maxLength: 4),
                        Day27SwitchProfileID = c.String(maxLength: 4),
                        Day28SwitchProfileID = c.String(maxLength: 4),
                        Day29SwitchProfileID = c.String(maxLength: 4),
                        Day30SwitchProfileID = c.String(maxLength: 4),
                        Day31SwitchProfileID = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => new { t.SwitchPlanNumber, t.SwitchPlanName, t.SwitchCalendarNumber, t.SwitchCalendarName, t.CalendarMonth });
            
            CreateTable(
                "dbo.RV_SwitchProfileGroupedPerTerminal",
                c => new
                    {
                        BuildingPlanID = c.Long(nullable: false),
                        TermID = c.Int(nullable: false),
                        TerminalID = c.Long(nullable: false),
                        TermType = c.String(nullable: false, maxLength: 128),
                        CalendarID = c.Long(nullable: false),
                        SwitchProfileID = c.Int(nullable: false),
                        Profile_Id = c.String(nullable: false, maxLength: 4),
                        Profile_Nr = c.Long(nullable: false),
                        Number = c.Int(nullable: false),
                        DayFrom = c.Int(nullable: false),
                        DayTo = c.Int(nullable: false),
                        TimeFrom = c.DateTime(nullable: false),
                        TimeTo = c.DateTime(nullable: false),
                        num = c.Int(nullable: false),
                        RowNum = c.Long(),
                        TerminalDescription = c.String(),
                        ProfileDescription = c.String(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => new { t.BuildingPlanID, t.TermID, t.TerminalID, t.TermType, t.CalendarID, t.SwitchProfileID, t.Profile_Id, t.Profile_Nr, t.Number, t.DayFrom, t.DayTo, t.TimeFrom, t.TimeTo, t.num });
            
            CreateTable(
                "dbo.RV_VisitorPlanAccessCalendar",
                c => new
                    {
                        VisitorPlanNr = c.Long(nullable: false),
                        Calendar_Nr = c.Int(nullable: false),
                        Calendar_Name = c.String(nullable: false, maxLength: 128),
                        AccessProfileID = c.Long(nullable: false),
                        AccessCalendarMonthNr = c.Int(nullable: false),
                        VisitorPlanDescription = c.String(),
                        Day1ProfileAccessProfileID = c.String(maxLength: 100),
                        Day2ProfileAccessProfileID = c.String(maxLength: 100),
                        Day3ProfileAccessProfileID = c.String(maxLength: 100),
                        Day4ProfileAccessProfileID = c.String(maxLength: 100),
                        Day5ProfileAccessProfileID = c.String(maxLength: 100),
                        Day6ProfileAccessProfileID = c.String(maxLength: 100),
                        Day7ProfileAccessProfileID = c.String(maxLength: 100),
                        Day8ProfileAccessProfileID = c.String(maxLength: 100),
                        Day9ProfileAccessProfileID = c.String(maxLength: 100),
                        Day10ProfileAccessProfileID = c.String(maxLength: 100),
                        Day11ProfileAccessProfileID = c.String(maxLength: 100),
                        Day12ProfileAccessProfileID = c.String(maxLength: 100),
                        Day13ProfileAccessProfileID = c.String(maxLength: 100),
                        Day14ProfileAccessProfileID = c.String(maxLength: 100),
                        Day15ProfileAccessProfileID = c.String(maxLength: 100),
                        Day16ProfileAccessProfileID = c.String(maxLength: 100),
                        Day17ProfileAccessProfileID = c.String(maxLength: 100),
                        Day18ProfileAccessProfileID = c.String(maxLength: 100),
                        Day19ProfileAccessProfileID = c.String(maxLength: 100),
                        Day20ProfileAccessProfileID = c.String(maxLength: 100),
                        Day21ProfileAccessProfileID = c.String(maxLength: 100),
                        Day22ProfileAccessProfileID = c.String(maxLength: 100),
                        Day23ProfileAccessProfileID = c.String(maxLength: 100),
                        Day24ProfileAccessProfileID = c.String(maxLength: 100),
                        Day25ProfileAccessProfileID = c.String(maxLength: 100),
                        Day26ProfileAccessProfileID = c.String(maxLength: 100),
                        Day27ProfileAccessProfileID = c.String(maxLength: 100),
                        Day28ProfileAccessProfileID = c.String(maxLength: 100),
                        Day29ProfileAccessProfileID = c.String(maxLength: 100),
                        Day30ProfileAccessProfileID = c.String(maxLength: 100),
                        Day31ProfileAccessProfileID = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.VisitorPlanNr, t.Calendar_Nr, t.Calendar_Name, t.AccessProfileID, t.AccessCalendarMonthNr });
            
            CreateTable(
                "dbo.RV_VisitorPlanVisitors",
                c => new
                    {
                        AccessPlanNr = c.Long(nullable: false),
                        Pers_Nr = c.Long(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        AccessPlanDescription = c.String(),
                        Card_Nr = c.Long(),
                        CostCenterName = c.String(),
                        LocationName = c.String(),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => new { t.AccessPlanNr, t.Pers_Nr, t.FirstName, t.LastName });
            
            CreateTable(
                "dbo.SCP",
                c => new
                    {
                        SwitchCalendarID = c.Long(nullable: false),
                        SwitchProfileId = c.Int(nullable: false),
                        CalendaDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.SwitchCalendarID, t.SwitchProfileId });
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.String(nullable: false, maxLength: 88),
                        Created = c.DateTime(nullable: false),
                        Expires = c.DateTime(nullable: false),
                        LockDate = c.DateTime(nullable: false),
                        LockCookie = c.Int(nullable: false),
                        Locked = c.Boolean(nullable: false),
                        SessionItem = c.Binary(),
                        Flags = c.Int(nullable: false),
                        Timeout = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessionId);
            
            CreateTable(
                "dbo.ShiftResourceBac",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        IsDefaultLoaded = c.Boolean(nullable: false),
                        Code = c.String(maxLength: 50, unicode: false),
                        Description = c.String(),
                        Color = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Name, t.IsDefaultLoaded });
            
            CreateTable(
                "dbo.Status_Dynamic",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StatusNr = c.Int(),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Status_Static",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StatusNr = c.Int(),
                        StatusName = c.String(maxLength: 50),
                        LastAccess = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SwitchCalendarMapped",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CalendarYear = c.Int(nullable: false),
                        SwitchCalendarNumber = c.String(nullable: false, maxLength: 50, unicode: false),
                        SwitchCalendarName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Memo = c.String(maxLength: 400, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SwitchCalendarMonthMapped",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SwitchCalendarId = c.Long(nullable: false),
                        CalendarMonth = c.Int(nullable: false),
                        Day1SwitchProfileId = c.Int(nullable: false),
                        Day2SwitchProfileId = c.Int(nullable: false),
                        Day3SwitchProfileId = c.Int(nullable: false),
                        Day4SwitchProfileId = c.Int(nullable: false),
                        Day5SwitchProfileId = c.Int(nullable: false),
                        Day6SwitchProfileId = c.Int(nullable: false),
                        Day7SwitchProfileId = c.Int(nullable: false),
                        Day8SwitchProfileId = c.Int(nullable: false),
                        Day9SwitchProfileId = c.Int(nullable: false),
                        Day10SwitchProfileId = c.Int(nullable: false),
                        Day11SwitchProfileId = c.Int(nullable: false),
                        Day12SwitchProfileId = c.Int(nullable: false),
                        Day13SwitchProfileId = c.Int(nullable: false),
                        Day14SwitchProfileId = c.Int(nullable: false),
                        Day15SwitchProfileId = c.Int(nullable: false),
                        Day16SwitchProfileId = c.Int(nullable: false),
                        Day17SwitchProfileId = c.Int(nullable: false),
                        Day18SwitchProfileId = c.Int(nullable: false),
                        Day19SwitchProfileId = c.Int(nullable: false),
                        Day20SwitchProfileId = c.Int(nullable: false),
                        Day21SwitchProfileId = c.Int(nullable: false),
                        Day22SwitchProfileId = c.Int(nullable: false),
                        Day23SwitchProfileId = c.Int(nullable: false),
                        Day24SwitchProfileId = c.Int(nullable: false),
                        Day25SwitchProfileId = c.Int(nullable: false),
                        Day26SwitchProfileId = c.Int(nullable: false),
                        Day27SwitchProfileId = c.Int(nullable: false),
                        Day28SwitchProfileId = c.Int(nullable: false),
                        Day29SwitchProfileId = c.Int(nullable: false),
                        Day30SwitchProfileId = c.Int(nullable: false),
                        Day31SwitchProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SwitchCalendarMapped", t => t.SwitchCalendarId)
                .Index(t => t.SwitchCalendarId);
            
            CreateTable(
                "dbo.SwitchCalendarProfiles",
                c => new
                    {
                        SwitchCalendarID = c.Long(nullable: false),
                        SwitchProfileId = c.Int(nullable: false),
                        CalendaDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.SwitchCalendarID, t.SwitchProfileId });
            
            CreateTable(
                "dbo.SwitchProfilePairs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ProfileID = c.Long(nullable: false),
                        Number = c.Int(nullable: false),
                        DayFrom = c.Int(nullable: false),
                        DayTo = c.Int(nullable: false),
                        TimeFrom = c.DateTime(nullable: false),
                        TimeTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SwitchProfiles",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Profile_Nr = c.Long(nullable: false),
                        Profile_Id = c.String(nullable: false, maxLength: 4),
                        Description = c.String(),
                        ProfileTimeMode = c.Int(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.TA_BookingsReport",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        BookingsReportTypeNr = c.Int(nullable: false),
                        DailyBookingsTabPosition = c.Int(nullable: false),
                        Orientation = c.Int(nullable: false),
                        AbsencePosition = c.Int(nullable: false),
                        TpPosition = c.Int(nullable: false),
                        ShiftPosition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TA_BookingsReportAbsences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReportID = c.Int(nullable: false),
                        AbsenceID = c.Int(nullable: false),
                        AbsencePosition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TA_BookingsReport", t => t.ReportID, cascadeDelete: true)
                .Index(t => t.ReportID);
            
            CreateTable(
                "dbo.TA_BookingsReportAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReportID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                        AccountPosition = c.Int(nullable: false),
                        DailySum = c.Boolean(nullable: false),
                        WeeklySum = c.Boolean(nullable: false),
                        MonthlySum = c.Boolean(nullable: false),
                        YearlySum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TA_BookingsReport", t => t.ReportID, cascadeDelete: true)
                .Index(t => t.ReportID);
            
            CreateTable(
                "dbo.TA_BookingsReportTitles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReportID = c.Int(nullable: false),
                        PositionNr = c.Int(nullable: false),
                        PositionTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TA_BookingsReport", t => t.ReportID, cascadeDelete: true)
                .Index(t => t.ReportID);
            
            CreateTable(
                "dbo.TA_BookingsReportTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        InBookings = c.Int(nullable: false),
                        OutBookings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TbAcessPlanReaderMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BuildingID = c.Long(nullable: false),
                        AcessPlanID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TerminalBookingRawData",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        EmpNumber = c.Int(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        StatusNr = c.Int(),
                        ProcessingStatus = c.Int(),
                        Comment = c.String(),
                        Source = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TerminalConnectionType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ConnectionType = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TerminalOEMNew",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        TerminalOEMNr = c.Int(),
                        TerminalOEMDescription = c.String(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TerminalsNew",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        TermOEMID = c.Long(),
                        TermType = c.String(),
                        Description = c.String(),
                        Connection = c.String(maxLength: 50),
                        Reader = c.String(),
                        Access = c.String(),
                        Image = c.String(),
                        TermOEM = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TimeRanges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transponders",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TransponderNr = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.View_AccessCalendarProfiles",
                c => new
                    {
                        AccessCalendarID = c.Long(nullable: false),
                        ProfileID = c.Int(nullable: false),
                        DateTime = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.AccessCalendarID, t.ProfileID });
            
            CreateTable(
                "dbo.View_AccessLogs",
                c => new
                    {
                        Pers_Type = c.Int(nullable: false),
                        ID_Nr = c.Long(nullable: false),
                        Card_Nr = c.Long(nullable: false),
                        TA_Come = c.Int(nullable: false),
                        TA_Go = c.Int(nullable: false),
                        BookingTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BookingCorrection = c.Int(nullable: false),
                        LogID = c.Long(nullable: false),
                        ID = c.Long(),
                        FullName = c.String(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        ClientName = c.String(),
                        AccessEndData = c.DateTime(precision: 7, storeType: "datetime2"),
                        DynamicField1 = c.String(),
                        PlanDefinition = c.String(),
                        BuildingPlanID = c.Long(),
                        LocationID = c.Int(),
                        BuildingID = c.Int(),
                        FloorID = c.Int(),
                        RoomID = c.Int(),
                        DoorID = c.Int(),
                    })
                .PrimaryKey(t => new { t.Pers_Type, t.ID_Nr, t.Card_Nr, t.TA_Come, t.TA_Go, t.BookingTime, t.BookingCorrection, t.LogID });
            
            CreateTable(
                "dbo.View_CardAllocationOverview",
                c => new
                    {
                        Pers_Nr = c.Long(nullable: false),
                        PersonnelActive = c.Boolean(nullable: false),
                        ClientName = c.String(nullable: false, maxLength: 128),
                        ClientID = c.Long(nullable: false),
                        Client_Nr = c.Long(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false, maxLength: 128),
                        Location_Nr = c.Long(nullable: false),
                        Department_Nr = c.Long(nullable: false),
                        CostCenter_Nr = c.Long(nullable: false),
                        TransPonderID = c.Long(nullable: false),
                        TransponderNr = c.Long(nullable: false),
                        ID = c.Long(),
                        LocationName = c.String(),
                        LocationID = c.Long(),
                        DepartmentName = c.String(),
                        DepartmentID = c.Long(),
                        CostCenterName = c.String(),
                        CostCenterID = c.Long(),
                        Action = c.Int(),
                        TransponderStatus = c.Boolean(),
                        ValidTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        TransponderDeactivatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.Pers_Nr, t.PersonnelActive, t.ClientName, t.ClientID, t.Client_Nr, t.LastName, t.FirstName, t.FullName, t.Location_Nr, t.Department_Nr, t.CostCenter_Nr, t.TransPonderID, t.TransponderNr });
            
            CreateTable(
                "dbo.View_DFHoliday",
                c => new
                    {
                        HolidayDate = c.String(nullable: false, maxLength: 10, unicode: false),
                        RefGroup = c.Long(nullable: false),
                        RefTime = c.Int(nullable: false),
                        TerminalDescription = c.String(),
                    })
                .PrimaryKey(t => new { t.HolidayDate, t.RefGroup, t.RefTime });
            
            CreateTable(
                "dbo.View_ERPSoftwareUpdateService",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        ModuleNumber = c.Long(nullable: false),
                        InstallationDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        PurchaseVersion = c.String(),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        LastVersionAfterUpdate = c.String(),
                        UpdateAfterBuying = c.DateTime(precision: 7, storeType: "datetime2"),
                        SoftwareUpdateContract = c.Boolean(),
                        SoftwareContractFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndOfContract = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateInfoByMail = c.Boolean(),
                        ModuleName = c.String(),
                        CustomerID = c.Int(),
                        ContractStatusNr = c.Int(),
                    })
                .PrimaryKey(t => new { t.ID, t.ModuleNumber });
            
            CreateTable(
                "dbo.View_MemberAccessLog",
                c => new
                    {
                        TA_Come = c.Int(nullable: false),
                        TA_Go = c.Int(nullable: false),
                        BookingTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BookingCorrection = c.Int(nullable: false),
                        LogID = c.Long(nullable: false),
                        TerminalSerial = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        ReaderID = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        ID = c.Long(),
                        MemberNumber = c.Long(),
                        SurName = c.String(),
                        FirstName = c.String(),
                        ExitDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.TA_Come, t.TA_Go, t.BookingTime, t.BookingCorrection, t.LogID, t.TerminalSerial, t.ReaderID });
            
            CreateTable(
                "dbo.View_ReaderBuildingPlan",
                c => new
                    {
                        ReaderID = c.Int(nullable: false),
                        PlanDefinition = c.String(nullable: false, maxLength: 128),
                        TermID = c.Int(),
                        Description = c.String(),
                        DoorID = c.Int(),
                        RoomID = c.Int(),
                        FloorID = c.Int(),
                        LocationID = c.Int(),
                        BuildingID = c.Int(),
                        BuildingPlanID = c.Long(),
                    })
                .PrimaryKey(t => new { t.ReaderID, t.PlanDefinition });
            
            CreateTable(
                "dbo.View_SwitchTimes",
                c => new
                    {
                        SchaltprofilID = c.Long(nullable: false),
                        Schaltprofil = c.Long(nullable: false),
                        LEVEL = c.Int(nullable: false),
                        DayFrom = c.Int(nullable: false),
                        DayTo = c.Int(nullable: false),
                        TimeFrom = c.DateTime(nullable: false),
                        TimeTo = c.DateTime(nullable: false),
                        Weekdays = c.String(maxLength: 9, unicode: false),
                    })
                .PrimaryKey(t => new { t.SchaltprofilID, t.Schaltprofil, t.LEVEL, t.DayFrom, t.DayTo, t.TimeFrom, t.TimeTo });
            
            CreateTable(
                "dbo.View_SwitchTimesCalendarProfiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false),
                        SwitchCalendarID = c.Long(),
                        CalendarDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.View_TeminalInformation",
                c => new
                    {
                        TerminalID = c.Long(nullable: false),
                        TermID = c.Int(nullable: false),
                        TermType = c.String(nullable: false, maxLength: 128),
                        ReaderId = c.Long(nullable: false),
                        ReaderAssigned = c.Boolean(nullable: false),
                        ReaderNo = c.Int(nullable: false),
                        ID = c.Long(nullable: false),
                        AccessProfileActive = c.Boolean(nullable: false),
                        SwitchProfileActive = c.Boolean(nullable: false),
                        ManualOpeningActive = c.Boolean(nullable: false),
                        TerminalDescription = c.String(),
                        ReaderDescription = c.String(),
                        Direction = c.Int(),
                        Status = c.Int(),
                        unique_id = c.String(maxLength: 200, unicode: false),
                        DoorID = c.Int(),
                        AssignedReaderTerminalID = c.Long(),
                        AssignedReaderReaderID = c.Long(),
                        ConnectionID = c.Int(),
                        BuildingPlanID = c.Long(),
                        RelayTime = c.Int(),
                        LocationID = c.Int(),
                        BuildingID = c.Int(),
                        FloorID = c.Int(),
                        RoomID = c.Int(),
                        ReaderType = c.String(),
                        IPPort = c.Int(),
                        IpAddress = c.String(),
                        Connection = c.String(),
                        TerminalTypeID = c.Int(),
                    })
                .PrimaryKey(t => new { t.TerminalID, t.TermID, t.TermType, t.ReaderId, t.ReaderAssigned, t.ReaderNo, t.ID, t.AccessProfileActive, t.SwitchProfileActive, t.ManualOpeningActive });
            
            CreateTable(
                "dbo.View_TerminalAccessProfiles",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        AccessGroupNumber = c.Int(nullable: false),
                        AccessGroupName = c.String(nullable: false, maxLength: 128),
                        AccessProfileNo = c.Int(nullable: false),
                        AccessProfileID = c.String(nullable: false, maxLength: 100),
                        AccessDescription = c.String(nullable: false, maxLength: 128),
                        TimeframeID = c.Long(nullable: false),
                        MonFrom = c.DateTime(nullable: false),
                        MonTo = c.DateTime(nullable: false),
                        TueFrom = c.DateTime(nullable: false),
                        TueTo = c.DateTime(nullable: false),
                        WedFrom = c.DateTime(nullable: false),
                        WedTo = c.DateTime(nullable: false),
                        ThurFrom = c.DateTime(nullable: false),
                        ThurTo = c.DateTime(nullable: false),
                        FriFrom = c.DateTime(nullable: false),
                        FriTo = c.DateTime(nullable: false),
                        SatFrom = c.DateTime(nullable: false),
                        SatTo = c.DateTime(nullable: false),
                        SunFrom = c.DateTime(nullable: false),
                        SunTo = c.DateTime(nullable: false),
                        SerialNumber = c.String(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.AccessGroupNumber, t.AccessGroupName, t.AccessProfileNo, t.AccessProfileID, t.AccessDescription, t.TimeframeID, t.MonFrom, t.MonTo, t.TueFrom, t.TueTo, t.WedFrom, t.WedTo, t.ThurFrom, t.ThurTo, t.FriFrom, t.FriTo, t.SatFrom, t.SatTo, t.SunFrom, t.SunTo });
            
            CreateTable(
                "dbo.View_TerminalFunction",
                c => new
                    {
                        AccountNo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AccountNo, t.Name });
            
            CreateTable(
                "dbo.View_TerminalHolidays",
                c => new
                    {
                        HolidayDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AccessProfileID = c.Long(nullable: false),
                        TerminalSerialNumber = c.String(),
                        TerminalDescription = c.String(),
                    })
                .PrimaryKey(t => new { t.HolidayDate, t.AccessProfileID });
            
            CreateTable(
                "dbo.View_TerminalReader",
                c => new
                    {
                        TerminalID = c.Long(nullable: false),
                        TermID = c.Int(nullable: false),
                        TermType = c.String(nullable: false, maxLength: 128),
                        ReaderId = c.Long(nullable: false),
                        ReaderAssigned = c.Boolean(nullable: false),
                        ReaderNo = c.Int(nullable: false),
                        ID = c.Long(nullable: false),
                        ReaderStatus = c.Boolean(nullable: false),
                        AccessProfileActive = c.Boolean(nullable: false),
                        SwitchProfileActive = c.Boolean(nullable: false),
                        ManualOpeningActive = c.Boolean(nullable: false),
                        BuildingPlanID = c.Long(nullable: false),
                        TA_Come = c.Boolean(nullable: false),
                        TA_Go = c.Boolean(nullable: false),
                        TerminalDescription = c.String(),
                        Direction = c.Int(),
                        Status = c.Int(),
                        ReaderInfo = c.String(),
                        unique_id = c.String(maxLength: 200, unicode: false),
                        LocationID = c.Int(),
                        BuildingID = c.Int(),
                        FloorID = c.Int(),
                        RoomID = c.Int(),
                        DoorID = c.Int(),
                        TerminalTypeID = c.Int(),
                        IpAddress = c.String(),
                        Port = c.Int(),
                        ConnectionType = c.String(),
                        PassBackNr = c.Int(),
                        Lock = c.Int(),
                        ReaderDescription = c.String(),
                        ReaderType = c.String(),
                    })
                .PrimaryKey(t => new { t.TerminalID, t.TermID, t.TermType, t.ReaderId, t.ReaderAssigned, t.ReaderNo, t.ID, t.ReaderStatus, t.AccessProfileActive, t.SwitchProfileActive, t.ManualOpeningActive, t.BuildingPlanID, t.TA_Come, t.TA_Go });
            
            CreateTable(
                "dbo.View_Transponders",
                c => new
                    {
                        Pers_Type = c.Int(nullable: false),
                        TransponderNr = c.Long(nullable: false),
                        IDNr = c.Long(),
                        TransponderStatus = c.Boolean(),
                        ValidFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        ValidTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        TransponderDeactivatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        Action = c.Int(),
                        Memo = c.String(),
                        TransponderType = c.Int(),
                    })
                .PrimaryKey(t => new { t.Pers_Type, t.TransponderNr });
            
            CreateTable(
                "dbo.View_VisitorAccessLog",
                c => new
                    {
                        Pers_Nr = c.Long(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        TA_Come = c.Int(nullable: false),
                        TA_Go = c.Int(nullable: false),
                        BookingTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BookingCorrection = c.Int(nullable: false),
                        LogID = c.Long(nullable: false),
                        TerminalSerial = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        ReaderID = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        ID = c.Long(),
                        ExitDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Name = c.String(),
                        AccessEndData = c.DateTime(precision: 7, storeType: "datetime2"),
                        DynamicField1 = c.String(),
                        Card_Nr = c.Long(),
                    })
                .PrimaryKey(t => new { t.Pers_Nr, t.LastName, t.FirstName, t.TA_Come, t.TA_Go, t.BookingTime, t.BookingCorrection, t.LogID, t.TerminalSerial, t.ReaderID });
            
            CreateTable(
                "dbo.View_VisitorEntryLog",
                c => new
                    {
                        VisitorID = c.Long(nullable: false),
                        TA_Come = c.Int(nullable: false),
                        TA_Go = c.Int(nullable: false),
                        BookingTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BookingCorrection = c.Int(nullable: false),
                        LogId = c.Long(nullable: false),
                        TerminalSerial = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        ReaderID = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        ID = c.Long(),
                    })
                .PrimaryKey(t => new { t.VisitorID, t.TA_Come, t.TA_Go, t.BookingTime, t.BookingCorrection, t.LogId, t.TerminalSerial, t.ReaderID });
            
            CreateTable(
                "dbo.ViewMemberCardsInfo",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        TransponderNr = c.Long(nullable: false),
                        TransponderID = c.Long(nullable: false),
                        MemberName = c.String(),
                        MemberNumber = c.Long(),
                        GroupNr = c.Long(),
                        GroupName = c.String(),
                        TransponderStatus = c.Boolean(),
                        ValidFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        ValidTo = c.DateTime(precision: 7, storeType: "datetime2"),
                        TransponderDeactivatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        Action = c.Int(),
                        Memo = c.String(),
                        TransponderType = c.Int(),
                        ExtendedTo = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.ID, t.TransponderNr, t.TransponderID });
            
            CreateTable(
                "dbo.ViewTA_TerminalGroupMapping",
                c => new
                    {
                        TermID = c.Int(nullable: false),
                        TermType = c.String(nullable: false, maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                        Description = c.String(),
                        SerialNumber = c.String(),
                        ConnectionType = c.String(),
                        IpAddress = c.String(),
                        Port = c.Int(),
                        TerminalGroupId = c.Long(),
                        TerminalInstanceId = c.Long(),
                        Pers_Nr = c.Long(),
                    })
                .PrimaryKey(t => new { t.TermID, t.TermType, t.IsActive });
            
            CreateTable(
                "dbo.ViewTerminalGroupMapping",
                c => new
                    {
                        TermID = c.Int(nullable: false),
                        TermType = c.String(nullable: false, maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                        TerminalGroupId = c.Long(nullable: false),
                        TerminalInstanceId = c.Long(nullable: false),
                        Description = c.String(),
                        SerialNumber = c.String(),
                        ConnectionType = c.String(),
                        IpAddress = c.String(),
                        Port = c.Int(),
                    })
                .PrimaryKey(t => new { t.TermID, t.TermType, t.IsActive, t.TerminalGroupId, t.TerminalInstanceId });
            
            CreateTable(
                "dbo.VirtualPersonalGroupsMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VtermID = c.Long(),
                        Pers_Nr = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VirtualTerminalGroups", t => t.VtermID, cascadeDelete: true)
                .Index(t => t.VtermID);
            
            CreateTable(
                "dbo.VirtualTerminalGroups",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        GroupNr = c.Long(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VirtualTerminalCommunicationSettings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FixedIPAddress = c.String(),
                        FixedIPAddressEnabled = c.Boolean(),
                        FixedIPAddressPort = c.Int(),
                        DynamicIPAddress = c.String(),
                        DynamicIPAddressEnabled = c.Boolean(),
                        DynamicIPAddressPort = c.Int(),
                        Active = c.Boolean(),
                        TerminalId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VirtualTerminalFunctionKeys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TerminalID = c.Long(nullable: false),
                        FunctionKey1 = c.Int(nullable: false),
                        FunctionKey2 = c.Int(nullable: false),
                        FunctionKey3 = c.Int(nullable: false),
                        FunctionKey4 = c.Int(nullable: false),
                        FunctionKey5 = c.Int(nullable: false),
                        FunctionKey6 = c.Int(nullable: false),
                        FunctionKey7 = c.Int(nullable: false),
                        FunctionKey8 = c.Int(nullable: false),
                        FunctionType1 = c.Int(nullable: false),
                        FunctionType2 = c.Int(nullable: false),
                        FunctionType3 = c.Int(nullable: false),
                        FunctionType4 = c.Int(nullable: false),
                        FunctionType5 = c.Int(nullable: false),
                        FunctionType6 = c.Int(nullable: false),
                        FunctionType7 = c.Int(nullable: false),
                        FunctionType8 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VirtualTerminalGroupsMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        GroupID = c.Long(nullable: false),
                        TerminalID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VirtualTerminalInputSettings",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TerminalID = c.Long(),
                        Biometric = c.Boolean(nullable: false),
                        RFID = c.Boolean(nullable: false),
                        BarCode = c.Boolean(nullable: false),
                        PinCode = c.Boolean(nullable: false),
                        PersonalNumber = c.Boolean(nullable: false),
                        InividualNumber = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VirtualTerminal",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TerminalId = c.Long(nullable: false),
                        Description = c.String(),
                        LocationId = c.Int(nullable: false),
                        CostCenterId = c.Int(nullable: false),
                        TerminalActive = c.Boolean(),
                        TerminalType = c.Int(),
                        LogoutCode = c.Int(),
                        RealTimeActive = c.Boolean(),
                        TerminalCostCenter = c.String(maxLength: 10, fixedLength: true),
                        DisplayDepartment = c.Boolean(nullable: false),
                        DisplayPersonalNumber = c.Boolean(nullable: false),
                        DisplayCostCenter = c.Boolean(nullable: false),
                        FunctionKeysDisplayMode = c.Int(nullable: false),
                        TerminalOffline = c.Boolean(),
                        DatabaseServer = c.String(),
                        DataIntervalHours = c.Int(),
                        DataintervalMinutes = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VIS_PersPasswordsProfile",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Pers_Nr = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 128),
                        CurrentPassword = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        OldPassword = c.String(),
                        ProfileID = c.Int(),
                        PrivateMobile = c.String(),
                        CompanyTel = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Pers_Nr, t.UserName, t.CurrentPassword, t.FirstName, t.LastName });
            
            CreateTable(
                "dbo.VisitorAdditionalInfo",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VisitorID = c.Long(nullable: false),
                        PhysicalAddress = c.String(),
                        Street = c.String(),
                        PlaceOfBirth = c.String(),
                        MaritalStatus = c.String(),
                        Profession = c.String(),
                        VehicleModel = c.String(),
                        VehicleReg = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VisitorApplications", t => t.VisitorID, cascadeDelete: true)
                .Index(t => t.VisitorID);
            
            CreateTable(
                "dbo.VisitorApplications",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ApplicationID = c.Long(nullable: false),
                        VisitorNr = c.Long(nullable: false),
                        PersonalID = c.Long(nullable: false),
                        VisitorName = c.String(nullable: false),
                        Title = c.String(maxLength: 50),
                        IdentificationNr = c.String(),
                        PassportNr = c.String(),
                        Gender = c.String(maxLength: 50),
                        DOB = c.DateTime(precision: 3, storeType: "datetime2"),
                        DateFiled = c.DateTime(precision: 7, storeType: "datetime2"),
                        TimeFiled = c.DateTime(precision: 7, storeType: "datetime2"),
                        EntryDate = c.DateTime(precision: 3, storeType: "datetime2"),
                        EntryTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExitDate = c.DateTime(precision: 3, storeType: "datetime2"),
                        ExitTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        Nationality = c.String(),
                        Active = c.Boolean(nullable: false),
                        VisitorType = c.Long(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitorContacts",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VisitorID = c.Long(nullable: false),
                        Company = c.String(),
                        CompanyTel = c.String(),
                        PrivateTel = c.String(),
                        CompanyMobile = c.String(),
                        PrivateMobile = c.String(),
                        CompanyFax = c.String(),
                        PrivateFax = c.String(),
                        CompanyEmail = c.String(),
                        PrivateEmail = c.String(),
                        PostalAddress = c.String(),
                        PostalCode = c.String(),
                        ZipCode = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VisitorApplications", t => t.VisitorID, cascadeDelete: true)
                .Index(t => t.VisitorID);
            
            CreateTable(
                "dbo.VisitorPlanGroup",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AccessGroupNumber = c.Int(nullable: false),
                        AccessGroupName = c.String(nullable: false),
                        AccessGroupType = c.Int(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VisitorType",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TypeNr = c.Long(nullable: false),
                        Name = c.String(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.vw_PermissionMapping",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        ProfileNr = c.Int(nullable: false),
                        ProfileDescription = c.String(nullable: false, maxLength: 128),
                        PermissionKey = c.Long(nullable: false),
                        PermissionType = c.Long(nullable: false),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.ProfileNr, t.ProfileDescription, t.PermissionKey, t.PermissionType });
            
            CreateTable(
                "dbo.vw_PortalKunden",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Code = c.Int(),
                        EMail = c.String(name: "E-Mail", maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.vw_PortalUserProfile",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        ProfileNr = c.Int(nullable: false),
                        ProfileDescription = c.String(nullable: false, maxLength: 128),
                        EmailAddress = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => new { t.ID, t.ProfileNr, t.ProfileDescription, t.EmailAddress });
            
            CreateTable(
                "dbo.vw_PortalUsersProfilePermissionMapping",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        ProfileNr = c.Int(nullable: false),
                        PermissionKey = c.Long(nullable: false),
                        PermissionType = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.ProfileNr, t.PermissionKey, t.PermissionType });
            
            CreateTable(
                "dbo.vw_users",
                c => new
                    {
                        usr_id = c.Long(nullable: false),
                        u_action = c.String(nullable: false, maxLength: 100),
                        audit_date = c.DateTime(nullable: false),
                        ID = c.Long(nullable: false),
                        Salutation = c.String(nullable: false, maxLength: 50),
                        Firstname = c.String(nullable: false, maxLength: 128),
                        CompanyName = c.String(nullable: false, maxLength: 128),
                        StreetNo = c.String(nullable: false, maxLength: 128),
                        PostalCode = c.String(nullable: false, maxLength: 128),
                        Country = c.String(nullable: false, maxLength: 128),
                        EmailAddress = c.String(nullable: false, maxLength: 100),
                        RoleId = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 128),
                        Code = c.String(nullable: false, maxLength: 128),
                        Isactive = c.Boolean(nullable: false),
                        FirstPassChanged = c.Boolean(nullable: false),
                        PortalNo = c.Long(nullable: false),
                        comment = c.String(),
                        Surname = c.String(),
                        MobileNo = c.String(maxLength: 50),
                        TelephoneNo = c.String(maxLength: 50),
                        TaxId = c.String(),
                        Location = c.String(),
                        StreetName = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => new { t.usr_id, t.u_action, t.audit_date, t.ID, t.Salutation, t.Firstname, t.CompanyName, t.StreetNo, t.PostalCode, t.Country, t.EmailAddress, t.RoleId, t.Password, t.Code, t.Isactive, t.FirstPassChanged, t.PortalNo });
            
            CreateTable(
                "dbo.VwHolidayCalender",
                c => new
                    {
                        TermID = c.Int(nullable: false),
                        TermType = c.String(nullable: false, maxLength: 128),
                        HolidayPlanCalendarNumber = c.Long(nullable: false),
                        HolidayPlanCalendarName = c.String(nullable: false, maxLength: 128),
                        CalendarMonth = c.Int(nullable: false),
                        Day1ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day2ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day3ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day4ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day5ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day6ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day7ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day8ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day9ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day10ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day11ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day12ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day13ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day14ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day15ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day16ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day17ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day18ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day19ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day20ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day21ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day22ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day23ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day24ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day25ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day26ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day27ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day28ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day29ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day30ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Day31ProfileHolidayId = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.TermID, t.TermType, t.HolidayPlanCalendarNumber, t.HolidayPlanCalendarName, t.CalendarMonth, t.Day1ProfileHolidayId, t.Day2ProfileHolidayId, t.Day3ProfileHolidayId, t.Day4ProfileHolidayId, t.Day5ProfileHolidayId, t.Day6ProfileHolidayId, t.Day7ProfileHolidayId, t.Day8ProfileHolidayId, t.Day9ProfileHolidayId, t.Day10ProfileHolidayId, t.Day11ProfileHolidayId, t.Day12ProfileHolidayId, t.Day13ProfileHolidayId, t.Day14ProfileHolidayId, t.Day15ProfileHolidayId, t.Day16ProfileHolidayId, t.Day17ProfileHolidayId, t.Day18ProfileHolidayId, t.Day19ProfileHolidayId, t.Day20ProfileHolidayId, t.Day21ProfileHolidayId, t.Day22ProfileHolidayId, t.Day23ProfileHolidayId, t.Day24ProfileHolidayId, t.Day25ProfileHolidayId, t.Day26ProfileHolidayId, t.Day27ProfileHolidayId, t.Day28ProfileHolidayId, t.Day29ProfileHolidayId, t.Day30ProfileHolidayId, t.Day31ProfileHolidayId });
            
            CreateTable(
                "dbo.VwPersDataZUT",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false, maxLength: 128),
                        EntryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Active = c.Boolean(nullable: false),
                        Expr4 = c.Long(nullable: false),
                        CardActive = c.Boolean(nullable: false),
                        AccessPlanID = c.Long(nullable: false),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DepartmentID = c.Long(nullable: false),
                        VisitorID = c.Long(nullable: false),
                        PinCode = c.Long(nullable: false),
                        PinCodeType = c.Int(nullable: false),
                        PinCodeStatus = c.Boolean(nullable: false),
                        CostCenterID = c.Long(nullable: false),
                        MiddleName = c.String(),
                        Title = c.String(),
                        ExitDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        PersType = c.Long(),
                        Memo = c.String(),
                        Card_Nr = c.Long(),
                        Imported = c.Boolean(),
                        Passport_Nr = c.String(),
                        PhysicalAddress = c.String(),
                        Street = c.String(),
                        PlaceOfBirth = c.String(),
                        DOB = c.DateTime(precision: 7, storeType: "datetime2"),
                        Gender = c.String(),
                        MaritalStatus = c.String(),
                        Position = c.String(),
                        Profession = c.String(),
                        Nationality = c.String(),
                        VehicleModel = c.String(),
                        VehicleReg = c.String(),
                        CompanyName = c.String(),
                        CompanyTel = c.String(),
                        PrivateTel = c.String(),
                        CompanyMobile = c.String(),
                        PrivateMobile = c.String(),
                        CompanyFax = c.String(),
                        PrivateFax = c.String(),
                        CompanyEmail = c.String(),
                        PrivateEmail = c.String(),
                        PostalAddress = c.String(),
                        PostalCode = c.String(),
                        VehicleID = c.Long(),
                    })
                .PrimaryKey(t => new { t.ID, t.FirstName, t.LastName, t.FullName, t.EntryDate, t.Active, t.Expr4, t.CardActive, t.AccessPlanID, t.StartDate, t.EndDate, t.DepartmentID, t.VisitorID, t.PinCode, t.PinCodeType, t.PinCodeStatus, t.CostCenterID });
            
            CreateTable(
                "dbo.VwPersonnelData",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false, maxLength: 128),
                        Active = c.Boolean(nullable: false),
                        Pers_Nr = c.Long(nullable: false),
                        CardActive = c.Boolean(nullable: false),
                        Imported = c.Boolean(nullable: false),
                        PersonnelNr_string = c.Long(nullable: false),
                        MiddleName = c.String(),
                        Title = c.String(),
                        EntryDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExitDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        PersType = c.Long(),
                        Memo = c.String(),
                        Passport_Nr = c.String(),
                        PhysicalAddress = c.String(),
                        Street = c.String(),
                        PlaceOfBirth = c.String(),
                        DOB = c.DateTime(precision: 7, storeType: "datetime2"),
                        Gender = c.String(),
                        MaritalStatus = c.String(),
                        Position = c.String(),
                        Profession = c.String(),
                        Nationality = c.String(),
                        VehicleModel = c.String(),
                        VehicleReg = c.String(),
                        CompanyName = c.String(),
                        CompanyTel = c.String(),
                        PrivateTel = c.String(),
                        CompanyMobile = c.String(),
                        PrivateMobile = c.String(),
                        CompanyFax = c.String(),
                        PrivateFax = c.String(),
                        CompanyEmail = c.String(),
                        PrivateEmail = c.String(),
                        PostalAddress = c.String(),
                        PostalCode = c.String(),
                        DepartmentID = c.Long(),
                        CostCenterID = c.Long(),
                        VehicleID = c.Long(),
                        LocationID = c.Long(),
                        LocationName = c.String(),
                        Location_Nr = c.Long(),
                        DepartmentName = c.String(),
                        Department_Nr = c.Long(),
                        CostCenterName = c.String(),
                        CostCenter_Nr = c.Long(),
                        IdentificationNr_string = c.Long(),
                        PersNr_Fullname = c.String(),
                        EyeColor = c.String(maxLength: 50),
                        Height = c.String(maxLength: 50),
                        Expr1 = c.String(),
                        Salutation = c.String(),
                        Additonal = c.String(),
                        Since = c.DateTime(precision: 7, storeType: "datetime2"),
                        Bankname = c.String(),
                        AccountOwner = c.String(),
                        BankCode = c.String(),
                        AccountNo = c.String(),
                        BIC = c.String(),
                        IBAN = c.String(),
                        DriversLicense = c.String(),
                        Children = c.String(),
                        TaxOfficee = c.String(),
                        TaxClass = c.String(),
                        HealthInsuarance = c.String(),
                        HealInsuaranceNo = c.String(),
                        PensionInsuarance = c.String(),
                        SozVerzNo = c.String(),
                        Contract = c.String(),
                        EmployedFrom = c.DateTime(precision: 7, storeType: "datetime2"),
                        LearnedOccupation = c.String(),
                        EmployedAs = c.String(),
                        EmploymentType = c.String(),
                        ResidencePermit = c.String(),
                        AuthorisedBy = c.String(),
                        ApprovedBy = c.String(),
                        NoOfHours = c.String(),
                        EndOfContract = c.DateTime(precision: 7, storeType: "datetime2"),
                        EliminatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        Reason = c.String(),
                        CertificateOfEmployment = c.String(),
                        ClientID = c.Long(),
                        ClientName = c.String(),
                        StreetNr = c.String(),
                        Expr2 = c.String(),
                        Pers_Passport = c.String(),
                        ActiveCardType = c.Int(),
                        Card_Nr = c.Long(),
                        DynamicField1 = c.String(),
                        Client_Nr = c.Long(),
                    })
                .PrimaryKey(t => new { t.ID, t.FirstName, t.LastName, t.FullName, t.Active, t.Pers_Nr, t.CardActive, t.Imported, t.PersonnelNr_string });
            
            CreateTable(
                "dbo.vwPersPinCodes",
                c => new
                    {
                        Pers_Nr = c.Long(nullable: false),
                        Aus_PinCodeType = c.Int(),
                        Aus_PinCode = c.String(),
                        Aus_PinCodeStatus = c.Boolean(),
                        Nur_PinCodeType = c.Int(),
                        Nur_PinCode = c.String(),
                        Nur_PinCodeStatus = c.Boolean(),
                        Sicher_PinCodeType = c.Int(),
                        Scher_PinCode = c.String(),
                        Scher_PinCodeStatus = c.Boolean(),
                    })
                .PrimaryKey(t => t.Pers_Nr);
            
            CreateTable(
                "dbo.vwSwitchProfiles",
                c => new
                    {
                        BuildingPlanID = c.Long(nullable: false),
                        TermID = c.Int(nullable: false),
                        TerminalID = c.Long(nullable: false),
                        TermType = c.String(nullable: false, maxLength: 128),
                        CalendarID = c.Long(nullable: false),
                        SwitchProfileID = c.Int(nullable: false),
                        Profile_Id = c.String(nullable: false, maxLength: 4),
                        Profile_Nr = c.Long(nullable: false),
                        Number = c.Int(nullable: false),
                        DayFrom = c.Int(nullable: false),
                        DayTo = c.Int(nullable: false),
                        TimeFrom = c.DateTime(nullable: false),
                        TimeTo = c.DateTime(nullable: false),
                        TerminalDescription = c.String(),
                        ProfileDescription = c.String(),
                        Memo = c.String(),
                    })
                .PrimaryKey(t => new { t.BuildingPlanID, t.TermID, t.TerminalID, t.TermType, t.CalendarID, t.SwitchProfileID, t.Profile_Id, t.Profile_Nr, t.Number, t.DayFrom, t.DayTo, t.TimeFrom, t.TimeTo });
            
            CreateTable(
                "dbo.vwVisitorCompany",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        VisitorID = c.Long(nullable: false),
                        PersonalID = c.Long(),
                        SurName = c.String(),
                        FullName = c.String(),
                        Company = c.String(),
                        CompanyStreet = c.String(),
                        CompanyStreetNr = c.String(),
                        CompanyPostalCode = c.String(),
                        Street = c.String(),
                        VisitorNr = c.String(),
                        Location = c.String(),
                        Telephone = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        PostalCode = c.String(),
                        VisitorType = c.Int(),
                        StreetNr = c.String(),
                        VisitorPhoto = c.String(),
                        CardActive = c.Boolean(),
                        VehicleRegNr = c.String(),
                        VisitorVehicleType = c.Long(),
                        VisitReason = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.VisitorID });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitorContacts", "VisitorID", "dbo.VisitorApplications");
            DropForeignKey("dbo.VisitorAdditionalInfo", "VisitorID", "dbo.VisitorApplications");
            DropForeignKey("dbo.VirtualPersonalGroupsMapping", "VtermID", "dbo.VirtualTerminalGroups");
            DropForeignKey("dbo.TA_BookingsReportTitles", "ReportID", "dbo.TA_BookingsReport");
            DropForeignKey("dbo.TA_BookingsReportAccounts", "ReportID", "dbo.TA_BookingsReport");
            DropForeignKey("dbo.TA_BookingsReportAbsences", "ReportID", "dbo.TA_BookingsReport");
            DropForeignKey("dbo.SwitchCalendarMonthMapped", "SwitchCalendarId", "dbo.SwitchCalendarMapped");
            DropForeignKey("dbo.Portal_PermissionMapping", "PermissionKey", "dbo.Portal_Permissions");
            DropForeignKey("dbo.Portal_ProfileUSerMapping", "ProfileID", "dbo.Portal_PermissionProfile");
            DropForeignKey("dbo.Portal_Users", "RoleId", "dbo.UserRoles");
            DropForeignKey("dbo.Portal_ProfileUSerMapping", "USerID", "dbo.Portal_Users");
            DropForeignKey("dbo.Portal_PermissionMapping", "ProfileID", "dbo.Portal_PermissionProfile");
            DropForeignKey("dbo.MapCalendarMonth", "MapCalendarID", "dbo.MapCalendar");
            DropForeignKey("dbo.JC_Activities", "CurrencyID", "dbo.JC_Currency");
            DropForeignKey("dbo.HolidayPlanCalendarMonthMapped", "HolidayPlanCalendarId", "dbo.HolidayPlanCalendarMapped");
            DropForeignKey("dbo.EmpAdditionalInfo", "ColumnID", "dbo.DynamicColumns");
            DropForeignKey("dbo.DatafoxTerminalReaders", "DatafoxTerminalID", "dbo.DatafoxTerminalInstances");
            DropForeignKey("dbo.PlannedCalendar", "DailyCalendarId", "dbo.DailyCalendar");
            DropForeignKey("dbo.PlannedCalendarTime", "CalendarId", "dbo.PlannedCalendar");
            DropForeignKey("dbo.MonthlyCalendar", "CalendarId", "dbo.PlannedCalendar");
            DropForeignKey("dbo.PlannedCalendar", "MonthlyCalendarId", "dbo.MonthlyCalendar");
            DropForeignKey("dbo.DailyCalendar", "CalendarId", "dbo.PlannedCalendar");
            DropForeignKey("dbo.Pers_Areas", "AreaID", "dbo.Areas");
            DropForeignKey("dbo.Pers_Departments", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Areas", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Accounts_Year", "ID", "dbo.Accounts_Day");
            DropForeignKey("dbo.Accounts_Week", "ID", "dbo.Accounts_Day");
            DropForeignKey("dbo.Accounts_Month", "ID", "dbo.Accounts_Day");
            DropForeignKey("dbo.AC_ReportSettings", "ReportID", "dbo.AC_Reports");
            DropForeignKey("dbo.AC_ReportListChecks", "ReportListID", "dbo.AC_ReportList");
            DropForeignKey("dbo.AC_PermissionMapping", "PermissionKey", "dbo.AC_Permissions");
            DropForeignKey("dbo.AC_PersProfileMapping", "ProfileID", "dbo.AC_PermissionProfile");
            DropForeignKey("dbo.AC_PersProfileADMapping", "ProfileID", "dbo.AC_PermissionProfile");
            DropForeignKey("dbo.AC_PermissionMapping", "ProfileId", "dbo.AC_PermissionProfile");
            DropForeignKey("dbo.Specialdays", "Absence_Reason", "dbo.Absences");
            DropForeignKey("dbo.EmployeeAbsence", "AbsenceId", "dbo.Absences");
            DropForeignKey("dbo.WorkedHoursAcc", "EmpID", "dbo.Employee");
            DropForeignKey("dbo.EmployeeTariff", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "InfoId", "dbo.EmployeeInfo");
            DropForeignKey("dbo.Pers_CostCenters", "CostCenterID", "dbo.CostCenters");
            DropForeignKey("dbo.EmployeeInfo", "CostCenterId", "dbo.CostCenters");
            DropForeignKey("dbo.EmployeeAbsence", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.DailyAccountTime", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.SurchargesAccountsMapping", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.SurchargesAccountsMapping", "SurchargeID", "dbo.Surcharges");
            DropForeignKey("dbo.Surcharges", "WeekDays_ID", "dbo.SurchargeDays");
            DropForeignKey("dbo.Surcharges", "DailyProgramID", "dbo.DailyPrograms");
            DropForeignKey("dbo.ResourceEvent", "ShiftId", "dbo.Shifts");
            DropForeignKey("dbo.ResourceEvent", "ResourceId", "dbo.ShiftResource");
            DropForeignKey("dbo.ResourceEventMapped", "ResourceId", "dbo.ShiftResource");
            DropForeignKey("dbo.ResourceEventMapped", "ShiftId", "dbo.Shifts");
            DropForeignKey("dbo.ResourceEventMapped", "DailyProgramId", "dbo.DailyProgramMapped");
            DropForeignKey("dbo.Shifts", "DailyProgramId", "dbo.DailyPrograms");
            DropForeignKey("dbo.DP_Shifts", "DP_ID", "dbo.DailyPrograms");
            DropForeignKey("dbo.Shift_Breaks", "Shift_ID", "dbo.DP_Shifts");
            DropForeignKey("dbo.Shift_Breaks", "Break_ID", "dbo.Breaks");
            DropForeignKey("dbo.DailyAccountTime", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Addresses", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.AccessGroupEmployee", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.ZuttritProfiles", "GroupID", "dbo.AccessGroup");
            DropForeignKey("dbo.TbAccessPlanPersMapping", "AccessPlan_Nr", "dbo.TbAccessPlan");
            DropForeignKey("dbo.TbAccessPlanMembersMapping", "AccessPlan_ID", "dbo.TbAccessPlan");
            DropForeignKey("dbo.ReaderAccessPlan", "AccessPlanId", "dbo.TbAccessPlan");
            DropForeignKey("dbo.MembersAccessPlanMapping", "AccessPlan_Nr", "dbo.TbAccessPlan");
            DropForeignKey("dbo.TbAccessPlan", "BuildingPlanID", "dbo.BuildingPlan");
            DropForeignKey("dbo.SwitchPlan", "BuidingPlanID", "dbo.BuildingPlan");
            DropForeignKey("dbo.AccessPlanGroupDoorMapping", "BuildingPlanID", "dbo.BuildingPlan");
            DropForeignKey("dbo.Pers_AccessGroups", "GroupID", "dbo.TbAccessPlanGroup");
            DropForeignKey("dbo.MemberAccessGroups", "GroupID", "dbo.TbAccessPlanGroup");
            DropForeignKey("dbo.TbAccessPlanMembersMapping", "MemberID", "dbo.MembersData");
            DropForeignKey("dbo.MembersTransponders", "MemberID", "dbo.MembersData");
            DropForeignKey("dbo.MembersAccessPlanMapping", "MemberID", "dbo.MembersData");
            DropForeignKey("dbo.MemberPassport", "MemberID", "dbo.MembersData");
            DropForeignKey("dbo.MemberIdentityCard", "MemberID", "dbo.MembersData");
            DropForeignKey("dbo.MemberHealthCard", "MemberID", "dbo.MembersData");
            DropForeignKey("dbo.MembersData", "MemberGroupId", "dbo.MemberGroups");
            DropForeignKey("dbo.MemberDynamicFields", "MemberID", "dbo.MembersData");
            DropForeignKey("dbo.MembersData", "ContractDuration", "dbo.MemberDuration");
            DropForeignKey("dbo.MemberDrivingLicense", "MemberID", "dbo.MembersData");
            DropForeignKey("dbo.MemberCommonInfo", "MemberID", "dbo.MembersData");
            DropForeignKey("dbo.MemberAccessGroups", "MemberID", "dbo.MembersData");
            DropForeignKey("dbo.MembersData", "Salutation", "dbo.ERP_Anrede");
            DropForeignKey("dbo.ERP_KAnsprechp", "AnredeCode", "dbo.ERP_Anrede");
            DropForeignKey("dbo.TbAccessPlanGroup", "BuildingPlanID", "dbo.BuildingPlan");
            DropForeignKey("dbo.AccessPlanGroupDoorMapping", "AccessPlanGroupID", "dbo.TbAccessPlanGroup");
            DropForeignKey("dbo.VisitorAccessTime", "VisitPlanId", "dbo.TbVisitorPlan");
            DropForeignKey("dbo.VisitorTransponders", "VisitorID", "dbo.Visitors");
            DropForeignKey("dbo.Visitors", "Company", "dbo.VisitorCompanyTb");
            DropForeignKey("dbo.VisitorAccessTime", "VisitorId", "dbo.Visitors");
            DropForeignKey("dbo.Visitors", "VisitorVehicleType", "dbo.VehicleTypes");
            DropForeignKey("dbo.Visitor_Vehicle", "VehicleID", "dbo.VehicleTypes");
            DropForeignKey("dbo.Pers_Vehicles", "VehicleID", "dbo.VehicleTypes");
            DropForeignKey("dbo.Visitors", "PersonalID", "dbo.Personal");
            DropForeignKey("dbo.PersonnelTariff", "PersonnelID", "dbo.Personal");
            DropForeignKey("dbo.TariffCalendar", "TariffId", "dbo.Tariff");
            DropForeignKey("dbo.Tariff", "SurchargeId", "dbo.SurchargeMapped");
            DropForeignKey("dbo.Tariff", "PlannedCalendarId", "dbo.PlannedCalendarMapped");
            DropForeignKey("dbo.PlannedCalendarTimeMapped", "CalendarId", "dbo.PlannedCalendarMapped");
            DropForeignKey("dbo.MonthlyCalendarMapped", "CalendarId", "dbo.PlannedCalendarMapped");
            DropForeignKey("dbo.PlannedCalendarMapped", "MonthlyCalendarId", "dbo.MonthlyCalendarMapped");
            DropForeignKey("dbo.DailyCalendarMapped", "CalendarId", "dbo.PlannedCalendarMapped");
            DropForeignKey("dbo.PlannedCalendarMapped", "DailyCalendarId", "dbo.DailyCalendarMapped");
            DropForeignKey("dbo.PersonnelTariff", "TariffID", "dbo.Tariff");
            DropForeignKey("dbo.Tariff", "MapCalendarId", "dbo.MapCalendarMapped");
            DropForeignKey("dbo.MapCalendarMonthMapped", "MapCalendarId", "dbo.MapCalendarMapped");
            DropForeignKey("dbo.EmployeeTariff", "TariffId", "dbo.Tariff");
            DropForeignKey("dbo.Personal", "PersType", "dbo.Pers_Type");
            DropForeignKey("dbo.VisitorAccessTime", "CompanyTo", "dbo.Clients");
            DropForeignKey("dbo.Pers_Client", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Clients", "State", "dbo.LocationsFederalStates");
            DropForeignKey("dbo.ReaderVisitorPlan", "VisitorPlanId", "dbo.TbVisitorPlan");
            DropForeignKey("dbo.TerminalReaders", "ReaderNr", "dbo.TerminalReadersStatic");
            DropForeignKey("dbo.TerminalUtilities", "TerminalConfigID", "dbo.TerminalConfig");
            DropForeignKey("dbo.TerminalSignalBreaks", "TerminalID", "dbo.TerminalConfig");
            DropForeignKey("dbo.TerminalReaders", "TermID", "dbo.TerminalConfig");
            DropForeignKey("dbo.TerminalInfoText", "TerminalConfigID", "dbo.TerminalConfig");
            DropForeignKey("dbo.TerminalConfig", "TerminalInfoId", "dbo.TerminalInfo");
            DropForeignKey("dbo.TerminalGroupMapping", "TerminalInstanceId", "dbo.TerminalConfig");
            DropForeignKey("dbo.TerminalGroupMapping", "TerminalGroupId", "dbo.TerminalGroups");
            DropForeignKey("dbo.TerminalFunctionKeys", "TerminalConfigID", "dbo.TerminalConfig");
            DropForeignKey("dbo.TerminalDatafoxFunction", "TerminalID", "dbo.TerminalConfig");
            DropForeignKey("dbo.TerminalConfig", "TerminalConnectId", "dbo.TerminalConnect");
            DropForeignKey("dbo.Terminals", "TermOEMID", "dbo.TerminalOEM");
            DropForeignKey("dbo.TerminalConfig", "TerminalOEMId", "dbo.TerminalOEM");
            DropForeignKey("dbo.TerminalConfig", "TerminalId", "dbo.Terminals");
            DropForeignKey("dbo.TA_TerminalGroupMapping", "TerminalInstanceId", "dbo.TerminalConfig");
            DropForeignKey("dbo.TA_TerminalGroupMapping", "TerminalGroupId", "dbo.TA_TerminalGroups");
            DropForeignKey("dbo.TA_PersonalGroupMapping", "TerminalGroupId", "dbo.TA_TerminalGroups");
            DropForeignKey("dbo.ReaderVisitorPlan", "ReaderId", "dbo.TerminalReaders");
            DropForeignKey("dbo.ReaderAssigned", "ReaderID", "dbo.TerminalReaders");
            DropForeignKey("dbo.ReaderAssigned", "BuildingPlanID", "dbo.BuildingPlan");
            DropForeignKey("dbo.ReaderAccessPlan", "ReaderId", "dbo.TerminalReaders");
            DropForeignKey("dbo.TbVisitorPlan", "HolidayPlanCalendarId", "dbo.HolidayPlanCalendar");
            DropForeignKey("dbo.TbAccessPlan", "HolidayPlanCalendarId", "dbo.HolidayPlanCalendar");
            DropForeignKey("dbo.TbAccessPlanGroup", "HolidayPlanCalendarId", "dbo.HolidayPlanCalendar");
            DropForeignKey("dbo.SwitchPlan", "SwitchCalendarId", "dbo.SwitchCalendar");
            DropForeignKey("dbo.SwitchCalendarMonth", "SwitchCalendarId", "dbo.SwitchCalendar");
            DropForeignKey("dbo.SwitchPlan", "HolidayPlanCalendarId", "dbo.HolidayPlanCalendar");
            DropForeignKey("dbo.HolidayPlanCalendarMonth", "HolidayPlanCalendarId", "dbo.HolidayPlanCalendar");
            DropForeignKey("dbo.HolidayPlanAccessProfileMonth", "HolidayPlanCalendarId", "dbo.HolidayPlanCalendar");
            DropForeignKey("dbo.HolidayPlanCalendar", "HolidayCalenderId", "dbo.HolidayCalendar");
            DropForeignKey("dbo.HolidayCalendarMonth", "HolidayCalendarId", "dbo.HolidayCalendar");
            DropForeignKey("dbo.TbVisitorPlan", "BuildingPlanID", "dbo.BuildingPlan");
            DropForeignKey("dbo.TbVisitorPlan", "AccessCalendarId", "dbo.AccessCalendar");
            DropForeignKey("dbo.TbAccessPlanGroup", "AccessCalendarId", "dbo.AccessCalendar");
            DropForeignKey("dbo.AccessCalendarMonth", "AccessCalendarID", "dbo.AccessCalendar");
            DropForeignKey("dbo.TbAccessPlan", "AccessGroupID", "dbo.AccessGroup");
            DropForeignKey("dbo.AccessProfileAccessGroupMapping", "AccessGroupID", "dbo.AccessGroup");
            DropForeignKey("dbo.ZuttritProfilesTimeFrames", "AccessProfID", "dbo.ZuttritProfiles");
            DropForeignKey("dbo.AccessProfileAccessGroupMapping", "AccessProfileID", "dbo.ZuttritProfiles");
            DropForeignKey("dbo.AccessGroupEmployee", "AccessGroupId", "dbo.AccessGroup");
            DropIndex("dbo.VisitorContacts", new[] { "VisitorID" });
            DropIndex("dbo.VisitorAdditionalInfo", new[] { "VisitorID" });
            DropIndex("dbo.VirtualPersonalGroupsMapping", new[] { "VtermID" });
            DropIndex("dbo.TA_BookingsReportTitles", new[] { "ReportID" });
            DropIndex("dbo.TA_BookingsReportAccounts", new[] { "ReportID" });
            DropIndex("dbo.TA_BookingsReportAbsences", new[] { "ReportID" });
            DropIndex("dbo.SwitchCalendarMonthMapped", new[] { "SwitchCalendarId" });
            DropIndex("dbo.Portal_Users", new[] { "RoleId" });
            DropIndex("dbo.Portal_ProfileUSerMapping", new[] { "ProfileID" });
            DropIndex("dbo.Portal_ProfileUSerMapping", new[] { "USerID" });
            DropIndex("dbo.Portal_PermissionMapping", new[] { "ProfileID" });
            DropIndex("dbo.Portal_PermissionMapping", new[] { "PermissionKey" });
            DropIndex("dbo.MapCalendarMonth", new[] { "MapCalendarID" });
            DropIndex("dbo.JC_Activities", new[] { "CurrencyID" });
            DropIndex("dbo.HolidayPlanCalendarMonthMapped", new[] { "HolidayPlanCalendarId" });
            DropIndex("dbo.EmpAdditionalInfo", new[] { "ColumnID" });
            DropIndex("dbo.DatafoxTerminalReaders", new[] { "DatafoxTerminalID" });
            DropIndex("dbo.PlannedCalendarTime", new[] { "CalendarId" });
            DropIndex("dbo.MonthlyCalendar", new[] { "CalendarId" });
            DropIndex("dbo.PlannedCalendar", new[] { "MonthlyCalendarId" });
            DropIndex("dbo.PlannedCalendar", new[] { "DailyCalendarId" });
            DropIndex("dbo.DailyCalendar", new[] { "CalendarId" });
            DropIndex("dbo.Pers_Areas", new[] { "AreaID" });
            DropIndex("dbo.Pers_Departments", new[] { "DepartmentID" });
            DropIndex("dbo.Areas", new[] { "DeptId" });
            DropIndex("dbo.Accounts_Year", new[] { "ID" });
            DropIndex("dbo.Accounts_Week", new[] { "ID" });
            DropIndex("dbo.Accounts_Month", new[] { "ID" });
            DropIndex("dbo.AC_ReportSettings", new[] { "ReportID" });
            DropIndex("dbo.AC_ReportListChecks", new[] { "ReportListID" });
            DropIndex("dbo.AC_PersProfileMapping", new[] { "ProfileID" });
            DropIndex("dbo.AC_PersProfileADMapping", new[] { "ProfileID" });
            DropIndex("dbo.AC_PermissionMapping", new[] { "ProfileId" });
            DropIndex("dbo.AC_PermissionMapping", new[] { "PermissionKey" });
            DropIndex("dbo.Specialdays", new[] { "Absence_Reason" });
            DropIndex("dbo.WorkedHoursAcc", new[] { "EmpID" });
            DropIndex("dbo.Pers_CostCenters", new[] { "CostCenterID" });
            DropIndex("dbo.EmployeeInfo", new[] { "CostCenterId" });
            DropIndex("dbo.ResourceEvent", new[] { "ShiftId" });
            DropIndex("dbo.ResourceEvent", new[] { "ResourceId" });
            DropIndex("dbo.ResourceEventMapped", new[] { "ShiftId" });
            DropIndex("dbo.ResourceEventMapped", new[] { "DailyProgramId" });
            DropIndex("dbo.ResourceEventMapped", new[] { "ResourceId" });
            DropIndex("dbo.Shifts", new[] { "DailyProgramId" });
            DropIndex("dbo.Shift_Breaks", new[] { "Break_ID" });
            DropIndex("dbo.Shift_Breaks", new[] { "Shift_ID" });
            DropIndex("dbo.DP_Shifts", new[] { "DP_ID" });
            DropIndex("dbo.Surcharges", new[] { "DailyProgramID" });
            DropIndex("dbo.Surcharges", new[] { "WeekDays_ID" });
            DropIndex("dbo.SurchargesAccountsMapping", new[] { "AccountID" });
            DropIndex("dbo.SurchargesAccountsMapping", new[] { "SurchargeID" });
            DropIndex("dbo.DailyAccountTime", new[] { "EmployeeId" });
            DropIndex("dbo.DailyAccountTime", new[] { "AccountId" });
            DropIndex("dbo.Addresses", new[] { "EmployeeID" });
            DropIndex("dbo.TbAccessPlanPersMapping", new[] { "AccessPlan_Nr" });
            DropIndex("dbo.Pers_AccessGroups", new[] { "GroupID" });
            DropIndex("dbo.TbAccessPlanMembersMapping", new[] { "MemberID" });
            DropIndex("dbo.TbAccessPlanMembersMapping", new[] { "AccessPlan_ID" });
            DropIndex("dbo.MembersTransponders", new[] { "MemberID" });
            DropIndex("dbo.MembersAccessPlanMapping", new[] { "MemberID" });
            DropIndex("dbo.MembersAccessPlanMapping", new[] { "AccessPlan_Nr" });
            DropIndex("dbo.MemberPassport", new[] { "MemberID" });
            DropIndex("dbo.MemberIdentityCard", new[] { "MemberID" });
            DropIndex("dbo.MemberHealthCard", new[] { "MemberID" });
            DropIndex("dbo.MemberDynamicFields", new[] { "MemberID" });
            DropIndex("dbo.MemberDrivingLicense", new[] { "MemberID" });
            DropIndex("dbo.MemberCommonInfo", new[] { "MemberID" });
            DropIndex("dbo.ERP_KAnsprechp", new[] { "AnredeCode" });
            DropIndex("dbo.MembersData", new[] { "ContractDuration" });
            DropIndex("dbo.MembersData", new[] { "Salutation" });
            DropIndex("dbo.MembersData", new[] { "MemberGroupId" });
            DropIndex("dbo.MemberAccessGroups", new[] { "GroupID" });
            DropIndex("dbo.MemberAccessGroups", new[] { "MemberID" });
            DropIndex("dbo.VisitorTransponders", new[] { "VisitorID" });
            DropIndex("dbo.Visitor_Vehicle", new[] { "VehicleID" });
            DropIndex("dbo.Pers_Vehicles", new[] { "VehicleID" });
            DropIndex("dbo.TariffCalendar", new[] { "TariffId" });
            DropIndex("dbo.PlannedCalendarTimeMapped", new[] { "CalendarId" });
            DropIndex("dbo.MonthlyCalendarMapped", new[] { "CalendarId" });
            DropIndex("dbo.DailyCalendarMapped", new[] { "CalendarId" });
            DropIndex("dbo.PlannedCalendarMapped", new[] { "MonthlyCalendarId" });
            DropIndex("dbo.PlannedCalendarMapped", new[] { "DailyCalendarId" });
            DropIndex("dbo.MapCalendarMonthMapped", new[] { "MapCalendarId" });
            DropIndex("dbo.EmployeeTariff", new[] { "TariffId" });
            DropIndex("dbo.EmployeeTariff", new[] { "EmployeeId" });
            DropIndex("dbo.Tariff", new[] { "SurchargeId" });
            DropIndex("dbo.Tariff", new[] { "PlannedCalendarId" });
            DropIndex("dbo.Tariff", new[] { "MapCalendarId" });
            DropIndex("dbo.PersonnelTariff", new[] { "TariffID" });
            DropIndex("dbo.PersonnelTariff", new[] { "PersonnelID" });
            DropIndex("dbo.Personal", new[] { "PersType" });
            DropIndex("dbo.Visitors", new[] { "VisitorVehicleType" });
            DropIndex("dbo.Visitors", new[] { "Company" });
            DropIndex("dbo.Visitors", new[] { "PersonalID" });
            DropIndex("dbo.Pers_Client", new[] { "ClientID" });
            DropIndex("dbo.Clients", new[] { "State" });
            DropIndex("dbo.VisitorAccessTime", new[] { "CompanyTo" });
            DropIndex("dbo.VisitorAccessTime", new[] { "VisitPlanId" });
            DropIndex("dbo.VisitorAccessTime", new[] { "VisitorId" });
            DropIndex("dbo.TerminalUtilities", new[] { "TerminalConfigID" });
            DropIndex("dbo.TerminalSignalBreaks", new[] { "TerminalID" });
            DropIndex("dbo.TerminalInfoText", new[] { "TerminalConfigID" });
            DropIndex("dbo.TerminalGroupMapping", new[] { "TerminalInstanceId" });
            DropIndex("dbo.TerminalGroupMapping", new[] { "TerminalGroupId" });
            DropIndex("dbo.TerminalFunctionKeys", new[] { "TerminalConfigID" });
            DropIndex("dbo.TerminalDatafoxFunction", new[] { "TerminalID" });
            DropIndex("dbo.Terminals", new[] { "TermOEMID" });
            DropIndex("dbo.TA_PersonalGroupMapping", new[] { "TerminalGroupId" });
            DropIndex("dbo.TA_TerminalGroupMapping", new[] { "TerminalInstanceId" });
            DropIndex("dbo.TA_TerminalGroupMapping", new[] { "TerminalGroupId" });
            DropIndex("dbo.TerminalConfig", new[] { "TerminalId" });
            DropIndex("dbo.TerminalConfig", new[] { "TerminalOEMId" });
            DropIndex("dbo.TerminalConfig", new[] { "TerminalInfoId" });
            DropIndex("dbo.TerminalConfig", new[] { "TerminalConnectId" });
            DropIndex("dbo.ReaderAssigned", new[] { "ReaderID" });
            DropIndex("dbo.ReaderAssigned", new[] { "BuildingPlanID" });
            DropIndex("dbo.ReaderAccessPlan", new[] { "AccessPlanId" });
            DropIndex("dbo.ReaderAccessPlan", new[] { "ReaderId" });
            DropIndex("dbo.TerminalReaders", new[] { "ReaderNr" });
            DropIndex("dbo.TerminalReaders", new[] { "TermID" });
            DropIndex("dbo.ReaderVisitorPlan", new[] { "VisitorPlanId" });
            DropIndex("dbo.ReaderVisitorPlan", new[] { "ReaderId" });
            DropIndex("dbo.SwitchCalendarMonth", new[] { "SwitchCalendarId" });
            DropIndex("dbo.SwitchPlan", new[] { "HolidayPlanCalendarId" });
            DropIndex("dbo.SwitchPlan", new[] { "BuidingPlanID" });
            DropIndex("dbo.SwitchPlan", new[] { "SwitchCalendarId" });
            DropIndex("dbo.HolidayPlanCalendarMonth", new[] { "HolidayPlanCalendarId" });
            DropIndex("dbo.HolidayPlanAccessProfileMonth", new[] { "HolidayPlanCalendarId" });
            DropIndex("dbo.HolidayCalendarMonth", new[] { "HolidayCalendarId" });
            DropIndex("dbo.HolidayPlanCalendar", new[] { "HolidayCalenderId" });
            DropIndex("dbo.TbVisitorPlan", new[] { "HolidayPlanCalendarId" });
            DropIndex("dbo.TbVisitorPlan", new[] { "BuildingPlanID" });
            DropIndex("dbo.TbVisitorPlan", new[] { "AccessCalendarId" });
            DropIndex("dbo.AccessCalendarMonth", new[] { "AccessCalendarID" });
            DropIndex("dbo.TbAccessPlanGroup", new[] { "HolidayPlanCalendarId" });
            DropIndex("dbo.TbAccessPlanGroup", new[] { "AccessCalendarId" });
            DropIndex("dbo.TbAccessPlanGroup", new[] { "BuildingPlanID" });
            DropIndex("dbo.AccessPlanGroupDoorMapping", new[] { "BuildingPlanID" });
            DropIndex("dbo.AccessPlanGroupDoorMapping", new[] { "AccessPlanGroupID" });
            DropIndex("dbo.TbAccessPlan", new[] { "HolidayPlanCalendarId" });
            DropIndex("dbo.TbAccessPlan", new[] { "BuildingPlanID" });
            DropIndex("dbo.TbAccessPlan", new[] { "AccessGroupID" });
            DropIndex("dbo.ZuttritProfilesTimeFrames", new[] { "AccessProfID" });
            DropIndex("dbo.ZuttritProfiles", new[] { "GroupID" });
            DropIndex("dbo.AccessProfileAccessGroupMapping", new[] { "AccessGroupID" });
            DropIndex("dbo.AccessProfileAccessGroupMapping", new[] { "AccessProfileID" });
            DropIndex("dbo.AccessGroupEmployee", new[] { "EmployeeId" });
            DropIndex("dbo.AccessGroupEmployee", new[] { "AccessGroupId" });
            DropIndex("dbo.Employee", new[] { "InfoId" });
            DropIndex("dbo.EmployeeAbsence", new[] { "AbsenceId" });
            DropIndex("dbo.EmployeeAbsence", new[] { "EmployeeId" });
            DropTable("dbo.vwVisitorCompany");
            DropTable("dbo.vwSwitchProfiles");
            DropTable("dbo.vwPersPinCodes");
            DropTable("dbo.VwPersonnelData");
            DropTable("dbo.VwPersDataZUT");
            DropTable("dbo.VwHolidayCalender");
            DropTable("dbo.vw_users");
            DropTable("dbo.vw_PortalUsersProfilePermissionMapping");
            DropTable("dbo.vw_PortalUserProfile");
            DropTable("dbo.vw_PortalKunden");
            DropTable("dbo.vw_PermissionMapping");
            DropTable("dbo.VisitorType");
            DropTable("dbo.VisitorPlanGroup");
            DropTable("dbo.VisitorContacts");
            DropTable("dbo.VisitorApplications");
            DropTable("dbo.VisitorAdditionalInfo");
            DropTable("dbo.VIS_PersPasswordsProfile");
            DropTable("dbo.VirtualTerminal");
            DropTable("dbo.VirtualTerminalInputSettings");
            DropTable("dbo.VirtualTerminalGroupsMapping");
            DropTable("dbo.VirtualTerminalFunctionKeys");
            DropTable("dbo.VirtualTerminalCommunicationSettings");
            DropTable("dbo.VirtualTerminalGroups");
            DropTable("dbo.VirtualPersonalGroupsMapping");
            DropTable("dbo.ViewTerminalGroupMapping");
            DropTable("dbo.ViewTA_TerminalGroupMapping");
            DropTable("dbo.ViewMemberCardsInfo");
            DropTable("dbo.View_VisitorEntryLog");
            DropTable("dbo.View_VisitorAccessLog");
            DropTable("dbo.View_Transponders");
            DropTable("dbo.View_TerminalReader");
            DropTable("dbo.View_TerminalHolidays");
            DropTable("dbo.View_TerminalFunction");
            DropTable("dbo.View_TerminalAccessProfiles");
            DropTable("dbo.View_TeminalInformation");
            DropTable("dbo.View_SwitchTimesCalendarProfiles");
            DropTable("dbo.View_SwitchTimes");
            DropTable("dbo.View_ReaderBuildingPlan");
            DropTable("dbo.View_MemberAccessLog");
            DropTable("dbo.View_ERPSoftwareUpdateService");
            DropTable("dbo.View_DFHoliday");
            DropTable("dbo.View_CardAllocationOverview");
            DropTable("dbo.View_AccessLogs");
            DropTable("dbo.View_AccessCalendarProfiles");
            DropTable("dbo.Transponders");
            DropTable("dbo.TimeRanges");
            DropTable("dbo.TerminalsNew");
            DropTable("dbo.TerminalOEMNew");
            DropTable("dbo.TerminalConnectionType");
            DropTable("dbo.TerminalBookingRawData");
            DropTable("dbo.TbAcessPlanReaderMapping");
            DropTable("dbo.TA_BookingsReportTypes");
            DropTable("dbo.TA_BookingsReportTitles");
            DropTable("dbo.TA_BookingsReportAccounts");
            DropTable("dbo.TA_BookingsReportAbsences");
            DropTable("dbo.TA_BookingsReport");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.SwitchProfiles");
            DropTable("dbo.SwitchProfilePairs");
            DropTable("dbo.SwitchCalendarProfiles");
            DropTable("dbo.SwitchCalendarMonthMapped");
            DropTable("dbo.SwitchCalendarMapped");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Status_Static");
            DropTable("dbo.Status_Dynamic");
            DropTable("dbo.ShiftResourceBac");
            DropTable("dbo.Sessions");
            DropTable("dbo.SCP");
            DropTable("dbo.RV_VisitorPlanVisitors");
            DropTable("dbo.RV_VisitorPlanAccessCalendar");
            DropTable("dbo.RV_SwitchProfileGroupedPerTerminal");
            DropTable("dbo.RV_SwitchPlanSwitchCalendar");
            DropTable("dbo.RV_HolidayPlanSwitchPlan");
            DropTable("dbo.RV_HolidayPlanPerTerminal");
            DropTable("dbo.RV_HolidayPlanAccessProfilesPerTerminal");
            DropTable("dbo.RV_HolidayPlanAccessPlan");
            DropTable("dbo.RV_HolidayCalendarNames");
            DropTable("dbo.RV_HolidayCalendarAccessPlan");
            DropTable("dbo.RV_HolidayCalendar");
            DropTable("dbo.RV_AccessProfilesPerTerminal");
            DropTable("dbo.RV_AccessPlanPersonnel");
            DropTable("dbo.RV_AccessPlanAccessCalendar");
            DropTable("dbo.Rooms");
            DropTable("dbo.RawBookings");
            DropTable("dbo.Portal_Permissions");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Portal_Users");
            DropTable("dbo.Portal_ProfileUSerMapping");
            DropTable("dbo.Portal_PermissionProfile");
            DropTable("dbo.Portal_PermissionMapping");
            DropTable("dbo.Portal_Audit");
            DropTable("dbo.Pers_Visitors");
            DropTable("dbo.Pers_Transponders");
            DropTable("dbo.Pers_PinCode");
            DropTable("dbo.Pers_Photo");
            DropTable("dbo.Pers_Passport");
            DropTable("dbo.Pers_Locations");
            DropTable("dbo.Pers_IdentityCard");
            DropTable("dbo.Pers_HealthCard");
            DropTable("dbo.Pers_DynamicFields");
            DropTable("dbo.Pers_DrivingLicense");
            DropTable("dbo.Pers_Contact");
            DropTable("dbo.Pers_Archive");
            DropTable("dbo.Pers_AdditionalInfo");
            DropTable("dbo.Pers_AccessPlanDuration");
            DropTable("dbo.MV_TerminalReaderBuildingPlans");
            DropTable("dbo.MV_AccessControlTransactionPersonel");
            DropTable("dbo.MV_AccessControlLogs");
            DropTable("dbo.MenuTable");
            DropTable("dbo.MapCalendar");
            DropTable("dbo.MapCalendarMonth");
            DropTable("dbo.Locations");
            DropTable("dbo.JC_Projects");
            DropTable("dbo.JC_Currency");
            DropTable("dbo.JC_Activities");
            DropTable("dbo.Holiday");
            DropTable("dbo.HolidayPlanCalendarMonthMapped");
            DropTable("dbo.HolidayPlanCalendarMapped");
            DropTable("dbo.HolidayCalendar_with_DateTime");
            DropTable("dbo.HolidayAccessPlam_with_DateTime");
            DropTable("dbo.GroupAccessProfiles");
            DropTable("dbo.Global_Settings");
            DropTable("dbo.FingerPrints");
            DropTable("dbo.FingerprintPassword");
            DropTable("dbo.ERP_SoftwareUpdateService");
            DropTable("dbo.ERP_SoftwareModules");
            DropTable("dbo.ERP_SoftwareContractStatus");
            DropTable("dbo.ERP_Länder");
            DropTable("dbo.ERP_KundenMark");
            DropTable("dbo.ERP_KundenGrMark");
            DropTable("dbo.ERP_KundenGr");
            DropTable("dbo.ERP_Kunden");
            DropTable("dbo.EmployeePhotos");
            DropTable("dbo.DynamicFieldsMember");
            DropTable("dbo.DynamicFields");
            DropTable("dbo.EmpAdditionalInfo");
            DropTable("dbo.DynamicColumns");
            DropTable("dbo.DF_TIME");
            DropTable("dbo.DatafoxTerminalReaders");
            DropTable("dbo.DatafoxTerminalInstances");
            DropTable("dbo.PlannedCalendarTime");
            DropTable("dbo.MonthlyCalendar");
            DropTable("dbo.PlannedCalendar");
            DropTable("dbo.DailyCalendar");
            DropTable("dbo.DailyBookingsReports");
            DropTable("dbo.DailyBooking");
            DropTable("dbo.Customers");
            DropTable("dbo.Countries");
            DropTable("dbo.Colors");
            DropTable("dbo.CellPhoneMaster");
            DropTable("dbo.CCAccounts");
            DropTable("dbo.BreaksType");
            DropTable("dbo.BreaksMapped");
            DropTable("dbo.BookingPairs");
            DropTable("dbo.AuditHist");
            DropTable("dbo.Pers_Areas");
            DropTable("dbo.Pers_Departments");
            DropTable("dbo.Departments");
            DropTable("dbo.Areas");
            DropTable("dbo.Accounts_Year");
            DropTable("dbo.Accounts_Week");
            DropTable("dbo.Accounts_Month");
            DropTable("dbo.Accounts_Day");
            DropTable("dbo.AccessControlLogs");
            DropTable("dbo.AccessCalendarProfiles");
            DropTable("dbo.AC_vwPersonelAccessPlan");
            DropTable("dbo.AC_ReportSettings");
            DropTable("dbo.AC_Reports");
            DropTable("dbo.AC_ReportListChecks");
            DropTable("dbo.AC_ReportList");
            DropTable("dbo.AC_PersPasswordsProfile");
            DropTable("dbo.AC_PersPasswords");
            DropTable("dbo.AC_Permissions");
            DropTable("dbo.AC_PersProfileMapping");
            DropTable("dbo.AC_PersProfileADMapping");
            DropTable("dbo.AC_PermissionProfile");
            DropTable("dbo.AC_PermissionMapping");
            DropTable("dbo.Specialdays");
            DropTable("dbo.WorkedHoursAcc");
            DropTable("dbo.Pers_CostCenters");
            DropTable("dbo.CostCenters");
            DropTable("dbo.EmployeeInfo");
            DropTable("dbo.SurchargeDays");
            DropTable("dbo.ResourceEvent");
            DropTable("dbo.ShiftResource");
            DropTable("dbo.DailyProgramMapped");
            DropTable("dbo.ResourceEventMapped");
            DropTable("dbo.Shifts");
            DropTable("dbo.Breaks");
            DropTable("dbo.Shift_Breaks");
            DropTable("dbo.DP_Shifts");
            DropTable("dbo.DailyPrograms");
            DropTable("dbo.Surcharges");
            DropTable("dbo.SurchargesAccountsMapping");
            DropTable("dbo.Accounts");
            DropTable("dbo.DailyAccountTime");
            DropTable("dbo.Addresses");
            DropTable("dbo.TbAccessPlanPersMapping");
            DropTable("dbo.Pers_AccessGroups");
            DropTable("dbo.TbAccessPlanMembersMapping");
            DropTable("dbo.MembersTransponders");
            DropTable("dbo.MembersAccessPlanMapping");
            DropTable("dbo.MemberPassport");
            DropTable("dbo.MemberIdentityCard");
            DropTable("dbo.MemberHealthCard");
            DropTable("dbo.MemberGroups");
            DropTable("dbo.MemberDynamicFields");
            DropTable("dbo.MemberDuration");
            DropTable("dbo.MemberDrivingLicense");
            DropTable("dbo.MemberCommonInfo");
            DropTable("dbo.ERP_KAnsprechp");
            DropTable("dbo.ERP_Anrede");
            DropTable("dbo.MembersData");
            DropTable("dbo.MemberAccessGroups");
            DropTable("dbo.VisitorTransponders");
            DropTable("dbo.VisitorCompanyTb");
            DropTable("dbo.Visitor_Vehicle");
            DropTable("dbo.Pers_Vehicles");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.TariffCalendar");
            DropTable("dbo.SurchargeMapped");
            DropTable("dbo.PlannedCalendarTimeMapped");
            DropTable("dbo.MonthlyCalendarMapped");
            DropTable("dbo.DailyCalendarMapped");
            DropTable("dbo.PlannedCalendarMapped");
            DropTable("dbo.MapCalendarMonthMapped");
            DropTable("dbo.MapCalendarMapped");
            DropTable("dbo.EmployeeTariff");
            DropTable("dbo.Tariff");
            DropTable("dbo.PersonnelTariff");
            DropTable("dbo.Pers_Type");
            DropTable("dbo.Personal");
            DropTable("dbo.Visitors");
            DropTable("dbo.Pers_Client");
            DropTable("dbo.LocationsFederalStates");
            DropTable("dbo.Clients");
            DropTable("dbo.VisitorAccessTime");
            DropTable("dbo.TerminalReadersStatic");
            DropTable("dbo.TerminalUtilities");
            DropTable("dbo.TerminalSignalBreaks");
            DropTable("dbo.TerminalInfoText");
            DropTable("dbo.TerminalInfo");
            DropTable("dbo.TerminalGroups");
            DropTable("dbo.TerminalGroupMapping");
            DropTable("dbo.TerminalFunctionKeys");
            DropTable("dbo.TerminalDatafoxFunction");
            DropTable("dbo.TerminalConnect");
            DropTable("dbo.TerminalOEM");
            DropTable("dbo.Terminals");
            DropTable("dbo.TA_PersonalGroupMapping");
            DropTable("dbo.TA_TerminalGroups");
            DropTable("dbo.TA_TerminalGroupMapping");
            DropTable("dbo.TerminalConfig");
            DropTable("dbo.ReaderAssigned");
            DropTable("dbo.ReaderAccessPlan");
            DropTable("dbo.TerminalReaders");
            DropTable("dbo.ReaderVisitorPlan");
            DropTable("dbo.SwitchCalendarMonth");
            DropTable("dbo.SwitchCalendar");
            DropTable("dbo.SwitchPlan");
            DropTable("dbo.HolidayPlanCalendarMonth");
            DropTable("dbo.HolidayPlanAccessProfileMonth");
            DropTable("dbo.HolidayCalendarMonth");
            DropTable("dbo.HolidayCalendar");
            DropTable("dbo.HolidayPlanCalendar");
            DropTable("dbo.TbVisitorPlan");
            DropTable("dbo.AccessCalendarMonth");
            DropTable("dbo.AccessCalendar");
            DropTable("dbo.TbAccessPlanGroup");
            DropTable("dbo.AccessPlanGroupDoorMapping");
            DropTable("dbo.BuildingPlan");
            DropTable("dbo.TbAccessPlan");
            DropTable("dbo.ZuttritProfilesTimeFrames");
            DropTable("dbo.ZuttritProfiles");
            DropTable("dbo.AccessProfileAccessGroupMapping");
            DropTable("dbo.AccessGroup");
            DropTable("dbo.AccessGroupEmployee");
            DropTable("dbo.Employee");
            DropTable("dbo.EmployeeAbsence");
            DropTable("dbo.Absences");
        }
    }
}
