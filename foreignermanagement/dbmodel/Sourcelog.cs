using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Sourcelog
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public DateTime? Begintime { get; set; }
        public DateTime? Endtime { get; set; }
        public sbyte? Success { get; set; }
    }
}
