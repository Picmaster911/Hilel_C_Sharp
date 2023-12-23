using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork_11
{
    internal class FactorialProcessor
    {
        private int _param;
        static void MathFactorial(int myNumber)
        {
            DateTime time = DateTime.Now;
            Thread currentThread = Thread.CurrentThread;
            long _result = 1;

            for (int i = 1; i <= myNumber; i++)
            {
                _result = i * _result;
            }
            Console.WriteLine($"Factorial {myNumber} is result = {_result} Thead {currentThread.ManagedThreadId} --- {time.Millisecond}mSec");
        }
        public void startThread(int i)
        {
            var thead = new Thread(() => MathFactorial(i));
            thead.Start();
            thead.Join();
        }

        public void Go(int param, bool parallelMode)

        {
            _param = param <= 15 ? param : throw new ArgumentException(" Int must be in diaposon 0 - 15");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (parallelMode)
            {
                for (int i = 1; i <= param; i++)
                {
                    startThread(i);
                }
            }
            else
            {
                for (int i = 1; i <= param; i++)
                {
                    MathFactorial(i);
                }
            }
            stopWatch.Stop();
            TimeSpan cicleTime = stopWatch.Elapsed;
            Console.WriteLine($"Cicle time = {cicleTime.Ticks}");
            Console.WriteLine($"Cicle time = {cicleTime.Milliseconds}");
        }
    }
}
