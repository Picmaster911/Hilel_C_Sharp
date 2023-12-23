using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_07
{
    public class CurRateDysplay<CurR> where CurR : struct
    {
        private CurR CurencyRate;
        private List<CurR> CurencyRateList = new List<CurR>();

        public void ChangeRate(CurR CurencyRate)
        {
            Console.WriteLine($"New Curency rate {CurencyRate}");
            CurencyRateList.Add(CurencyRate);
        }

        public void PrintHistory()
        {
            foreach (var CurencyRate in CurencyRateList)
            {
                Console.WriteLine($"Curency rate history {CurencyRate}");
            }
        }
    }
}
