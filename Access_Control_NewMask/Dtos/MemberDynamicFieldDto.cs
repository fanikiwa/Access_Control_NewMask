using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class MemberDynamicFieldDto
    {
        public long MemberID { get; set; }
        public int FieldIndex { get; set; }
        public string FieldText { get; set; }
        public string FieldValue { get; set; }
    }
}