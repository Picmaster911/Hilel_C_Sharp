using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_05
{
    internal class Animal
    {
        private string _name;
        private int _age;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Age
        {
            get => _age;
            set => _age = value;
        }
        public Animal(string name, int age)
        {
         _age = age;
         _name = name;
        }
        public Animal() 
        {
            _name = string.Empty;
        }
         public virtual void Move()
        {
            Console.WriteLine("It is mooving");
        }
        public virtual void Speek()
        {
            Console.WriteLine("Animal speeking");
        }
    }
}
