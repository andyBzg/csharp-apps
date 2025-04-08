using System.Text.Json;

namespace Aufgabe_Kaffeautomat
{
    //Programmiere einen Kaffeeautomaten
    //Der Kaffeeautomat hat eine bestimmte Menge Wasser und eine bestimmte Menge Bohnen.
    //Der Tank sowohl für Bohnen als auch für Wasser hat eine maximale Größe.
    //Die Kaffeemaschine hat ein Menü, in dem man einen Kaffee zubereiten kann.
    //Bei der Zubereitung eines Kaffees wird eine bestimmte Menge an Bohnen und an Wasser verbraucht.
    //Wenn Bohnen oder Wasser nicht mehr ausreichen, wird man dazu aufgefordert, entsprechend Bohnen oder Wasser nachzufüllen.
    //Nach 30 Kaffeeausgaben soll die Maschine eine Entkalkung anfordern.
    //Über das Menü kann man ebenfalls die Anzahl der Kaffees, das Nachfüllen von Zutaten und die letzten Entkalkungen einsehen (diese sollen untereinander aufgelistet werden).
    //Nutze dafür Arrays, Dictionaries und Schleifen, um die Aufgabe umzusetzen.
    //Informiere dich über Thread.Sleep() + DateTime.
    //Die Historie soll in eine JSON-Datei gespeichert werden.

    // Methoden:
    // Menü
    // Kaffee nachfüllen
    // Wasser nachfüllen
    // Kaffee zubereiten
    // Entkalken
    // Historie
    internal class Program
    {
        static void Main(string[] args)
        {
            int index, countKaffeausgaben = 0, maxAusgaben = 30, wasser = 1000, bohnen = 500, maxWasser = 2000, maxBohnen = 1000;
            bool weiter = true;
            string filename = "history.json";
            string[] menue = { "Kaffee zubereiten", "Wasser auffüllen", "Bohnen auffüllen", "Entkalken", "Aktueller Stand", "Historie" };
            Dictionary<string, string> history = new Dictionary<string, string>();

            do
            {
                if (countKaffeausgaben >= maxAusgaben)
                {
                    PrintInRed("Entkalkung ist notwendig! Drücken Sie Enter, um zu starten...");
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        EntkalkenStarten();
                        AddToHistory(history, filename, "Entkalken");
                        countKaffeausgaben = 0;
                    }
                    else
                    {
                        PrintInRed("Weiter ohne Entkalkung...");
                    }
                }

                index = MenueAnzeigen(menue);

                switch (index)
                {
                    case 1:
                        countKaffeausgaben += BereiteKaffeeZu(ref wasser, ref bohnen);
                        AddToHistory(history, filename, "Kaffee zubereiten");
                        break;
                    case 2:
                        WasserAuffuellen(ref wasser, maxWasser);
                        AddToHistory(history, filename, "Wasser auffüllen");
                        break;
                    case 3:
                        BohnenAuffuellen(ref bohnen, maxBohnen);
                        AddToHistory(history, filename, "Bohnen auffüllen");
                        break;
                    case 4:
                        EntkalkenStarten();
                        AddToHistory(history, filename, "Entkalken");
                        break;
                    case 5:
                        StatusAnzeigen(wasser, bohnen, countKaffeausgaben, maxAusgaben);
                        break;
                    case 6:
                        HistoryAnzeigen(filename);
                        break;
                    default:
                        PrintInRed("Unbekannter Fehler...");
                        break;
                }

                Console.WriteLine("Noch einen Kaffee? Drücken Sie Enter...");
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Programm beendet.");
                    weiter = false;
                }

            } while (weiter);
        }

        private static int MenueAnzeigen(string[] menue)
        {
            int index;
            bool check;
            for (int i = 0; i < menue.Length; i++)
            {
                Console.WriteLine($"({i + 1}) {menue[i]}");
            }
            Console.WriteLine();

            do
            {
                Console.Write($"Ihre Wahl (1 - {menue.Length}): ");
                check = int.TryParse(Console.ReadLine(), out index);
            }
            while (!(check && index > 0 && index <= menue.Length));
            return index;
        }

        private static void HistoryAnzeigen(string filename)
        {
            Console.WriteLine("Historie wird angezeigt...");
            string gelesenerText = File.ReadAllText(filename);
            Dictionary<string, string>? geladenesDictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(gelesenerText);
            if (geladenesDictionary != null)
            {
                foreach (var key in geladenesDictionary.Keys)
                {
                    Console.WriteLine($"{key} : {geladenesDictionary[key]}");
                }
            }
        }

        private static void AddToHistory(Dictionary<string, string> history, string filename, string text)
        {
            history.Add(DateTime.Now.ToString(), text);
            string jsonString = JsonSerializer.Serialize(history, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, jsonString);
        }

        private static void PrintInRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void StatusAnzeigen(int wasser, int bohnen, int countKaffeausgaben, int maxAusgaben)
        {
            Console.WriteLine("Aktueller Status wird angezeigt...");
            Console.WriteLine(
                $"Aktueller Status:\n" +
                $"Wassermenge: {wasser} ml\n" +
                $"Bohnenmenge: {bohnen} Gramm\n" +
                $"Noch {maxAusgaben - countKaffeausgaben} Ausgabe(n) bis zur Entkalkung"
                );
        }

        private static void EntkalkenStarten()
        {
            Console.WriteLine("Entkalken wird ausgeführt...");
            int countdown = 5;
            for (int i = countdown; i >= 0; i--)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        private static int NutzerEingabeBearbeiten(string text, int maxWert)
        {
            int menge;
            bool check;
            do
            {
                Console.Write(text);
                check = int.TryParse(Console.ReadLine(), out menge) && menge > 0 && menge <= maxWert;
                if (!check)
                {
                    Console.WriteLine("Ungültige Eingabe, Bitte versuchen Sie es erneut");
                }
            }
            while (!check);
            return menge;
        }

        private static void BohnenAuffuellen(ref int bohnen, int maxBohnen)
        {
            int maxFuellmenge = maxBohnen - bohnen;
            int menge = NutzerEingabeBearbeiten($"Bitte Kaffeebohnenmenge in Gramm eingeben (max {maxFuellmenge}): ", maxFuellmenge);
            bohnen += menge;
            Thread.Sleep(1000);
            Console.WriteLine($"Kaffeebohnen erfolgreich aufgefüllt. Aktueller Stand: {bohnen} Gramm.");
        }

        private static void WasserAuffuellen(ref int wasser, int maxWasser)
        {
            int maxFuellmenge = maxWasser - wasser;
            int menge = NutzerEingabeBearbeiten($"Bitte Wassermenge im Milliliter eingeben (max {maxFuellmenge}): ", maxFuellmenge);
            wasser += menge;
            Thread.Sleep(1000);
            Console.WriteLine($"Wasser erfolgreich aufgefüllt. Aktueller Stand: {wasser} ml.");
        }

        private static int BereiteKaffeeZu(ref int wasser, ref int bohnen)
        {
            if (wasser < 200)
            {
                PrintInRed("Bitte Wasser nachfüllen");
                return 0;
            }
            else if (bohnen < 10)
            {
                PrintInRed("Bitte Bohnen nachfüllen");
                return 0;
            }
            else
            {
                Console.WriteLine("Zubereitung im Fortschritt...");
                wasser -= 200;
                bohnen -= 10;
                Thread.Sleep(3000);
                Console.WriteLine("Kaffee ist fertig!");
                return 1;
            }
        }
    }
}
