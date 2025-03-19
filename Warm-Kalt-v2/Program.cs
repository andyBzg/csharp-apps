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
            string spielmodus;
            int maxZahl = 100;

            Random rnd = new Random();
            int random = rnd.Next(1, 101);

            Console.Write("Schwierigkeitsgrad auswählen. \n" +
                "Möchten Sie Hardmode (Zahlen von 1 bis 1000) spielen? (y/n): ");
            spielmodus = Console.ReadLine();
            
            if (spielmodus != null && spielmodus.ToLower().Equals("y"))
            {
                random = rnd.Next(1, 1001);
                maxZahl = 1000;
            }

            do
            {
                do
                {
                    Console.Write($"Geben Sie eine Zahl zwischen 1 und {maxZahl} ein: ");
                    check = int.TryParse(Console.ReadLine(), out versuch) && versuch >= 1 && versuch <= maxZahl;
                    if (!check)
                    {
                        Console.Write($"Ungültige Eingabe! ");
                    }
                }
                while (!check);

                counter++;
                int dif = Math.Abs(random - versuch);

                if (versuch == random)
                {
                    Console.WriteLine(
                            $"Herzlichen Glückwunsch, Sie haben gewonnen! \n" +
                            $"Verschteckte Zahl: {random}\n" +
                            $"Anzahl Versuche: {counter}"
                            );

                    Console.Write("Möchten Sie noch eine Partie spielen? (y/n): ");
                    string antwort = Console.ReadLine();

                    if (antwort != null && antwort.ToLower().Equals("n"))
                    {
                        break;
                    }
                    else if (antwort != null && antwort.ToLower().Equals("y"))
                    {
                        Console.Write("Möchten Sie Hardmode (Zahlen von 1 bis 1000) spielen? (y/n): ");
                        spielmodus = Console.ReadLine();
                        if (spielmodus != null && spielmodus.ToLower().Equals("y"))
                        {
                            random = rnd.Next(1, 1001);
                            maxZahl = 1000;
                        }
                        else
                        {
                            random = rnd.Next(1, 101);
                            maxZahl = 100;
                        }
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
