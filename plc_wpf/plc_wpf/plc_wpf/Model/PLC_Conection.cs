using S7.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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
        public CpuType PlcType { get; set; }
        public int Slot { get; set; }
        public int Rack { get; set; }
        public List <TagsForPlc> PlcTags { get; set;}
    }
}
