using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Counties
    {
        public Counties()
        {
            Taskcounty = new HashSet<Taskcounty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }

        public ICollection<Taskcounty> Taskcounty { get; set; }
    }
}
