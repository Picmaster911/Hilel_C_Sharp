using plc_wpf.Infrastructure.Commands;
using plc_wpf.Model;
using plc_wpf.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace plc_wpf.ViewModel
{
    class AddNewPLCconectionsWindowVM
    { public AddNewPLCconectionsWindowVM()
        {
            #region Commands
            AddNewConectionWindowCommand = new LambdaCommand(
                OnAddNewConectWinCommandExecuted,
                CanAddNewConectWinCommandExecuted
                );
            #endregion
        }
        public int Id { get; set; }
        public string PlcName { get; set; }
        public string IpAddress { get; set; }
        public string PlcTypeSelected { get; set; }
        public List<string> PlcType
        { get => new List<string> {
            "S7-1200",
            "S7-300"
        };}
        public int Slot { get; set; }
        public int Rack { get; set; }

        #region Commands
        #region AddNewConectionWindowCommand
        public ICommand AddNewConectionWindowCommand { get; }

        private void OnAddNewConectWinCommandExecuted(object p)
        {
            DataWorker.CreatePlc(PlcName, IpAddress, PlcTypeSelected, Slot, Rack);
           
        }
        private bool CanAddNewConectWinCommandExecuted(object p)
        {
            if (PlcName != null && IpAddress != null )
                return true;
            else return false;
        }
        #endregion
        #endregion
    }
}
