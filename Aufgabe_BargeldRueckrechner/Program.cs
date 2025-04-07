namespace Aufgabe_BargeldRueckrechner
{
    /*Der Computer soll einen zufälligen Geldbetrag Ausgeben.
     * Der User soll angeben im nächsten Schritt wie viel Geld er hat.
     * Der Computer soll danach in Scheinen und Münzen ausgeben die Differenz zwischen dem Betrag des Computers und des Users.
     * 
     * Beispiel:
     * Computer gibt ab : 455,00 Euro
     * User macht eingabe 1000,00 Euro
     * Ausgabe:     1 x 500 Euroschein
     *              2 x 20 Euroscheine
     *              1 x 5 Euroschein
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal eurobetrag, centbetrag, benutzerGeld, differenz;
            int euroteil, centteil;
            int[] scheine = { 500, 200, 100, 50, 20, 10, 5 };
            int[] muenzen = { 50, 20, 10, 5, 2, 1 };
            bool weiter = true;
            Random rnd = new Random();

            Console.WriteLine("Willkommen bei der Wechselgeld-Rechner-App!");
            Console.WriteLine("Geben Sie Ihren Betrag in Euro ein (z.B. 123.45), und die App zeigt Ihnen, wie das Wechselgeld in Scheinen und Münzen ausgegeben wird.");
            Console.WriteLine("Drücken Sie beliebege Taste um fortzufahren...");
            Console.ReadKey();

            do
            {
                eurobetrag = rnd.Next(5000);
                centbetrag = rnd.Next(100);
                eurobetrag += centbetrag / 100;

                Console.WriteLine($"Computer gibt ab: {eurobetrag} Euro");

                Console.Write("Wie viel Geld haben Sie? ");
                benutzerGeld = Convert.ToDecimal(Console.ReadLine());

                differenz = benutzerGeld - eurobetrag;

                if (differenz < 0)
                {
                    Console.WriteLine("Sie haben nicht genug Geld!");
                    return;
                }

                Console.WriteLine($"Differenz ist: {differenz}");

                euroteil = (int)Math.Floor(differenz);
                decimal nachKomma = differenz % 1;
                centteil = (int)(nachKomma * 100);

                Console.WriteLine("Sie bekommen folgendes Wechselgeld:");
                Console.WriteLine("Euro Scheine:");

                for (int i = 0; i < scheine.Length; i++)
                {
                    int anzahlScheine = euroteil / scheine[i];
                    int abgedeckterBetrag = anzahlScheine * scheine[i];

                    if (euroteil / scheine[i] > 0)
                    {
                        Console.WriteLine($"{anzahlScheine} x {scheine[i]} Euro");
                        euroteil = euroteil - abgedeckterBetrag;
                    }
                }

                if (euroteil > 0)
                {
                    Console.WriteLine("Euro-Münzen:");

                    if (euroteil / 2 > 0)
                    {
                        Console.WriteLine(euroteil / 2 + " x 2 Euro");
                        euroteil = euroteil - (euroteil / 2) * 2;
                    }
                    if (euroteil / 1 > 0)
                    {
                        Console.WriteLine(euroteil / 1 + " x 1 Euro");
                        euroteil = euroteil - (euroteil / 1) * 1;
                    }
                }

                if (centteil > 0)
                {
                    Console.WriteLine("Cent-Münzen:");
                    for (int i = 0; i < muenzen.Length; i++)
                    {
                        int anzahlMuenzen = centteil / muenzen[i];
                        int abgedeckterBetrag = anzahlMuenzen * muenzen[i];

                        if (centteil / muenzen[i] > 0)
                        {
                            Console.WriteLine($"{anzahlMuenzen} x {muenzen[i]} Cent");
                            centteil = centteil - abgedeckterBetrag;
                        }
                    }
                }

                Console.Write("Möchten Sie fortsetzen? (y/n): ");
                weiter = Console.ReadLine()?.ToLower() == "y";
                Console.Clear();
            } while (weiter);
        }
    }
}
