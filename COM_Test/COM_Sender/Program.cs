using TCP_Server;

var reciever = new Reciever();
//var sender = new Sender();

reciever.MessageRecieved += Reciever_MessageRecieved;

reciever.Start();
//sender.Init();


//await sender.SendMessageAsync("test1");
//await sender.SendMessageAsync("test2");
//await sender.SendMessageAsync("test3");
//await sender.SendMessageAsync("test4");
//await sender.SendMessageAsync("test5");

Console.ReadLine();

void Reciever_MessageRecieved(string text)
{
    Console.WriteLine($"Got Message : {text}");
}
