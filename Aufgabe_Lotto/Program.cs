﻿namespace Aufgabe_Lotto
{
    internal class Program
    {
        /*Schreiben Sie ein Lottoprogramm (6 aus 49)

        Erstellen sie eine Klasse "Lotto":
        Dieses soll ein Array enthalten, das zufallsbasiert 6 Gewinnzahlen beinhaltet.
        (Nutzen Sie dazu ein random-Objekt).

        Nun sollte der Anwender 6 Zahlen aus 49 auswählen, die mit den Gewinnzahlen
        verglichen werden müssen und es ausgegeben wird, wieviele "Richtige" er hat.

        Zu beachtende Schritte:
        1. User-Eingaben der 6 getippten Zahlen => Speicherung in einem Array
        2. 6 zufällige Zahlen zwischen 1 und 49 "ziehen" => Speicherung in einem neuen Array
        3. Vergleich der getippten und gezogenen Zahlen => Speicherung der Anzahl der "Richtigen"
        4. Ausgabe der gezogenen Zahlen, der getippten Zahlen und der Anzahl der "Richtigen"*/
        static void Main(string[] args)
        {
            // Variablen
            Random rnd = new Random();
            int[] userEingabe = new int[6];
            int[] gewinnzahlen = new int[6];
            bool check;
            int neueZahl, richtige = 0;

            // Begrüssung: Lotto 6 aus 49
            Console.WriteLine("**************************************");
            Console.WriteLine("* Willkommen beim Lotto 6 aus 49! *");
            Console.WriteLine("* Tippe deine Glückszahlen und prüfe *");
            Console.WriteLine("* wie viele Treffer du hast! *");
            Console.WriteLine("**************************************");

            // Eingabe der 6 Zahlen des Users & Speicherung in einem Array
            for (int i = 0; i < userEingabe.Length; i++)
            {
                do
                {
                    Console.Write($"Bitte geben Sie {i + 1}. Zahl ein: ");
                    check = int.TryParse(Console.ReadLine(), out userEingabe[i]);
                    if (!check)
                    {
                        Console.WriteLine("Fehler: Bitte ein Zahl eingeben!");
                    }
                    else if (userEingabe[i] < 1 || userEingabe[i] > 49)
                    {
                        Console.WriteLine("Fehler: Nur Zahlen zwischen 1 und 49 sind erlaubt!");
                        check = false;
                    }
                    else if (userEingabe.Take(i).Contains(userEingabe[i]))
                    {
                        Console.WriteLine("Fehler: Diese Zahl wurde bereits eingegeben!");
                        check = false;
                    }
                }
                while (!check);
            }

            // 6 Zufallszahlen erzeugen & Speicherung in einem anderen Array
            for (int i = 0; i < gewinnzahlen.Length; i++)
            {
                do
                {
                    neueZahl = rnd.Next(1, 50);
                } while (gewinnzahlen.Contains(neueZahl));
                gewinnzahlen[i] = neueZahl;
            }

            // Vergleich der Zahlen und Ermittlung der Anzahl der "Richtigen"
            foreach (var item in gewinnzahlen)
            {
                foreach (var item1 in userEingabe)
                {
                    if (item == item1)
                    {
                        richtige++;
                    }
                }
            }

            // Ausgabe: Gezogene Zahl, getippten Zahlen, Anzahl "Richtige"
            Console.Clear();
            Console.Write("Gezogene Zahlen: ");
            foreach (var item in gewinnzahlen)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Getippten Zahlen: ");
            foreach (var item in userEingabe)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine($"Anzahl \"Richtige\": {richtige}");
        }
    }
}
