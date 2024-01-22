using S7.Net;
using System.ComponentModel.DataAnnotations.Schema;

namespace plc_wpf.Model
{
    public class TagsForPlc
    {
        public int Id { get; set; }
        /// <summary>
        /// Memory area to read 
        /// </summary>
        public DataType DataType { get; set; }

        /// <summary>
        /// Type of data to be read (default is bytes)
        /// </summary>
        public VarType VarType { get; set; }

        /// <summary>
        /// Address of memory area to read (example: for DB1 this value is 1, for T45 this value is 45)
        /// </summary>
        public int DB { get; set; }

        /// <summary>
        /// Address of the first byte to read
        /// </summary>
        public int StartByteAdr { get; set; }

        /// <summary>
        /// Addess of bit to read from StartByteAdr
        /// </summary>
        public byte BitAdr { get; set; }

        /// <summary>
        /// Number of variables to read
        /// </summary>
        public int Count { get; set; }

        public int PLC_ConectionId { get; set; }  
        
        public PLC_Conection Plc;
    }
}
