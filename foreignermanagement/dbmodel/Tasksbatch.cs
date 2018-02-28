using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Tasksbatch
    {
        public Tasksbatch()
        {
            Taskcounty = new HashSet<Taskcounty>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Amount { get; set; }
        public int? Finished { get; set; }

        public ICollection<Taskcounty> Taskcounty { get; set; }
    }
}
