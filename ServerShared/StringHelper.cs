namespace ComToDatabase
{
    // Klasse for å handtere rå melding fra porten.
    public static class StringHelper
    {
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
        public static bool GetIfInfoDoorLockedUnLocked(string enMelding)
        {
            int posI = enMelding.IndexOf('D');
            if (posI >= 0)
            {
                string tempSomTekst = enMelding.Substring(posI + 5, 1);
                if (tempSomTekst == "0")
                {
                    bool state = false;
                    return state;
                }
                else if (tempSomTekst == "1")
                {
                    bool state = true;
                    return state;
                }
            }
            return false;
        }
        public static bool GetIfInfoDoorClosedOpened(string enMelding)
        {
            int posI = enMelding.IndexOf('D');
            if (posI >= 0)
            {
                string tempSomTekst = enMelding.Substring(posI + 6, 1);
                if (tempSomTekst == "0")
                {
                    bool state = false;
                    return state;
                }
                else if (tempSomTekst == "1")
                {
                    bool state = true;
                    return state;
                }
            }
            return false;
        }
        public static bool GetIfAlarmForNoReason(string enMelding)
        {
            int posI = enMelding.IndexOf('D');
            if (posI >= 0)
            {
                string tempSomTekst = enMelding.Substring(posI + 7, 1);
                if (tempSomTekst == "0")
                {
                    bool state = false;
                    return state;
                }
                else if (tempSomTekst == "1")
                {
                    bool state = true;
                    return state;
                }
            }
            return false;
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
    }
}
