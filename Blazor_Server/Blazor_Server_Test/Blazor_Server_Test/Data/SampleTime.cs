using System.Data;

namespace Blazor_Server_Test.Data
{
    public class SampleTime : ISampleTime
    {
        public string CurrentTime { get; set; } = DateTime.Now.ToString();
    }
}
