namespace HomeWork_22_HTTP_Client.Models
{
    internal class DataWorker
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
                        Date = DateTime.Now.ToString()
                    });
                    _loger.WriteLogData($"{DateTime.Now.ToString()} Add to DB{currency.Ccy} ");
                }
                myDB.SaveChanges();
            }
        }
    }
}
