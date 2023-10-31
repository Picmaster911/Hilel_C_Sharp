using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_09
{
    internal class AnimalsFeedProcessor:IDisposable
    {
        private List<AnimalPlace> _allAnimalsPlace = new List<AnimalPlace>();

        public void AddNewAnimalPlace (AnimalPlace newAnimalPlace)
        {
            _allAnimalsPlace.Add (newAnimalPlace);
            newAnimalPlace.FoodFinished += FeedAll;
        }

        private void FeedAll(string feedName, AnimalPlace animalPlace)
        {
            Console.WriteLine($"Warning {animalPlace.AnimalName} finish feed {feedName}, I add feed now !");
            if (animalPlace.AnimalName == "Wolf")
            animalPlace.Feed(3);
            else if (animalPlace.AnimalName == "Camel")
                animalPlace.Feed(5);
            else if (animalPlace.AnimalName == "Birds")
                animalPlace.Feed(8);
        }

        public void Dispose()
        {
            _allAnimalsPlace.ForEach(animalPlace => animalPlace.FoodFinished -= FeedAll);
        }

    }
}
