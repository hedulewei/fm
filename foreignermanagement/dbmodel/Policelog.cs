using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Policelog
    {
        public int Id { get; set; }
        public int? Police { get; set; }
        public DateTime? Intime { get; set; }
        public string Inlocation { get; set; }
        public DateTime? Outtime { get; set; }
        public string Outlocation { get; set; }

        public Police PoliceNavigation { get; set; }
    }
}
