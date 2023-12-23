using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace plc_wpf.Model
{
    public class DataWorker : IPlcDataProvider
    {
        public static List<PLC_Conection> AllConections()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Plc_Conections.ToList();
            }
        }

        /// <summary>
        /// Create PLC in Db
        /// </summary>
        /// <param name="name">Name eqipment PLC </param>
        /// <param name="ip"></param>
        /// <param name="type"></param>
        /// <param name="slot"></param>
        /// <param name="rack"></param>
        /// <returns></returns>

        public static string CreatePlc(string name, string ip, string type, int slot, int rack)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var includeConnection = db.Plc_Conections.Where(plc => plc.IpAddress == ip).Any();
                if (!includeConnection)
                {
                    db.Add(new PLC_Conection()
                    {
                        PlcName = name,
                        PlcType = type,
                        Slot = slot,
                        Rack = rack,
                        IpAddress = ip,
                    });
                    db.SaveChanges();
                    return "PLC Create in BD";
                }
                return "PLC include in DB";
            }
        }
        //редактировать ПЛС
        public static string EditPlc(string name, string ip, string type, int slot, int rack)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var plcForEdit = db.Plc_Conections.Where(plc => plc.IpAddress == ip).FirstOrDefault();
                if (plcForEdit != null)
                {
                    plcForEdit.PlcName = name;
                    plcForEdit.PlcType = type;
                    plcForEdit.Slot = slot;
                    plcForEdit.Rack = rack;
                    db.SaveChanges();
                    return "Plc change model";
                }
                return "Plc not found in DB";
            }
        }
        //удалить ПЛС
        public static string DeletePlc(string ip)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var plcForDelete = db.Plc_Conections.Where(plc => plc.IpAddress == ip).FirstOrDefault();
                if (plcForDelete != null)
                {
                    db.Remove(plcForDelete);
                    db.SaveChanges();
                    return "Plc delete in BD";
                }
                return "PLCnot found in DB";
            }
        }
        public async Task<IEnumerable<PLC_Conection>?> GetConectionsAsync()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Plc_Conections;
                return result;
            }
        }
    }
}
