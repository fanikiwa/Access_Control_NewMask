namespace KruAll.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VirtualTerminalFunctionKey
    {
        public int ID { get; set; }

        public long TerminalID { get; set; }

        public int FunctionKey1 { get; set; }

        public int FunctionKey2 { get; set; }

        public int FunctionKey3 { get; set; }

        public int FunctionKey4 { get; set; }

        public int FunctionKey5 { get; set; }

        public int FunctionKey6 { get; set; }

        public int FunctionKey7 { get; set; }

        public int FunctionKey8 { get; set; }

        public int FunctionType1 { get; set; }

        public int FunctionType2 { get; set; }

        public int FunctionType3 { get; set; }

        public int FunctionType4 { get; set; }

        public int FunctionType5 { get; set; }

        public int FunctionType6 { get; set; }

        public int FunctionType7 { get; set; }

        public int FunctionType8 { get; set; }
    }
}
