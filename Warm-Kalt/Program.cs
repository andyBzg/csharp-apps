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
            int versuch;
            int differenz = 0;
            int prevDifferenz = -1;
            int counter = 0;
            bool check;

            string antwort = "";

            string nachrichtBisHundert = "Geben Sie eine Zahl zwischen 1 und 100 ein: ";
            //string nachrichtBisTausend = "Geben Sie eine Zahl zwischen 1 und 1000 ein: ";

            Random rnd = new Random();
            int randomZahlBisHundert = rnd.Next(1, 101);
            //Console.WriteLine($"Random: {randomZahlBisHundert}");

            //int randomBisTausend = rnd.Next(1, 1001);
            //Console.WriteLine(randomBisTausend);

            Console.Write(nachrichtBisHundert);

            while (true)
            {
                do
                {
                    Console.WriteLine("Geben Sie ein Zahl ein:");
                    check = int.TryParse(Console.ReadLine(), out versuch) && versuch >= 1 && versuch <= 100;
                    if (!check)
                    {
                        Console.Write($"Ungültige Eingabe! {nachrichtBisHundert}");
                    }
                }
                while (!check);

                if (versuch == randomZahlBisHundert)
                {
                    Console.WriteLine(
                        $"Herzlichen Glückwunsch, Sie haben gewonnen! \n" +
                        $"Verschteckte Zahl: {randomZahlBisHundert}\n" +
                        $"Anzahl Versuche: {counter + 1}"
                        );

                    versuch = 0;
                    differenz = 0;
                    prevDifferenz = 0;
                    counter = 0;

                    Console.Write("Möchten Sie noch eine Partie spielen? (Y/N): ");
                    antwort = Console.ReadLine();
                    if (antwort != null && antwort.ToLower().Equals("n"))
                    {
                        break;
                    }
                    else if (antwort != null && antwort.ToLower().Equals("y"))
                    {
                        versuch = 0;
                        differenz = 0;
                        prevDifferenz = 0;
                        counter = 0;
                        antwort = "";
                        randomZahlBisHundert = rnd.Next(1, 101);
                        Console.Write(nachrichtBisHundert);
                    }
                }

                differenz = Math.Abs(randomZahlBisHundert - versuch);

                if (counter == 0)
                {
                    if (differenz < 20)
                    {
                        Console.WriteLine("Warm");
                    }
                    else
                    {
                        Console.WriteLine("Kalt");
                    }
                }
                else if (differenz < prevDifferenz)
                {
                    Console.WriteLine("wärmer");
                }
                else if (differenz > prevDifferenz)
                {
                    Console.WriteLine("kälter");
                }
                else
                {
                    Console.WriteLine("gleich");
                }

                counter++;
                prevDifferenz = differenz;
            }
        }
    }
}
