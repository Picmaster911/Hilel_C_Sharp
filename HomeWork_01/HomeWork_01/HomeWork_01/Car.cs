using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_01

{
    internal class Car
    {
        private int _id;
        private Color _color;
        public string Model { get; set; }
        public string Type { get; set; }
        public string NumberOfCar { get; set; }
        public DateTime DateAraive { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public int Id { get => _id; }

        /// <summary>
        /// Object Car
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <param name="color"></param>
        /// <param name="numberOfCar"></param>
        public Car ( int id, string type,string model, Color color, string numberOfCar)
        {
            _id = id;
            Model = model;
            Type = type;    
            _color = color;
            NumberOfCar = numberOfCar;  
        }
        /// <summary>
        /// Car set clor default value; 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="numberOfCar"></param>
        /// <param name="model"></param>
        public Car(int id, string type, string numberOfCar, string model ="NoName")
        {
            _id = id;
            Model = model;
            Type = type;
            _color = new Color();
            NumberOfCar = numberOfCar;
        }
        /// <summary>
        /// Method change color car 
        /// </summary>
        /// <param name="color"></param>
        public void ChangeColor (Color color) 
        {
            _color= color;
        }
    }
}
