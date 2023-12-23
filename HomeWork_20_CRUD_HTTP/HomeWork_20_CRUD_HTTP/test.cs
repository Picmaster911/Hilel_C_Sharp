using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_20_CRUD_HTTP
{
    internal class test
    {
      public void Test([CallerMemberName] string fcsd = null)
        {
            Console.WriteLine(fcsd);
        }
    }
}
