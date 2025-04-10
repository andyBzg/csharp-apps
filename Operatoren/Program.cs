namespace Operatoren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Logische Operatoren
            // && und
            // || oder
            // !  nicht

            // Vergleichs Operatoren
            // != ungleich
            // == ist gleich
            // >  ist gößer als
            // <  ist kleiner als
            // >= ist größer oder gleich
            // <= ist kleiner oder gleich
            // %  gibt rest einer Division

            Console.WriteLine(true && true); // true beide müssen wahr sein
            Console.WriteLine(true || false);
            Console.WriteLine(true != true); // false weil beide seiten müssen unterschiedlich sein
            Console.WriteLine(!false); // true invertiert wahrheitswerte ins gegenteil
            Console.WriteLine(!false && false); // false weil nicht beide true sind
            Console.WriteLine(!(false && false)); // true weil wir erst in den klammern den wahrheitswert beachten und das ergebnis umdrehen

            Console.WriteLine(5 > 6); // false den das stimmt nicht
            Console.WriteLine((5 > 6) == true); // false weil es false == true ist was nicht stimmt
            Console.WriteLine(false == (5 > 6)); // true weil false == false ist
            Console.WriteLine((false != false) == false); // false != false ist false und false == false ist true
            Console.WriteLine((5 > 6) != (3 > 5)); // false != false ist false

            Console.WriteLine(5 % 2); // Ergebnis 1 weil 2 passt 2x in 5 und rest ist 1
            // Verwendungszweck zb. zum prüfen gerader oder ungerader zahlen 4 % 2 ergibt nicht 0 und ist deshalb ungerade

            // null bedeutet nichts
            int? i = null; // wir haben mit int? einen Nullable integer das bedeutet das dieser integer möglicherweise null sein kann
            Console.WriteLine(i);
            // null bedeutet das wenn wir eine variable im Arbeitspeicher keinen wert zuweisen
            // oben haben wir einen int32, das bedeutet das zur Laufzeit 32 bit im Arbeitspeicher belegt sind
            // diese 32bit werden aber nicht verwendet
            // vor der definition oder wertzuweisung ist eine variable zwangsläufig null
            // mit der zuweisung von = null entfernen wir zb. bestehende werte, unsere speicherreservierung bleibt aber aktiv

            int? y = 25;
            Console.WriteLine(y); // 25
            y = null;
            Console.WriteLine(y);

            // nehmen wir an wir würden über eine Abfrage im Internet machen und würden Wetter daten erwarten in form von doubles
            // Wegen eines Fehler 404 kommen keine Daten an unser Programm speichert also null in die vorgesehenen variablen
            // wenn wir später diese Daten formatieren (Umwandlung in anderen Datentyp oder damit rechnen, dann würde unser Programm abstürzen)

            string? meineDaten = null;
            //Console.WriteLine(meineDaten.Trim()); // Formatierung der Textdaten durch entfernung von Leerzeichen
            // Unser Programm stürtzt ab

            // Mögliches Nullable handling
            // 1
            string handling1;
            if (meineDaten != null)
            {
                handling1 = meineDaten;
            }
            else
            {
                handling1 = "Daten Fehlerhaft";
            }
            Console.WriteLine(handling1);

            // 2
            string handling2 = meineDaten ?? "Daten Fehlerhaft"; // Wenn meineDaten = null sind dann schreibe hier "Daten Fehlerhaft"

            // 3
            Console.WriteLine(meineDaten?.Length); // Wenn neineDaten == null ist dann führe .Length hier nicht aus, sondern gebe einfach null zurück

            meineDaten = "Das sind meine Daten";
            if (meineDaten?.Length == null) Console.WriteLine("Das Ergebnis ist null");
            else
            {
                int? zahl = meineDaten?.Length;
                Console.WriteLine(zahl);
            }
        }
    }
}
