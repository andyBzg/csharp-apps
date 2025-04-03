namespace Aufgabe_Persoenliche_Daten
{
    /*b) Thema: Array
    Der Anwender soll seine persönlichen Daten eingeben:
    Name, Geburtsdatum, Anschrift.
    Jede dieser Informationen soll im gleichen Array vom Datentyp string gespeichert werden.
    Beispiel:
    An Index 0 => Name
    An Index 1 => Geburtsdatum
    An Index 2 => Adresse
    Anschließend sollen die Daten im Array komplett ausgegeben werden.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fragen = { "Name", "Geburtsdatum", "Adresse" };
            string[] userDaten = new string[fragen.Length];
            string? eingabe;

            Console.WriteLine($"Bitte geben Sie Ihre Daten ein: ");
            for (int i = 0; i < fragen.Length; i++)
            {
                Console.Write($"{fragen[i]}: ");
                while (string.IsNullOrEmpty(eingabe = Console.ReadLine()))
                {
                    Console.WriteLine("Fehler: Sie haben keine Eingabe gemacht.");
                    Console.Write($"{fragen[i]}: ");
                }
                userDaten[i] = $"{fragen[i]}: {eingabe}";
            }

            Console.Clear();
            Console.WriteLine("Ihre Daten: \n+++++++++++++++++++");
            foreach (var item in userDaten)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("+++++++++++++++++++");
        }
    }
}
