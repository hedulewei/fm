using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Taskcounty
    {
        public int Id { get; set; }
        public int? Batchid { get; set; }
        public int? County { get; set; }
        public int? Amount { get; set; }
        public int? Finished { get; set; }

        public Tasksbatch Batch { get; set; }
        public Counties CountyNavigation { get; set; }
    }
}
