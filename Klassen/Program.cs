namespace Klassen
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            Kunde kunde = new Kunde(); // Instanzierung eines Objekts der Klasse Kunde mit dem leeren Konstruktor
                                        // kunde1 ist eine Variable die einen leeren "Kunden" beinhaltet

            Kunde kunde2 = new Kunde(1, "Max", "Musterman", 30);
            Kunde kunde3 = new Kunde(1, "Max", "Musterman", 30);

            Console.WriteLine(kunde2 == kunde3); // False, weil jedes Objekt ein separater Block im Speicher ist.
            Console.WriteLine();

            Console.WriteLine(kunde2.Id);
            Console.WriteLine(kunde2.Vorname);
            Console.WriteLine(kunde2.Nachname);
            Console.WriteLine(kunde2.Alter);
            Console.WriteLine();

            Kunde kunde4 = new Kunde(2, "Michael", "Lutz", 25);

            kunde3.KundenAnzeigen();
            Console.WriteLine();
            kunde4.KundenAnzeigen();
            Console.WriteLine();          

            // call by value, call by reference, overriding 
        }
    }
}
