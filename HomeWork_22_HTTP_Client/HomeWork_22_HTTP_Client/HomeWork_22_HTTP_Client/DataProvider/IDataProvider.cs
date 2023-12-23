using HomeWork_22_HTTP_Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_22_HTTP_Client.DataProvider
{
    internal interface IDataProvider
    {
        Task<IEnumerable<Currency>> GetData();
    }
}
