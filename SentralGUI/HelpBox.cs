using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace SentralGUI
{
    public partial class SentralGUI_HelpBox : Form
    {
        public SentralGUI_HelpBox()
        {
            InitializeComponent();
            Info();
        }
        public void Info()
        {            
            lb_HelpBox.Items.Add("Format som brukes i 'Rapport Kommando' feltet.");
            lb_HelpBox.Items.Add("");
            lb_HelpBox.Items.Add("Liste brukerdata på grunnlag av brukernavn: [brukernavn]");
            lb_HelpBox.Items.Add("Liste alle innpasseringsforsøk for en dør med ikke godkjent adgang: [romnummer]");
            lb_HelpBox.Items.Add("Liste adgangslogg på grunnlag av brukernavn og dato fra-til: [brukernavn] [dato] [tid]");
            lb_HelpBox.Items.Add("Liste alarmer mellom to datoer fra-til: [fra dato] [fra tid] [til dato] [til tid]");
            lb_HelpBox.Items.Add("Første og siste adgang for et rom: [romnummer]");
            lb_HelpBox.Items.Add("");
            lb_HelpBox.Items.Add("Eksempel på brukernavn: Bruker1");
            lb_HelpBox.Items.Add("Eksempel på romnummer: 1001");
            lb_HelpBox.Items.Add("Format til dato: 2020-01-01");
            lb_HelpBox.Items.Add("Format til tid: 12:00:00");
            lb_HelpBox.Items.Add("");
            lb_HelpBox.Items.Add("I 'Server Kommando'-feltet kan enn skrive inn eigen SQL-kode.");
            lb_HelpBox.Items.Add("Koden må vere på PostgreSQL format.");
            lb_HelpBox.Items.Add("Når koden er skrive inn, trykk på 'Velg Server'-feltet og velg server den skal kommunisere med.");
            lb_HelpBox.Items.Add("");
            lb_HelpBox.Items.Add("For å skru av Hjelp-vinduet, trykk på 'Avbryt'-knappen under 'Rapport Kommando' feltet.");
        }
    }
}
