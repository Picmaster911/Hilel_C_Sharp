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
            set => _redColor =  value < 255 ? value : 0;
        }
        /// <summary>
        /// GreenColor
        /// </summary>
        public int GreenColor
        {
            get => _greenColor;
            set => _greenColor = value < 255 && value > 0 ? value : 0;
        }
        /// <summary>
        /// BlueColor
        /// </summary>
        public int BlueColor
        {
            get => _blueColor;
            set => _blueColor = value < 255 && value > 0 ? value : 0;
        }
        /// <summary>
        /// Opacity
        /// </summary>
        public int Opacity
        {
            get => _opacity;
            set => _opacity = value < 100 && value > 0 ? value : 0;
        }
        /// <summary>
        /// Constructor for color Car R, G, B, Opacity  
        /// </summary>
        /// <param name="redColor"></param>
        /// <param name="greenColor"></param>
        /// <param name="blueColor"></param>
        /// <param name="opacity"></param>
        public Color (int redColor, int greenColor , int blueColor, int opacity)
        {
            _redColor = redColor < 255 && redColor > 0 ? redColor : 0;
            _greenColor = greenColor < 255 && greenColor > 0 ? greenColor : 0;
            _blueColor = blueColor < 255 && blueColor > 0 ? blueColor : 0;
            _opacity = opacity < 100 && opacity > 0 ? opacity : 0;
        }
    }
}
