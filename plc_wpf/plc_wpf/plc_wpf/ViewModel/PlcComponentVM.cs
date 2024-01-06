using plc_modules;
using plc_wpf.Infrastructure;
using plc_wpf.Infrastructure.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace plc_wpf.ViewModel
{
    class PlcComponentVM: ViewModelBase
    {
        private PlcObj plcObj;
        private FabricCreatorPlc _fabricCreatorPlc;
        public List<PlcObj> Test { get => _fabricCreatorPlc.PlcObjList; }
        public static ObservableCollection<PlcVM> AllPlcColection { get; set; } 
        public PlcObj SelectedPlc { get => plcObj; set => plcObj = value; }      
        public PlcComponentVM(FabricCreatorPlc fabricCreatorPlc)
        {
            _fabricCreatorPlc = fabricCreatorPlc;
            var AllPlc = _fabricCreatorPlc.PlcObjListVM;
            CreateObserColection(AllPlc);
            #region Commands
            OnConection = new LambdaCommand(
                OnOnConection,
                CanOnConection
                );
            #endregion
        }

        #region Commands
        #region OpenAddNewConectionWindowCommand
        public ICommand OnConection { get; }

        private void OnOnConection(object p)
        {
            var t = (PlcVM)p;
            t.IpAdress = "127.127.127.0";
            t.Enable = true;
            AllPlcColection.Add(new PlcVM(new PlcObj("test")));             
        }
        private bool CanOnConection(object p) => true;
        #endregion
        #endregion
        private void CreateObserColection (List<PlcVM> plclist)
        {
            AllPlcColection = new ObservableCollection<PlcVM>();
            plclist.ForEach(x => AllPlcColection.Add(x));
        }
    }
}
