using System.IO.Ports;
using Timer = System.Windows.Forms.Timer;
using TCP_Server;
using System.Diagnostics;
using System.Text.RegularExpressions;
using ComToDatabase;

namespace CardReaderGUI
{
    public partial class CardReader_GUI : Form
    {
        public const string COMPORT = "COM8";
        public const int COMSPEED = 9600;

        Timer loginTimer = new Timer();
        SerialPort sp = new SerialPort(COMPORT, COMSPEED);
        Sender send = new Sender();

        Timer communicationTimer;

        bool communicate;
        string enMelding;
        string data;

        private int counter;
        private int KortId;
        private int pinkode;
        private bool logRequest;

        public CardReader_GUI()
        {
            InitializeComponent();

            CardReader_txtCardID.TextChanged += CardReader_txtCardID_TextChanged;
            Kortleser_TekstPINkode.TextChanged += Kortleser_TekstPINkode_TextChanged;
            CardReader_TimeLeftTimer.Enabled = true;

            Kortleser_DørLukket.BackColor = Color.White;
            Kortleser_DørÅpen.BackColor = Color.White;
            Kortleser_Alarm.BackColor = Color.White;

            CounterLabel.Text = "45";
            Kortleser_TekstPINkode.Enabled = false;
            CardReader_txtCardID.Enabled = false;

            //CardReader_AccessButton_Click(null, null);
            StartCommunicationTimer();
            StartComWithSimSim();
            InitLoginTimer();
        }
        // Kommunikasjon med Porten
        private void StartComWithSimSim()
        {
            communicate = true;
            try
            {
                sp.Open();
            }
            catch (Exception unntak)
            {
                MessageBox.Show("Feil: " + unntak.Message);
            }
            if (sp.IsOpen)
            {
                SendMessegeToSimSim(sp, "$O41");
            }
        }
        //Sender informasjon til sentralen
        private void StartCommunicationTimer()
        {
            communicationTimer = new Timer();
            communicationTimer.Interval = 1000;
            communicationTimer.Tick += async (_, _) =>
            {
                bwSerialCommunication.RunWorkerAsync();
                var msg = BuildMessage();
                if (!string.IsNullOrEmpty(msg))
                    await send.SendMessageAsync(msg);
            };
            communicationTimer.Start();
        }
        // Bygger melding til Sentralen
        private string BuildMessage()
        {
            string melding = "$O51";
            if (string.IsNullOrEmpty(enMelding))
            {
                return null;
            }
            bool firstInfo = StringHelper.GetIfInfoDoorLockedUnLocked(enMelding);
            bool secondInfo = StringHelper.GetIfInfoDoorClosedOpened(enMelding);
            bool thirdInfo = StringHelper.GetIfAlarmForNoReason(enMelding);            
            if (secondInfo)
            {
                Kortleser_DørLukket.BackColor = Color.Lime;
                Kortleser_DørÅpen.BackColor = Color.White;
                if (sp.IsOpen)
                {
                    SendMessegeToSimSim(sp, melding);
                }                
            }
            else
            {
                Kortleser_DørLukket.BackColor = Color.White;
                Kortleser_DørÅpen.BackColor = Color.Yellow;                
            }
            if (thirdInfo && secondInfo)
            {
                Kortleser_DørLukket.BackColor = Color.Lime;
                Kortleser_DørÅpen.BackColor = Color.Yellow;
            }
            if (thirdInfo) { Kortleser_Alarm.BackColor = Color.Red; }
            var msg = $"$I{KortId}P{pinkode}A{firstInfo}B{secondInfo}C{thirdInfo}" +
                $"D{StringHelper.GetPotmeterData(enMelding)}R{logRequest}L#";
            return msg;
        }
        // Parser Kort Id
        private void CardReader_txtCardID_TextChanged(object? sender, EventArgs e)
        {
            if (!int.TryParse(CardReader_txtCardID.Text, out KortId)) { }
        }
        // Parser Pinkode
        private void Kortleser_TekstPINkode_TextChanged(object? sender, EventArgs e)
        {
            if (!int.TryParse(Kortleser_TekstPINkode.Text, out pinkode)) { }
        }
        // Intren timer
        private void InitLoginTimer()
        {
            counter = 46;
            loginTimer.Interval = 1000;
            loginTimer.Tick += new EventHandler(Timer_Tick);            
        }
        // timer Event
        private void Timer_Tick(object sender, EventArgs e)
        {            
            if (counter == 0)
            {
                SendMessegeToSimSim(sp, "$O40");
                CardReader_txtCardID.Enabled = false;
                Kortleser_TekstPINkode.Enabled = false;                
                CardReader_LoginButton.Enabled = false;
                counter = 46;
                loginTimer.Enabled = false;
                CardReader_txtCardID.Clear();
                Kortleser_TekstPINkode.Clear();
                InformationListBox.Items.Clear();
                CounterLabel.Text = CounterLabel.Text = counter.ToString();
            }
            counter--;
            CounterLabel.Text = counter.ToString();
        }        
        private void CardReader_ResetButton_Click(object sender, EventArgs e)
        {
            counter = 46;
            loginTimer.Enabled = false;
            CounterLabel.Text = "45";
            Kortleser_Alarm.BackColor = Color.White;
        }
        private void CardReader_AccessButton_Click(object sender, EventArgs e)
        {


            loginTimer.Enabled = true;
            CardReader_txtCardID.Enabled = true;
            Kortleser_TekstPINkode.Enabled = true;
            CardReader_LoginButton.Enabled = true;
        }
        private async void CardReader_LoginButton_Click(object sender, EventArgs e)
        {
            communicationTimer.Stop();
            logRequest = true;
            var msg = BuildMessage();
            var res = await send.SendMessageAsync(msg);
            logRequest = false;
            communicationTimer.Start();
            if (pinkode.ToString().Length > 0)
            {
                string star = "*";
                string showStars = "";
                for (int i = 0; i < pinkode.ToString().Length; i++)
                {
                    showStars += star;
                }
                if (res)
                {
                    InformationListBox.Items.Add("Card_ID:      pinCode:      Access:");
                    InformationListBox.Items.Add($"{KortId}               {showStars}                Granted");
                }
                else
                {
                    InformationListBox.Items.Add("Card_ID      pinCode      Access");
                    InformationListBox.Items.Add($"{KortId}               {showStars}              Denied");
                }
            }
        }
        // Leser melding fra Porten
        public static string GetMessege(SerialPort sp)
        {
            string svar = "";
            try
            {
                svar = sp.ReadExisting();
            }
            catch (Exception unntak)
            {
                Debug.WriteLine("Feil: " + unntak.Message);
            }
            return svar;
        }
        //Sende melding til ComPort
        public void SendMessegeToSimSim(SerialPort s, string melding)
        {
            try
            {
                s.Write(melding);
            }
            catch (Exception unntak)
            {
                Kortleser_Alarm.BackColor = Color.Red;
                Debug.WriteLine("Feil: " + unntak.Message);
            }
        }
        // BW somm kjører Com metodene i bakrunnen.
        private void bwSerialCommunication_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool enHelMeldingMotatt = false;
            enMelding = "";
            while (communicate && !enHelMeldingMotatt)
            {
                data = data + GetMessege(sp);
                if (StringHelper.DataIsMessege(data))
                {
                    data = StringHelper.GetStringFromMessege(data, ref enMelding);
                    enHelMeldingMotatt = true;
                }
            }
        }
        private void bwSerialCommunication_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            StringHelper.GetPotmeterData(enMelding);
            StringHelper.GetIfInfoDoorLockedUnLocked(enMelding);
            StringHelper.GetIfInfoDoorClosedOpened(enMelding);
            StringHelper.GetIfAlarmForNoReason(enMelding);

            bwSeriellKommunikasjon.RunWorkerAsync(enMelding);
        }
    }
}