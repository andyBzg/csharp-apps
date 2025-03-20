using System.Diagnostics.Metrics;

namespace Warm_Kalt_v2
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
            int versuch, maxZahl;
            int counter = 0;
            int prevDif = int.MaxValue;

            Random rnd = new Random();
            int random;

            Console.Write("Schwierigkeitsgrad auswählen.\nMöchten Sie Hardmode (Zahlen von 1 bis 1000) spielen? (y/n): ");
            maxZahl = Console.ReadLine()?.ToLower() == "y" ? 1000 : 100;
            random = rnd.Next(1, maxZahl + 1);

            do
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
                    Console.WriteLine($"Herzlichen Glückwunsch, Sie haben gewonnen!\nVerschteckte Zahl: {random}\nAnzahl Versuche: {counter}");
                    Console.Write("Möchten Sie noch eine Partie spielen? (y/n): ");

                    if (Console.ReadLine()?.ToLower() == "n")
                    {
                        break;
                    }
                    else 
                    {
                        Console.Write("Möchten Sie Hardmode (Zahlen von 1 bis 1000) spielen? (y/n): ");
                        maxZahl = Console.ReadLine()?.ToLower() == "y" ? 1000 : 100;
                        random = rnd.Next(1, maxZahl + 1);
                        counter = 0;
                        prevDif = 0;
                    }
                }

                if (counter == 1)
                {
                    Console.WriteLine(dif <= 15 ? "Warm" : "Kalt");
                }
                else if (prevDif > 0 && dif < prevDif)
                {
                    Console.WriteLine("wärmer");
                }
                else if (prevDif > 0 && dif > prevDif)
                {
                    Console.WriteLine("kälter");
                }

                prevDif = dif;
            }
            while (true);
        }
    }
}
