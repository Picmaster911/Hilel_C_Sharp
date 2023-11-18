using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13
{
    internal class MovieLibrary : IEnumerator, IEnumerable
    {
        static string[] _ordinaryMovies = {
            "THE MARVELS",
            "THE KILLER",
            "FIVE NIGHTS AT FREDDY'S",
            "KILLERS OF THE FLOWER MOON",
            "THE HOLDOVERS",
            "DUMB MONEY",
            "NYAD" };
        static string[] _onlyAdultMovies = {
            "XXX",
            "PRISCILLA",
            "A HAUNTING IN VENICE ",
            "WHEN EVIL LURKS",
            "QUIZ LADY" };

        private int _position = -1;

        private static string[] _result = new string[_ordinaryMovies.Length];
        private string[] _allConcat = Concat();
        public string this[int index]
        {
            get
            {
                if (Validation(index))
                {
                    throw new Exception("index out range");
                }
                return Concat()[index];
            }
            set
            {
                if (Validation(index))
                {
                    throw new Exception("index out range");
                }
                if (index < _ordinaryMovies.Length)
                {
                    _ordinaryMovies[index] = value;
                }
                var offset = _onlyAdultMovies.Length - ((_ordinaryMovies.Length + _onlyAdultMovies.Length) - index);
                _onlyAdultMovies[offset] = value;
            }
        }

        private bool Validation(int index)
        {
            if (index < 0 || index >= _allConcat.Length)
            {
                return true;
            }
            return false;
        }
        public string GetMovie(int movieNum)
        {
            return _allConcat[movieNum];
        }
        private static string[] Concat()
        {
            var oldResult = _ordinaryMovies;

            for (int i = 0; i <= _onlyAdultMovies.Length - 1; i++)
            {
                var newResult = new string[oldResult.Length + 1];
                oldResult.CopyTo(newResult, 0);
                newResult[_result.Length + i] = _onlyAdultMovies[i];
                oldResult = new string[_result.Length + 1];
                oldResult = newResult;
            }
            return oldResult;
        }
        public IEnumerator GetEnumerator()
        {
            return  this;
        }
        bool IEnumerator.MoveNext()
        {
            _position++;
            var dataTime = DateTime.Now;
            if (dataTime.Hour > 23 || dataTime.Hour >= 0 && dataTime.Hour <= 7)
            {
                return (_position < _allConcat.Length);
            }
            else
            {
                return (_position < _ordinaryMovies.Length);
            }

        }
        void IEnumerator.Reset()
        {
            _position = -1;
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
                    return _allConcat[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

    }
}
