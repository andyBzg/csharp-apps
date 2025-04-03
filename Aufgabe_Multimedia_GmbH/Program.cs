namespace Aufgabe_Multimedia_GmbH
{
    /*c) Thema: if-else
    Die offenen Forderungen der MULTIMEDIA GmbH gegenüber Kunden
    haben ein solches Ausmaß erreicht, dass mittlerweile die eigene
    Zahlungsfähigkeit gefährdet ist. Die Geschäftsleitung ist deshalb
    zum Handeln gezwungen.

    In einer Besprechung wird die Abwicklung des Warenverkaufs neu festgelegt.

    Das Ergebnis wurde stichwortartig im folgenden Protokoll festgehalten:

    Ware wird dem Kunden nur dann auf Rechnung verkauft, wenn sie im Lager
    vorhanden ist und der Kunde bisher seine Rechnungen zuverlässig bezahlt
    hat.
    War das Zahlungsverhalten eines Kunden bisher nicht zuverlässig,
    erhält er Ware nur gegen Barzahlung. Wenn die Ware nicht am Lager ist
    und der Kunde bisher zuverlässig seine Rechnungen gezahlt hat oder
    bar zahlt, wird die Ware bestellt. Andernfalls wird der Kaufantrag
    abgewiesen. 

    Erstellen Sie ein Programm, dass die entsprechenden Daten abfragt:
    - Zahlte der Kunde in der Vergangenheit zuverlässig?
    - Zahlung per Rechnung oder bar?
    - Ist die Ware auf Lager?
    Entsprechend der Antworten, welche der Anwender eingibt, soll die
    Entscheidung über den Verkauf nach obigem Text ausgegeben werden.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            bool istAufLager, istZuverlaessig, istRechnungszahlung;
            string? antwort;
            string falscheEingabe = "Ungültige Eingabe! Bitte geben Sie 'j' oder 'n' ein.";

            while (true)
            {
                Console.Write("Ist die Ware auf Lager? (j/n): ");
                antwort = Console.ReadLine()?.ToLower();

                if (antwort == "j")
                {
                    istAufLager = true;
                    break;
                }
                else if (antwort == "n")
                {
                    istAufLager = false;
                    break;
                }
                else
                {
                    Console.WriteLine(falscheEingabe);
                }
            }

            if (!istAufLager)
            {
                Console.Clear();
                Console.WriteLine("+++++++++++++++++++");
                Console.WriteLine("Die Ware ist nicht auf Lager. Ein Verkauf ist nicht möglich.");
                Console.WriteLine("Die Ware wird bestellt. Der Kaufantrag wurde abgelehnt.");
                Console.WriteLine("+++++++++++++++++++");
            }
            else
            {
                while (true)
                {
                    Console.Write("Hat der Kunde in der Vergangenheit seine Rechnungen zuverlässig bezahlt? (j/n): ");
                    antwort = Console.ReadLine()?.ToLower();

                    if (antwort == "j")
                    {
                        istZuverlaessig = true;
                        break;
                    }
                    else if (antwort == "n")
                    {
                        istZuverlaessig = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(falscheEingabe);
                    }
                }

                while (true)
                {
                    Console.Write("Soll die Zahlung auf Rechnung erfolgen? (j/n): ");
                    antwort = Console.ReadLine()?.ToLower();

                    if (antwort == "j")
                    {
                        istRechnungszahlung = true;
                        break;
                    }
                    else if (antwort == "n")
                    {
                        istRechnungszahlung = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(falscheEingabe);
                    }
                }

                Console.Clear();
                Console.WriteLine("+++++++++++++++++++");
                Console.WriteLine("Ergebnis der Kaufentscheidung:");
                Console.WriteLine("Die Ware ist auf Lager.");

                if (istRechnungszahlung && istZuverlaessig)
                {
                    Console.WriteLine("Verkauf auf Rechnung möglich.");
                }
                else if (!istRechnungszahlung)
                {
                    Console.WriteLine("Bezahlung mit Bar.");
                }
                else if (!istZuverlaessig)
                {
                    Console.WriteLine("Rechnungzahlung nicht möglich. Verkauf nur gegen Barzahlung.");
                }

                Console.WriteLine("+++++++++++++++++++");
            }
        }
    }
}
