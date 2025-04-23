namespace Warm_Kalt
{
    /*Schreiben Sie ein Programm, welches das Spiel "Warm oder Kalt" simuliert.

    Das soll wie folgt funktionieren:

    - Das Programm bestimmt eine zufällige ganze Zahl zwischen 1 und 100

    - Der Spieler/Anwender soll diese Zahl nun erraten, indem er eine Zahl
      eingibt

    - nun wird der vorherige Versuch (falls es einen gab, es also nicht der
      erste Versuch war) mit dem aktuellen Versuch verglichen werden:
      - ist man näher dran als bei dem vorherigen Versuch: wärmer
      - ist man weiter weg als bei dem vorherigen Versuch: kälter

    - Errät der Spieler die Zahl, hat er gewonnen

    - Nachdem die Zahl erraten wurde, soll die Anzahl der Versuche ausgegeben
      werden (damit man zu anderen Spielern einen Vergleich hat)

    - Am Ende des Programms soll der Spieler gefragt werden, ob er noch eine
      Partie spielen möchte

    Optional:
    ---------
    - Am Anfang des Programms kann der Spieler auch einen "Hardmode" auswählen.
      Das bedeutet, dass die gesuchte Zahl zwischen 1 und 1000 liegt*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            bool weiterSpielen;

            do
            {
                int versuch, counter = 0;

                Console.Write("Schwierigkeitsgrad auswählen.\nMöchten Sie Hardmode (Zahlen von 1 bis 1000) spielen? (y/n): ");
                bool hardmode = Console.ReadLine()?.ToLower() == "y";
                int maxZahl = hardmode ? 1000 : 100;
                int random = rnd.Next(1, maxZahl + 1);
                int prevDif = maxZahl;

                Console.WriteLine($"Das Spiel beginnt! Erraten Sie eine Zahl von 1 bis {maxZahl}.");

                while (true)
                {
                    while (true)
                    {
                        Console.Write($"Geben Sie eine Zahl zwischen 1 und {maxZahl} ein: ");

                        if (int.TryParse(Console.ReadLine(), out versuch) && versuch >= 1 && versuch <= maxZahl)
                        {
                            break;
                        }
                        Console.Write("Ungültige Eingabe! ");
                    }

                    counter++;
                    int dif = Math.Abs(random - versuch);

                    if (versuch == random)
                    {
                        Console.WriteLine($"Herzlichen Glückwunsch, Sie haben gewonnen! \nVerschteckte Zahl: {random}\nAnzahl Versuche: {counter}");
                        break;
                    }

                    if (counter == 1)
                        Console.WriteLine(dif <= 15 ? "Warm" : "Kalt");
                    else if (prevDif > 0 && dif < prevDif)
                        Console.WriteLine("wärmer");
                    else if (prevDif > 0 && dif > prevDif)
                        Console.WriteLine("kälter");
                    else
                        Console.WriteLine("gleich");

                    prevDif = dif;
                }

                Console.Write("Möchten Sie noch eine Partie spielen? (y/n): ");
                weiterSpielen = Console.ReadLine()?.ToLower() == "y";
            }
            while (weiterSpielen);

            Console.WriteLine("Danke fürs Spiel!");
        }
    }
}
