using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.Dtos
{
    public class PersonalCardPrint_DTO
    {
        public long PersNr { get; set; }
        public string Client { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExpireDate { get; set; }
        public string PersType { get; set; }
        public string PicturePath { get; set; }
    }
}