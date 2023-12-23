
using HomeWork_22_HTTP_Client.Models;

namespace HomeWork_22_HTTP_Client
{
    internal interface IRemoteData
    {
        public Task<IEnumerable<Currency>> GetData();
    }
}
