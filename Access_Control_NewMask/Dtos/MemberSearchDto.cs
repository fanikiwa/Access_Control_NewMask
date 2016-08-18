using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class MemberSearchDto
    {
        public long ID { get; set; }
        public long GroupId { get; set; }
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1}", SurName, FirstName); }
        }
        public long MemberNumber { get; set; }
        public bool Active { get; set; }
    }
}