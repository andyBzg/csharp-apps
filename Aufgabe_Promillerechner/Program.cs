namespace Aufgabe_Promillerechner
{
    /*
    Der User soll angeben können, wieviel Bier in Litern getrunken wurde. 
    Daraus wird die Menge des Reinalkohols in Gramm berechnet.  
    Getrunkene Menge in Milliliter * Alkoholgehalt * Dichte des Ethanols. 

    Bei Bier also: Getrunkene Menge in Milliliter * 0.05 * 0.8 
    Der User soll auch sein Gewicht in Kilogramm angeben.  
    Dann wird der Blutalkoholgehalt in Promille berechnet und auf 2 Nachkommastellen gerundet. 

    (Das bitte selbst Recherchieren) 
    c = A / (0.65*G) 
    c ist der Promillewert, A der aufgenommene Alkohol in Gramm und G das Körpergewicht in kg. 
    Es soll dann eine Ausgabe, abhängig vom Promillewert folgen: 
    bis 0.3: "Noch akzeptabel. Dennoch vorsichtig sein!" 
    bis 0.5: "Achtung! Hände weg vom Steuer." 
    bis 0.8: "Das ist jetzt schon ganz schön ordentlich." 
    ab 0.8: "Kein Kommentar..." 

    Wähle die passenden Datentypen für die jeweils notwendigen Variablen. 
    Etwaige Eingabefehler sollen über einen else-Block abgefangen werden.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            double biermenge, alkoholgehalt = 0.05, dichte = 0.8, promillewert, gewicht, alkohol;
            bool check;


            do
            {
                Console.Write("Bitte Biermenge in Liter eingeben: ");
                check = double.TryParse(Console.ReadLine(), out biermenge);
                if (!check)
                {
                    Console.WriteLine("Fehler: Bitte eine Zahl eingeben!");
                }
                else if (biermenge < 0)
                {
                    Console.WriteLine("Fehler: Bitte eine positive Zahl eingeben!");
                    check = false;
                }
            } while (!check);

            if (biermenge == 0)
            {
                Console.WriteLine("Sie haben nichts getrunken. Kein Promillewert berechnet.");
                return;
            }
            else
            {
                biermenge *= 1000; // Umrechnung in Milliliter
                alkohol = biermenge * alkoholgehalt * dichte; // Alkohol in Gramm
            }

            Console.WriteLine("Bitte geben Sie Ihr Gewicht in Kilogramm ein (zwischen 30 und 300 kg).");
            do
            {
                Console.Write("Bitte Gewicht eingeben: ");
                check = double.TryParse(Console.ReadLine(), out gewicht);
                if (!check)
                {
                    Console.WriteLine("Fehler: Bitte eine Zahl eingeben!");
                }
                else if (gewicht < 0)
                {
                    Console.WriteLine("Fehler: Bitte eine positive Zahl eingeben!");
                    check = false;
                }
                else if (gewicht < 30 || gewicht > 300)
                {
                    Console.WriteLine("Fehler: Bitte ein Gewicht zwischen 30 und 300 kg eingeben!");
                    check = false;
                }
            }
            while (!check);

            // Berechnung des Promillewerts
            promillewert = Math.Round(alkohol / (0.65 * gewicht), 2);
            Console.WriteLine($"Ihr Promillewert beträgt: {promillewert}‰");

            if (promillewert <= 0.3)
            {
                Console.WriteLine("Noch akzeptabel. Dennoch vorsichtig sein!");
            }
            else if (promillewert <= 0.5)
            {
                Console.WriteLine("Achtung! Hände weg vom Steuer.");
            }
            else if (promillewert <= 0.8)
            {
                Console.WriteLine("Das ist jetzt schon ganz schön ordentlich.");
            }
            else
            {
                Console.WriteLine("Kein Kommentar...");
            }
        }
    }
}
