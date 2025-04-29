namespace Aufgabe_Hangman_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void Ueberschrift()
            {
                Console.Clear();
                Console.WriteLine("====== HANGMAN ======\n");
            }

            string LeseSpielerEingabe(string message)
            {
                string eingabe;
                do
                {
                    Console.Write(message);
                    eingabe = (Console.ReadLine() ?? "").Trim();
                    if (eingabe == "")
                    {
                        Console.WriteLine("Du hast nichts eingegeben!");
                    }
                } while (eingabe == "");
                return eingabe.ToLower();
            }

            void ZeigeErratenesWort(char[] chars)
            {
                Console.Write("Geheimes Wort: ");
                for (int i = 0; i < chars.Length; i++)
                {
                    if (i == 0)
                        Console.Write(char.ToUpper(chars[i]));
                    else
                        Console.Write(chars[i]);
                }
                Console.WriteLine("\n");
            }

            void ZeigeFalscheBuchstaben(List<string> buchstaben)
            {
                Console.Write("Falsche Buchstaben: ");
                buchstaben.ForEach(b => Console.Write(b + " "));
                Console.WriteLine("\n");
            }

            string BuildCorrectWord(char[] buchstaben)
            {
                return string.Join("", buchstaben);
            }

            void ZweiteSpielerGewonnen(string wort)
            {
                Console.WriteLine("Herzlichen Glückwunsch! Spieler 2 hat gewonnen!");
                ZeigeErratenesWort(wort.ToArray());
                Console.ReadKey();
            }


            int fehler = 0;

            Ueberschrift();
            string geheimesWort = LeseSpielerEingabe("Hallo Spieler 1, gebe ein geheimes Wort ein: ");
            string erratenesWort = "";
            char[] errateneBuchstaben = Enumerable.Repeat('_', geheimesWort.Length).ToArray();
            List<string> falscheBuchstaben = new List<string>();

            do
            {
                Ueberschrift();
                Console.WriteLine($"Anzahl Fehler: {fehler}");
                if (fehler == 4) //Replace with Hangman index
                {
                    Console.WriteLine("Game Over");
                    Console.ReadKey();
                    break;
                }
                if (geheimesWort == erratenesWort)
                {
                    ZweiteSpielerGewonnen(geheimesWort);
                    break;
                }

                ZeigeErratenesWort(errateneBuchstaben);
                ZeigeFalscheBuchstaben(falscheBuchstaben);

                string versuch = LeseSpielerEingabe("Hey Spieler 2 gebe einen Buchstaben oder das ganze Wort ein: ");

                if (versuch.Length == geheimesWort.Length)
                {
                    if (versuch == geheimesWort)
                    {
                        ZweiteSpielerGewonnen(geheimesWort);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Leider falsch. Spieler 1 hat gewonnen!");
                        Console.WriteLine($"Das richtige Wort ist: *{char.ToUpper(geheimesWort[0])}{geheimesWort.Substring(1)}*");
                        Console.ReadKey();
                        break;
                    }
                }
                else if (versuch.Length == 1)
                {
                    if (errateneBuchstaben.Contains(Convert.ToChar(versuch)))
                    {
                        fehler++;
                    }
                    else if (geheimesWort.Contains(versuch))
                    {
                        for (int i = 0; i < geheimesWort.Length; i++)
                        {
                            if (geheimesWort[i] == Convert.ToChar(versuch))
                            {
                                errateneBuchstaben[i] = geheimesWort[i];
                            }
                        }
                        erratenesWort = BuildCorrectWord(errateneBuchstaben);
                    }
                    else
                    {
                        falscheBuchstaben.Add(versuch.ToUpper());
                        fehler++;
                    }
                }                
            }
            while (true);
        }
    }
}
