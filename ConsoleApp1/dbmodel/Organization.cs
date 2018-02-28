using System;
using System.Collections.Generic;

namespace ConsoleApp1.dbmodel
{
    public partial class Organization
    {
        public Organization()
        {
            Foreigner = new HashSet<Foreigner>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Foreigner> Foreigner { get; set; }
    }
}
