using DirectShowLib;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Open_CV_WPF.Service
{
    public class CameraService
    {
        private VideoCapture _capture;
        private Mat _frame;
        private DsDevice[] _webCams;
        private int _selectedCameraId;
        private Mat _videoSource;
        private int _frameWidth;
        private int _frameHeight;
        private VideoWriter _writer;
        public List<string> AllCams = new List<string>();

        public event Action<ImageSource> EventFromVideoCams;

        public int SelectedCameraId
        {
            get => _selectedCameraId;

            set
            {
                _selectedCameraId = value;
                _capture.Stop();
                InitCamera();
            }

        }

        public void StartRecord()
        {
            // Устанавливаем размер кадра и частоту кадров для записываемого видео

        }
        public void InitCamera()
        {
            _webCams = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            var test = _webCams;

            if (_webCams != null)
            {
                CvInvoke.UseOpenCL = false;
                AllCams = _webCams.Select(p => p.Name).ToList();
                _capture = new VideoCapture(_selectedCameraId);
                _frameWidth = (int)_capture.Get(Emgu.CV.CvEnum.CapProp.FrameWidth);
                _frameHeight = (int)_capture.Get(Emgu.CV.CvEnum.CapProp.FrameHeight);
                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start();
              //  _writer = new VideoWriter("output.avi", VideoWriter.Fourcc('M', 'J', 'P', 'G'),
                 //   30, new System.Drawing.Size(_frameWidth, _frameHeight), true);
            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                using (_frame = new Mat())
                {
                    _capture.Retrieve(_frame, 0);
                    string currentDate = DateTime.Now.ToString();
                    //CvInvoke.BitwiseNot(_frame, _frame); //
                    //CvInvoke.CvtColor(_frame, _frame, ColorConversion.Bgr2Gray);
                    //CvInvoke.InRange(_frame, new ScalarArray(new MCvScalar(0, 0, 100)), new ScalarArray(new MCvScalar(100, 100, 255)), _frame);
                    // Добавляем текущую дату в верхний левый угол кадра
                    CvInvoke.PutText(_frame, currentDate, new System.Drawing.Point(10, 30),
                    FontFace.HersheyComplex, 1, new MCvScalar(125, 225, 155), 2);
                    //_frame = DetectRedObjects(_frame);
                    DrawGrid(_frame);
                   // _writer.Write(_frame);
                    EventFromVideoCams.Invoke(ToBitmapSource(_frame));
                }

            }
        }
        // Конвертирует Mat в BitmapSource
        private ImageSource ToBitmapSource(Mat image)
        {
            using (var bitmap = image.ToBitmap())
            {
                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Bmp);
                    stream.Seek(0, SeekOrigin.Begin);

                    var bitmapSource = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    return bitmapSource;
                }
            }
        }

        static Mat DetectRedObjects(Mat input)
        {
            // Конвертируем изображение из формата BGR в HSV
            Mat hsvImage = new Mat();
            CvInvoke.CvtColor(input, hsvImage, ColorConversion.Bgr2Hsv);

            // Определяем красный диапазон в HSV
            ScalarArray lowerRed = new ScalarArray(new MCvScalar(0, 100, 100));
            ScalarArray upperRed = new ScalarArray(new MCvScalar(10, 255, 255));

            // Создаем маску для красных пикселей
            Mat redMask = new Mat();
            CvInvoke.InRange(hsvImage, lowerRed, upperRed, redMask);

            // Найдем контуры объектов на маске
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(redMask, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            // Создаем черное изображение такого же размера, как исходное, чтобы нарисовать контуры на нем
            Mat result = new Mat(input.Size, DepthType.Cv8U, 3);
            result.SetTo(new MCvScalar(0, 0, 0));

            // Рисуем контуры красных объектов на черном изображении
            for (int i = 0; i < contours.Size; i++)
            {
                CvInvoke.DrawContours(result, contours, i, new MCvScalar(0, 0, 255), -1);
            }

            return result;
        }

        private Mat DrawGrid(Mat frame)
        {
            // Рисуем вертикальные линии сетки
            for (int x = 0; x < frame.Width; x += 50)
            {
                CvInvoke.Line(frame, new System.Drawing.Point(x, 0), new System.Drawing.Point(x, frame.Height), new MCvScalar(0, 255, 0), 1);
            }

            // Рисуем горизонтальные линии сетки
            for (int y = 0; y < frame.Height; y += 50)
            {
                CvInvoke.Line(frame, new System.Drawing.Point(0, y), new System.Drawing.Point(frame.Width, y), new MCvScalar(0, 255, 0), 1);
            }
            return frame;
        }

        public void GoReadVideo(string SelectedFilePath)
        {
            _capture.Stop();

            if (_webCams != null)
            {
                using (var capture = new VideoCapture(SelectedFilePath))
                {
                    // Проверяем, удалось ли открыть видеофайл
                    if (!capture.IsOpened)
                    {
                        Console.WriteLine("Не удалось открыть видеофайл.");
                        return;
                    }

                    while (true)
                    {
                        Mat frame = new Mat();
                        capture.Read(frame); ; // Считываем кадр из видеофайла

                        if (frame.IsEmpty) // Если кадр пустой, значит видео закончилось
                            break;
                        EventFromVideoCams.Invoke(ToBitmapSource(frame));
                        // Ожидаем нажатия клавиши для выхода
                        if (Emgu.CV.CvInvoke.WaitKey(30) >= 0)
                            break;
                    }
                }
            }
        }
    }
}