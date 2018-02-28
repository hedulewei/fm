using System;
using System.Collections.Generic;

namespace ConsoleApp1.dbmodel
{
    public partial class Police
    {
        public Police()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public short? Level { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public sbyte? Online { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
