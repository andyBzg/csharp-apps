using System.Transactions;

namespace Brauerei_Lösung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variablen
            int anzahl, rabatt = 0;

            // User-Eingabe
            Console.Write("Bitte die Anzahle der Kästen eingeben: ");
            anzahl = int.Parse(Console.ReadLine());

            // Daten berechnen
            if (anzahl >= 100)
            {
                rabatt = 10;
            }
            else if (anzahl >= 50)
            {
                rabatt = 7;
            }
            else if (anzahl >= 10)
            {
                rabatt = 5;
            }

            // Ausgabe
            Console.WriteLine();
            Console.WriteLine("Ihr Rabatt: " + rabatt + "%.");
        }
    }
}
