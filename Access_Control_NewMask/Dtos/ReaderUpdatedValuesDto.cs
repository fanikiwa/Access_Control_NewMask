using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class ReaderUpdatedValuesDto
    {
        public long ReaderId { get; set; }
        public bool IsChecked { get; set; }
    }
}