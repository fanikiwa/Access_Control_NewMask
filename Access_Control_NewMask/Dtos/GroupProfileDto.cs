using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class GroupProfileDto
    {
        public int ID
        {
            get
            {
                return -1 * AccessProfileNo;
            }
        }
        public int AccessProfileNo { get; set; }
        public string AccessDescription { get; set; }
        public string AccessProfileID { get; set; }
        public long GroupNo { get; set; }

        public string GroupDescription { get; set; }

    }
}