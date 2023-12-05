// See https://aka.ms/new-console-template for more information
using HomeWork_18_Serialization;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

var person = new Person("volodymyr", "klychko", 55, 75);

var personJson = JsonConvert.SerializeObject(person);

BinaryFormatter formatter = new BinaryFormatter();
byte[] serializeData;

using (MemoryStream memoryStream = new MemoryStream())
{
    formatter.Serialize(memoryStream, personJson);
    serializeData = memoryStream.ToArray();
}

using (MemoryStream memoryStream = new MemoryStream(serializeData))
{
    var jsonPerson = (string)formatter.Deserialize(memoryStream);
    var objPerson = JsonConvert.DeserializeObject<Person>(jsonPerson);
}