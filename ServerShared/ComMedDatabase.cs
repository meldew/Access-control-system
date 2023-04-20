using Npgsql;
namespace ServerShared
{
    // Link til struc i TCP reciever 
    public struct TCPipData
    {
        public int KorID { get; set; }
        public int Pinkode { get; set; }
        public bool FirstInfoDoor { get; set; }
        public bool SecondInfoDoor { get; set; }
        public bool ThirdInfoDoor { get; set; }
        public int PotMeterInfo { get; set; }
        public bool LogRequestData { get; set; }
    }
    // Kommunikasjonsklassen til databasen, alle metodene her kan kommunisere til databasen.
    public class ComMedDatabase
    {
        private NpgsqlConnection con;
        private NpgsqlCommand cmd;
        public ComMedDatabase()
        {
        var cs = "Host=20.56.240.122;Username=#######;Password=######;Database=######";
            con = new NpgsqlConnection(cs);
            con.Open();
            cmd = new NpgsqlCommand();
            cmd.Connection = con;
            UserDatabase();
            CardReaderDatabase();
            ContollAccessDatabase();
        }
        public void SendLogToAccessDatabase(bool res, TCPipData data)
        {
            Random rnd = new Random();
            DateTime time = DateTime.Now;
            var t = $"{time.Year}-{time.Month}-{time.Day} {time.Hour}:{time.Minute}:{time.Second}";
            cmd.CommandText = $"insert into adgangskontroll values (1,{res}, '{t}', {data.KorID});";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"insert into Kortleser values (1,{data.FirstInfoDoor}, {data.SecondInfoDoor},'{t}');";
            cmd.ExecuteNonQuery();
        }
        public bool TestIfDataExists(int pinKode, int kortID)
        {
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT EXISTS(SELECT FROM bruker WHERE kortid = '{kortID}' AND pinkode = '{pinKode}')";
            cmd.ExecuteNonQuery();
            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            bool res = rdr.GetBoolean(0);
            return res;
        }
        private bool TestIfTableExists(string tableName)
        {
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT EXISTS (SELECT FROM information_schema.tables WHERE table_schema = 'public' AND table_name = '{tableName}');";
            cmd.ExecuteNonQuery();
            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            bool res = rdr.GetBoolean(0);
            return res;
        }
        public void AdminCommnado(string commando)
        {
            cmd.CommandText = commando;
            cmd.ExecuteNonQuery();
        }
        public void UserDatabase()
        {
            try
            {
                if (!TestIfTableExists("bruker"))
                {
                    using var cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "CREATE TABLE Bruker( Etternavn VARCHAR(15) NOT NULL, Fornavn varchar(15) NOT NULL, Epost varchar(30) NOT NULL, KortID  int  NOT NULL, Gyldighetsperiode TIMESTAMP NULL, Pinkode  int NOT NULL,PRIMARY KEY (KortID));";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Bruker values ('Bruker1', 'Bruker1', 'Bruker1@stud.hvl.no', 0000, '2020-06-22 19:10:25', 0000);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Bruker values ('Bruker2', 'Bruker2', 'Bruker2@stud.hvl.no', 1111, '2020-06-22 19:10:25', 0001);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Bruker values ('Bruker3', 'Bruker3', 'Bruker3@stud.hvl.no ', 2222, '2020-06-22 19:10:25', 0010);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Bruker values ('Bruker4', 'Bruker4', 'Bruker4@stud.hvl.no', 3333, '2020-06-22 19:10:25', 0011);";
                    cmd.ExecuteNonQuery();
                    cmd.Prepare();
                }
            }
            catch (Exception error)
            {
                Console.Write(error.ToString());
            }
        }
        public string GetInfoFromUserDatabase(string commando)
        {
            try
            {
                string messege = "";
                cmd.CommandText = commando;
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                string namesspace = $"{rdr.GetName(0),-12} {rdr.GetName(1),-10}  {rdr.GetName(2),-20}  {rdr.GetName(3),-14}  {rdr.GetName(4),-15} {rdr.GetName(5),8}\r";
                while (rdr.Read())
                {
                    string list = $"{rdr.GetString(0),-12} {rdr.GetString(1),-10}  {rdr.GetString(2),-20}  {rdr.GetInt32(3),-15}  {rdr.GetTimeStamp(4),-15} {rdr.GetInt32(5),8}\r";
                    messege += list;
                }
                return namesspace + messege;
            }
            catch (Exception error)
            {
                return error.ToString();
            }            
        }
        public void CardReaderDatabase()
        {
            try
            {
                if (!TestIfTableExists("kortleser"))
                {
                    using var cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "CREATE TABLE Kortleser(KortleserNummer int NOT NULL,alarm_dør_åpen BOOL NULL ,alarm_dør_timeout BOOL NULL ,passering TIMESTAMP NOT NULL);";
                    cmd.ExecuteNonQuery();
                    cmd.Prepare();
                }
            }
            catch (Exception error)
            {
                Console.Write(error.ToString());
            }
        }
        public string GetInfoFromCardReaderDatabase(string commando)
        {
            try
            {
                string messege = "";
                cmd.CommandText = commando;
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                string namesspace = $"{rdr.GetName(0),1} {rdr.GetName(1),-10} {rdr.GetName(2),-10} {rdr.GetName(3),1}\r";
                while (rdr.Read())
                {
                    string list = $"{rdr.GetInt32(0),-15} {rdr.GetBoolean(1),-15} {rdr.GetBoolean(2),-12} {rdr.GetTimeStamp(3),1}\r";
                    messege += list;
                }
                return namesspace + messege;
            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }
        public void ContollAccessDatabase()
        {
            try
            {
                if (!TestIfTableExists("adgangskontroll"))
                {
                    using var cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "CREATE TABLE Adgangskontroll(Romnummer int NOT NULL,adgang BOOL NULL ,passering DATETIME NOT NULL,KortID int NOT NULL,PRIMARY KEY (passering));";
                    cmd.ExecuteNonQuery();
                    cmd.Prepare();
                }
            }
            catch (Exception error)
            {
                Console.Write(error.ToString());
            }
        }
        public string GetInfoFromControllAccessDatabase(string commando)
        {
            try
            {
                string messege = "";
                cmd.CommandText = commando;
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                string namesspace = $"{rdr.GetName(0),-8} {rdr.GetName(1),1} {rdr.GetName(2),-10} {rdr.GetName(3),-10}\r";
                while (rdr.Read())
                {
                    string list = $"{rdr.GetInt32(0),-8} {rdr.GetBoolean(1),-8} {rdr.GetTimeStamp(2),-10} {rdr.GetInt32(3),-10}\r";                    
                    messege += list;
                }
                return namesspace + messege;
            }
            catch (Exception error)
            {
                return error.ToString();
            }            
        }
        public string GetListOfUserdataWithSurname(string brukernavn)
        {
            try
            {
                cmd.CommandText = $"select * from Bruker where fornavn = '{brukernavn}'";
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                string namesspace = $"{rdr.GetName(0),1} {rdr.GetName(1),-15} {rdr.GetName(2),-27} {rdr.GetName(3),-10} {rdr.GetName(4),-25} {rdr.GetName(5),10}";
                while (rdr.Read())
                {
                    string list = $"{rdr.GetString(0),1} {rdr.GetString(1),-15} {rdr.GetString(2),-27} {rdr.GetInt32(3),-10} {rdr.GetTimeStamp(4),-20} {rdr.GetInt32(5),7}";
                    string messege = namesspace + "\n" + list + "\n";
                    return messege;
                }
            }
            catch (Exception error)
            {
                return error.ToString();
            }
            return "Empty" + "\n";
        }
        public string GetListWithFailedAccessFromControllAccessDatabase(int kortleserNummer)
        {
            try
            {
                cmd.CommandText = $"select * from Adgangskontroll where dørnummer = {kortleserNummer} and adgang = false";
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                string namesspace = $"{rdr.GetName(0),1} {rdr.GetName(1),10} {rdr.GetName(2),20} {rdr.GetName(3),-10}";
                while (rdr.Read())
                {
                    string list = $"{rdr.GetInt32(0),1} {rdr.GetBoolean(1),14} {rdr.GetTimeStamp(2),31} {rdr.GetInt32(3),-10}";
                    return namesspace + "\n" + list + "\n";
                }
            }
            catch (Exception error)
            {
                return error.ToString();
            }
            return "\n";
        }
        public string TryGetAccessListWithFisrtNameAndBetweenDates(string commando)
        {
            try
            {
                string firstDate = commando.Substring(0, 19);
                string secondDate = commando.Substring(20, 19);
                string name = commando.Substring(39, commando.Length - 39);
                cmd.CommandText = $"SELECT adgangskontroll.romnummer, adgangskontroll.adgang, adgangskontroll.passering, adgangskontroll.kortid, bruker.fornavn FROM adgangskontroll LEFT JOIN bruker ON " +
                    $"adgangskontroll.kortid = bruker.kortid WHERE passering BETWEEN '{firstDate}' AND '{secondDate}' AND fornavn = '{name}'";
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                string namesspace = $"{rdr.GetName(0),-8} {rdr.GetName(1),1} {rdr.GetName(2),-10} {rdr.GetName(3),-10} {rdr.GetName(4),-10}";
                if (rdr.Read())
                {
                    while (rdr.Read())
                    {
                        string list = $"{rdr.GetInt32(0),-8} {rdr.GetBoolean(1),-8} {rdr.GetTimeStamp(2),-10} {rdr.GetInt32(3),-10} {rdr.GetString(4),-10}";
                        string messege = namesspace + "\n" + list + "\n";
                        return messege;
                    }
                }
            }
            catch (Exception error)
            {
                return error.ToString();
            }
            return "Empty Messege" + "\n";
        }
        public string GetListOfAllarmsBetweenToDates(string commando)
        {
            try
            {
                string firstDate = commando.Substring(0, 19);
                string secondDate = commando.Substring(20, 19);
                cmd.CommandText = $"SELECT kortleser.alarm_dør_åpen, kortleser.alarm_dør_timeout FROM kortleser WHERE passering BETWEEN '{firstDate}' AND '{secondDate}'";
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                string namesspace = $"{rdr.GetName(0),1} {rdr.GetName(1),-10}";

                while (rdr.Read())
                {
                    string list = $"{rdr.GetBoolean(0),-15} {rdr.GetBoolean(1),-15}";
                    string messege = namesspace + "\n" + list + "\n";
                    return messege;
                }
            }
            catch (Exception error)
            {
                return error.ToString();
            }
            return "Empty Messege" + "\n";
        }
        public string GetFirstAndLastAccessFromRoom(int kortleserNummer)
        {
            try
            {
                cmd.CommandText = $"SELECT MIN(passering), MAX(passering) FROM adgangskontroll WHERE romnummer = {kortleserNummer}";
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                string namesspace = $"{rdr.GetName(0),1} {rdr.GetName(1),-10}";
                if (rdr.Read())
                {
                    while (rdr.Read())
                    {
                        string list = $"{rdr.GetTimeStamp(0),-15}   {rdr.GetTimeStamp(1),-15}";
                        string messege = namesspace + "\n" + list + "\n";
                        return messege;
                    }
                }
            }
            catch (Exception error)
            {
                return error.ToString();
            }
            return "Empty Messege" + "\n";
        }
        public void ClosePort()
        {
            con.Close();
        }
    }
}
