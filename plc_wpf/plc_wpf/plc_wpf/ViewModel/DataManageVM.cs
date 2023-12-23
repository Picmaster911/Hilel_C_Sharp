using plc_wpf.Model;
using plc_wpf.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace plc_wpf.ViewModel
{
    internal class DataManageVM : INotifyPropertyChanged
    {
        private List<PLC_Conection> allConections = DataWorker.AllConections();
        public List<PLC_Conection> AllConections
        {
            get { return allConections; }
            set
            {
                allConections = value;
                NotifyPropertyChanged("AllConections");
            }
        }
        //Методы открытия окон
        private void OpenAddConectionWindowMethod()
        {
            AddNewPLCconectionsWindow addNewPLCconectionsWindow = new AddNewPLCconectionsWindow();
            addNewPLCconectionsWindow.Owner = Application.Current.MainWindow;
            addNewPLCconectionsWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addNewPLCconectionsWindow.ShowDialog();
        }
        //Комманда Открытие окна

        private RelayCommand openAddNewConectionWindow;
        public RelayCommand OpenAddNewConectionWindow
        {
            get
            {
                return openAddNewConectionWindow ?? new RelayCommand( obj =>
                {
                    OpenAddConectionWindowMethod();
                });

            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
