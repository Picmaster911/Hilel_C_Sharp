using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_08
{
    public class Main
    {
        public static double CalculatePensionForUSA(int exp, int age)
        {
            if (exp <= 5)
            {
                Console.WriteLine($"Pension USA = {(1000 / (65 - age) * (double)exp * 0.2) * 2.2}");
                return (1000 / (65 - age) * (double)exp * 0.2) * 2.2;             
            }

               
            else if (exp > 5 && exp <= 10)
            {
                Console.WriteLine($"Pension USA = {(1000 / (65 - age) * (double)exp * 0.6) * 2.2}");
                return (1000 / (65 - age) * (double)exp * 0.6) * 2.2;
            }
            else
            {
                Console.WriteLine($"Pension USA = {(1000 / (65 - age) * (double)exp * 1) * 2.2}");
                return (1000 / (65 - age) * (double)exp * 1) * 2.2;
            }
        }
        public static double CalculatePensionForUK(int exp, int age)
        {
            if (exp <= 5)
            {
                Console.WriteLine($"Pension UK = {(1000 / (65 - age) * (double)exp * 0.2) * 5.2}");
                return (2000 / (65 - age) * (double)exp * 0.2) * 5.2;
            }


            else if (exp > 5 && exp <= 10)
            {
                Console.WriteLine($"Pension UK = {(1000 / (65 - age) * (double)exp * 0.6) * 5.2}");
                return (2000 / (65 - age) * (double)exp * 0.6) * 5.2;
            }
            else
            {
                Console.WriteLine($"Pension UK = {(1000 / (65 - age) * (double)exp * 1) * 5.2}");
                return (2000 / (65 - age) * (double)exp * 1) * 5.2;
            }
        }
        public static double CalculatePensionForAUS(int exp, int age)
        {
            if (exp <= 5)
            {
                Console.WriteLine($"Pension AUS = {(1000 / (65 - age) * (double)exp * 0.2) * 3.2}");
                return (3000 / (65 - age) * (double)exp * 0.2) * 3.2;
            }


            else if (exp > 5 && exp <= 10)
            {
                Console.WriteLine($"Pension AUS = {(1000 / (65 - age) * (double)exp * 0.6) * 3.2}");
                return (3000 / (65 - age) * (double)exp * 0.6) * 3.2;
            }
            else
            {
                Console.WriteLine($"Pension AUS = {(1000 / (65 - age) * (double)exp * 1) * 3.2}");
                return (3000 / (65 - age) * (double)exp * 1) * 3.2;
            }
        }
    }
}
