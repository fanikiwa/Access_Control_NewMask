using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class PersonalDynamicField_DTO
    {
        public long PersonalNumber { get; set; }
        public int FieldIndex { get; set; }
        public string FieldText { get; set; }
        public string FieldValue { get; set; }
    }
}