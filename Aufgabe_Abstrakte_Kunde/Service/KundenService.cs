using Aufgabe_Abstrakte_Kunde.Model;

namespace Aufgabe_Abstrakte_Kunde.Service
{
    internal class KundenService
    {
        public static Kunde ErstelleKunde(string name, bool istFirmenkunde)
        {
            if (istFirmenkunde)
                return new Firmenkunde(name);
            else
                return new Privatkunde(name);
        }

        public static void ZeigeKundenRabatte(List<KundenEintrag> kunden)
        {
            foreach (var eintrag in kunden)
            {
                eintrag.Kunde.Begruessen();
                decimal rabatt = eintrag.Kunde.BerechneRabatt(eintrag.Betrag);
                ZeigeErgebnis(eintrag.Betrag, rabatt);
                Console.WriteLine();
            }
        }

        private static void ZeigeErgebnis(decimal summe, decimal rabatt)
        {
            Console.WriteLine($"Der Rabatt ab einem Betrag von {summe} Euro beträgt {rabatt} Euro");
        }
    }
}
