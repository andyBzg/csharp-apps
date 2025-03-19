namespace Variablen_Datentypen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dies ist ein Komentar

            // Variablen & Datentypen => Datenspeicher in RAM, benötigt Datentyp & Bezeichner

            // Variablen-Deklaration
            int zahl;       // int ~ -2,1 Millionen bis 2,1 Millionen
            zahl = 42;      // Initialisierung: Zuweisung erster Wert
            zahl = 21;

            // Numerischen Datentüpen - Ganzzahl
            int i;          // 32-bit Ganzzahl
            short sh;       // 16-bit Ganzzahl
            long l;         // 64-bit Ganzzahl

            // Numerischen Datentüpen ß Gleitkommazahl
            float f;        // 7-8 Stellen: 0,123456 / 1234567
            double d;       // 15 Stellen
            decimal de;     // 28 Stellen

            f = 42.35F;
            d = 42.35;
            de = 42.35M;

            // Zeichen & Zeichenketten
            string s1 = "Hallo Welt!";      // " zeigt den Anfang und das Ende eines strings
            char c = 'x';                   // ' zeigt den Anfang und das Ende eines Zeichnes

            // logischer Datentyp (Wahrheitswert: true oder false)
            bool b1 = true;
            b1 = false;

            // Bezeichner: alle Buchstaben, alle Ziffern, der _, darf nicht mit einer Ziffer beginnen
        }
    }
}
