// See https://aka.ms/new-console-template for more information
using plc_modules;
using S7.Net;
using S7.Net.Types;

Console.WriteLine("Hello, World!");


var plc = new PlcObj();

plc.Enable = true;
plc.DataForRequest.Add( new DataItem 
{ DataType = DataType.DataBlock, DB = 1, StartByteAdr = 0, VarType = VarType.Int});
plc.DataForRequest.Add(new DataItem
{ DataType = DataType.DataBlock, DB = 1, StartByteAdr = 2, VarType = VarType.Int });


while (true)
{
    Thread.Sleep(1000);
    Console.WriteLine("MAIN");
}