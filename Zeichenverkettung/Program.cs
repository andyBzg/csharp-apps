namespace Zeichenverkettung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vorname = "Agathe";
            string nachname = "Bauer";

            // Variante 1
            Console.WriteLine("Hallo, " + vorname + " " + nachname + "! Schön, dass Du da bist.");
            
            // Variante 2
            Console.WriteLine("Hallo, {0} {1}! Schön, dass Du da bist.", vorname, nachname);

            // Variante 3
            Console.WriteLine($"Hallo, {vorname} {nachname}! Schön, dass Du da bist.");

            string s1 = string.Format("Hallo, {0} {1}! Schön, dass Du da bist.", vorname, nachname);
            string s2 = $"Hallo, {vorname} {nachname}! Schön, dass Du da bist.";

            // Escape-Sequenzen: \t Tabulator, \n Zeilenumruch, \" " als Zeichen

            Console.WriteLine("Name:\t\tHanz Dampf");
            Console.WriteLine("Geburtstag:\t27.03.1987");

            Console.WriteLine("C:\\Test\\Datei.txt");
            Console.WriteLine(@"C:\Test\Datei.txt");

            Console.WriteLine("Pete \"Maverick\" Mitchell");
        }
    }
}
