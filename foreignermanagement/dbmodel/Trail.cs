using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Trail
    {
        public int Id { get; set; }
        public DateTime? Eventtime { get; set; }
        public string Location { get; set; }
        public int? Foreigner { get; set; }
        public string Description { get; set; }
        public string Associates { get; set; }

        public Foreigner ForeignerNavigation { get; set; }
    }
}
