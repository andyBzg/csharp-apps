
namespace Aaufgabe_Taschenrechner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool weiterRechnen = true;
            double zahl1, zahl2;
            int index;
            bool check;

            // Begrüssung
            Console.WriteLine("******************************");
            Console.WriteLine(" Willkommen beim Taschenrechner! ");
            Console.WriteLine(" Geben Sie zwei Zahlen ein und wählen Sie eine Operation. ");
            Console.WriteLine("******************************");

            do
            {
                // Eingabe der 1. Zahl
                zahl1 = ZahlEingabe("Bitte geben Sie 1. Zahl ein: ");

                // Eingabe der 2. Zahl
                zahl2 = ZahlEingabe("Bitte geben Sie 2. Zahl ein: ");

                // Auswahl der Rechnerart: + - * /
                // Hier bietet sich ein Menü an (switch)
                Console.WriteLine("Auswahl der Recherart: ");
                Console.WriteLine("[1] +");
                Console.WriteLine("[2] -");
                Console.WriteLine("[3] *");
                Console.WriteLine("[4] /");

                do
                {
                    Console.Write("Bitte Rechenart auswählen: ");
                    check = int.TryParse(Console.ReadLine(), out index);
                }
                while (!(check && index > 0 && index <= 4));

                // Berechnung (kann man im switch)
                // Ausgabe des Ergebnisses
                switch (index)
                {
                    case 1:
                        Console.WriteLine($"Ergebnis: {zahl1 + zahl2}");
                        break;
                    case 2:
                        Console.WriteLine($"Ergebnis: {zahl1 - zahl2}");
                        break;
                    case 3:
                        Console.WriteLine($"Ergebnis: {zahl1 * zahl2}");
                        break;
                    case 4:
                        if (zahl2 == 0)
                            Console.WriteLine("Teilen durch 0 nicht möglich");
                        else
                            Console.WriteLine($"Ergebnis: {zahl1 / zahl2}");
                        break;
                    default:
                        Console.Write("Kein Recherart ausgewählt.");
                        break;
                }

                Console.Write("Möchten Sie fortsetzen? (y/n): ");
                weiterRechnen = Console.ReadLine()?.ToLower() == "y";
                Console.Clear();
            }
            while (weiterRechnen);

            Console.WriteLine("******************************");
            Console.WriteLine(" Danke für die Nutzung des Rechners! ");
            Console.WriteLine(" Auf Wiedersehen und einen schönen Tag! ");
            Console.WriteLine("******************************");

            // (x) optional: Das Programm wird dauernd wiederholt
            // (x) optional: DAU-Sicherheit der Eingaben
            // (x) optional: Sicherstellen, dass eine Berechnung mathematisch möglich ist

            // (-) super-optional: Korrekte Berechnung mit 3 Zahlen:
            // Beachten Sie Punkt-vor-Strich
        }

        private static double ZahlEingabe(string text)
        {
            double zahl;
            do
            {
                Console.Write(text);
            }
            while (!double.TryParse(Console.ReadLine(), out zahl));
            return zahl;
        }
    }
}
