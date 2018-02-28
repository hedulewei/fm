using System;
using System.Collections.Generic;

namespace ConsoleApp1.dbmodel
{
    public partial class Inspectlog
    {
        public int Id { get; set; }
        public DateTime? Time { get; set; }
        public int? Foreigner { get; set; }

        public Foreigner ForeignerNavigation { get; set; }
    }
}
