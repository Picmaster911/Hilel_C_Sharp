﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_22_HTTP_Client
{
    internal class LogerToConsole : ILoger
    {
        public void WriteLogData(string data)
        {
            Console.WriteLine(data);
        }
    }
}
