using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05.Bird
{
    internal class Bird : Animal
    {
        public Bird(string name, int age) : base(name, age) { }
        public sealed override void Move()
        {
            Console.WriteLine($"{Name} is flies");
        }
    }
}
