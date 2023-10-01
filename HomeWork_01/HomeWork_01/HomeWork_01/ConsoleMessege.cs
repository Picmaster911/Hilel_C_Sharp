using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_01
{
    public class ConsoleMessege : IMessege
    {
        public void SendMessege(string messege)
        {
            Console.WriteLine(messege);
        }
    }
}
