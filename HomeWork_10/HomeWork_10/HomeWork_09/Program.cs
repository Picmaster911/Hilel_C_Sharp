using HomeWork_09;

var list = new NodeList<string>();
list.AddNode("1");
list.AddNode("2");
list.AddNode("3");
list.AddNode("4");
list.AddNode("5");
list.ShowAllNodes();
list.DeletNode("2");
list.ShowAllNodes();
list.Clean();
list.ShowAllNodes();


