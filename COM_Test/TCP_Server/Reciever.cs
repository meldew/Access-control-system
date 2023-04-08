using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using ServerShared;

namespace TCP_Server
{
    public class Reciever : Server
    {
        private bool _isActive;
        private Socket _handler;
        ComMedDatabase com = new ComMedDatabase();
        public event Action<bool, TCPipData> MessageRecieved;
        // Metoden som starter Reciveren
        public async void Start()
        {
            _isActive = true;
            try
            {
                _socket.Bind(_ipPoint);
                _socket.Listen(10);
                Debug.WriteLine("Reciever is up to work");
                while (_isActive)
                {
                    _handler = await _socket.AcceptAsync();
                    Debug.WriteLine("Reciever is connected to sender");
                    var builder = new StringBuilder();
                    var data = new byte[ServerShared.BYTE_SIZE];
                    do
                    {
                        await _handler.ReceiveAsync(data, SocketFlags.None);
                        builder.Append(Encoding.Unicode.GetString(data));
                    } while (_handler.Available > 0);
                    var requestText = builder.ToString();
                    var tcpData = ConvertStringToData(requestText);
                    var res = com.TestIfDataExists(tcpData.Pinkode, tcpData.KorID);
                    Debug.WriteLine(DateTime.Now.ToShortTimeString() + ": " + requestText);
                    MessageRecieved?.Invoke(res, tcpData);
                    data = Encoding.Unicode.GetBytes(res.ToString());
                    await _handler.SendAsync(data, SocketFlags.None);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        // Handtering av meldingen fra senderen
        private TCPipData ConvertStringToData(string data)
        {
            try
            {
                int posStart = data.IndexOf('$');
                int posSlutt = data.IndexOf('#');
                var enMelding = data.Substring(posStart, (posSlutt - posStart) + 1);

                // Å gjøre : Fikse benevnelser, får disser ser trist ut!! 
                int posPinStart = enMelding.IndexOf('I');
                int posPinSlutt = enMelding.IndexOf('P') - 1;

                int posKIDStart = enMelding.IndexOf('P');
                int posKIDSlutt = enMelding.IndexOf('A') - 1;

                int alarm1Start = enMelding.IndexOf('A');
                int alarm1Stopp = enMelding.IndexOf('B') - 1;

                int alarm2Start = enMelding.IndexOf('B');
                int alarm2Stopp = enMelding.IndexOf('C') - 1;

                int alarm3Start = enMelding.IndexOf('C');
                int alarm3Stopp = enMelding.IndexOf('D') - 1;

                int potmStart = enMelding.IndexOf('D');
                int potmStop = enMelding.IndexOf('R') - 1;

                int logRStart = enMelding.IndexOf('R');
                int logRStop = enMelding.IndexOf('L') - 1;

                if (posPinStart >= 0 && posPinSlutt >= 0 && posKIDStart >= 0 && posKIDSlutt >= 0)
                {
                    string kortID = enMelding.Substring(posPinStart + 1, (posPinSlutt - posPinStart));
                    string pinKode = enMelding.Substring(posKIDStart + 1, (posKIDSlutt - posKIDStart));

                    string firstDoorInfo = enMelding.Substring(alarm1Start + 1, alarm1Stopp - alarm1Start);
                    string secondDoorInfo = enMelding.Substring(alarm2Start + 1, alarm2Stopp - alarm2Start);
                    string thirdDoorInfo = enMelding.Substring(alarm3Start + 1, alarm3Stopp - alarm3Start);
                    string potMeterData = enMelding.Substring(potmStart + 1, potmStop - potmStart);
                    string logRequestData = enMelding.Substring(logRStart + 1, logRStop - logRStart);

                    var res = new TCPipData()
                    {
                        KorID = Convert.ToInt32(kortID),
                        Pinkode = Convert.ToInt32(pinKode),
                        FirstInfoDoor = Convert.ToBoolean(firstDoorInfo),
                        SecondInfoDoor = Convert.ToBoolean(secondDoorInfo),
                        ThirdInfoDoor = Convert.ToBoolean(thirdDoorInfo),
                        PotMeterInfo = Convert.ToInt32(potMeterData),
                        LogRequestData = Convert.ToBoolean(logRequestData)
                    };
                    return res;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }            
            return default;
        }
        public void Stop()
        {
            _isActive = false;
            _handler.Shutdown(SocketShutdown.Both);
            _handler.Close();
            Debug.WriteLine("Reciever is stopped");
        }
    }
}
