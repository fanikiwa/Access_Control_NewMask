using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class GateDisplaypanelDto
    {
        public long IDNr { get; set; }
        public int CardStatus { get; set; }
        public int Pers_Type { get; set; }
        public string Name1 { get; set; }
        public long? ID_Nr1 { get; set; }
        public DateTime? TimeIn1 { get; set; }
        public DateTime? TimeOut1 { get; set; }
        public int CardStatus1 { get; set; }

        public string Name2 { get; set; }
        public long? ID_Nr2 { get; set; }
        public DateTime? TimeIn2 { get; set; }
        public DateTime? TimeOut2 { get; set; }
        public int CardStatus2 { get; set; }

        public string Name3 { get; set; }
        public long? ID_Nr3 { get; set; }
        public DateTime? TimeIn3 { get; set; }
        public DateTime? TimeOut3 { get; set; }
        public int CardStatus3 { get; set; }
    }
}