using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HomeWork_13
{
    internal class MovieLibrary : IEnumerable
    {
        private Dictionary<int, string> _ordinaryMovies = new Dictionary<int, string>();

        private Dictionary<int, string> _onlyAdultMovies = new Dictionary<int, string>();

        public MovieLibrary(Dictionary<int, string>  ordinaryMovies, Dictionary<int, string> onlyAdultMovies)
        {
            _ordinaryMovies = ordinaryMovies;
            _onlyAdultMovies = onlyAdultMovies;
        }
        public string this[int index]
        {
            get
            {
                return GetMovie(index);
            }
        }

        private bool Validation()
        {
            var dataTime = DateTime.Now;
            return (dataTime.Hour > 23 || dataTime.Hour >= 0 && dataTime.Hour <= 7) ? false : true;
        }
        public string GetMovie(int movieNum)
        {
            if (Validation())
            {
                if (_ordinaryMovies.ContainsKey(movieNum))
                    return _ordinaryMovies[movieNum];
            }
            else
            {
                if (_onlyAdultMovies.ContainsKey(movieNum))
                    return _onlyAdultMovies[movieNum];
                if (_ordinaryMovies.ContainsKey(movieNum))
                    return _ordinaryMovies[movieNum];
            }
            return "NOT FOUND FILMS";
        }
        public IEnumerator GetEnumerator()
        {
            Dictionary<int, string> allColection = new Dictionary<int, string>();
            if (!Validation())
            {
                allColection = _ordinaryMovies.Union(_onlyAdultMovies).ToDictionary(pair => pair.Key, pair => pair.Value);
                return new MovieLibraryEnum(allColection);
            }
            else
            {
                return new MovieLibraryEnum(_ordinaryMovies);
            }
        }
    }
}
