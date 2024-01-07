using plc_wpf.Infrastructure.Commands;
using plc_wpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace plc_wpf.ViewModel
{
    class PlcConectionVM : ViewModelBase
    {
        private PLC_Conection _selectedItem;
        public PLC_Conection SelectedItem
        {
            get => _selectedItem;           
            set
            {
                _selectedItem = value;
                UpdateConectionInput(_selectedItem);
            }
        }
      
        private string _namePLC;
        public string NamePLC
        {
            get => _namePLC;
    
            set
            {
                _namePLC = value;
                OnPropertyChanged();
            }
        }
        private string _ipAddress;
        public string IpAdress
        {
            get
            {
                return _ipAddress;
            }

            set
            {
                _ipAddress = value;
                OnPropertyChanged();
            }
        }

        private string _typePlc;
        public string TypePlc
        {
            get
            {
                return _typePlc;
            }

            set
            {
                _typePlc = value;
                OnPropertyChanged();
            }
        }
        private int _slot;
        public int Slot
        {
            get
            {
                return _slot;
            }

            set
            {
                _slot = value;
                OnPropertyChanged();
            }
        }
        private int _rack;
        public int Rack
        {
            get
            {
                return _rack;
            }

            set
            {
                _rack = value;
                OnPropertyChanged();
            }
        }
        private void UpdateConectionInput(PLC_Conection selectedItem)
        {
            if (selectedItem != null)
            {
                NamePLC = selectedItem.PlcName;
                IpAdress = selectedItem.IpAddress;
                TypePlc = selectedItem.PlcType;
                Slot = selectedItem.Slot;
                Rack = selectedItem.Rack;
            }
            else
            {

                NamePLC = "";
                IpAdress = "";
                TypePlc = "";
                Slot = 0;
                Rack = 0;
            }
          
        }
        //public string TypePLC { get; set; }
        //public int Slot { get; set; }
        //public string Rack { get; set; }
        //public bool AutoConect { get; set; }
        public PlcConectionVM()
        {
            #region Commands
            AddConection = new LambdaCommand(
                OnAddConection,
                CanAddConection
                );
            EditConection = new LambdaCommand(
              OnEditConection,
              CanEditConection
              );
            DeleteConection = new LambdaCommand(
              OnDeleteConection,
              CanDeleteConection
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
        #region AddConection
        public ICommand AddConection { get; }

        private void OnAddConection(object p)
        {
            var t = p;
        }
        private bool CanAddConection(object p) => true;
        #endregion
        #region EditConection
        public ICommand EditConection { get; }

        private void OnEditConection(object p)
        {

        }
        private bool CanEditConection(object p) => true;
        #endregion
        #region DeleteConection
        public ICommand DeleteConection { get; }

        private void OnDeleteConection(object p)
        {
            AllConections.Remove(SelectedItem);

        }
        private bool CanDeleteConection(object p) => (SelectedItem != null);
        #endregion
        #endregion
    }
}
