using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Task
    {
        public int Id { get; set; }
        public DateTime? Assigndate { get; set; }
        public int? Foreigner { get; set; }
        public int? Police { get; set; }
        public string Finishdate { get; set; }
        public string Content { get; set; }
        public string Pictures { get; set; }
        public string Videos { get; set; }

        public Foreigner ForeignerNavigation { get; set; }
        public Police PoliceNavigation { get; set; }
    }
}
