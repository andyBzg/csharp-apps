namespace Aufgabe_Call_By_Value_Reference
{
    //Aufgabe 
    //Erstelle eine Methode die gleichzeitig ref und out verwendet
    //Diese Methode soll eine boolean zurückgeben gleichzeitig einen string infoText initialisieren mit out
    //und als ref eine Liste abrufen mit Inventargegenständen

    //Die Methode soll es uns erlauben einen Heiltrank zu trinken des sich in der Liste befindet 
    //als infotext soll darüber informiert werden ob der Trank konsumiert wurde wenn er vorhanden ist, wenn nicht soll er Sagen das keine Tranke vorhanden sind
    //zudem soll eine int Lebenspunkte intilisiert werden die wenn ein Trank vorhanden ist um 50pts erht wird
    internal class Program
    {
        static void Main(string[] args)
        {
            int lebenspunkte = 25;
            List<string> inventar = new List<string>() { "Heiltrank", "Heiltrank", "Heiltrank" };

            while (true)
            {
                ZeigeZustand(lebenspunkte, inventar);
                FrageNachTrank(ref inventar, ref lebenspunkte);
            }
        }

        private static void FrageNachTrank(ref List<string> inventar, ref int lebenspunkte)
        {
            Console.Write("Drücke \"H\", um einen Heiltrank zu trinken ");

            if (Console.ReadKey().Key == ConsoleKey.H)
            {
                bool istHeiltrankKonsumiert = RegenerationsSchluck(ref inventar, out string info);
                Console.WriteLine();
                ZeigeInfo(info);
                ErhoeheLebenspunkte(ref lebenspunkte, istHeiltrankKonsumiert);
            }
            else
            {
                ZeigeInfo("\nDu hast dich entschieden, keinen Heiltrank zu trinken.");
            }

            WarteSpielerEingabe("Bitte beliebige Taste drücken");
        }

        private static void WarteSpielerEingabe(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ReadKey();
            Console.Clear();
        }

        private static void ZeigeZustand(int lebenspunkte, List<string> inventar)
        {
            Console.WriteLine($"Lebenspunkte: {lebenspunkte} pts");
            Console.WriteLine($"Inventargegenstände: {inventar.Count}");
            Console.WriteLine();
        }

        private static void ZeigeInfo(string info)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(info);
            Console.ResetColor();
        }

        private static void ErhoeheLebenspunkte(ref int lebenspunkte, bool istHeiltrankKonsumiert)
        {
            if (istHeiltrankKonsumiert)
            {
                lebenspunkte += 50;
            }
        }

        private static bool RegenerationsSchluck(ref List<string> inventar, out string infoText)
        {
            string item = "Heiltrank";

            if (inventar.Count == 0)
            {
                infoText = "Das Inventar ist leer";
                return false;
            }
            else if (!inventar.Contains(item))
            {
                infoText = "Keine Tränke vorhanden";
                return false;
            }
            else
            {
                inventar.Remove(item);
                infoText = "Der Trank wurde konsumiert";
                return true;
            }
        }
    }
}
