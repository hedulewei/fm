using System;
using System.Collections.Generic;

namespace foreignermanagement.dbmodel
{
    public partial class Messages
    {
        public int Id { get; set; }
        public DateTime? Time { get; set; }
        public int? Assigner { get; set; }
        public string Assignees { get; set; }
        public string Description { get; set; }
    }
}
