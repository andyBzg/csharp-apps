namespace Schaltjahr
{
    internal class Program
    {
        /*Weil die astronomische Dauer eines Jahres (wenn die Erde die Sonne einmal umrundet
        hat) etwas länger ist als 365 Tage, wurden Schaltjahre zum Ausgleich eingeführt.

        Ein Schaltjahr ist ein Jahr, welches eine Jahreszahl hat, die durch 4 teilbar ist.
        Jahreszahlen, die durch 100 teilbar sind, sind allerdings keine Schaltjahre. Es sei denn,
        die Jahreszahl ist durch 400 teilbar.

        Erstellen Sie ein Struktogramm für ein Programm, welches prüft, ob eine eingegebene
        Jahresziffer ein Schaltjahr ist oder nicht und anschließend eine entsprechende Antwort
        ausgibt.*/
        static void Main(string[] args)
        {
            // Variablen
            int jahr;
            bool check;
            string eingabe = "Bitte geben Sie eine Jahreszahl ein: ";
            string falscheEingabe = "Ungültige Eingabe! Bitte geben Sie ein Zahl ein.";

            // Eingabe
            do
            {
                Console.Write(eingabe);
                check = int.TryParse(Console.ReadLine(), out jahr);
                if (!check)
                {
                    Console.WriteLine(falscheEingabe);
                }
            }
            while (!check);

            // Logik/Ausgabe
            if (jahr % 400 == 0 || (jahr % 4 == 0 && jahr % 100 != 0))
            {
                Console.WriteLine($"{jahr} ist Schaltjahr.");
            }
            else
            {
                Console.WriteLine($"{jahr} ist kein Schaltjahr.");
            }
        }
    }
}
