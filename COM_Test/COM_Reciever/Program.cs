using System.Net;
using System.Net.Sockets;
using System.Text;

const string LOCALHOST = "127.0.0.1";
const int PORT = 9050;
const int BYTE_SIZE = 1024;

var loopFlag = true;

Console.WriteLine("Reciever app is started");

var ipPoint = new IPEndPoint(IPAddress.Parse(LOCALHOST), PORT);

var listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
try
{
    listenSocket.Bind(ipPoint);

    listenSocket.Listen(10);

    Console.WriteLine("Reciever is up to work");

    var handler = listenSocket.Accept();

    Console.WriteLine("Reciever is connected to sender");

    while (loopFlag)
    {
        var builder = new StringBuilder();
        var bytes = 0;
        var data = new byte[BYTE_SIZE];

        do
        {
            bytes = await handler.ReceiveAsync(data, SocketFlags.None);
            builder.Append(Encoding.Unicode.GetString(data));
        } while (handler.Available > 0);

        var requestText = builder.ToString();

        Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + requestText);

        var answer = "Message is recieved";
        data = Encoding.Unicode.GetBytes(answer);
        await handler.SendAsync(data, SocketFlags.None);

        if (requestText == "stop")
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            loopFlag = false;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}