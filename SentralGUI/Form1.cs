using Npgsql;
using ServerShared;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Schema;
using TCP_Server;
using Timer = System.Windows.Forms.Timer;

namespace SentralGUI
{
    public partial class SentrallVindu : Form
    {
        SentralGUI_HelpBox helpBox = new SentralGUI_HelpBox();
        ComMedDatabase com = new ComMedDatabase();
        private NpgsqlCommand cmd;
        Reciever reciever = new Reciever();
        Timer loginTimer = new Timer();

        private int doorTimer;
        private int counter;
        private int doorNumber = 1;

        public SentrallVindu()
        {
            InitializeComponent();

            reciever.MessageRecieved += Reciever_MessageRecieved;
            RapportComboBox.SelectedIndexChanged += RapportComboBox_SelectedIndexChanged;
            ServerComboBox.SelectedIndexChanged += ServerComboBox_SelectedIndexChanged;
            reciever.Start();

            timer1.Enabled = false;
            this.FormClosed += (_, _) => reciever.Stop();
            Timer();
            ChooseListToReport();
            ChooseServerMethod();

            rapportTextBox.Enabled = false;
            SendRapportKommando.Enabled = false;
            AvbrytRapportKommando.Enabled = false;

            adminTextBox.Enabled = false;
            SendAdminKommando.Enabled = false;
            AvbrytAdminKommando.Enabled = false;
        }
        // Intern timer
        private void Timer()
        {
            counter = 0;
            loginTimer.Interval = 1000;
            loginTimer.Tick += new EventHandler(Timer_Tick);
        }
        // Intern timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
        }
        // Event for mottak av meldinger fra Kortleseren
        private void Reciever_MessageRecieved(bool res, TCPipData data)
        {
            try
            {
                if (data.LogRequestData)
                {
                    com.SendLogToAccessDatabase(res, data);
                }
                if (data.PotMeterInfo > 500)
                {
                    AlarmVindu.Items.Add("Dør Brutt Opp");
                }
                else
                {
                    AlarmVindu.Items.Add("Dør ok");
                }
                if (!data.SecondInfoDoor)
                {
                    loginTimer.Enabled = true;
                }
                else
                {
                    loginTimer.Enabled = false;
                    doorTimer = 0;
                }
                if (counter >= 20 && !data.SecondInfoDoor)
                {
                    AlarmVindu.Items.Add("Dør åpen for lenge");
                }
                else if (data.SecondInfoDoor)
                {
                    counter = 0;
                    loginTimer.Enabled = false;
                }
                else
                {
                    AlarmVindu.Items.Add("Dør TimOut status: OK");
                }
                AlarmVindu.TopIndex = AlarmVindu.Items.Count - 1;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error Code : " + error);
            }
        }
        private void ServerComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            adminTextBox.Enabled = true;
            SendAdminKommando.Enabled = true;
            AvbrytAdminKommando.Enabled = true;
        }
        private void RapportComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            SendRapportKommando.Enabled = true;
            rapportTextBox.Enabled = true;
            AvbrytRapportKommando.Enabled = true;
        }
        // Valg av rapporter
        void ChooseListToReport()
        {
            RapportComboBox.Items.Add("Listebrukerdata på grunnlag av brukernavn");
            RapportComboBox.Items.Add("Listealle innpasseringsforsøk foren dør med ikke-godkjent adgang(uansett bruker)");
            RapportComboBox.Items.Add("Listeadgangslogg (inkludert forsøk på adgang)på grunnlag av brukernavn og datoer fra –til");
            RapportComboBox.Items.Add("Liste av alarmer mellom to datoer");
            RapportComboBox.Items.Add("For et rom: første og siste adgang («brukstid») (for dager det har vært i bruk)");

        }
        // Valg av Server å rapportere til
        void ChooseServerMethod()
        {
            ServerComboBox.Items.Add("User Database");
            ServerComboBox.Items.Add("Card reader Database");
            ServerComboBox.Items.Add("Controll Access Database");
            ServerComboBox.Items.Add("Admin Commando");
        }
        //Frontend : 
        private void SendRapportKommando_Click(object sender, EventArgs e)
        {
            try
            {

                if (RapportComboBox.SelectedItem == "Listebrukerdata på grunnlag av brukernavn")
                {
                    string data = com.GetListOfUserdataWithSurname(rapportTextBox.Text);
                    ServerVindu.Text += data;
                }

                if (RapportComboBox.SelectedItem == "Listealle innpasseringsforsøk foren dør med ikke-godkjent adgang(uansett bruker)")
                {
                    string data = com.GetListWithFailedAccessFromControllAccessDatabase(Convert.ToInt32(rapportTextBox.Text));
                    ServerVindu.Text += data;
                }

                if (RapportComboBox.SelectedItem == "Listeadgangslogg (inkludert forsøk på adgang)på grunnlag av brukernavn og datoer fra –til")
                {
                    string data = com.TryGetAccessListWithFisrtNameAndBetweenDates(rapportTextBox.Text);
                    ServerVindu.Text += data;
                }
                
                if (RapportComboBox.SelectedItem == "Liste av alarmer mellom to datoer")
                {
                    string data = com.GetListOfAllarmsBetweenToDates(rapportTextBox.Text);
                    ServerVindu.Text += data;
                }

                if (RapportComboBox.SelectedItem == "For et rom: første og siste adgang («brukstid») (for dager det har vært i bruk)")
                {
                    
                    string data = com.GetFirstAndLastAccessFromRoom(Convert.ToInt32(rapportTextBox.Text));
                    ServerVindu.Text += data;
                }
            }
            catch (Exception error)
            {
                AlarmVindu.Items.Add(error.ToString());
            }

        }
        private void AvbrytRapportKommando_Click(object sender, EventArgs e)
        {
            RapportComboBox.ResetText();
            rapportTextBox.Clear();
            rapportTextBox.Enabled = false;
            SendRapportKommando.Enabled = false;
            AvbrytRapportKommando.Enabled = false;
            ServerVindu.Clear();
            AlarmVindu.Items.Clear();
            helpBox.Hide();
        }
        private void SendAdminKommando_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServerComboBox.SelectedItem == "User Database")
                {
                    string data = com.GetInfoFromUserDatabase(adminTextBox.Text);
                    ServerVindu.Text += data;
                }
                if (ServerComboBox.SelectedItem == "Card reader Database")
                {
                    string data = com.GetInfoFromCardReaderDatabase(adminTextBox.Text);
                    //Informasjonsvidu.Text += data;
                    ServerVindu.Text += data;
                }
                if (ServerComboBox.SelectedItem == "Controll Access Database")
                {
                    string data = com.GetInfoFromControllAccessDatabase(adminTextBox.Text);
                    ServerVindu.Text += data;
                }
                if (ServerComboBox.SelectedItem == "Admin Commando")
                {
                    com.AdminCommnado(rapportTextBox.Text);
                }
            }
            catch (Exception error)
            {
                AlarmVindu.Items.Add(error.ToString());
            }
        }
        private void AvbrytAdminKommando_Click(object sender, EventArgs e)
        {
            ServerComboBox.ResetText();
            adminTextBox.Clear();
            ServerVindu.Clear();
            adminTextBox.Enabled = false;
            SendAdminKommando.Enabled = false;
            AvbrytAdminKommando.Enabled = false;

        }
        private void HjelpKommando_Click(object sender, EventArgs e)
        {
            helpBox.ControlBox = false;
            AvbrytRapportKommando.Enabled = true;
            helpBox.Show();
        }
    }
}