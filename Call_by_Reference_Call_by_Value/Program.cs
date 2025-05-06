namespace Call_by_Reference_Call_by_Value
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Call by Value
            CallByValue();

            // Call by Reference
            CallByReference();

            // Beuen einer eigenen Try Parse Methode

            bool TryParseStringToInt(string? meinText, out int zahl)
            {
                zahl = 0;
                if (meinText == null)                
                    return false;                

                try
                {
                    zahl = Convert.ToInt32(meinText.Trim());
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            void Test(bool hatGeklappt, int eingabe)
            {
                if (hatGeklappt)                
                    Console.WriteLine("Deine Eingabe ist eine Zahl: " + eingabe);                
                else                
                    Console.WriteLine("Gebe eine Zahl ein");                
            }

            string stringOhneZahl = "Das ist ein string";
            string stringMitZahl = "321";

            bool hatGeklappt = TryParseStringToInt(stringOhneZahl, out int eingabe);
            Test(hatGeklappt, eingabe);

            hatGeklappt = TryParseStringToInt(stringMitZahl, out eingabe);
            Test(hatGeklappt, eingabe);
        }

        private static void CallByReference()
        {
            // mit ref-Schlüsselwort
            int gehalt = 3600;

            void Zusammenrechnen(ref int x)
            {
                x += 500;
            }

            Zusammenrechnen(ref gehalt);
            Console.WriteLine(gehalt);

            // mit out-Schlüsselwort
            int gehaltZwei;

            void Abzuege(out int summe, int gehalt)
            {
                if (gehalt >= 2500)
                {
                    summe = 500;
                }
                else if (gehalt < 2500 && gehalt >= 1500)
                {
                    summe = 300;
                }
                else
                {
                    summe = 0;
                }
            }

            gehaltZwei = 4400;
            Abzuege(out int summe, gehaltZwei); // "out int summe" Mit der Deklaration einer neuen Variable
            Console.WriteLine($"Es wurden von deinem Gehalt mit {gehaltZwei} Euro folgendes abgezogen: {summe} Euro");

            int gehaltDrei = 1700;
            int abzuege;

            Abzuege(out abzuege, gehaltDrei); // "out abzuege" ohne eine neue Variable zu deklarieren
            Console.WriteLine($"Es wurden von deinem Gehalt mit {gehaltDrei} Euro folgendes abgezogen: {abzuege} Euro");
        }

        private static void CallByValue()
        {
            void Ausgabe(int x)
            {
                x = x + 5;
                Console.WriteLine("Call by Value macht mit a die Ausgabe " + x + " durch die Kopie x");
            }

            int a = 5;
            Ausgabe(a);
            Console.WriteLine("Aber a selber bleibt unverändert also " + a);

            // Beispiel mit Rückgabewert Call by Value wenn wir den Uhrsprungswert überschreiben wollen

            int Ueberschreiben(int x)
            {
                return x = x + 5;
            }

            a = Ueberschreiben(a);
            Console.WriteLine(a);
        }
    }
}
