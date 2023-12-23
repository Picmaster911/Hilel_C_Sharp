using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace HomeWork_20_CRUD_HTTP
{
    internal class Delegatecs
    {
        public event Action <string> MyName;

       public void Go ([CallerMemberName] string propertyName = null)
        {
            MyName?.Invoke(propertyName);
        }
    }
        
}
