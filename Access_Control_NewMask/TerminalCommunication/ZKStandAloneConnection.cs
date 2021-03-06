﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZKSDKCommunication;
using ZKSDKCommunication.ZKBusinessObjects;

namespace Access_Control_NewMask.TerminalCommunication
{
    public class ZKStandAloneConnection : ITerminalConnection
    {
        private string terminalIPAddress = string.Empty;
        private string terminalPortNumber = string.Empty;
        private string terminalDescription = string.Empty;
        DataCommunication.SDKType _sdkType = new DataCommunication.SDKType();
        private const int ZK_TERMINAL_DEFAULT_PORT = 4370;

        private StandAloneInterface standAloneSDK = null;

        public ZKStandAloneConnection()
        {

        }
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

        public TerminalInterface.ActionResultType LastActionResult
        {
            get; set;
        }

        public string LastActionResultMessage
        {
            get; set;
        }

        public void GetBookings()
        {

        }

        public void SendMasterData()
        {
            ZKTerminal _currentTerminal = getCurrentTerminal();

            standAloneSDK = new StandAloneInterface(_currentTerminal);

            if (standAloneSDK.ConnectToDevice())
            {
                standAloneSDK.SendMasterData();
                standAloneSDK.Disconnect();

                this.LastActionResult = TerminalInterface.ActionResultType.Success;
                this.LastActionResultMessage = Resources.LocalizedText.DataSentSuccessfully;
            }
            else
            {
                this.LastActionResult = TerminalInterface.ActionResultType.Error;
                this.LastActionResultMessage = Resources.LocalizedText.ErrorSendingData;
            }
        }

        public void SendSystemTime()
        {
            ZKTerminal _currentTerminal = getCurrentTerminal();

            standAloneSDK = new StandAloneInterface(_currentTerminal);

            if (standAloneSDK.ConnectToDevice())
            {
                standAloneSDK.SetDeviceDateTime();
                standAloneSDK.Disconnect();

                this.LastActionResult = TerminalInterface.ActionResultType.Success;
                this.LastActionResultMessage = "Terminal Date Time Has Been synchronized";
            }
            else
            {
                this.LastActionResult = TerminalInterface.ActionResultType.Error;
                this.LastActionResultMessage = "Error Synchronize Time";
            }
        }

        public void TestConnection()
        {
            ZKTerminal _currentTerminal = getCurrentTerminal();

            standAloneSDK = new StandAloneInterface(_currentTerminal);

            if (standAloneSDK.ConnectToDevice())
            {
                this.LastActionResult = TerminalInterface.ActionResultType.Success;
                this.LastActionResultMessage = Resources.LocalizedText.ConnectionTestSuccessful;
                standAloneSDK.Disconnect();
            }
            else
            {
                this.LastActionResult = TerminalInterface.ActionResultType.Error;
                this.LastActionResultMessage = Resources.LocalizedText.ConnectionTestFailed;
            }
        }

        private ZKTerminal getCurrentTerminal()
        {
            ZKTerminal _currentTerminal = new ZKTerminal();

            _currentTerminal.Description = this.TerminalDescription;
            _currentTerminal.IPAddress = this.IPAddress;
            _currentTerminal.PortNumber = ZK_TERMINAL_DEFAULT_PORT;
            _currentTerminal.DataCollectionType = ZKTerminalEnums.DataCollectionType.AccessControl;

            switch(this.SDKType)
            {
                case DataCommunication.SDKType.ZKStandAloneBlackAndWhite:
                    _currentTerminal.SDKType = ZKTerminalEnums.SDKType.BlackAndWhiteStandAlone;
                    break;
                case DataCommunication.SDKType.ZKStandAloneColorTFT:
                    _currentTerminal.SDKType = ZKTerminalEnums.SDKType.TFTStandAlone;
                    break;
            }
            

            return _currentTerminal;

        }

        public void SendVisitorDataToTerminals()
        {
            this.SendMasterData();
        }
    }
}