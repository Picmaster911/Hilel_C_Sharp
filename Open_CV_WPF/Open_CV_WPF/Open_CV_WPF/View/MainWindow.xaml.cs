using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Windows;
using System;
using Open_CV_WPF.Service;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using DirectShowLib;


namespace Open_CV_WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(CameraService cameraService)
        {
            InitializeComponent();
        }
    }
}