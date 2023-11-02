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
            newAnimalPlace.FoodFinished += FeedAnimal;
        }

        private void FeedAnimal(string feedName, AnimalPlace animalPlace)
        {
            Console.WriteLine($"Warning {animalPlace.AnimalName} finish feed {feedName}, I add 20 item of feed !");
            animalPlace.Feed(20);
        }
        public void FeedAll(int addFeed)
        {
            _allAnimalsPlace.ForEach(animalPlace => animalPlace.Feed(addFeed));
        }
        public void Dispose()
        {
            _allAnimalsPlace.ForEach(animalPlace => animalPlace.FoodFinished -= FeedAnimal);
        }

    }
}
