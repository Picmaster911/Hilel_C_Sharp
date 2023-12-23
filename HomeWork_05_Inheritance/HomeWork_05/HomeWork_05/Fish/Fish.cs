using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05.Fish
{
    internal class Fish : Animal
    {
        public Fish(string name, int age) : base(name, age) { }
        public override void Speek()
        {
            Console.WriteLine($"{Name} speaking Byl Byl");
        }
        public sealed override void Move()
        {
            Console.WriteLine($"{Name} is swiming");
        }
    }
}
