using plc_modules;
using plc_wpf.Model;
using plc_wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plc_wpf.Infrastructure
{
  public class FabricCreatorPlc

    {
        private List<PlcObj> _plcObjList = new List<PlcObj>();
        private List<PlcVM> _plcObjListVM = new List<PlcVM>();
        //     private DataWorker _dataWorker;
        public List<PlcObj> PlcObjList { get { return _plcObjList; } }
        public List<PlcVM> PlcObjListVM { get { return _plcObjListVM; } }

        public void CreatePlcList()
        {
           var allPlc = DataWorker.AllConections().ToList();
            if (allPlc != null)
            {
                allPlc.ForEach(PlcObj => 
                {
                    var plc = new PlcObj(PlcObj.IpAddress);
                    var plcVM = new PlcVM(plc);
                    _plcObjList.Add(plc);
                    _plcObjListVM.Add(plcVM);
                }) ;
            }

        }
    }
}
