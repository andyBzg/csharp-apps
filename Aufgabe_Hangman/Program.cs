
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
            string str = "";
            Console.WriteLine(str.Length);
            Console.ReadKey();
            //VersionOne();

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

            foreach (var item in galgenteile)
            {
                Console.WriteLine(item);
                Thread.Sleep(1000);
                Console.Clear();
            }
            Console.ReadKey();

            while (true)
            {
                int fehler = 0;
                bool gameover = false;
                string gefundenesWort = "";
                string platzhalter = "";
                Console.Clear();
                Console.WriteLine(ueberschrift);
                Console.Write("Hallo Spieler 1, gebe ein geheimes Wort ein: ");
                string geheim = (Console.ReadLine() ?? "").Trim().ToLower();
                if (geheim == "")
                {
                    Console.WriteLine("Spieler 1 hat nichts eingegeben");
                    break;
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(ueberschrift);
                    for (int i = 0; i < geheim.Length; i++)
                    {
                        if (gefundenesWort.Length == geheim.Length)
                        {
                            if (gefundenesWort[i] == '_')
                            {
                                platzhalter += "_";
                            }
                            else
                            {
                                platzhalter += gefundenesWort[i];
                            }
                        }
                        else
                        {
                            platzhalter += "_";
                            gefundenesWort += "_";
                        }
                        Console.WriteLine(platzhalter + "\n\n");
                        Console.Write("Hey Spieler 2, gebe einen Buchstaben oder das ganze Wort ein: ");
                        string gefunden = (Console.ReadLine() ?? "").Trim().ToLower();


                        if (gefunden == gefundenesWort)
                        {
                            break;
                        }
                        else if (gefunden.Length == 1)
                        {
                            string neuesWort = "";
                            for (int j = 0; j < geheim.Length; j++)
                            {
                                if (geheim[i].ToString() == gefunden)
                                {
                                    neuesWort += gefunden;
                                }
                                else
                                {
                                    neuesWort += "_";
                                }
                            }
                        }


                        platzhalter = "";
                    }
                }
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
            List<char> errateneChars = new List<char>();

            versteckteWort = GetNutzerEingabe("[Spieler 1] \nBitte geben Sie ein Wort ein: ");

            Console.Clear();
            Console.WriteLine(hangman);
            //PrintVersteckteWort(versteckteWort);

            versuch = GetNutzerEingabe("[Spieler 2] \nBitte geben Sie einen Buchstaben ein oder erraten Sie das ganze Wort: ");

            if (versuch.Length > 1)
            {
                if (versuch == versteckteWort)
                    Console.WriteLine("Glückwunsch! Sie haben gewonnen!");
                else
                {
                    Console.WriteLine("You lose. Game over");
                    Console.WriteLine($"Das richtige Wort war: *{char.ToUpper(versteckteWort[0])}{versteckteWort.Substring(1)}*");
                    Console.ReadKey();
                }
            }
            else
            {
                for (int i = 0; i < versteckteWort.Length; i++)
                {
                    if (versteckteWort[i] == Convert.ToChar(versuch))
                        errateneChars.Add(versteckteWort[i]);
                }
            }
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
