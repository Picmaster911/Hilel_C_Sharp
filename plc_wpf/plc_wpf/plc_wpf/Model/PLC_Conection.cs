using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plc_wpf.Model
{
    public class PLC_Conection
    {
        public int Id { get; set; }
        public string PlcName { get; set; }
        public string IpAddress { get; set; }
        public string PlcType { get; set; }
        public int Slot { get; set; }
        public int Rack { get; set; }
     
    }
}
