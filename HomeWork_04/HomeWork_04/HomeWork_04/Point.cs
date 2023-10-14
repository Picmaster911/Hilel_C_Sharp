using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_04
{
    internal class Point
    {
        private int _x;
        private int _y;
        public static int CountInstanse;
        /// <summary>
        /// Input  X coordinate 0 - 2,147,483,647 
        /// if input minus value automatic set default value = 0;
        /// </summary>
        public int X
        {
            get => _x;
            set => _x = value;
        }
        /// <summary>
        /// <summary>
        /// Input  Y coordinate 0 - 2,147,483,647 
        /// if input minus value automatic set default value = 0;
        /// </summary>
        public int Y
        {
            get => _y;
            set => _y = value;
        }
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
            CountInstanse += 1;
        }
        /// <summary>
        /// Returns the distance between two objects ( input Obj type Point, and input Obj type Point )
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <returns></returns>
        public static int GetDestancebetweenPoints(Point firstPoint, Point secondPoint)
        {
            var catet_1 = firstPoint.X > secondPoint.X ? firstPoint.X - secondPoint.X : secondPoint.X - firstPoint.X;
            var catet_2 = firstPoint.Y > secondPoint.Y ? firstPoint.Y - secondPoint.Y : secondPoint.Y - firstPoint.Y;
            return (int)Math.Round(Math.Sqrt(Math.Pow(catet_1, 2) + Math.Pow(catet_2, 2)));

        }
        /// <summary>
        /// Returns the distance between two objects (this.Obj type Point and input Obj type Point )
        /// </summary>
        /// <param name="secondPoint"></param>
        /// <returns></returns>
        public int GetDistanceToPoint(Point secondPoint)
        {
            var catet_1 = _x > secondPoint.X ? _x - secondPoint.X : secondPoint.X - _x;
            var catet_2 = _y > secondPoint.Y ? _y - secondPoint.Y : secondPoint.Y - _y;
            return (int)Math.Round(Math.Sqrt(Math.Pow(catet_1, 2) + Math.Pow(catet_2, 2)));
        }

    }
}

