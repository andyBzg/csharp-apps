using System.Security.Cryptography.X509Certificates;

namespace Methoden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Methoden (in C#) oder auch Funktion genant
            // In C# werden wiederverwendbere Codeabschnitte in sogenannten Methoden geschrieben
            // Normalerweise sind Methoden Teil von Klassen und müssen diesen zugeordnet sein, weil C#
            // eine Objektorientierte Sprache ist.

            // Lokale Methoden.
            // Statische Methoden sind Methoden, die ohne Objekt aufgerufen werden können
            // Lokale Methoden sind statische Methoden, die innerhalb einer anderen Methoden existieren

            // Bestandteile
            // (Zugriffsmodifikator (z.B. public, private, protected, ...)) (wird bei lokalen Methoden nicht benutzt)
            // static (wenn es eine statische Methode sein soll) bedeutet der Aufruf funktioniert ohne Objekt
            // Rückgabewert ist ein Wert, der zurückgegeben wird, wir müssen den Datentyp dieses Wertes festlegen (int, string, double, ...)
            // Wenn die Angabe "void" ist, dann sagen wir das es keine Rückgabe gibt
            // Bezeichner (Methodenname) immer in PascalCase
            // Parameter z.B. (int a, int b, string x)
            // Methodenkörper in {} der zu ausführende Code

            // Zugriffsmodifikator static Rückgabewert Bezeichner (Parameter) 
            // {
            //    Code ...
            // }

            // Beispiel. Lokale Methode
            /*public static*/
            int Addieren(int zahl1, int zahl2)
            {
                int ergebnis = zahl1 + zahl2;
                return ergebnis;
            }

            int meineZahl = Addieren(8, 9);
            Console.WriteLine(meineZahl);

            void Substrahieren(int zahl1, int zahl2)
            {
                int ergebnis = zahl1 - zahl2;
                Console.WriteLine(ergebnis);
            }

            Substrahieren(6, 2); // Die Methode gibt zwar text in der Konsole aus hat aber keinen Rückgabewert
                                 // bedeutet: wir können nicht mit dem Ergebnis der Rechnung arbeiten

            // Rückgabewert != Konsolenausgabe
            //int nochEineZahl = Substrahieren(6, 2); Das Funktioniert nicht, weil die Methode nichts zurückgibt

            //AufgabeEins();
            //AufgabeZwei();

        }

        private static void AufgabeZwei()
        {
            // Aufgabe 2
            // Der User soll Name, Nachname und Alter eingeben können
            // Schreibe eine Methode die einen String zurückgibt mit diesen Informationen
            // Im Anschluss soll der String benutzt werden um den User zu fragen ob die Informationen richtig sind

            Console.Clear();

            string FrageNameAb(string msg)
            {
                string eingabe;
                do
                {
                    Console.Write(msg);
                    eingabe = (Console.ReadLine() ?? "").Trim();
                    if (string.IsNullOrEmpty(eingabe))
                        Console.WriteLine("Ungültige Eingabe");
                } while (string.IsNullOrEmpty(eingabe));
                Console.Clear();
                return eingabe;
            }

            int FrageAlterAb(string msg)
            {
                int eingabe;
                bool check;
                do
                {
                    Console.Write(msg);
                    check = int.TryParse(Console.ReadLine(), out eingabe) && eingabe > 0;
                    if (!check)
                        Console.WriteLine("Ungültige Eingabe. Versuchen Sie es Erneut");
                } while (!check);
                Console.Clear();
                return eingabe;
            }

            string ErstelleEinString(string vorname, string nachname, int alter)
            {
                return $"Vorname: {vorname} , Nachname: {nachname} , Alter: {alter}";
            }

            string vorname = FrageNameAb("Bitte geben Sie Ihren Vornamen ein: ");
            string nachname = FrageNameAb("Bitte geben Sie Ihren Nachnamen ein: ");
            int alter = FrageAlterAb("Bitte geben Sie Ihr Alter ein: ");

            string benutzerdaten = ErstelleEinString(vorname, nachname, alter);
            Console.Write($"Ihre Eingabe \n{benutzerdaten} \nSind diese Informationen korrekt? (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine("Daten wurden gespeichert ...");
            }
            else
            {
                Console.WriteLine("Weiter ohne speicherung ...");
            }
            Console.ReadKey();
        }

        private static void AufgabeEins()
        {
            // Aufgabe 1
            // Schreibe eine Lokale Methode, die eine Ganzzahl entgegen nimmt und prüft ob es sich dabei um eine
            // gerade oder ungerade Zahl handelt.

            bool IstGerade(int zahl)
            {
                return zahl % 2 == 0 ? true : false;
            }

            int zahl1 = 55;
            int zahl2 = 8;

            Console.WriteLine("==== Gerade / Ungerade ====");
            Console.WriteLine($"{zahl1}: {IstGerade(zahl1)}");
            Console.WriteLine($"{zahl2}: {IstGerade(zahl2)}");

            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            list.ForEach(x => Console.WriteLine(x % 2 == 0 ? $"{x} ist gerade" : $"{x} ist ungerade"));
        }
    }
}
