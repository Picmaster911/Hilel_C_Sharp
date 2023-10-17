using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05.Bird
{
    internal class Eagle : Bird
    {
        public Eagle(string name, int age) : base(name, age) { }
        public override void Speek()
        {
            Console.WriteLine($"{Name} speaking I am Eagle ");
        }
    }
}
