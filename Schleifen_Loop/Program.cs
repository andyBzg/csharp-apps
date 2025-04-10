namespace Schleifen_Loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Eine Schleife ist ein sich wiederholender Codeabschnitt der solange ausgeführt wird, solange eine bestimmte Bedingung erfüllt ist.

            // Kopfgesteuerte Schleifen (while Schleife)
            //WhileSchleife();

            // Fußgesteuerte Schleife (do-while Schleife)
            //DoWhileSchleife();

            // Zählergesteuerte Schleife (for Schleife)
            ForSchleife();
        }

        private static void ForSchleife()
        {
            // for i
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine(i);
            }

            // Nutzen wir diese Schleife um die einzelnen Buchstaben eines Strings zu ermitteln
            string muster = "Ich bin ein Musterstring";

            for (int i = 0; i < muster.Length; i++)
            {
                Console.Write(muster[i]);
                Thread.Sleep(100);
            }
            Console.WriteLine();

            // foreach
            // Diese Schleife ist vor allem dafür da um durch Elemente durch-zu-iterieren
            foreach (char zeichen in muster) // char zeichen ist unsere platzhalter variabel diese nimmt den wert von der stelle
                                             // an der wir uns wärend der iteration befinden
            {
                Console.Write(zeichen + " ");
                Thread.Sleep(100);
            }            
        }

        private static void DoWhileSchleife()
        {
            // Wird immer mindestens einmal ausgeführt, selbst wenn die Bedingung nicht zutrifft
            int wert = 10;

            do
            {
                Console.WriteLine(wert);
                wert = wert - 1;
            }
            while (wert >= 0);
            Console.WriteLine();
        }

        private static void WhileSchleife()
        {
            // Wird eventuell nie ausgeführt (je nach Bedingung)
            int zahl = 5; // Zähler für unsere Schleife

            while (zahl >= 0) // Kopf der Schleife mit Bedingung
            {
                Console.WriteLine(zahl);
                Thread.Sleep(1000);         // Die Berechnung für 1000ms "schlafen"
                zahl = zahl - 1;
            }
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Diese Schleife bricht ab");
                break; // Eine Schleife kann vorzeitig beendet werden mit dem break-Befehl
            }

            string? eingabe = "";

            while (eingabe != "stop")
            {
                Console.WriteLine("Schleife läuft weiter");

                Console.Write("Gebe stop ein um zu beenden: ");
                eingabe = Console.ReadLine();
            }

            // Man kann Schleifen sehr gut verschachteln zb. um Koordinaten eines Koordinatsystems abzufragen
            int x = 0;
            int y = 0;

            while (y <= 10)
            {
                while (x <= 10)
                {
                    Console.WriteLine($"x:{x}  y:{y}");
                    x++;
                }
                y++;
                x = 0;
            }
        }
    }
}
