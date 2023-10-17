// See https://aka.ms/new-console-template for more information
using HomeWork_05;
using HomeWork_05.Bird;
using HomeWork_05.Fish;
using HomeWork_05.Mammal;

var listAnimal = new List<Animal>()
{
    new Dog ("Buldog",12),
    new Cat ("Sfinks",15),
    new Shark ("WhiteShark",7),
    new Dorado ("DoradoFish",5),
    new Eagle ("Eagle",11),
    new Owl ("Owl",2),
};

foreach (var animal in listAnimal)
{
    animal.Speek();
    animal.Move();
}
