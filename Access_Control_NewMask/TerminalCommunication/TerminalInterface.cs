using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.TerminalCommunication
{
    public class TerminalInterface
    {
        public enum ActionResultType
        {
            Success, Error
        }
        public long TerminalID { get; set; }
        public string IPAddress { get; set; }
        public string TerminalDescription { get; set; }
        public string SerialNumber { get; set; }
        public string TerminalType { get; set; }
        public string ActionResultMessage { get; set; }
        public ActionResultType ResultType { get; set; }


    }
}