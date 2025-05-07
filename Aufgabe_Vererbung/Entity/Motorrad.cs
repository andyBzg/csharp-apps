namespace Aufgabe_Vererbung.Entity
{
    internal class Motorrad : Fahrzeug
    {
        public bool HatHelm { get; set; }

        public Motorrad(string name, bool hatHelm) : base(name)
        {
            HatHelm = hatHelm;
        }

        public new void Fahren()
        {
            Console.WriteLine($"Das Motorrad \"{Name}\" fährt mit Geschwindigkeit {Geschwindigkeit} kmh");
        }
    }
}
