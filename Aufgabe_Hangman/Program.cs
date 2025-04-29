
namespace Aufgabe_Hangman
{
    //Programmiere das Spiel Hangman. User 1 soll ein Wort eingeben.
    //User 2 muss danach eine Eingabe machen entweder für einen Buchstaben oder das gesuchte Wort.
    //User 2 Gewinnt wenn er entweder alle Buchstaben oder das richte Wort erraten hat.
    //Ansonsten baut sich der Galgen auf mit folgender Ausgabe als Finale:

    //
    //"  ======||  "
    //"  |     ||  "
    //"  O     ||  "
    //" -x-    ||  "
    //"  x     ||  "
    //" | |    ||  "
    //"        ||  "
    //"============"
    //
    //Ist der Galgen fertig aufgebaut hat User 2 Verloren und User 1 Gewinnt 
    //Am Ende soll eine weitere Spielrunde angeboten werden.

    internal class Program
    {
        static void Main(string[] args)
        {
            //VersionOne();

            VersionTwo();
        }

        private static void VersionTwo()
        {
            string ueberschrift = "====== Hangman ======\n\n";
            List<string> galgenteile = new List<string> { @"
                  #======
                  #     | 
                  #     
                  #     
                  #     
                  #     
                  #     
                  #      
                  #
                ==============" , @"
                  #======
                  #     | 
                  #     @
                  #     ^
                  #     
                  #     
                  #     
                  #      
                  #
                ==============" , @"
                  #======
                  #     | 
                  #     @
                  #     ^
                  #     | 
                  #     ^
                  #     
                  #      
                  #
                ==============" , @"
                  #======
                  #     | 
                  #     @
                  #     ^
                  #   / | 
                  #     ^
                  #     
                  #      
                  #
                ==============" , @"
                  #======
                  #     | 
                  #     @
                  #     ^
                  #   / | \
                  #     ^
                  #     
                  #      
                  #
                ==============" , @"
                  #======
                  #     | 
                  #     @
                  #     ^
                  #   / | \
                  #     ^
                  #    / 
                  #      
                  #
                ==============" , @"
                  #======
                  #     | 
                  #     @
                  #     ^
                  #   / | \
                  #     ^
                  #    / 
                  #   /   
                  #
                ==============" , @"
                  #======
                  #     | 
                  #     @
                  #     ^
                  #   / | \
                  #     ^
                  #    / \
                  #   /   
                  #
                ==============" , @"
                  #======
                  #     | 
                  #     @
                  #     ^
                  #   / | \
                  #     ^
                  #    / \
                  #   /   \
                  #
                =============="
            };

            while (true)
            {
                int fehler = 0;
                bool gameover = false;
                string gefundenesWort = "";
                string platzhalter = "";
                Console.Clear();
                System.Console.WriteLine(ueberschrift);
                System.Console.Write("Hallo Spieler 1 gebe ein geheimes Wort ein: ");
                string geheim = Console.ReadLine() ?? "";
                if (geheim == "")
                {
                    System.Console.WriteLine("Spieler 1 hat nichts eingegeben");
                    break;
                }

                while (true)
                {
                    Console.Clear();
                    System.Console.WriteLine(ueberschrift);

                    if (fehler > 0)
                    {
                        System.Console.WriteLine(galgenteile[fehler - 1]);
                        if (fehler >= galgenteile.Count)
                        {
                            gameover = true;
                            break;
                        }
                    }

                    for (int i = 0; i < geheim.Length; i++)
                    {
                        if (gefundenesWort.Length == geheim.Length)
                        {
                            if (gefundenesWort[i] == '_')
                            {
                                platzhalter += "_";
                            }
                            else platzhalter += gefundenesWort[i];
                        }
                        else
                        {
                            platzhalter += "_";
                            gefundenesWort += "_";
                        }
                    }
                    System.Console.WriteLine(platzhalter + "\n\n");
                    System.Console.Write("Hey Spieler 2 gebe einen Buchstaben oder das ganze Wort ein: ");
                    string gefunden = Console.ReadLine() ?? "";

                    if (geheim.ToLower() == gefunden.ToLower())
                    {
                        gefundenesWort = gefunden;
                        break;
                    }
                    else if (gefunden.Length == 1)
                    {
                        string neuesWort = "";
                        for (int i = 0; i < geheim.Length; i++)
                        {
                            if (geheim[i].ToString().ToLower() == gefunden.ToLower())
                            {
                                if (i == 0) neuesWort += gefunden.ToUpper();
                                else neuesWort += gefunden.ToLower();

                            }
                            else neuesWort += gefundenesWort[i];
                        }
                        if (gefundenesWort == neuesWort) fehler++;
                        gefundenesWort = neuesWort;
                    }
                    else fehler++;

                    platzhalter = "";
                    if (geheim.ToLower() == gefundenesWort.ToLower()) break;
                }

                if (gameover)
                {
                    System.Console.WriteLine("Spieler 2 du hast verloren, Spieler 1 ist der Gewinner!");
                }
                else if (geheim.ToLower() == gefundenesWort.ToLower())
                {
                    System.Console.WriteLine("Speieler 2 du hast gewonnen, Spieler 1 hat verloren!");
                }
                Console.ReadKey();
            }
        }

        private static void VersionOne()
        {
            string hangman = @"                
              #======
              #     | 
              #     @
              #     ^
              #   / | \
              #     ^
              #    / \
              #   /   \
              #
            ==============";
            Console.WriteLine(hangman);

            string? versteckteWort, versuch;

            versteckteWort = GetNutzerEingabe("[Spieler 1] \nBitte geben Sie ein Wort ein: ");
            char[] errateneBuchstaben = new char[versteckteWort.Length];

            do
            {
                Console.Clear();
                Console.WriteLine(hangman);
                Console.Write("Wort: ");
                for (int i = 0; i < errateneBuchstaben.Length; i++)
                {
                    if (errateneBuchstaben[i] == 0)
                        Console.Write(errateneBuchstaben[i]);
                }
                Console.WriteLine();
                Console.ReadLine();

                versuch = GetNutzerEingabe("[Spieler 2] \nBitte geben Sie einen Buchstaben ein oder erraten Sie das ganze Wort: ");

                if (versteckteWort.Length == versuch.Length)
                {
                    if (versuch == versteckteWort)
                        Console.WriteLine("Glückwunsch! Spieler 2 hat gewonnen!");
                    else
                    {
                        Console.WriteLine("Spieler 1 hat gewonnen. Game over");
                        Console.WriteLine($"Das richtige Wort war: *{char.ToUpper(versteckteWort[0])}{versteckteWort.Substring(1)}*");
                        Console.ReadKey();
                    }
                }
                else if (versuch.Length == 1)
                {
                    for (int i = 0; i < versteckteWort.Length; i++)
                    {
                        if (versteckteWort[i] == Convert.ToChar(versuch))
                        {
                            errateneBuchstaben[i] = Convert.ToChar(versuch);
                        }
                    }
                }
            }
            while (true);
        }

        private static string GetNutzerEingabe(string message)
        {
            string? eingabe;
            while (true)
            {
                Console.Write(message);
                eingabe = Console.ReadLine()?.ToLower();

                if (string.IsNullOrEmpty(eingabe))
                {
                    Console.WriteLine("Fehler: Sie haben nichts eingegeben.");
                }
                else if (eingabe.Any(char.IsDigit))
                {
                    Console.WriteLine("Fehler: Das Wort darf keine Zahlen enthalten.");
                }
                else
                {
                    return eingabe;
                }
                Console.WriteLine("Bitte versuchen Sie es erneut...\n");
            }
        }
    }
}
