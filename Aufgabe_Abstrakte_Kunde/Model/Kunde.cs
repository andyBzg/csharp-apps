using System.Runtime.CompilerServices;

namespace Aufgabe_Abstrakte_Kunde.Model
{
    abstract class Kunde
    {
        public string Name { get; set; }

        public Kunde(string name)
        {
            Name = name;
        }

        public void Begruessen()
        {
            Console.WriteLine($"Herzlich Willkommen, {Name}! ({GetType().Name})");
        }

        public abstract decimal BerechneRabatt(decimal betrag);
    }
}
