using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace HomeWork_09
{
    internal class AnimalPlace
    {
        public string AnimalName { get; set; }
        public string FeedName { get; set; }
        private int _amount;
        public event Action<string, AnimalPlace> FoodFinished;

        public AnimalPlace(string animalName, string feedName, int amount)
        {
            AnimalName = animalName;
            FeedName = feedName;
            _amount = amount;
        }

        public void Feed(int amount)
        {
            _amount = amount;
        }

        public void ActionEndFeed()
        {
            FoodFinished?.Invoke(FeedName, this);
        }
    }
}
