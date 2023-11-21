using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13
{
    internal class MovieLibraryEnum : IEnumerator
    {
        private Dictionary<int, string> _colection;
        private int _position = -1;
        public MovieLibraryEnum(Dictionary<int, string> colection)
        {
            _colection = colection;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public string Current
        {
            get
            {
                try
                {
                    return _colection.Values.ToList()[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        bool IEnumerator.MoveNext()
        {
            _position++;
            return _position < _colection.Count;
        }

        void IEnumerator.Reset()
        {
            _position = -1;
        }
    }
}
