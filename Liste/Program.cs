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

            List<string> list = new List<string>(5); // Die anfängliche Größe der Liste wird in Klammern angegeben

            int[] array = new int[10];
            List<int> ints = new List<int>(array);

            // Typle
            var daten = ("Sport", 16, true);
            (string name, int alter, bool anwesend) test = ("Anna", 17, true);
        }
    }
}
