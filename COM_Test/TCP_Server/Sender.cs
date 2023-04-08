using System.Net.Sockets;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace TCP_Server
{
    // Klassen som handterer overføring av TCP data
    public class Sender : Server
    {
        public async Task<bool> SendMessageAsync(string message)
        {
            if (message == null) { return false; }
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            await _socket.ConnectAsync(_ipPoint);
            Debug.WriteLine("Sender is connected");

            var data = Encoding.Unicode.GetBytes(message);
            await _socket.SendAsync(data, SocketFlags.None);

            data = new byte[ServerShared.BYTE_SIZE];
            var builder = new StringBuilder();
            try
            {
                do
                {
                    await _socket.ReceiveAsync(data, SocketFlags.None);
                    builder.Append(Encoding.Unicode.GetString(data));
                } while (_socket.Available > 0);
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
            }
            _socket.Close();
            Debug.WriteLine("Sender is Disconnected");
            var answer = builder.ToString();
            return bool.Parse(answer);
        }
    }
}
