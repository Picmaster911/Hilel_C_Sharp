using DevExpress.Mvvm;
using PlcTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlcTest.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private static Timer aTimer;
        private Page _plcTable;
        private Page _test;
        private Page _mainWindow;
        public Page CurentPage { get; set; }
        public Page MainWindow  { get; set; }
        public double Opacity { get; set; } 

        public string TimerString { get; set; } 
        public MainViewModel()
        {
            _plcTable = new Pages.PlcTable();
            _test = new Pages.Test();
            _mainWindow = new Pages.MainPage();
            CurentPage = _mainWindow;
            Opacity = 1;
        }

       public void Start()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 2000;
            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;

            aTimer.Elapsed += OnTimedEvent;
        }
        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            TimerString = DateTime.UtcNow.ToString();
        }
        public ICommand SetMainWindow    {
            get
            {
                return new DelegateCommand (() => CurentPage = _mainWindow);
            }
        }

        public ICommand SetTestWindow
        {
            get
            {
                return new DelegateCommand(() => CurentPage = _test);
            }
        }

        public ICommand SetPlcTableWindow
        {
            get
            {
                return new DelegateCommand(() => CurentPage = _plcTable);
            }
        }

       
    }
}
