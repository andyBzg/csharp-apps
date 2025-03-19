namespace Schleifen_Loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kopfgesteuerte Schleifen (while-Schleife)
            // Wird eventuell nie ausgeführt (je nach Bedingung)
            int zahl = 5;

            while (zahl >= 0)
            {
                Console.WriteLine(zahl);
                Thread.Sleep(1000);         // Die Berechnung für 1000ms "schlafen"
                zahl = zahl - 1;
            }
            Console.WriteLine();

            // Fußgesteuerte Schleife
            // Wird immer mindestens einmal ausgeführt, selbst wenn die bedingung nicht zutrifft
            int wert = 10;

            do
            {
                Console.WriteLine(wert);
                wert = wert - 1;
            }
            while (wert >= 0);
            Console.WriteLine();

            // Zählergesteuerte Schleife (for-Schleife)
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
