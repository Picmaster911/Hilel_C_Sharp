using plc_modules;
using plc_wpf.Infrastructure.Commands;
using plc_wpf.Model;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows.Input;

namespace plc_wpf.ViewModel
{
    class PlcConectionVM : ViewModelBase
    {
        private PLC_Conection _selectedItem;
        private IPAddress ip;
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

        private CpuType _typePlc;
        public CpuType TypePlc
        {
            get => _typePlc;

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

                Slot = 0;
                Rack = 0;
            }
          
        }
        private PlcComponentVM _plcComponentVM;
        public PlcConectionVM(PlcComponentVM plcComponentVM)
        {
            _plcComponentVM = plcComponentVM;
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
            try
            {
               DataWorker.CreatePlc(_namePLC, _ipAddress, _typePlc, _slot, _rack);
                var sameConection = PlcComponentVM.AllPlcColection.Where(x => x.IpAdress == _ipAddress).Any();
                if (!sameConection)
                {
                    PlcComponentVM.AllPlcColection.Add(new PlcVM(new PlcObj(_namePLC, _typePlc, _ipAddress, _rack, _slot, 2000)));
                    AllConections.Add(new PLC_Conection
                    {
                        PlcName = _namePLC,
                        IpAddress = _ipAddress,
                        PlcType = _typePlc,
                        Slot = _slot,
                        Rack = _rack,
                    });
                }         
            }
           catch (Exception ex)
            {

            }
        }
        private bool CanAddConection(object p) => ValidationConection();
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
            var itemForDelete = PlcComponentVM.AllPlcColection
                .Where(x => x.Plc.IpAdress == _selectedItem.IpAddress)
                .FirstOrDefault();
            if (itemForDelete != null) 
            {
                PlcComponentVM.AllPlcColection.Remove(itemForDelete);
                DataWorker.DeletePlc(itemForDelete.IpAdress);
            }
           
            AllConections.Remove(SelectedItem);

        }
        private bool CanDeleteConection(object p) => (SelectedItem != null);
        #endregion
        #endregion

        private bool ValidationConection()
        {
           
            bool ValidateIP = IPAddress.TryParse(_ipAddress, out ip);
            return ValidateIP;
        }
     //     private void NumberValidationTextBox()
     //      {
     //        Regex regex = new Regex("[^0-9]+");
     //       e.Handled = regex.IsMatch();
     //   }
    }
}
