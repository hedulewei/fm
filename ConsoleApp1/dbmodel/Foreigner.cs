using System;
using System.Collections.Generic;

namespace ConsoleApp1.dbmodel
{
    public partial class Foreigner
    {
        public Foreigner()
        {
            Inspectlog = new HashSet<Inspectlog>();
            Residence = new HashSet<Residence>();
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Organization { get; set; }
        public JsonObject<> Hisorg { get; set; }

        public Organization OrganizationNavigation { get; set; }
        public ICollection<Inspectlog> Inspectlog { get; set; }
        public ICollection<Residence> Residence { get; set; }
        public ICollection<Task> Task { get; set; }
    }
}
