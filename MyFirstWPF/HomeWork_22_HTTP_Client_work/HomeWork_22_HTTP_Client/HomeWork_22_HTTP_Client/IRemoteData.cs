
using HomeWork_22_HTTP_Client.Models;

namespace HomeWork_22_HTTP_Client
{
    public interface IRemoteData
    {
        public Task GetData (CancellationToken cancellationToken);
        bool Enable {get; set;}
        bool RequestLight { get; }

        public event Action<List<Currency>> EventRequestLight;
    }
}
