namespace Aufgabe_Countdown
{
    /*a) Thema: Schleifen
    Erstellen Sie ein Programm, in dem ein Anwender einen Countdown starten kann.
    Zuerst erfolgt eine Eingabe, die die Länge des Countdowns darstellt.
    Danach soll der Countdown von dieser Zahl auf 0 herunter gezählt werden.
    Beispiel:
    Eingabe => 10
    Ausgabe => 10 9 8 7 6 5 4 3 2 1 0
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int countdownStart;

            Console.Write("Bitte geben Sie eine Zahl für den Countdown ein: ");
            bool check = int.TryParse(Console.ReadLine(), out countdownStart);
            
            if (check && countdownStart > 0)
            {
                Console.WriteLine();
                for (int i = countdownStart; i >= 0; i--)
                {
                    Console.Write(countdownStart-- + " ");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("Fehler: Bitte geben Sie eine gültige positive Zahl ein.");
            }
        }
    }
}
