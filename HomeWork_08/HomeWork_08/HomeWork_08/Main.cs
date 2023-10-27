using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_08
{
    public class Main
    {
        public static double MatchMany(int allS, int age, double exp, double kCunt, string country)
        {
            if (exp <= 5)
            {
                Console.WriteLine($"Pension {country} = {(allS / (65 - age) * (double)exp * 0.2) * kCunt}");
                return (1000 / (65 - age) * (double)exp * 0.2) * 2.2;
            }


            else if (exp > 5 && exp <= 10)
            {
                Console.WriteLine($"Pension {country} = {(allS / (65 - age) * (double)exp * 0.6) * kCunt}");
                return (1000 / (65 - age) * (double)exp * 0.6) * 2.2;
            }
            else
            {
                Console.WriteLine($"Pension {country} = {(allS / (65 - age) * (double)exp * 1) * kCunt}");
                return (1000 / (65 - age) * (double)exp * 1) * 2.2;
            }
        }
        public static double CalculatePensionForUSA(int exp, int age)
        {
            return MatchMany(1000, age, exp, 2.2, "USA");
        }
        public static double CalculatePensionForUK(int exp, int age)
        {
            return MatchMany(2000, age, exp, 5.2, "UK");
        }
        public static double CalculatePensionForAUS(int exp, int age)
        {
            return MatchMany(3000, age, exp, 3.2, "AUS");

        }
    }
}
