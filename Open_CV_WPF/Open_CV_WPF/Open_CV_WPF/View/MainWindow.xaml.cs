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
        private void image1_Initialized(object sender, EventArgs e)
        {
            //string win1 = "Test Window (Press any key to close)"; //The name of the window
            ////CvInvoke.NamedWindow(win1); //Create the window using the specific name
            //using (Mat frame = new Mat())
            //using (VideoCapture capture = new VideoCapture())
            //{
            //    capture.Read(frame);
            //    image1.Source = frame.ToBitmapSource();
            //}
        }
    }
}