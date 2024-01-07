using plc_wpf.Infrastructure.Commands;
using plc_wpf.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Windows.Input;

namespace plc_wpf.ViewModel
{
    class MainWindowVM : ViewModelBase
    {
        public PlcComponentVM PlcComponentViewModel { get; }
        public PlcConectionVM PlcConectionViewModel { get; }
        public MainWindowVM(PlcComponentVM plcComponentViewModel, PlcConectionVM plcConectionViewModel)
        {
            PlcComponentViewModel = plcComponentViewModel;
            PlcConectionViewModel = plcConectionViewModel;          
        }       
    }
}
