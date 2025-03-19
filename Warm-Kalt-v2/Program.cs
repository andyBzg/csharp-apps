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
            bool check;
            int versuch;
            int counter = 0;
            int prevDif = 0;

            Random rnd = new Random();
            int random = rnd.Next(1, 101);

            do
            {
                do
                {
                    Console.Write("Geben Sie eine Zahl zwischen 1 und 100 ein: ");
                    check = int.TryParse(Console.ReadLine(), out versuch) && versuch >= 1 && versuch <= 100;
                    if (!check)
                    {
                        Console.Write("Ungültige Eingabe! Geben Sie eine Zahl zwischen 1 und 100 ein: ");
                    }
                }
                while (!check);

                counter++;
                int dif = Math.Abs(random - versuch);

                Console.WriteLine("Try: " + versuch);
                Console.WriteLine("Random: " + random);
                Console.WriteLine("Dif: " + dif);
                Console.WriteLine("PrevDif: " + prevDif);
                Console.WriteLine("Counter: " + counter);

                if (versuch == random)
                {
                    Console.WriteLine(
                            $"Herzlichen Glückwunsch, Sie haben gewonnen! \n" +
                            $"Verschteckte Zahl: {random}\n" +
                            $"Anzahl Versuche: {counter}"
                            );

                    Console.Write("Möchten Sie noch eine Partie spielen? (Y/N): ");
                    string antwort = Console.ReadLine();

                    if (antwort != null && antwort.ToLower().Equals("n"))
                    {
                        break;
                    }
                    else if (antwort != null && antwort.ToLower().Equals("y"))
                    {
                        random = rnd.Next(1, 101);
                        counter = 0;
                        prevDif = 0;
                    }
                }

                if (counter == 1)
                {
                    if (dif <= 15)
                    {
                        Console.WriteLine("Warm");
                    }
                    else
                    {
                        Console.WriteLine("Kalt");
                    }
                }
                else if (prevDif > 0 && dif < prevDif)
                {
                    Console.WriteLine("wärmer");
                }
                else if (prevDif > 0 && dif > prevDif)
                {
                    Console.WriteLine("kälter");
                }
                else if (prevDif > 0 && dif == prevDif)
                {
                    Console.WriteLine("gleich");
                }

                prevDif = dif;
            }
            while (true);

        }
    }
}
