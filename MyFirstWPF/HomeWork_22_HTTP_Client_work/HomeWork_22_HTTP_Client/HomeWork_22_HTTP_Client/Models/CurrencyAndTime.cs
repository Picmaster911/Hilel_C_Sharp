using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace HomeWork_22_HTTP_Client.Models
{
    public class CurrencyAndTime
    {
        public int Id { get; set; }
        public string Ccy { get; set; }
        public string Base_ccy { get; set; }
        public string Buy { get; set; }
        public string Sale { get; set; }
        public DateTime Date { get; set; }
    }
}
