namespace Aufgabe_ConsoleColor
{
    internal class Program
    {
        // Der User soll gefragt werden welche Farbe die Konsole soll rot, gelb oder blau.
        // Der User kann eine Eingabe machen und das Programm soll dann die Farbe der Konsole ändern
        // Löse diese Aufgabe mit Ternären Operatoren, sollte das nicht funktionieren ist auch eine if-else struktur erlaubt
        static void Main(string[] args)
        {
            Console.WriteLine("Welche Farbe soll die Konsole haben?");
            Console.WriteLine("r/rot");
            Console.WriteLine("g/gelb");
            Console.WriteLine("b/blau");
            Console.Write("Bitte treffen Sie Ihre Wahl: ");

            string eingabe = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (!string.IsNullOrEmpty(eingabe))
            {
                Console.ForegroundColor =
                    eingabe == "r" || eingabe == "rot" ? ConsoleColor.Red :
                    eingabe == "g" || eingabe == "gelb" ? ConsoleColor.Yellow :
                    eingabe == "b" || eingabe == "blau" ? ConsoleColor.Blue :
                    ConsoleColor.White;

                string zusatz = eingabe.Length > 1 ? $"Die Farbe ist jetzt {eingabe}" : "";
                Console.WriteLine($"Herzlichen Glückwunsch! Sie haben die Farbe der Konsole geändert! {zusatz}");
                Console.ResetColor();
            }
            else { Console.WriteLine("Die Farbe der Konsole wurde nicht geändert"); }

            //ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), eingabe);
        }
    }
}
