namespace Aufgabe_Wordle
{
    /*Programmieren Sie eine Konsolen-Variante des Spiels
    "Wordle".

    Am Anfang des Spiels wird ein zufälliges Wort, welches
    aus genau 5 Buchstaben besteht vom Spiel ausgewählt.
    (Hierfür wäre eine Liste von Worten mit 5 Buchstaben
    gut, aus der ausgewählt werden kann).

    Danach hat der Spieler maximal 6 Versuche, das Wort
    zu erraten.

    Nach jeder Eingabe wird überprüft, ob die Buchstaben,
    welche der Anwender eingegeben hat, in dem Wort vorkommen
    und ob sie an der richtigen Stelle stehen.

    Buchstaben, welche im gesuchten Wort vorkommen, aber nicht
    an der richtigen Stelle stehen, sollen gelb eingefärbt werden.

    Buchstaben, welche im gesuchten Wort vorkommen und an der
    richtigen Stelle stehen, sollen grün eingefärbt werden.

    Diese Informationen sollen dem Anwender angezeigt werden,
    bevor er ein neues Wort eingibt.

    Ein Beispiel:
    Zu findendes Wort: Salbe
    1. Versuch: Nabel

    Bei diesem Beispiel würde der Buchstabe "a" grün eingefärbt
    werden, da er im gesuchten Wort vorkommt und an 2. Stelle
    steht, wie auch im gesuchten Wort "Salbe".
    Die Buchstaben "b", "e" und "l" würden gelb eingefärbt werden,
    weil sie in "Salbe" vorkommen, aber an der falschen stelle
    stehen.
    Der Buchstabe "N" bleibt wie er ist, da er in "Salbe" nicht
    vorkommt.

    Der Anweder soll auch alle vorherigen Versuche immmer angezeigt
    bekommen (Korrekt eingefärbt).

    Sollte der Anwender das Wort in maximal 6 Versuchen erraten,
    hat er gewonnen, andernfalls nicht.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] woerter =
                {
                    "Salbe", "Blume", "Worte", "Farbe", "Glück", "Traum", "Karte", "Welle", "Sturm", "Licht",
                    "Dampf", "Tisch", "Brand", "Regen", "Stein", "Pferd", "Brot", "Herz", "Schar", "Kranz",
                    "Fisch", "Lager", "Warte", "Maler", "Preis", "Wurst", "Blitz", "Garde", "Kunst", "Spitz"
                };
            char[] randomWortChars, eingabeChars;
            string? eingabe;
            string randomWort;

            randomWort = woerter[rnd.Next(woerter.Length)].ToLower();
            randomWortChars = randomWort.ToCharArray();

            Console.WriteLine("Willkommen zu Wordle!");
            Console.WriteLine("Erraten Sie das 5-buchstabige Wort innerhalb von 6 Versuchen.");
            Console.WriteLine("Grüne Buchstaben sind korrekt platziert, gelbe kommen vor, aber an einer falschen Stelle.\n");

            for (int i = 5; i >= 0; i--)
            {
                while (true)
                {
                    Console.Write("Bitte geben Sie ein Wort ein: ");
                    eingabe = Console.ReadLine()?.ToLower();

                    if (string.IsNullOrEmpty(eingabe))
                    {
                        Console.WriteLine("Fehler: Sie haben nichts eingegeben.");
                    }
                    else if (eingabe.Any(char.IsDigit))
                    {
                        Console.WriteLine("Fehler: Das Wort darf keine Zahlen enthalten.");
                    }
                    else if (eingabe.Length != 5)
                    {
                        Console.WriteLine($"Fehler: Ihr Wort hat {eingabe.Length} Buchstaben. Es muss genau 5 Buchstaben haben.");
                    }
                    else
                    {
                        eingabeChars = eingabe.ToCharArray();
                        break;
                    }
                    Console.WriteLine("Bitte versuchen Sie es erneut...\n");
                }

                if (randomWort == eingabe)
                {
                    Console.WriteLine();
                    Console.WriteLine("Glückwunsch! Sie haben gewonnen!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(char.ToUpper(randomWort[0]) + randomWort.Substring(1));
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }
                else
                {
                    for (int j = 0; j < randomWortChars.Length; j++)
                    {
                        if (randomWortChars[j] == eingabeChars[j])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(j == 0 ? char.ToUpper(eingabeChars[j]) : eingabeChars[j]);
                            Console.ResetColor();
                        }
                        else if (randomWortChars.Contains(eingabeChars[j]))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(j == 0 ? char.ToUpper(eingabeChars[j]) : eingabeChars[j]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(j == 0 ? char.ToUpper(eingabeChars[j]) : eingabeChars[j]);
                        }
                    }

                    if (i > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Verbleibende Versuche: {i}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("You lose. Game over");
                        Console.WriteLine($"Das richtige Wort war: *{char.ToUpper(randomWort[0]) + randomWort.Substring(1)}*");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
