using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class PermissionDto2
    {
        public PermissionDto2() { }

        #region Service Studio Complete Access
        public bool AllServiceStudioEdit { get; set; }
        public bool AllServiceStudioRead { get; set; }
        #endregion

        #region  Access Control Complete Access
        public bool AllAccessControlEdit { get; set; }
        public bool AllAccessControlRead { get; set; }
        #endregion

        #region 1. Access Control Settings
        public bool SettingsEdit { get; set; }
        public bool SettingsRead { get; set; }


        //Personnel Master Data Settings
        public bool SettingsPersMasterRead { get; set; }
        public bool SettingsPersMasterEdit { get; set; }

        public bool PersInactiveRead { get; set; }
        public bool PersInactiveEdit { get; set; }

        public bool MembersInactiveRead { get; set; }
        public bool MembersInactiveEdit { get; set; }

        public bool ClientsRead { get; set; }
        public bool ClientsEdit { get; set; }

        public bool LocationsRead { get; set; }
        public bool LocationsEdit { get; set; }

        public bool DepartmentRead { get; set; }
        public bool DepartmentEdit { get; set; }

        public bool CostCentersRead { get; set; }
        public bool CostCentersEdit { get; set; }

        public bool VisitorFirmsRead { get; set; }
        public bool VisitorFirmsEdit { get; set; }

        public bool VehiclesRead { get; set; }
        public bool VehiclesEdit { get; set; }

        public bool MembersGroupRead { get; set; }
        public bool MembersGroupEdit { get; set; }

        public bool MembersContractRead { get; set; }
        public bool MembersContractEdit { get; set; }


        //Access Settings
        public bool SettingsAccessRead { get; set; }
        public bool SettingsAccessEdit { get; set; }

        public bool SettingsAccessProfileRead { get; set; }
        public bool SettingsAccessProfileEdit { get; set; }

        public bool SettingsAccessCalenderRead { get; set; }
        public bool SettingsAccessCalenderEdit { get; set; }

        public bool SettingsSwitchProfileRead { get; set; }
        public bool SettingsSwitchProfileEdit { get; set; }

        public bool SettingsSwitchCalenderRead { get; set; }
        public bool SettingsSwitchCalenderEdit { get; set; }

        public bool SettingsHolidayCalenderRead { get; set; }
        public bool SettingsHolidayCalenderEdit { get; set; }

        public bool SettingsHolidayPlanRead { get; set; }
        public bool SettingsHolidayPlanEdit { get; set; }


        //General Settings
        public bool SettingsGeneralRead { get; set; }
        public bool SettingsGeneralEdit { get; set; }

        public bool SettingsLanguageRead { get; set; }
        public bool SettingsLanguageEdit { get; set; }

        public bool SettingsRightsRead { get; set; }
        public bool SettingsRightsEdit { get; set; }

        public bool SettingsPasswordProfileRead { get; set; }
        public bool SettingsPasswordProfileEdit { get; set; }


        //Groups Settings
        public bool SettingsGroupRead { get; set; }
        public bool SettingsGroupEdit { get; set; }

        public bool SettingsAccessProfileGroupRead { get; set; }
        public bool SettingsAccessProfileGroupEdit { get; set; }

        public bool SettingsAccessPlanGroupRead { get; set; }
        public bool SettingsAccessPlanGroupEdit { get; set; }
        #endregion

        #region 2. Gate Monitor
        public bool GateMonitorEdit { get; set; }
        public bool GateMonitorRead { get; set; }


        //Gate Monitor
        public bool GateMonitorPersonnelRead { get; set; }
        public bool GateMonitorPersonnelEdit { get; set; }

        public bool GateMonitorMembersRead { get; set; }
        public bool GateMonitorMembersEdit { get; set; }

        public bool GateMonitorVisitorsRead { get; set; }
        public bool GateMonitorVisitorsEdit { get; set; }

        public bool GateMonitorDisplayPanelRead { get; set; }
        public bool GateMonitorDisplayPanelEdit { get; set; }

        public bool GateMonitorInfoRead { get; set; }
        public bool GateMonitorInfoEdit { get; set; }
        #endregion

        #region 3. Access Control Master Data
        public bool MasterDataEdit { get; set; }
        public bool MasterDataRead { get; set; }


        //Access Control Master Data
        public bool PersActiveRead { get; set; }
        public bool PersActiveEdit { get; set; }

        public bool MembersActiveEdit { get; set; }
        public bool MembersActiveRead { get; set; }

        public bool BuildingPlanRead { get; set; }
        public bool BuildingPlanEdit { get; set; }

        public bool AccessGroupRead { get; set; }
        public bool AccessGroupEdit { get; set; }

        public bool AccessPlanEdit { get; set; }
        public bool AccessPlanRead { get; set; }

        public bool SwitchPlanRead { get; set; }
        public bool SwitchPlanEdit { get; set; }
        #endregion

        #region 4. Visitor Master Data
        public bool VisitorMasterDataEdit { get; set; }
        public bool VisitorMasterDataRead { get; set; }


        // Visitor Master Data
        public bool VisitorsRead { get; set; }
        public bool VisitorsEdit { get; set; }

        public bool VisitorApplicationsEdit { get; set; }
        public bool VisitorApplicationsRead { get; set; }

        public bool VisitorPlanRead { get; set; }
        public bool VisitorPlanEdit { get; set; }
        #endregion

        #region 5. Safety and Corrections
        public bool SafetyAndCorrectionsRead { get; set; }
        public bool SafetyAndCorrectionsEdit { get; set; }


        //Safety and Corrections
        public bool GraderRead { get; set; }
        public bool GraderEdit { get; set; }

        public bool DisplayPanelRead { get; set; }
        public bool DisplayPanelEdit { get; set; }

        public bool AlarmOpenRead { get; set; }
        public bool AlarmOpenEdit { get; set; }
        #endregion

        #region 6. Reports
        public bool ReportsEdit { get; set; }
        public bool ReportsRead { get; set; }
        #endregion

        #region 7. Communications
        public bool CommunicationEdit { get; set; }
        public bool CommunicationRead { get; set; }


        //Communication
        public bool CommunicationGETEdit { get; set; }
        public bool CommunicationGETRead { get; set; }

        public bool CommunicationSENDEdit { get; set; }
        public bool CommunicationSENDRead { get; set; }

        public bool CommunicationManualEdit { get; set; }
        public bool CommunicationManualRead { get; set; }
        #endregion


        #region Settings Group Levels Checks
        public bool AllSettingsCheck()
        {
            return AllPersSettingsCheck()
            || AllAccessSettingsCheck()
            || AllGeneralSettingsCheck()
            || AllGroupSettingsCheck();
        }

        private bool AllPersSettingsCheck()
        {
            return AllAccessControlRead || SettingsRead
                    || PersInactiveRead || MembersInactiveRead || ClientsRead
                    || LocationsRead || DepartmentRead || CostCentersRead
                    || VisitorFirmsRead || VehiclesRead || MembersGroupRead || MembersContractRead

                    || AllAccessControlEdit || SettingsEdit
                    || PersInactiveEdit || MembersInactiveEdit || ClientsEdit
                    || LocationsEdit || DepartmentEdit || CostCentersEdit
                    || VisitorFirmsEdit || VehiclesEdit || MembersGroupEdit || MembersContractEdit;
        }

        private bool AllAccessSettingsCheck()
        {
            return AllAccessControlRead || SettingsRead || SettingsAccessProfileRead
                    || SettingsAccessCalenderRead || SettingsSwitchProfileRead
                    || SettingsHolidayCalenderRead || SettingsHolidayPlanRead

                    || AllAccessControlEdit || SettingsEdit || SettingsAccessProfileEdit
                    || SettingsAccessCalenderEdit || SettingsSwitchProfileEdit
                    || SettingsHolidayCalenderEdit || SettingsHolidayPlanEdit;
        }

        private bool AllGeneralSettingsCheck()
        {
            return AllAccessControlRead || SettingsRead || SettingsLanguageRead
                    || SettingsRightsRead || SettingsPasswordProfileRead

                    || AllAccessControlEdit || SettingsEdit || SettingsLanguageEdit
                    || SettingsRightsEdit || SettingsPasswordProfileEdit;
        }

        private bool AllGroupSettingsCheck()
        {
            return AllAccessControlRead || SettingsRead
                    || SettingsAccessProfileGroupRead || SettingsAccessPlanGroupRead

                    || AllAccessControlEdit || SettingsEdit
                    || SettingsAccessProfileGroupEdit || SettingsAccessPlanGroupEdit;
        }
        #endregion

        #region Gate Monitor Group Levels Checks
        public bool AllGateMonitorCheck()
        {
            return AllAccessControlRead || GateMonitorRead || GateMonitorPersonnelRead
                    || GateMonitorMembersRead || GateMonitorVisitorsRead
                    || GateMonitorDisplayPanelRead || GateMonitorInfoRead

                    || AllAccessControlEdit || GateMonitorEdit || GateMonitorPersonnelEdit
                    || GateMonitorMembersEdit || GateMonitorVisitorsEdit
                    || GateMonitorDisplayPanelEdit || GateMonitorInfoEdit;
        }
        #endregion
    }
}