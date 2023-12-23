using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_08
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }


        public Person(string name, int age, int experience)
        {
            Name = name;
            Age = age;
            Experience = experience;
        }

        public void GetRetiremetnValue(Calculator calc)
        {
            calc.Invoke(Age, Experience);
        }

    }
}
