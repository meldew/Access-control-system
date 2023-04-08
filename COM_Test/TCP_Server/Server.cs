using System.Net.Sockets;
using System.Net;

namespace TCP_Server
{
    public abstract class Server
    {
        // Shared IP og socket
        protected IPEndPoint _ipPoint;
        protected Socket _socket;
        public Server()
        {
            _ipPoint = new IPEndPoint(IPAddress.Parse(ServerShared.LOCALHOST), ServerShared.PORT);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);            
        }
    }
}
