namespace Liste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Liste sind ähnlich wie Arrays nur mit dynamischer Größe
            // Zudem sind sie schneller und werden in moderner Programmierung Arrays vorgezogen

            List<string> namen = new List<string> { "Anna", "Bob", "Clara" };

            // Im gegensatz zum Array können wir weitere Werte hinzufügen und unsere Liste vergrößern
            namen.Add("Karl");

            foreach (var item in namen)
            {
                Console.WriteLine(item);
            }

            /* Aufgabe:
            Programmiere in C# nur mit der nutzung von Arrays folgendes:
            In einem Lagersystem hat 100 Plätze. Über ein Menü können wir Bauteile und 
            schrauben über die Konsole in unser Lagersysten eintragen. Wenn ein Lagerplatz bereits belegt ist 
            soll darauf verwiesen werden das element woander zu lagern. Wir können über die Lagerplatznummer uns auch 
            Elemente anfordern die wir dann entfernen können wen wir das wollen. und wir müssen 
            die möglichkeit haben Das Lager auszugeben in der Konsole. */
        }
    }
}
