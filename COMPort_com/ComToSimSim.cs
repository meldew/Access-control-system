using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace COMPort_com
{
    public class ComToSimSim
    {
        
        public void Communication()
        {
            string data = string.Empty;
            try
            {
                port.Open();
            }
            catch (Exception unntak)
            {
                Debug.WriteLine("Feil: " + unntak.Message);
            }
        }
        public static int GetPotmeterData(string enMelding)
        {
            int posI = enMelding.IndexOf('F');
            if (posI >= 0)
            {
                string tempSomTekst = enMelding.Substring(posI + 1, 4);
                int temp = Convert.ToInt32(tempSomTekst);
                return temp;
            }
            return 0;
        }
        public static string GetStringFromMessege(string data, ref string enMelding)
        {
            int posStart = data.IndexOf('$');
            int posSlutt = data.IndexOf('#');

            enMelding = data.Substring(posStart, (posSlutt - posStart) + 1);
            if (posStart > 0) data = data.Substring(posStart);
            if (enMelding.Length < data.Length) data = data.Substring(posSlutt + 1);
            else data = "";
            return data;
        }
        public static bool DataIsMessege(string data)
        {
            bool svar = false;

            int posStart = data.IndexOf('$');
            int posSlutt = data.IndexOf('#');
            if (posStart != -1 && posSlutt != -1)
            {
                if (posStart < posSlutt)
                {
                    svar = true;
                }
            }
            return svar;
        }
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
    }
}

