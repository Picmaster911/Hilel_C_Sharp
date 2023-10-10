using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_01
{
    public struct Color
    {
        private int _redColor;
        private int _greenColor;
        private int _blueColor;
        private int _opacity;
        /// <summary>
        /// RedColor
        /// </summary>
        public int RedColor
        {
            get => _redColor;
            set => _redColor = IsColorValid(value) ? value : 0;
        }
        /// <summary>
        /// GreenColor
        /// </summary>
        public int GreenColor
        {
            get => _greenColor;
            set => _greenColor = IsColorValid(value) ? value : 0;
        }
        /// <summary>
        /// BlueColor
        /// </summary>
        public int BlueColor
        {
            get => _blueColor;
            set => _blueColor = IsColorValid(value) ? value : 0;
        }
        /// <summary>
        /// Opacity
        /// </summary>
        public int Opacity
        {
            get => _opacity;
            set => _opacity = IsOpacityValid(value) ? value : 0;
        }
        /// <summary>
        /// Constructor for color Car R, G, B, Opacity  
        /// </summary>
        /// <param name="redColor"></param>
        /// <param name="greenColor"></param>
        /// <param name="blueColor"></param>
        /// <param name="opacity"></param>
        static bool IsColorValid(int colorValue)
        {
            return colorValue is < 255 and >= 0 ? true : false;
        }
        static bool IsOpacityValid(int colorValue)
        {
            return colorValue is < 100 and >= 0 ? true : false;
        }
        /// <summary>
        ///  Object color create
        ///  R = 0-255, G = 0-255, B = 0-255, Opacity = 0-100,
        /// </summary>
        /// <param name="redColor"></param>
        /// <param name="greenColor"></param>
        /// <param name="blueColor"></param>
        /// <param name="opacity"></param>
        public Color(int redColor, int greenColor, int blueColor, int opacity)
        {
            _redColor = IsColorValid(redColor) ? redColor : 0;
            _greenColor = IsColorValid(greenColor) ? greenColor : 0;
            _blueColor = IsColorValid(greenColor) ? blueColor : 0;
            _opacity = IsOpacityValid(greenColor) ? opacity : 0;
        }
        /// <summary>
        /// Object color create with defalut value R =100,
        /// G =100, B =100, Opacity =0;
        /// </summary>
        public Color()
        {
            _redColor = 100;
            _greenColor = 100;
            _blueColor = 100;
            _opacity = 0;
        }
    }
}
