using Emgu.CV;
using Open_CV_WPF.Service;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using Open_CV_WPF.Infrastructure.Commands;
using Microsoft.Win32;

namespace Open_CV_WPF.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
       public CameraFirstViewModel CameraFirstViewModel { get;}
        public MainWindowViewModel(CameraFirstViewModel cameraFirstViewModel)
        {
            CameraFirstViewModel = cameraFirstViewModel;
        }
    }
}
