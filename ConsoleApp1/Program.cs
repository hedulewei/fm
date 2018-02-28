using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public class sam
        {
            public int MyProperty { get; set; }
            public string sMyProperty { get; set; }
            public List<int> ilist { get; set; }
            public List<string> slist { get; set; }
        }
        static void Main(string[] args)
        {
            var a = new sam
            {
                MyProperty = 10,
                sMyProperty = "haha",
                ilist=new List<int> { 2,33434,3234},
                slist=new List<string> { "ajfaf","ajdfj"}
            };
            var ss = Newtonsoft.Json.JsonConvert.SerializeObject(a);
            Console.WriteLine("Hello World!");
            Console.WriteLine(ss);
        }
    }
}
