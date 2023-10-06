using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_01
{
    internal class AboutParking
    {
        private string _nameParking;
        private string _adressParking;
        /// <summary>
        /// Info about parking
        /// </summary>
        /// <param name="nameParking"></param>
        /// <param name="adressParking"></param>
        public AboutParking(string nameParking, string adressParking)
        {
            _nameParking = nameParking;
            _adressParking = adressParking;
        }
    }
    
}
