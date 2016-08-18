using KruAll.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public partial class PersAccessGroupsDto
    {
        public PersAccessGroupsDto()
        {
            this.TbAccessPlanGroups = new List<TbAccessPlanGroup>(); ;
        }

        public long ID { get; set; }
        public long Pers_Nr { get; set; }
        public long OldGroupID { get; set; }
        public long GroupID { get; set; }
        public bool Active { get; set; }        
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public TbAccessPlanGroup TbAccessPlanGroup { get; set; }
        public List<TbAccessPlanGroup> TbAccessPlanGroups { get; set; }
    }
}