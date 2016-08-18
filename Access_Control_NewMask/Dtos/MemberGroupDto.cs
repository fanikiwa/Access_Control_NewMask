using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class MemberGroupDto
    {
        public long Id { get; set; }
        public long GroupNr { get; set; }
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }
        public string PersonHead { get; set; }
        public string TrainerOne { get; set; }
        public string TrainerTwo { get; set; }
        public string TrainerThree { get; set; }
        public string TrainerFour { get; set; }
        public string TrainerFive { get; set; }
    }
}