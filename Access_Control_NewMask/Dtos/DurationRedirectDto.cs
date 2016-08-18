using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class DurationRedirectDto
    {
        public long Id { get; set; }
        public long objectId { get; set; }
        public bool isNew { get; set; }
        public string pageFrom { get; set; }
    }
}