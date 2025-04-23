namespace Verzweigungen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Verzweigungen sind Wahrheitsabfragen gefolgt von auszuführendem Code

            // Kontrollstruktur mit if-else
            // if (bedingung) {Aktion}
            // else if (alternative bedingung) {Aktion} (Diese wird nur aufgeführen wenn vorgerige Wahrheitsabfragen nicht zutreffen)
            // else {Aktion} (Diese unabhängig von einer Bedingung wird aufgerufen wenn alle vorherigen abfragen scheitern)

            if (true != false)
            {
                Console.WriteLine("Wahr ist nicht falsch");
            }
            else if (false) Console.WriteLine("Wird niemals aufgeführen"); // Wenn es nur eune einzige Aktion gibt können wir in einer Zeile mit der Bedingung schreiben
            else Console.WriteLine("Wird niemals aufgeführen");

            // Kontrollstruktur mit switch-case (Mehrseitiger Fallauswahl)
            // switch (variabel)
            // {
            //      case wert: belibig viele
            //          Aktion
            //          break;
            //      default:
            //          Aktion
            //          break;
            // }

            string wohentag = "Donnerstag";

            switch (wohentag)
            {
                case string x when wohentag == "Donnerstag" || wohentag == "Freitag": // when erlaubt es uns zusätliche logik in einem switch-case anzuweisen
                                                                                      // string x ist hier notwendig um diese als platzhalter variabel zu verwenden

                case "Freitag": // Fall 1
                case "Dienstag": // Fall 2
                    Console.WriteLine("Option 1 trifft zu");
                    break;
                case "Freitag" or "Donnerstag" or "Montag": // Fall 3, 4, 5
                    Console.WriteLine("Option 2 trifft zu");
                    break;
                default:
                    Console.WriteLine("nichts von all dem drifft zu");
                    break;
            }

            // Ternäre operatoren

            // Wir wollen prüfen ob eine Bedingung true odeer false zurückgibt
            // Ternäre Operatoren sind genaugenommen keine Verzweigungen, da sie keine unterschiedlichen aktionspfade lifern sondern einen Rückgabewert

            string farbe = "rot";

            bool abfrage = farbe == "rot" ? true : false; // Hier prüft er ob der string gleich "rot" ist, wenn ja ist die rückgabe true und wenn nicht false
            Console.WriteLine(abfrage); // True

            // Im grunde können wir anstelle von true oder false auch werte platzieren vorausgesetzt die werte stimmen mit dem Datentyp über ein oder
            // Funktion wie Console.ReadLine() => Rückgabe Nullable-string oder "text".Length => Rückgabe int usw ...
            // Im Grunde jede Funktion die nicht void zurückgibt (void bedeutet keine Rückgabe, also keinen Wert der gespecihert werden kann)
            // Console.WriteLine() ist zum Beispiel void bedeutet wir können folgendes nicht tun:
            // string text = Console.WriteLine();

            // Beispiel für Funktion mit Ternären Operatoren:

            string? meinCoolerText = farbe == "grün" ? "Die Farbe ist Grün" : Console.ReadLine(); // Console.ReadLine() gibt einen Nullable-string zurück der in
                                                                                                  // meinerCoolerText gespeichert wird
            Console.WriteLine("die Farbe ist " + meinCoolerText);


            // Ternäre operationen lassen sich auch verschachteln:

            meinCoolerText =
                farbe == "blau" ? "Die Farbe ist Blau" : // wir prüfen hier ist farbe blau, wenn stimmt dann bekommt meinCoolerText den string "Die Farbe ist Blau" zugewiesen ansonsten
                farbe == "grün" ? "Die Farbe ist Grün" : // prüfen wir ob farbe "grün" ist, wenn stimmt bekommt meinCoolerText den string "Die Farbe ist Grün" zugewiesen ansonsten
                farbe == "rot" ? "Die Farbe ist Rot" : "Keine Ahnung was das für eine Farbe ist"; // prüfen wir ob farbe rot ist und würden "Die Farbe ist Rot" zurückgeben wenn das stimmt
                                                                                                  // ansonsten weisen wir den String "Keine Ahnung was das für eine Farbe ist" meinCoolerText zu.

            // Das funktioniert weil Ternäre Operationen einen Rückgabewert erzeugen und alles was ein Rückgabewert erzeugt akann wiederum in einem Ternären Operator   
        }
    }
}
