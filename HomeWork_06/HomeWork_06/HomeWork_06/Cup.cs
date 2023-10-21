using HomeWork_06.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_06
{
    public class Cup : CupBase, IContainingCoffee, IContainingMilk, IContainingWater, IContainingSugar
    {
        public void AddCoffee()
        {
            Console.WriteLine("Add Coffee");
        }

        public void AddMilk()
        {
            Console.WriteLine("Add Milk");
        }

        public void AddSugar()
        {
            Console.WriteLine("Add Sugar");
        }

        public void AddWater()
        {
            Console.WriteLine("Add Water");
        }
    }
}
