namespace Aufgabe_PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variablen
            Random rnd = new Random();
            string eingabe, password = "";
            int zufall, counter;
            bool check;

            // Array mit Zeichen erstellen
            string[] zeichen = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d",
                "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w",
                "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "!", "#", "$", "%", "&", "(", ")", "*",
                "+", "-", ".", "/", ":", ";", "<", "=", ">", "?", "@", "[", "]", "^", "_", "{", "}", "|", "~" };

            // Abfrage der Passwortlänge
            do
            {
                Console.Write("Wie lange soll Ihr Password sein: ");
                eingabe = Console.ReadLine();
                check = int.TryParse(eingabe, out counter);

                if (check == false)
                {
                    Console.WriteLine("Bitte ein Zahl eingeben!");
                    Console.WriteLine();
                }
            }
            while (check == false);

            // Zufallsgenerator soll die Zeichen aus dem Array auswählen => Passwort zusammenfügen
            for (int i = 0; i < counter; i++)
            {
                zufall = rnd.Next(0, zeichen.Length);
                password += zeichen[zufall];
            }

            // Ausgabe des Passworts
            Console.WriteLine();
            Console.WriteLine($"Ihr Password: {password}");
        }
    }
}
