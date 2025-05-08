namespace Aufgabe_Abstrakte_Kunde.Model
{
    internal class Firmenkunde : Kunde
    {
        private decimal _prozent = 0.1M;

        public Firmenkunde(string name) : base(name) { }

        public decimal Prozent { get => _prozent; }

        public override decimal BerechneRabatt(decimal betrag)
        {            
            return decimal.Multiply(betrag, Prozent);
        }
    }
}
