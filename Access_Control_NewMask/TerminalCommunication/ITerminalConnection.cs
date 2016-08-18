using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Control_NewMask.TerminalCommunication
{
    interface ITerminalConnection
    {
        string IPAddress { get; set; }
        string PortNumber { get; set; }
        string TerminalDescription { get; set; }
        void SendMasterData();
        void GetBookings();
        void SendSystemTime();
        void TestConnection();
        void SendVisitorDataToTerminals();
        DataCommunication.SDKType SDKType { get; set; }
        TerminalInterface.ActionResultType LastActionResult { get; set; }
        string LastActionResultMessage { get; set; }

    }
}
