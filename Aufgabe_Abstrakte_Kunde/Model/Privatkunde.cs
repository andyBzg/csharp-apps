namespace Aufgabe_Abstrakte_Kunde.Model
{
    internal class Privatkunde : Kunde
    {
        private decimal _prozent = 0.05M;

        public Privatkunde(string name) : base(name) { }

        public decimal Prozent { get => _prozent; }

        public override decimal BerechneRabatt(decimal betrag)
        {
            return decimal.Multiply(betrag, Prozent);
        }
    }
}
