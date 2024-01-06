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
        public MainWindowVM(PlcComponentVM plcComponentViewModel)
        {
            PlcComponentViewModel = plcComponentViewModel;
            #region Commands
            OpenAddNewConectionWindowCommand = new LambdaCommand(
                OnOpenAddNewConectWinCommandExecuted,
                CanOnOpenAddNewConectWinCommandExecuted
                );
            #endregion

        }

        private static List<PLC_Conection> conections = DataWorker.AllConections();

        private ObservableCollection<PLC_Conection> _allConections = new ObservableCollection<PLC_Conection>(conections);
        public ObservableCollection<PLC_Conection> AllConections { get; } = new(conections);

        private string _title = "All Plc conection";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #region Commands
        #region OpenAddNewConectionWindowCommand
        public ICommand OpenAddNewConectionWindowCommand { get; }

        private void OnOpenAddNewConectWinCommandExecuted(object p)
        {

        }
        private bool CanOnOpenAddNewConectWinCommandExecuted(object p) => true;
        #endregion
        #endregion
    }
}
