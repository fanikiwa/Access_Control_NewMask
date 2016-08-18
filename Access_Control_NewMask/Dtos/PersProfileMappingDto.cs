using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class PersProfileMappingDto
    {
        public PersProfileMappingDto() { }

        public long ID { get; set; }
        public long PersNr { get; set; }
        public int? ProfileID { get; set; }
        public bool UseAD { get; set; }
        public string AD_Username { get; set; }
        public string AD_Path { get; set; }
        public string AD_Controller { get; set; }
    }
}