using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05.Mammal
{
    internal class Dog : Mammal
    {
        public Dog(string name, int age) : base(name, age) { }

        public override void Speek()
        {
            Console.WriteLine($"{Name} speaking Gav Gav");
        }
    }
}
