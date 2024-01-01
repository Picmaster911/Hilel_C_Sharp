using Microsoft.EntityFrameworkCore;

namespace HomeWork_22_HTTP_Client.Models
{
    public class DataWorker
    {
        private ILoger _loger;
        public DataWorker (ILoger loger)
        {
            _loger = loger;
        }
        public void AddToDb(IEnumerable <Currency> currencys)
        {
            using (var myDB = new AppDbContext())
            {
                foreach (var currency in currencys)
                {
                    myDB.Currencys.Add(new CurrencyAndTime
                    {
                        Ccy = currency.Ccy,
                        Base_ccy = currency.Base_ccy,
                        Buy = currency.Buy,
                        Sale = currency.Sale,
                        Date = DateTime.Now
                    });
                    _loger.WriteLogData($"{DateTime.Now.ToString()} Add to DB{currency.Ccy} ");
                }
                myDB.SaveChanges();
            }
        }

        public async Task <IEnumerable<CurrencyAndTime>> ReadFromDb()
        {
    
            using (var myDB = new AppDbContext())
            {
                var data = await myDB.Currencys
                    .AsQueryable()
                    .Where(item => item.Date > DateTime.Now.AddDays(-1))
                    .OrderBy(item => item.Date)
                    .ToListAsync();
                return data.TakeLast(6); ;
            }

        }
    }
}
