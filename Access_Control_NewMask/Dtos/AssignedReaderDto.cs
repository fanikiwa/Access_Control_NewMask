using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class AssignedReaderDto
    {
        public int doorId { get; set; }
        public string readerType { get; set; }
        public bool readerStatus { get; set; }
        public int? readerDirection { get; set; }
        public bool readerAssigned { get; set; }
        public bool accessProfileActive { get; set; }
        public bool switchProfileActive { get; set; }
        public bool manualOpeningActive { get; set; }
        public bool accessPlanReaderStatus { get; set; }
        public int? passBackNr { get; set; }
    }
}