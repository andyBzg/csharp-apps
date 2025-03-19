namespace Zahlen_In_Worten
{
    internal class Program
    {
        /*Der Anwender soll eine beliebige Zahl zwischen 1-999 eingeben.
        Diese Zahl soll dann als String ausgegeben werden.

        Ein Beispiel:
        Eingabe: 128
        Ausgabe: einhundertachtundzwanzig*/
        static void Main(string[] args)
        {
            int eingabe, hunderterstelle, zehnerstelle, einserstelle;
            bool check;
            string nachricht = "Bitte geben Sie eine beliebige Zahl zwischen 1 und 999 ein: ";
            string falscheEingabe = "Ungültige Eingabe! ";

            string[] einstelligeZahlen = { "", "eins", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun" };
            // 0-9

            string[] zehnerBisNeunzehn = { "zehn", "elf", "zwölf", "dreizehn", "vierzehn", "fünfzehn", "sechzehn", "siebzehn", "achtzehn", "neunzehn" };
            // 10-19

            string[] zehnerZahlen = { "", "", "zwanzig", "dreißig", "vierzig", "fünfzig", "sechzig", "siebzig", "achtzig", "neunzig" };
            // 20-90

            string[] hunderterZahlen = { "", "einhundert", "zweihundert", "dreihundert", "vierhundert", "fünfhundert", "sechshundert", "siebenhundert", "achthundert", "neunhundert" };
            // 100-900

            do
            {
                Console.Write(nachricht);
                check = int.TryParse(Console.ReadLine(), out eingabe) && eingabe >= 1 && eingabe <= 999;
                if (!check)
                {
                    Console.Write(falscheEingabe);
                }
            }
            while (!check);

            hunderterstelle = eingabe / 100;
            zehnerstelle = (eingabe / 10) % 10;
            einserstelle = eingabe % 10;

            if (hunderterstelle > 0)
            {
                Console.Write(hunderterZahlen[hunderterstelle]);
                if (zehnerstelle == 0 && einserstelle == 0)
                {
                    Console.WriteLine();
                    return;
                }
            }

            if (zehnerstelle >= 2)
            {
                if (einserstelle == 1)
                {
                    Console.Write("einund");
                }
                else if (einserstelle > 1)
                {
                    Console.Write(einstelligeZahlen[einserstelle] + "und");
                }
                Console.WriteLine(zehnerZahlen[zehnerstelle]);
            }
            else if (zehnerstelle == 1)
            {
                Console.WriteLine(zehnerBisNeunzehn[(eingabe % 100) - 10]);
            }
            else if (einserstelle > 0)
            {
                Console.WriteLine(einstelligeZahlen[einserstelle]);
            }
        }
    }
}
