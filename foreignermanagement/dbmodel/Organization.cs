using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Organization
    {
        public Organization()
        {
            Foreigner = new HashSet<Foreigner>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Foreigner> Foreigner { get; set; }
    }
}
