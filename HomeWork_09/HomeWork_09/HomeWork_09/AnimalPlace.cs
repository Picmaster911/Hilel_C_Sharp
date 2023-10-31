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

        public async void StartEating()
        {
            while (true)
            {
                _amount -= 1;
                await Task.Delay(1000);
                if (_amount == 0)
                    FoodFinished?.Invoke(FeedName, this);
            }
        }
    }

}
