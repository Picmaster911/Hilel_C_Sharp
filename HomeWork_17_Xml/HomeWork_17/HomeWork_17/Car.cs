using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_17
{
    public class Car
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Number { get; set; }
        public Car(string name, string number, int price)
        {
            Name = name;
            Price = price;
            Number = number;
        }
    }
}
