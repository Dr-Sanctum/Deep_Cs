using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_1
{

    internal class Person
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public Person moteher { get; set; }
        public Person father { get; set; }
        public LinkedList<Person> children { get; set; } = new LinkedList<Person>() ;

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
