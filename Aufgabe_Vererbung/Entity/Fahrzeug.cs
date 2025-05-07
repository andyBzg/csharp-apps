namespace Aufgabe_Vererbung.Entity
{
    internal class Fahrzeug
    {
        public string Name { get; set; }
        public int Geschwindigkeit { get; set; } = 0;

        public Fahrzeug(string name)
        {
            Name = name;
        }

        public virtual void Fahren()
        {
            Console.WriteLine("Das Fahrzeug fährt");
        }
    }
}
