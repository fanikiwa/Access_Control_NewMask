using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class TransponderDto
    {
        public long ID { get; set; }
        public long Card { get; set; }
        public long PersNr { get; set; }
        public string TransponderNr { get; set; }
        public int TransponderType { get; set; }
        public bool TransponderActive { get; set; }
        public bool TransponderInActive { get; set; }
        public DateTime? ExtendedTo { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime? TransponderDeactivatedOn { get; set; }
        public string Action { get; set; }
        public string Memo { get; set; }
    }
}