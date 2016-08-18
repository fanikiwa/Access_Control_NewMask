using Krutec.Tools.Extensions;
using System.Data.Entity.Core.EntityClient;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System.Linq;
using System;

namespace Access_Control_NewMask.TerminalCommunication
{
    public class DatafoxConnection : ITerminalConnection
    {
        private string terminalIPAddress = string.Empty;
        private string terminalPortNumber = string.Empty;
        private string terminalDescription = string.Empty;
        DataCommunication.SDKType _sdkType = new DataCommunication.SDKType();

        public string IPAddress
        {
            get
            {
                return terminalIPAddress;
            }

            set
            {
                terminalIPAddress = value;
            }
        }

        public string PortNumber
        {
            get
            {
                return terminalPortNumber;
            }

            set
            {
                terminalPortNumber = value;
            }
        }

        public string TerminalDescription
        {
            get
            {
                return terminalDescription;
            }

            set
            {
                terminalDescription = value;
            }
        }
        public DataCommunication.SDKType SDKType
        {
            get
            {
                return _sdkType;
            }

            set
            {
                _sdkType = value;
            }
        }

        public void GetBookings()
        {
            string IPAddress = string.Empty;
            string DeviceName = string.Empty;

            while (true)
            {
                DeviceName = this.terminalDescription;
                IPAddress = this.IPAddress;

                var dbConnection = new ttxTools.ClsDB(this.connectionString);
                var termRecord = DataFoxEx.newTermRecord(DeviceName, IPAddress, dbConnection);
                var terminal = new KrutecDfTrans.Classes.DfTerminal(dbConnection, termRecord, 254);

                if (terminal.Info == "Offline")
                {
                   this.LastActionResult = TerminalInterface.ActionResultType.Error;
                   this.LastActionResultMessage = "Error getting Bookings";
                    break;
                }

                terminal.ReadTransactions(5);
                if(terminal.Stream.IsOpen)
                {
                    terminal.Stream.Close();
                }
                terminal = null;
                
                this.LastActionResult = TerminalInterface.ActionResultType.Success;
                this.LastActionResultMessage = "Booking Sent To Database";
                break;
            }
        }

        public void SendMasterData()
        {
            string IPAddress = string.Empty;
            string DeviceName = string.Empty;
            TerminalDatafoxFunction df = null;

            DeviceName = this.terminalDescription;
            IPAddress = this.IPAddress;

            var terminalInstance = new TerminalConfigRepository().GetAllTerminalsInstances().Where(x => x.Description == DeviceName).FirstOrDefault();

            if (terminalInstance != null)
            {
                if (terminalInstance.TerminalDatafoxFunctions != null)
                {
                    if (terminalInstance.TerminalDatafoxFunctions.Count > 0)
                    {
                        df = terminalInstance.TerminalDatafoxFunctions.FirstOrDefault();
                        df.AccessControl = true;
                        df.Project = false;
                    }
                }
            }

            if (df == null)
            {
                df = new TerminalDatafoxFunction()
                {
                    AccessControl = true,
                    ActionList = false,
                    BookingSpan = 0,
                    EventList = true,
                    HolidayList = true,
                    IdentificationList = true,
                    LocationList = false,
                    Project = false,
                    ReaderList = false,
                    TimeList = true
                };
            }


            while (true)
            {
                var dbConnection = new ttxTools.ClsDB(this.connectionString);
                var termRecord = DataFoxEx.newTermRecord(DeviceName, IPAddress, dbConnection);
                var terminal = new KrutecDfTrans.Classes.DfTerminal(dbConnection, termRecord, 254);

                if (terminal.Info == "Offline")
                {
                    this.LastActionResult = TerminalInterface.ActionResultType.Error;
                    this.LastActionResultMessage = Resources.LocalizedText.ErrorSendingData;
                    break;
                }

                terminal.SendCommonData(df);
                this.LastActionResult = TerminalInterface.ActionResultType.Success;
                this.LastActionResultMessage = Resources.LocalizedText.DataSentSuccessfully;
                break;
            }
        }

        public void SendSystemTime()
        {
            string IPAddress = string.Empty;
            string DeviceName = string.Empty;

            while (true)
            {
                DeviceName = this.terminalDescription;
                IPAddress = this.IPAddress;

                var dbConnection = new ttxTools.ClsDB(this.connectionString);
                var termRecord = DataFoxEx.newTermRecord(DeviceName, IPAddress, dbConnection);
                var terminal = new KrutecDfTrans.Classes.DfTerminal(dbConnection, termRecord, 254);

                if (terminal.Info == "Offline")
                {
                    this.LastActionResult = TerminalInterface.ActionResultType.Error;
                    this.LastActionResultMessage = "Error Synchronize Time";
                    break;
                }

                terminal.SyncTime();
                terminal = null;

                this.LastActionResult = TerminalInterface.ActionResultType.Success;
                this.LastActionResultMessage = "Terminal Date Time Has Been synchronized";
                break;
            }
        }

        public void TestConnection()
        {
            string IPAddress = string.Empty;
            string DeviceName = string.Empty;

            while (true)
            {
                DeviceName = this.terminalDescription;
                IPAddress = this.IPAddress;

                var dbConnection = new ttxTools.ClsDB(this.connectionString);
                var termRecord = DataFoxEx.newTermRecord(DeviceName, IPAddress, dbConnection);
                var terminal = new KrutecDfTrans.Classes.DfTerminal(dbConnection, termRecord, 254);

                if (terminal.Info == "Offline")
                {
                    this.LastActionResult = TerminalInterface.ActionResultType.Error;
                    this.LastActionResultMessage = Resources.LocalizedText.ConnectionTestFailed;
                }
                else
                {
                    this.LastActionResult = TerminalInterface.ActionResultType.Success;
                    this.LastActionResultMessage = Resources.LocalizedText.ConnectionTestSuccessful;
                    terminal.Stream.Close();
                }
                break;
            }
        }

        public void SendVisitorDataToTerminals()
        {
            string IPAddress = string.Empty;
            string DeviceName = string.Empty;
            TerminalDatafoxFunction df = null;

            DeviceName = this.terminalDescription;
            IPAddress = this.IPAddress;

            
            df = new TerminalDatafoxFunction()
            {
                AccessControl = true,
                ActionList = false,
                BookingSpan = 5,
                EventList = false,
                HolidayList = false,
                IdentificationList = true,
                LocationList = true,
                Project = false,
                ReaderList = false,
                TimeList = true
            };

            while (true)
            {
                var dbConnection = new ttxTools.ClsDB(this.connectionString);
                var termRecord = DataFoxEx.newTermRecord(DeviceName, IPAddress, dbConnection);
                var terminal = new KrutecDfTrans.Classes.DfTerminal(dbConnection, termRecord, 254);

                if (terminal.Info == "Offline")
                {
                    this.LastActionResult = TerminalInterface.ActionResultType.Error;
                    this.LastActionResultMessage = Resources.LocalizedText.ErrorSendingData;
                    break;
                }

                terminal.SendCommonData(df);
                this.LastActionResult = TerminalInterface.ActionResultType.Success;
                this.LastActionResultMessage = Resources.LocalizedText.DataSentSuccessfully;
                break;
            }
        }

        private string connectionString
        {
            get
            {
                string entityConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PZE_Entities"].ConnectionString;
                return new EntityConnectionStringBuilder(entityConnectionString).ProviderConnectionString;
            }
        }

        public TerminalInterface.ActionResultType LastActionResult
        {
            get; set;
        }

        public string LastActionResultMessage
        {
            get; set;
        }
    }
}