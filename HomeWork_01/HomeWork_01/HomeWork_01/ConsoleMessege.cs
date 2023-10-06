using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_01
{
    public class ConsoleMessege : IMessege
    {
        /// <summary>
        /// Send messege to console
        /// </summary>
        /// <param name="messege"></param>
        public void SendMessege(string messege)
        {
            Console.WriteLine(messege);
        }
    }
}
