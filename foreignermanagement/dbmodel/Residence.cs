using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Residence
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int? Foreigner { get; set; }

        public Foreigner ForeignerNavigation { get; set; }
    }
}
