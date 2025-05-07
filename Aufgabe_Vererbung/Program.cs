using Aufgabe_Vererbung.Entity;

namespace Aufgabe_Vererbung
{
    // Aufgabe
    // GTA Fahrzeugsystem

    // Erstelle eine Basisklasse Fahrzeug mit folgenden Eigenschaften und Methoden:
    // Eigenschaften:
    // - Name
    // - Geschwindigkeit
    // Methoden:
    // - Fahren()

    // Erstelle eine Kindklasse Auto, die von Fahrzeug erbt
    // Überschreibe Methode Fahren()
    // Zusätzlich hat diese Klasse eine Methode Hupen()

    // Erstelle eine Kindklasse Motorrad die auch erbt von Fahrzeug
    // Verschtecke die Methode Fahren mit new
    // Füge eine Eigenschaft HatHelm() hinzu

    // Erzeuge zwei Objekte für jede Kindklasse eins
    // Teste auf beiden die Methode Fahren()
    // Teste was bei Hupen passiert
    // Teste was bei der Feldusgabe HatHelm passiert
    internal class Program
    {
        static void Main(string[] args)
        {
            Fahrzeug fahrzeug = new Fahrzeug("Ferrari");
            fahrzeug.Geschwindigkeit = 10;
            fahrzeug.Fahren();
            Console.WriteLine();

            Auto auto1 = new Auto("Bmw");
            auto1.Geschwindigkeit = 100;
            auto1.Fahren();
            auto1.Hupen();
            Console.WriteLine();

            Auto auto2 = new Auto("Audi");
            auto2.Geschwindigkeit = 25;
            auto2.Fahren();
            auto2.Hupen();
            Console.WriteLine();


            Fahrzeug motorrad = new Motorrad("Yamaha", true);
            motorrad.Geschwindigkeit = 150;
            motorrad.Fahren();
            Console.WriteLine();

            Motorrad motorrad1 = new Motorrad("Honda", true);
            motorrad1.Geschwindigkeit = 300;
            motorrad1.Fahren();
            Console.WriteLine($"{motorrad1.Name} hat Helm: {motorrad1.HatHelm}");
            Console.WriteLine();

            Motorrad motorrad2 = new Motorrad("Harley-Davidson", false);
            motorrad2.Fahren();
            Console.WriteLine($"{motorrad2.Name} hat Helm: {motorrad2.HatHelm}");
            Console.WriteLine();
        }
    }
}
