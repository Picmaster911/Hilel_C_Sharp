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
        private CameraService _cameraService;
        private ImageSource _videoSource { get; set; }
        private string _selectedCam;
        public string SelectedFilePath { get; set; }
        public string SelectedCam {
            get => _selectedCam;
            set
            {
                _selectedCam = value;
                _cameraService.SelectedCameraId = _allCams.IndexOf(_selectedCam);
            }                       
        }   
        public ImageSource VideoSource 

        {   get => _videoSource;
            set
            {
                _videoSource = value;
                OnPropertyChanged();
            }
        }
        private List<string> _allCams  = new List<string>();    
        public List<string> AllCams { get => _allCams; set { _allCams = value;} }

        public MainWindowViewModel(CameraService cameraService)
        {
            _cameraService = cameraService;
            _cameraService.EventFromVideoCams += EventFromCamera;
            _cameraService = cameraService;
            _cameraService.InitCamera();
            _allCams = _cameraService.AllCams;
            _selectedCam = _allCams[0];


            #region Commands
           ButtonStopCommand = new LambdaCommand(
                 OnButtonStopCommand,
                CanOnButtonStopCommand);
            ButtonOpenFileCommand = new LambdaCommand(
                 OnButtonOpenFileCommand,
                CanOnButtonOpenFileCommand);

            #endregion
        }

        #region Commands
        #region ButtonStopCommand
        public ICommand ButtonStopCommand { get; }

        private void OnButtonStopCommand(object p)
        {
   
        }
        private bool CanOnButtonStopCommand(object p) => true;
        #endregion
        #region ButtonStopCommand
        public ICommand ButtonOpenFileCommand { get; }

        private void OnButtonOpenFileCommand(object p)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                SelectedFilePath = openFileDialog.FileName;
                _cameraService.GoReadVideo(SelectedFilePath);
            }
        }
        private bool CanOnButtonOpenFileCommand(object p) => true;
        #endregion

        #endregion

        public void EventFromCamera(ImageSource video)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                VideoSource = video;   
            });
        }

        //private void VideoImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    // Находим ячейку сетки, в которой было сделано нажатие мыши
        //    int cellX = (int)e.GetPosition(videoImage).X / cellWidth;
        //    int cellY = (int)e.GetPosition(videoImage).Y / cellHeight;

        //    // Выводим координаты ячейки сетки в консоль
        //    Console.WriteLine("Clicked cell: (" + cellX + ", " + cellY + ")");
        //}
    }
}
