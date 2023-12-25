using plc_wpf.Model;
using plc_wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;

namespace plc_wpf.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowVM();
            DataContext = _viewModel;
        }
    }
}
