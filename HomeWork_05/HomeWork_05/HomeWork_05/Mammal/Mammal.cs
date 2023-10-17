using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05.Mammal
{
    internal class Mammal : Animal
    {
        public Mammal(string name, int age) : base(name, age) { }
        public sealed override void Move()
        {
            Console.WriteLine($"{Name} is runing");
        }
    }
}
