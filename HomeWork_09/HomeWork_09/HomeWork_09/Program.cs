using HomeWork_09;

var animalPlacea1 = new AnimalPlace("Wolf", "Meat", 3);
var animalPlacea2 = new AnimalPlace("Camel", "Grass", 5);
var animalPlacea3 = new AnimalPlace("Birds", "Grain", 8);
using (var animalFeedProces = new AnimalsFeedProcessor())
{
    animalFeedProces.AddNewAnimalPlace(animalPlacea1);
    animalFeedProces.AddNewAnimalPlace(animalPlacea2);
    animalFeedProces.AddNewAnimalPlace(animalPlacea3);
    animalPlacea1.ActionEndFeed();
    animalPlacea2.ActionEndFeed();
    animalPlacea3.ActionEndFeed();
}


