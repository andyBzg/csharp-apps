namespace Aufgabe_Vererbung.Entity
{
    internal class Auto : Fahrzeug
    {
        public Auto(string name) : base(name) { }

        public override void Fahren()
        {
            Console.WriteLine($"Das Auto \"{Name}\" fährt mit Geschwindigkeit {Geschwindigkeit} kmh");
        }

        public void Hupen()
        {
            Console.WriteLine($"Das Auto \"{Name}\" hupt");
            Console.Beep();
        }
    }
}
