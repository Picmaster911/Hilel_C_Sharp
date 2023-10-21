using HomeWork_06;
using HomeWork_06.Contracts;

var capOffCoffe = new Cup();
AddWater(capOffCoffe);
AddSugar(capOffCoffe);
capOffCoffe.Stir();
AddMilk(capOffCoffe);
capOffCoffe.Stir();
AddCoffe(capOffCoffe);
capOffCoffe.Stir();

void AddWater(IContainingWater cap)
{
    cap.AddWater();
}
void AddSugar(IContainingSugar cap)
{
    cap.AddSugar();
}
void AddMilk(IContainingMilk cap)
{
    cap.AddMilk();
}
void AddCoffe(IContainingCoffee cap)
{
    cap.AddCoffee();
}