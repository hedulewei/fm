using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Foreigner
    {
        public Foreigner()
        {
            Inspectlog = new HashSet<Inspectlog>();
            ResidenceNavigation = new HashSet<Residence>();
            Task = new HashSet<Task>();
            Tasklog = new HashSet<Tasklog>();
            Trail = new HashSet<Trail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Organization { get; set; }
        public string Hisorg { get; set; }
        public string Address { get; set; }
        public string County { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string Passport { get; set; }
        public short? Gender { get; set; }
        public string Birthday { get; set; }
        public string Nation { get; set; }
        public short? Passportstatus { get; set; }
        public string Arrivalreason { get; set; }
        public DateTime? Arrivaltime { get; set; }
        public string Departurereason { get; set; }
        public byte[] Departuretime { get; set; }
        public string Residence { get; set; }

        public Organization OrganizationNavigation { get; set; }
        public ICollection<Inspectlog> Inspectlog { get; set; }
        public ICollection<Residence> ResidenceNavigation { get; set; }
        public ICollection<Task> Task { get; set; }
        public ICollection<Tasklog> Tasklog { get; set; }
        public ICollection<Trail> Trail { get; set; }
    }
}
