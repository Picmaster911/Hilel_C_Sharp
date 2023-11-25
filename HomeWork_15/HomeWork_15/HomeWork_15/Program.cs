using HomeWork_15;

var listInt = new List<int>(100);
for (int i = 0; i <= 100; i++)
{
    listInt.Add(i);
}
var listIntOdd = from x in listInt
                 where x % 2 == 0
                 select x;

var listIntQuad = from x in listIntOdd
                  select x * x;

var sumArray = listInt.Sum();
listIntOdd.ToList().ForEach(number => Console.WriteLine(number));
var persons = ListPerson.Persons;

var personTwentyYears = from person in persons
                        where person.Age >= 20
                        select person;

personTwentyYears.ToList().ForEach(personTwentyYear => 
Console.WriteLine($"Person older 20 year Name is {personTwentyYear.Name}"));

var pTwentyYearsAnbj = from person in persons
                       where person.Age >= 20
                       orderby person.Name
                       select new
                       {
                           Id = person.Id,
                           Name = person.Name,
                       };
pTwentyYearsAnbj.ToList().ForEach(person => Console.WriteLine($"Anonymous foreach {person.Name}"));
var penultimatePerson = personTwentyYears.PenultimateItem();
Console.WriteLine(penultimatePerson.Name);
