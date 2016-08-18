using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Control_NewMask.Dtos
{
    public class LocationCalendarDto
    {
        #region Constructor
        public LocationCalendarDto() { }

        #endregion

        #region Properties
        //These properties map to the fields in the Locations Table
        public long ID { get; set; }
        public long Location_Nr { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Feiertagskalender { get; set; }
        public string LocationHeadName { get; set; }
        public string LocationHeadPhone { get; set; }
        #endregion
    }
}
