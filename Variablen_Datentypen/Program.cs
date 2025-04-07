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
            double d;       // 15 Stellen | hat Rundungsfehler, da er nicht alle Stellen speichern kann
            decimal de;     // 28 Stellen | wird für Geldbeträge verwendet, da er keine Rundungsfehler hat

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

            byte b;         // 0-255
            sbyte sb;       // s steht für signed, -128 bis 127

            short sh2;      // 16-bit Ganzzahl, min -32.768, max 32.767
            ushort ush;     // u steht für unsigned, 0-65.535

            int i2;         // 32-bit Ganzzahl, min -2.147.483.648, max 2.147.483.647
            uint ui;        // 0-4.294.967.295

            long l2;        // 64-bit Ganzzahl, min -9.223.372.036.854.775.808, max 9.223.372.036.854.775.807
            ulong ul;       // 0-18.446.744.073.709.551.615

            // Sonstige
            bool istWahr = true; // 2 Zustände : 1 Bit

            char zeichen = 'A'; // 2 Byte, 16 Bit, Unicode

            string wort = "Hallo"; // Die Größe bemisst sich nach dem Inhalt des Strings | 2 Byte pro Zeichen, 16 Bit pro Zeichen, Unicode
        }
    }
}
