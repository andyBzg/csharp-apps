namespace Aufgabe_Abstrakte_Kunde.Model
{
    internal class KundenEintrag
    {
        public Kunde Kunde { get; set; }
        public decimal Betrag { get; set; }

        public KundenEintrag(Kunde kunde, decimal betrag)
        {
            Kunde = kunde;
            Betrag = betrag;
        }
    }
}
