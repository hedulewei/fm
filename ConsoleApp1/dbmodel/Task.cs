using System;
using System.Collections.Generic;

namespace ConsoleApp1.dbmodel
{
    public partial class Task
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Foreigner { get; set; }
        public int? Police { get; set; }

        public Foreigner ForeignerNavigation { get; set; }
        public Police PoliceNavigation { get; set; }
    }
}
