namespace Aufgabe_Wecker
{
    internal class Program
    {
        //Der user soll am anfang gefragt werden auf welche Uhrzeit er seinen weckerstellen möchte
        //Sobald der User bestätigt hat soll das Programm eine Uhr simulieren im format HH:mm:ss
        //sobald entsprechende Zeit ereicht ist soll eine nachricht in der Konsole erscheinen "Der Wecker klingelt"
        //Wichtig Datetime darf nur abgerufen werden am anfang um die uhr zu synchronisieren, danach nicht mehr
        //DateTime.Now.ToString("HH:mm:ss")
        //Arbeitet dafür mit dem befehl Thread.Sleep()
        static void Main(string[] args)
        {            
            Console.Write("Stelle dienen Wecker im Format HH:mm:ss : ");
            string weckzeit = (Console.ReadLine() ?? "").Trim();

            int weckerStunden = int.Parse(weckzeit.Substring(0, 2));
            int weckerMinuten = int.Parse(weckzeit.Substring(3, 2));
            int weckerSekunden = int.Parse(weckzeit.Substring(6, 2));

            if (weckzeit.Length > 8 || weckzeit.Length < 8
                || weckerStunden < 0 || weckerStunden > 23
                || weckerMinuten < 0 || weckerMinuten > 59
                || weckerSekunden < 0 || weckerSekunden > 59)
            {
                Console.WriteLine("Fehlerhafte Uhrzeit\nProgramm wird beendet");
                return;
            }
            else
            {
                Console.WriteLine("Wecker gestellt auf " + weckzeit);
                Thread.Sleep(1000);
            }

            string aktuelleZeit = DateTime.Now.ToString("HH:mm:ss");
            int stunden = int.Parse(aktuelleZeit.Substring(0, 2));
            int minuten = int.Parse(aktuelleZeit.Substring(3, 2));
            int sekunden = int.Parse(aktuelleZeit.Substring(6, 2));

            while (true)
            {
                if (stunden == weckerStunden && minuten == weckerMinuten && sekunden == weckerSekunden) break;

                Console.Clear();
                string stundenStr = stunden > 9 ? stunden.ToString() : "0" + stunden;
                string minutenStr = minuten > 9 ? minuten.ToString() : "0" + minuten;
                string sekundenStr = sekunden > 9 ? sekunden.ToString() : "0" + sekunden;

                Console.WriteLine($"{stundenStr}:{minutenStr}:{sekundenStr}");
                Thread.Sleep(1000);

                sekunden++;
                if (sekunden == 60)
                {
                    sekunden = 0;
                    minuten++;
                }
                if (minuten == 60)
                {
                    minuten = 0;
                    sekunden = 0;
                    stunden++;
                }
                if (stunden == 24)
                {
                    stunden = 0;
                    minuten = 0;
                    stunden = 0;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wäcker klingelt!");
            Console.ResetColor();
        }
    }
}
