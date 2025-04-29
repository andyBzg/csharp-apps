namespace Aufgabe_Parkhaus
{
    internal class Program
    {
        // Aufgabe 
        // Programmiere eine Klasse Auto, diese Klasse soll uns ermöglichen verschiedene Autos zu instazieren
        // Die Klasse soll folgende Felder haben: Farbe, Marke und Kennzeichen
        // Im Anschluss soll Algorithmus geschrieben werden der es uns erlaubt Autos zu erstellen und diese in ein Liste
        // abzuspeichern namens Parkhaus. Diese Liste soll nach dem erstellen des Autos in der Konsole ausgegeben werden.
        static void Main(string[] args)
        {
            List<string> automarken = new List<string>() { "BMW", "Mercedes-Benz", "Audi", "Volkswagen", "Porsche", "Opel", "Ford", "Toyota", "Tesla", "Honda" };
            List<string> farben = new List<string>() { "Rot", "Blau", "Gruen", "Gelb", "Schwarz", "Weiss", "Orange", "Lila", "Braun", "Rosa" };
            List<string> kennzeichen = new List<string>() { "M-AB ", "B-CD ", "S-EF ", "F-GH ", "HH-IJ ", "K-KL ", "D-MN ", "N-OP ", "HB-QR ", "E-ST " };
            List<Auto> parkhaus = new List<Auto>();
            string message = "Wie viele Autos stehen in Ihrem Parkhaus? Menge: ";
            string errorMessage = "Ungültige eingabe";
            int menge;

            menge = BenutzerAbfrage(message, errorMessage);
            parkhaus = ErstelleAutos(menge, automarken, farben, kennzeichen);
            ZeigAutosInParkhaus(parkhaus);
        }

        private static void ZeigAutosInParkhaus(List<Auto> parkhaus)
        {
            parkhaus.ForEach(auto => Console.WriteLine($"{parkhaus.IndexOf(auto) + 1}. {auto.GibAutoDetails()}"));
        }

        private static int BenutzerAbfrage(string message, string errorMsg)
        {
            int menge;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out menge) && menge >= 0)
                    return menge;
                else
                    Console.WriteLine(errorMsg);
            }
        }

        private static List<Auto> ErstelleAutos(int menge, List<string> markenListe, List<string> farbenListe, List<string> kennzeichenListe)
        {
            List<Auto> autos = new List<Auto>();
            string marke, farbe, kennzeichen;

            for (int i = 0; i < menge; i++)
            {
                marke = GibRandomWert(markenListe);
                farbe = GibRandomWert(farbenListe);
                kennzeichen = GibRandomKennzeichen(kennzeichenListe);
                autos.Add(new Auto(marke, farbe, kennzeichen));
            }
            return autos;
        }

        private static string GibRandomWert(List<string> list)
        {
            Random random = new Random();
            int index = random.Next(list.Count);
            return list[index];
        }

        private static string GibRandomKennzeichen(List<string> list)
        {
            Random random = new Random();
            string buchstaben = list[random.Next(list.Count)];
            string ziffern = random.Next(1000).ToString();
            return buchstaben + ziffern;
        }
    }
}
