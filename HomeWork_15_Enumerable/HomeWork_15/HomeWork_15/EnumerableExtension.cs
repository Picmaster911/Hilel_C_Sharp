using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_15
{
    public static class EnumerableExtension
    {
        public static Person PenultimateItem(this IEnumerable<Person> source)
        {
            
            if (source is null || !source.Any())
            {
                throw new InvalidOperationException("Cannot compute median for a null or empty set.");
            }
            var personLenght = source.Count();
            int count = 0;
            var penultimate = source.Where( x =>
                {
                    count++;
                    if (count == personLenght - 1)
                    return true;
                    else return false;
            }).FirstOrDefault();
            return penultimate;
        }
    }
}
