namespace Aufgabe_Schere_Stein_Papier
{
    /*Programmiere ein Schere, Stein, Papier Spiel.  
    Der User soll eines der Handzeichen wählen können. 
    Der Computer wählt per Zufall ein eigenes Zeichen. 
    Dem User wird dann ausgegeben, welches Zeichen der Computer gewählt hat und ob man gewonnen, verloren oder ein Unentschieden hat. 
    Danach kann sich der User entscheiden eine weitere Runde zu spielen, oder nicht. */
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] handzeichen = { "Schere", "Stein", "Papier" };
            bool check, weiterSpielen = true;
            int userEingabe;
            string userHandzeichen, zufall;

            while (weiterSpielen)
            {
                Console.WriteLine("Bitte wählen Sie Handzeichen (1 - 3):");
                for (int i = 0; i < handzeichen.Length; i++)
                {
                    Console.WriteLine($"[{i + 1}] {handzeichen[i]}");
                }

                Console.Write("Ihre Wahl: ");
                check = int.TryParse(Console.ReadLine(), out userEingabe);

                if (check && userEingabe > 0 && userEingabe <= 3)
                {
                    userHandzeichen = handzeichen[userEingabe - 1];
                    zufall = handzeichen[rnd.Next(handzeichen.Length)];

                    if (userHandzeichen == zufall)
                    {
                        Console.WriteLine("Unentschieden!");
                    }
                    else if (userHandzeichen == "Schere" && zufall == "Papier" ||
                            userHandzeichen == "Stein" && zufall == "Schere" ||
                            userHandzeichen == "Papier" && zufall == "Stein")
                    {
                        Console.WriteLine($"Sie haben gewonnen! \nComputer hat {zufall} gewählt.");
                    }
                    else
                    {
                        Console.WriteLine($"Sie haben verloren! \nComputer hat {zufall} gewählt.");
                    }
                }
                else
                {
                    Console.WriteLine("Fehler: Bitte eine Zahl zwischen 1 und 3 eingeben!");
                    return;
                }

                Console.WriteLine("Noch eine Runde? Drücken Sie Enter...");
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Programm beendet.");
                    weiterSpielen = false;
                }
            }
        }
    }
}
