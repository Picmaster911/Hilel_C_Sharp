using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_15
{
    public struct ListPerson
    {
        public static List<Person> Persons = new List<Person>()
            {
              new Person(1,"Vova",21),
              new Person(2,"Anna",18),
              new Person(3,"Tetiana",12),
              new Person(3,"Boris",45),
              new Person(5,"Vlada",31),
              new Person(6,"Serg",11),
              new Person(7,"Anatoliy",27),
              new Person(8,"Din",39),
              new Person(8,"Bob",29),
              new Person(8,"Jack",33),
              new Person(2,"Angela",58),
             };
        public ListPerson() { }
    };
}
