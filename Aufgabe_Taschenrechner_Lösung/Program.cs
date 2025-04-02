namespace Aufgabe_Taschenrechner_Lösung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variablen
            string eingabe;
            double ersteZahl, zweiteZahl, ergebnis = 0;
            bool check;

            // Begrüssung
            Console.WriteLine("Willkomen zum ultimativen Taschenrechner!");
            Console.WriteLine();

            // Wiederholung des Programs
            do
            {
                // Eingabe der 1. Zahl
                do
                {
                    Console.Write("Bitte geben Sie die 1. Zahl ein: ");
                    eingabe = Console.ReadLine();
                    check = double.TryParse(eingabe, out ersteZahl);

                    if (check == false)
                    {
                        Console.WriteLine("Bitte nur Ziffern eingeben!");
                        Console.WriteLine();
                    }
                }
                while (check == false);

                // Eingabe der 2. Zahl
                do
                {
                    Console.Clear();
                    Console.Write("Bitte geben Sie die 2. Zahl ein: ");
                    eingabe = Console.ReadLine();
                    check = double.TryParse(eingabe, out zweiteZahl);

                    if (check == false)
                    {
                        Console.WriteLine("Bitte nur Ziffern eingeben!");
                        Console.WriteLine();
                    }
                }
                while (check == false);

                // Auswahl der Rechenart: + - * /
                // hier bitet sin ein Menü an (switch)
                do
                {
                    check = true;
                    Console.Clear();
                    Console.WriteLine("Bitte wählen Sie Ihre Rechenart:");
                    Console.WriteLine();
                    Console.WriteLine("(+) Addition");
                    Console.WriteLine("(-) Substraktion");
                    Console.WriteLine("(*) Multiplikation");
                    Console.WriteLine("(/) Division");
                    Console.WriteLine();
                    Console.WriteLine($"1. Zahl: {ersteZahl} / 2. Zahl: {zweiteZahl}");
                    Console.WriteLine("Bitte treffen Sie Ihre Auswahl: ");
                    eingabe = Console.ReadLine();

                    // Berechnung (kann man in switch)
                    Console.WriteLine();
                    switch (eingabe)
                    {
                        case "+":
                            ergebnis = ersteZahl + zweiteZahl;
                            break;
                        case "-":
                            ergebnis = ersteZahl - zweiteZahl;
                            break;
                        case "*":
                            ergebnis = ersteZahl * zweiteZahl;
                            break;
                        case "/":
                            if (zweiteZahl != 0)
                            {
                                ergebnis = ersteZahl / zweiteZahl;
                            }
                            else
                            {
                                check = false;
                                Console.WriteLine("Eine Division durch 0 ist nicht möglich!");
                                Console.WriteLine("Bitte eine andere Rechenart wählen.");
                                Console.WriteLine("Weiter mit belibiger Taste...");
                                Console.ReadKey();
                            }
                            break;
                        default:
                            check = false;
                            Console.WriteLine("Bitte nur Rechenzeichen eingeben");
                            Console.WriteLine("Weiter mit beliebiger Taste...");
                            Console.ReadKey();
                            break;
                    }
                } while (check == false);

                // Ausgabe des Ergebnisses
                Console.Clear();
                Console.WriteLine("Ihr Ergebnis:");
                Console.WriteLine($"{ersteZahl} {eingabe} {zweiteZahl} = {ergebnis}");

                Console.WriteLine("Weiter mit belibiger Taste...");
                Console.ReadKey();
            }
            while (true);
            /* Programmlogik kann der Compiler nicht nachvollziehen, rein vom Syntax 
            * kann der Kompiler nicht sehen, dass wir jetzt die Variable ergebnis  
            * mit einem Wert befüllt haben. 
            * Wir haben geklärt, welche Loop-Bedingung bei 4 möglichen inputs ausgeführt wird,
            * wir haben aber nicht geklärt, welcher Wert ergebniss hat wenn der default im switch
            * ausgeführt wird. Bei falscher eingabe haben wir dann keinen Wert für ergebnis.
            * Die ergebnis-Variable ist nicht befüllt, !!!! Wenn wir Ihr keinen Wert zugewiesen haben
            * versteht der Kompiler nicht, dass wir keinen Wert haben. 
            * Wenn wir also die ausgabe außerhalb des Switch cases haben, können wir den Wert ergebnis 
            * nicht ausgeben, da er logischerweise keinen Wert hat wenn der default Fall eintrifft !!!!
            */
        }
    }
}
