using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_12
{
    internal class FactorialProcessor
    {
        private int _param;
        private int _countOperation;
        private void StartMath(int myNumber)
        {
            long _result = 1;
            for (int i = 1; i <= myNumber; i++)
            {
                _result = i * _result;
            }           
            Console.WriteLine($"Factorial {myNumber} is result = {_result}");
            _countOperation += 1;
        }
        public async Task AsyncMathFactorial(int myNumber, int param)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            await Task.Run(() => StartMath(myNumber));
            Console.WriteLine($"---------------------------------FinishTask");
            if (_countOperation >= param)
            {
                _countOperation = 0;
                TimeSpan cicleTime = stopWatch.Elapsed;
                stopWatch.Stop();
                Console.WriteLine($"Cicle time Ticks = {cicleTime.Ticks}");
                Console.WriteLine($"Cicle time Milliseconds = {cicleTime.Milliseconds}");
            }
        }

        public void MathFactorial(int myNumber)
        {
            StartMath(myNumber);
        }
        public async Task Go(int param, bool parallelMode)
        {
            _param = param <= 15 ? param : throw new ArgumentException(" Int must be in diaposon 0 - 15");
            if (parallelMode)
            {
                for (int i = 1; i <= param; i++)
                {
                     AsyncMathFactorial(i, param);
                }
            }
            else
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                for (int i = 1; i <= param; i++)
                {
                    MathFactorial(i);
                    _countOperation = 0;
                }
                TimeSpan cicleTime = stopWatch.Elapsed;
                stopWatch.Stop();
                Console.WriteLine($"Cicle time Ticks = {cicleTime.Ticks}");
                Console.WriteLine($"Cicle time Milliseconds = {cicleTime.Milliseconds}");
            }
        }
    }
}
