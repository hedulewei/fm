using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Police
    {
        public Police()
        {
            Policelog = new HashSet<Policelog>();
            Task = new HashSet<Task>();
            Tasklog = new HashSet<Tasklog>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public short? Level { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public sbyte? Online { get; set; }
        public string Accesstoken { get; set; }
        public string County { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public short? Permission { get; set; }

        public ICollection<Policelog> Policelog { get; set; }
        public ICollection<Task> Task { get; set; }
        public ICollection<Tasklog> Tasklog { get; set; }
    }
}
