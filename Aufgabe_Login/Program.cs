namespace Aufgabe_Login
{
    //Erstelle eine Anwendung mit einer Klasse User
    //Diese Klasse hat zwei Felder einmal Benutzername und einmal Passwort
    //Schreibe einen Algrytmus der nach einem Benutzernamen fragt und nach einem Passwort
    //Wenn der User nicht existiert soll falscher Benutzername ausgegeben werden
    //und wenn der User exisiert aber Passwort falsch ist soll falsches Passwort ausgegeben
    //Wenn die Loging Daten Korrekt sind soll Logging erfolgreich ausgegeben werden.
    internal class Program
    {
        static void Main(string[] args)
        {
            string benutzernameAbfrage = "Benutzername: ";
            string passwordAbfrage = "Passwort: ";
            string fehlermeldung = "Du hast nichts eingegeben!";
            string benutzername, passwort;
            List<User> users = new List<User>();

            users = AddTestUsers(users);

            while (true)
            {
                DisplayHeader();
                benutzername = ReadUserInput(benutzernameAbfrage, fehlermeldung);
                passwort = ReadUserInput(passwordAbfrage, fehlermeldung);

                VerifyUserLogin(benutzername, passwort, users);
            }
        }

        private static void VerifyUserLogin(string benutzername, string passwort, List<User> users)
        {
            bool contains = false;

            foreach (var user in users)
            {
                if (user.Username == benutzername)
                {
                    contains = true;
                    if (user.Password != passwort)
                        PrintToConsole("Falsches Passwort!", ConsoleColor.Red);
                    else
                        PrintToConsole("Erfolgreich eingeloggt", ConsoleColor.Blue);
                }
            }

            if (!contains)
                PrintToConsole("Falscher Benutzername!", ConsoleColor.Red);
        }

        private static List<User> AddTestUsers(List<User> users)
        {
            users.Add(new User("Admin", "Password"));
            users.Add(new User("Rick", "qwert123"));

            return users;
        }

        private static string ReadUserInput(string message, string errorMsg)
        {
            string eingabe;
            do
            {
                Console.Write(message);
                eingabe = (Console.ReadLine() ?? "").Trim();

                if (eingabe == "")
                    PrintToConsole(errorMsg, ConsoleColor.Red);

            } while (eingabe == "");
            return eingabe;
        }

        private static void PrintToConsole(string message, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadKey();
            DisplayHeader();
        }

        private static void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine("=== Log in ===");
        }
    }
}
