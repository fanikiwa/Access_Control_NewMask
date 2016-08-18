using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KruAll.Core.Repositories;

namespace Access_Control_NewMask.TerminalCommunication
{
    public class DataCommunication
    {
        private ZKPullConnection _zkPullConnection = null;
        private ZKStandAloneConnection _zkStandAloneConnection = null;
        private DatafoxConnection _dataFoxConnection = null;
        public enum SDKType
        {
            DataFox, ZKStandAloneColorTFT, ZKStandAloneBlackAndWhite, ZKPull
        }
        public void TestConnection(List<TerminalInterface> lcTerminals)
        {
            ITerminalConnection terminalConnection = null;
            foreach (TerminalInterface terminal in lcTerminals)
            {
                terminalConnection = _getTerminalConnection(terminal);
                terminalConnection.IPAddress = terminal.IPAddress;
                terminalConnection.TerminalDescription = terminal.TerminalDescription;
                terminalConnection.TestConnection();
                terminal.ActionResultMessage = terminalConnection.LastActionResultMessage;
                terminal.ResultType = terminalConnection.LastActionResult;
            }
        }

        public void SendSystemTime(List<TerminalInterface> lcTerminals)
        {
            ITerminalConnection terminalConnection = null;
            foreach (TerminalInterface terminal in lcTerminals)
            {
                terminalConnection = _getTerminalConnection(terminal);
                terminalConnection.IPAddress = terminal.IPAddress;
                terminalConnection.TerminalDescription = terminal.TerminalDescription;
                terminalConnection.SendSystemTime();
                terminal.ActionResultMessage = terminalConnection.LastActionResultMessage;
                terminal.ResultType = terminalConnection.LastActionResult;
            }
        }

        public void SendSystemData(List<TerminalInterface> lcTerminals)
        {
            ITerminalConnection terminalConnection = null;
            foreach (TerminalInterface terminal in lcTerminals)
            {
                terminalConnection = _getTerminalConnection(terminal);
                terminalConnection.IPAddress = terminal.IPAddress;
                terminalConnection.TerminalDescription = terminal.TerminalDescription;
                terminalConnection.SendMasterData();
                terminal.ActionResultMessage = terminalConnection.LastActionResultMessage;
                terminal.ResultType = terminalConnection.LastActionResult;
            }
        }

        public void GetBookings(List<TerminalInterface> lcTerminals)
        {
            ITerminalConnection terminalConnection = null;
            foreach (TerminalInterface terminal in lcTerminals)
            {
                terminalConnection = _getTerminalConnection(terminal);
                terminalConnection.IPAddress = terminal.IPAddress;
                terminalConnection.TerminalDescription = terminal.TerminalDescription;
                terminalConnection.GetBookings();
                terminal.ActionResultMessage = terminalConnection.LastActionResultMessage;
                terminal.ResultType = terminalConnection.LastActionResult;
            }
        }

        private ITerminalConnection _getTerminalConnection(TerminalInterface terminal)
        {
            ITerminalConnection terminalConnection = null;

            switch(TerminalSDKType(terminal.TerminalType))
            {
                case SDKType.DataFox:
                    _dataFoxConnection = new DatafoxConnection();
                    _dataFoxConnection.SDKType = TerminalSDKType(terminal.TerminalType);
                    terminalConnection = (ITerminalConnection)_dataFoxConnection;
                    break;
                case SDKType.ZKPull:
                    _zkPullConnection = new ZKPullConnection();
                    _zkPullConnection.SDKType = TerminalSDKType(terminal.TerminalType);
                    terminalConnection = (ITerminalConnection)_zkPullConnection;
                    break;
                case SDKType.ZKStandAloneBlackAndWhite:
                case SDKType.ZKStandAloneColorTFT:
                    _zkStandAloneConnection = new ZKStandAloneConnection();
                    _zkStandAloneConnection.SDKType = TerminalSDKType(terminal.TerminalType);
                    terminalConnection = (ITerminalConnection)_zkStandAloneConnection;
                    break;
            }

            return terminalConnection;

        }

        private SDKType TerminalSDKType(string TerminalType)
        {
            SDKType sdkType = new SDKType();

            switch (TerminalType)
            {
                case "TM 560bc":
                case "TM 560tc":
                case "TM 680tc":
                case "TM 680bc":
                case "TM 900bc":
                case "SCR100":

                    sdkType = SDKType.ZKStandAloneColorTFT;
                    break;
                case "SC403":
                case "TF1700":
                case "MA300out":
                case "ZB702in":
                case "ZB703in":
                case "TF 1700":
                    sdkType = SDKType.ZKStandAloneBlackAndWhite;
                    break;
                case "ZBBi-402":
                case "ZBBi-404":
                    sdkType = SDKType.ZKPull;
                    break;
                case "TM EVO 2.8":
                case "TM EVO 4.3":
                case "PZE- MasterIV":
                case "TM Master IV":
                case "TM Flex Master":
                case "Timeboy IV":
                case "ZK Master IV":
                    sdkType = SDKType.DataFox;
                    break;
            }
            return sdkType;
        }

        public void SendVisitorDataToTerminals(long visitorID)
        {
            List<long> terminalIDs = null;
            List<TerminalInterface> terminals = new List<TerminalInterface>();


            terminalIDs = new TerminalConfigRepository().GetTerminalIDsForVisitorPlan(visitorID);
            var allTerminals = new TerminalConfigRepository().GetAllTerminalsInstances();

            foreach (int terminalID in terminalIDs)
            {
                var terminalInstance = allTerminals.Where(x => x.ID == terminalID).FirstOrDefault();
                if(terminalInstance != null)
                {
                    TerminalInterface terminal = new TerminalInterface();
                    terminal.TerminalID = terminalID;
                    terminal.IPAddress = terminalInstance.IpAddress;
                    terminal.TerminalDescription = terminalInstance.Description;
                    terminal.SerialNumber = terminalInstance.SerialNumber;
                    terminal.TerminalType = terminalInstance.TermType;
                    terminal.ActionResultMessage = string.Empty;
                    terminal.ResultType = TerminalInterface.ActionResultType.Success;
                    terminals.Add(terminal);
                }
            }

            ITerminalConnection terminalConnection = null;

            foreach (TerminalInterface terminal in terminals)
            {
                terminalConnection = _getTerminalConnection(terminal);
                terminalConnection.IPAddress = terminal.IPAddress;
                terminalConnection.TerminalDescription = terminal.TerminalDescription;
                terminalConnection.SendVisitorDataToTerminals();
                terminal.ActionResultMessage = terminalConnection.LastActionResultMessage;
                terminal.ResultType = terminalConnection.LastActionResult;
            }
        }
    }
}