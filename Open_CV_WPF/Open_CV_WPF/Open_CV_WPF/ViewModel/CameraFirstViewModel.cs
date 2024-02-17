using Microsoft.Win32;
using Open_CV_WPF.Infrastructure.Commands;
using Open_CV_WPF.Service;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;


namespace Open_CV_WPF.ViewModel
{
    internal class CameraFirstViewModel: ViewModelBase
    {
        private CameraService _cameraService;
        private ImageSource _videoSource { get; set; }
        private string _selectedCam;
        public string SelectedFilePath { get; set; }
        private string _fileNameJpg;
        public string FileNameJpg
        {
            get => _fileNameJpg;
            set
            {
                _fileNameJpg = value;
                OnPropertyChanged();
            }
        }
        private string _recordColor = "White";
        public string RecordColor
        {
            get => _recordColor;
            set
            {
                _recordColor = value;
                OnPropertyChanged();
            }
        }
        private string _greenColor = "White";
        public string GreenColor
        {
            get => _greenColor;
            set
            {
                _greenColor = value;
                OnPropertyChanged();
            }
        }
        public string SelectedCam
        {
            get => _selectedCam;
            set
            {
                _selectedCam = value;
                _cameraService.SelectedCameraId = _allCams.IndexOf(_selectedCam);
            }
        }
        public ImageSource VideoSource

        {
            get => _videoSource;
            set
            {
                _videoSource = value;
                OnPropertyChanged();
            }
        }
        private List<string> _allCams = new List<string>();
        public List<string> AllCams { get => _allCams; set { _allCams = value; } }

        public CameraFirstViewModel(CameraService cameraService)
        {
            _cameraService = cameraService;
            _cameraService.EventFromVideoCams += EventFromCamera;
            _cameraService = cameraService;
            _cameraService.InitCamera();
            _allCams = _cameraService.AllCams;
            _selectedCam = _allCams[0];


            #region Commands
            StopCommand = new LambdaCommand(
                OnButtonStopCommand,
                CanOnButtonStopCommand);
            OpenFileCommand = new LambdaCommand(
                OnButtonOpenFileCommand,
                CanOnButtonOpenFileCommand);
            ClosingCommand = new LambdaCommand(
                OnClosingCommand,
                CanClosingCommand);
            StartRecordCommand = new LambdaCommand(
                OnStartRecordCommand,
                CanStartRecordCommand);
            PauseCommand = new LambdaCommand(
                OnPauseCommand,
                CanPauseCommand);
            PlayCommand = new LambdaCommand(
                OnPlayCommand,
                CanPlayCommand);
            TakeScreenshot = new LambdaCommand(
                OnTakeScreenshot,
                CanTakeScreenshot);
            #endregion

        }
        #region Commands
        #region ButtonStopCommand
        public ICommand StopCommand { get; }

        private void OnButtonStopCommand(object p)
        {
            _cameraService.StartRecordVideo = false;
            _cameraService.StoptRecord();
            RecordColor = "White";
            GreenColor = "White";
            _cameraService.Stop = true;
            _cameraService.CloseService();
            _cameraService.InitCamera();
        }
        private bool CanOnButtonStopCommand(object p) => true;
        #endregion
        #region ButtonStartRecordCommand
        public ICommand StartRecordCommand { get; }

        private void OnStartRecordCommand(object p)
        {
            _cameraService.CreateWriter();
            _cameraService.StartRecordVideo = true;
            RecordColor = "Red";
        }
        private bool CanStartRecordCommand(object p) => true;
        #endregion
        #region PauseCommand
        public ICommand PauseCommand { get; }

        private void OnPauseCommand(object p)
        {
            _cameraService.Pause = true;
            GreenColor = "White";
        }
        private bool CanPauseCommand(object p) => true;
        #endregion
        #region PlayCommand
        public ICommand PlayCommand { get; }

        private void OnPlayCommand(object p)
        {
            _cameraService.Pause = false;
            GreenColor = "Green";
        }
        private bool CanPlayCommand(object p) => true;
        #endregion

        #region TakeScreenshot
        public ICommand TakeScreenshot { get; }

        private void OnTakeScreenshot(object p)
        {
            _cameraService.TakeScreenshot(_fileNameJpg);
        }
        private bool CanTakeScreenshot(object p) => true;
        #endregion


        #region ButtonOpenFileCommand
        public ICommand OpenFileCommand { get; }

        private void OnButtonOpenFileCommand(object p)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                SelectedFilePath = openFileDialog.FileName;
                _cameraService.Stop = false;
                GreenColor = "Green";
                _cameraService.GoReadVideo(SelectedFilePath);
            }
        }
        private bool CanOnButtonOpenFileCommand(object p) => true;
        #endregion
        #region ClosingCommand
        public ICommand ClosingCommand { get; }
        private void OnClosingCommand(object p)
        {
            _cameraService.CloseService();
        }
        private bool CanClosingCommand(object p) => true;
        #endregion
        #endregion

        public void EventFromCamera(ImageSource video)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                VideoSource = video;
            });
        }
    }
}

