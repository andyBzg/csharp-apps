using System;

namespace Wassermelone
{
    internal class Program
    {
        /*Es ist Sommer und sehr warm. Sie befinden sich im Großraum München und sollen ein Programm
        für einen Wassermelonenverkäufer schreiben. Erwartet wird bei allen Eingaben, dass diese
        DAU-sicher sind.

        1. 
        Es sollen die Rechnungen automatisiert werden.
        Sie müssen also den Preis pro Melone und die Anzahl der Bestellmenge eintragen können.
        Am Ende soll der Betrag, den der Kunde zahlen muss, ausgegeben werden. 
        Ab einen Bestellwert von mindestens 5 Melonen soll es 5% Rabatt geben. 
        Ab 10 Melonen 10%.
        Hinweis: Runden Sie den Betrag auf 2 Nachkommastellen, um korrekt einen Preis zu
        simulieren. Schauen Sie Sich Math.Round() dazu an.

        2. 
        Simulieren Sie eine Quittung: Also Preis, Bestellmenge, Datum, Mehrwertsteuer usw.
        Erzeugen Sie ein ansprechendes Ausgabeformat in der Konsole.*/
        static void Main(string[] args)
        {
            // Variblen
            double stueckpreis, nettopreis, preisMitRabatt, mehrwertsteuer, rabatt, endpreis;
            int menge;
            bool check;

            string eingabeMenge = "Bitte geben Sie die Anzahl der Wassermelonen ein: ";
            string eingabeStueckpreis = "Bitte geben Sie den Preis für eine Wassermelone ein: ";
            string falscheEingabe = "Ungültige Eingabe! Bitte geben Sie ein Zahl ein!";

            // Eingabe
            do
            {
                Console.Write(eingabeMenge);
                check = int.TryParse(Console.ReadLine(), out menge) && menge > 0;
                if (!check)
                {
                    Console.WriteLine(falscheEingabe);
                }
            }
            while (!check);

            do
            {
                Console.Write(eingabeStueckpreis);
                check = double.TryParse(Console.ReadLine(), out stueckpreis) && stueckpreis > 0;
                if (!check)
                {
                    Console.WriteLine(falscheEingabe);
                }
            }
            while (!check);

            // Anwendungslogik
            nettopreis = Math.Round(menge * stueckpreis, 2);
            rabatt = BerechneRabatt(menge);
            preisMitRabatt = Math.Round(nettopreis * (1 - rabatt), 2);
            mehrwertsteuer = Math.Round(preisMitRabatt * 0.07, 2);
            endpreis = Math.Round(preisMitRabatt + mehrwertsteuer, 2);

            // Ausgabe
            string quittung = "---------------------------------\n" +
                              "\t\tRECHNUNG\n" +
                              "---------------------------------\n" +
                             $"Anzahl Melonen:\t\t{menge}\n" +
                              "---------------------------------\n" +
                             $"Preis pro Stück:\t{stueckpreis:F2} EUR\n" +
                              "---------------------------------\n" +
                             $"Zwischensumme (Netto):\t{nettopreis:F2} EUR\n" +
                             $"Preis mit Rabatt:\t{preisMitRabatt:F2} EUR\n" +
                             $"MwSt. (7%):\t\t{mehrwertsteuer:F2} EUR\n" +
                              "---------------------------------\n" +
                             $"GESAMT:\t\t\t{endpreis:F2} EUR\n" +
                              "---------------------------------";

            Console.WriteLine(quittung);
        }

        private static double BerechneRabatt(int menge)
        {
            if (menge >= 10) return 0.10;
            else if (menge >= 5) return 0.05;
            else return 0.0;
        }
    }
}
