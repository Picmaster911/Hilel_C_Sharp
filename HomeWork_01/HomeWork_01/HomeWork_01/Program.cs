// See https://aka.ms/new-console-template for more information
using HomeWork_01;
using System.Reflection;


var Car1 = new Car();

IEnumerable <FieldInfo> fields = Car1.GetType().GetTypeInfo().DeclaredFields;

foreach (var field in fields.Where(x => !x.IsStatic))
{
    Console.WriteLine($" Имя поля {field.Name} {field.GetValue(Car1)}");
}