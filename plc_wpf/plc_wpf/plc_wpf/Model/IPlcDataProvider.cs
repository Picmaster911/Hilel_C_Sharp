using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plc_wpf.Model
{
   public interface IPlcDataProvider
    {
        Task<IEnumerable<PLC_Conection>?> GetConectionsAsync();
        //Task<IEnumerable<string>> PutConectionsAsync();
        //Task<IEnumerable<string>> DeletConectionsAsync();
        //Task<string> PostConectionsAsync();
    }
}
