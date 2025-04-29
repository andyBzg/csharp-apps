using System; // using bezeichnet den Zugriff auf fremde (nicht im Projekt enthaltene) Namespaces
              // also fremde Bibloitheken

namespace Klassen // Namespace ist der Rahmen in dem sich der Code befindet
                  // Theoretisch kann man auch mit mehreren Namespaces ein und das selbe Projekt in mehrere Teile gliedern
                  // In sehr einfachen Projekten ist der Namespace der selbe wie der Projektname.
{
    internal class Kunde // Name der Klasse wir üblicherweise im Singular und PascalCase geschrieben
                         // Die Klasse stellt ein Bauplan also eine Schablone dar und ermöglicht es uns Objekte aufzubauen (zu konstruieren)
                         // Ein Objekt ist eine Instanz der erprechenden Klasse (instanzierung der Prozess der Objekt erstellung ist) 
    {
        // Klassen bestehen aus s.g. Members, diese können verschiedene Strukturen haben

        // Felder - felder

        public int Id; // Feld mit Datentyp int
        public string Vorname;
        public string Nachname;
        public int Alter;

        private int urlaubstage; // Private Felder werden in CamelCase geschrieben.

        // mit Zugriffsmodifikator wie public usw. können wir auf Felder, Methoden und Klassen zugreifen,
        // diese auslesen oder diese zu manipulieren.

        // Die möglichen Zugriffsmodifikatoren sind:
        // public - von überall zugreifen
        // private - nur innerhalb der Klasse zugreifen
        // protected - nur innerhalb der Klasse oder abgeleiteten Klassen zugreifen
        // internal - nur innerhalb des Namespaces zugreifen

        // Eigenschaften werden uns ermöglichen dennoch auf diese Werte zuzugreifen mit get und set

        public Kunde() // Zum Instanzieren eines Objekts muss der Konstruktor aufgerufen werden
        {
            // Code ...
        }

        // Konstruktoren sind dafür da ein Objekt einer Klasse zu erstellen
        //Wenn wir keinen Konstruktor vermerken wird im Hintergrund ein leerer Standart konstruktor generiert

        public Kunde(int id, string vorname, string nachname, int alter) // zweiter Konstruktor
                                                                         // dieser Konstruktor (im gegensatz zum leeren) erwartet Parameter
                                                                         // Diese Parameter werden beim aufruf des Konstruktors als Argumente erwartet
                                                                         // Dieser Konstruktor kann nur aufgerufen werden wenn wir entsprechend Argumente verwenden
        {
            Id = id;
            Vorname = vorname;
            Nachname = nachname;
            Alter = alter;
            // this.Id = id; // Private Felder werden in CamelCase geschrieben.
                             // In diesem Fall verwendet der Konstruktor das Wort „this“, um diese Felder zu initialisieren.
        }

        public void KundenAnzeigen()
        {
            Console.WriteLine($"Id: {Id}\nVorname: {Vorname}\nNachname: {Nachname}\nAlter: {Alter}");
        }
    }
}
