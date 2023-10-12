using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_01
{
    internal class test
    {
        public int I
        { get => _i; set => _i = value; }
        private int _i;
            public test (int i)
        {
            _i = i;
        }
    }
}
