namespace Aufgabe_Quiz
{
    /*d) Thema: switch
    Es wird ein Quiz mit 5 Fragen benötigt.
    Nach jeder Frage soll dem Anwender ein Menü mit 4 möglichen Antworten angeboten
    werden (und ja, eine davon sollte die richtige Antwort sein).
    Nachdem der Anwender zu jeder Frage seine Antwort eingegeben hat, soll der
    Anwender am Ende angezeigt bekommen, wieviele Fragen er richtig beantwortet hat.
    Ebenso, welche Fragen korrekt beantwortet wurden.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            int eingabe, counter = 0;
            bool check = false;

            string[] fragen =
                [
                    "Welches Element hat das chemische Symbol 'O'?",
                    "Wie viele Planeten gibt es in unserem Sonnensystem?",
                    "Wer schrieb das Buch 'Der Herr der Ringe'?",
                    "Welches Jahr begann der Zweite Weltkrieg?",
                    "Welcher dieser Flüsse ist der längste?"
                ];

            string[][] moeglicheAntworten =
                [
                    ["Osmium", "Oxid", "Ozon", "Sauerstoff"],  // Richtige Antwort: Sauerstoff
                    ["7", "8", "9", "10"],  // Richtige Antwort: 8
                    ["J.R.R. Tolkien", "George Orwell", "Johann Wolfgang von Goethe", "William Shakespeare"],  // Richtige Antwort: J.R.R. Tolkien
                    ["1914", "1939", "1945", "1923"],  // Richtige Antwort: 1939
                    ["Donau", "Nil", "Mississippi", "Amazonas"]  // Richtige Antwort: Amazonas
                ];

            string[] richtigeAntworten = { "Sauerstoff", "8", "J.R.R. Tolkien", "1939", "Amazonas" };

            string[] richtigeAnwenderAntworten = new string[5];

            Console.WriteLine("Willkommen beim Quiz!");
            Console.WriteLine("Drücken Sie eine beliebige Taste, um zu starten...");
            Console.ReadKey();

            for (int i = 0; i < fragen.Length; i++)
            {
                while (!check)
                {
                    Console.Clear();
                    Console.WriteLine(fragen[i]);

                    for (int j = 0; j < moeglicheAntworten[i].Length; j++)
                    {
                        // Menü mit Fragen
                        Console.WriteLine($"[{j + 1}] {moeglicheAntworten[i][j]}");
                    }

                    Console.Write("Bitte wählen Sie Ihre Antwort (1-4): ");
                    check = int.TryParse(Console.ReadLine(), out eingabe);

                    if (check && eingabe > 0 && eingabe <= 4)
                    {
                        string antwort = moeglicheAntworten[i][eingabe - 1];

                        switch (richtigeAntworten.ToList().Contains(antwort))
                        {
                            case true:
                                Console.WriteLine($"Sie haben gewählt: {antwort}");
                                Console.WriteLine("Das ist korrekt!");
                                richtigeAnwenderAntworten[i] = $"{fragen[i]} | {antwort}";
                                counter++;
                                break;
                            default:
                                Console.WriteLine("Leider falsch :(");
                                break;
                        }

                        Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Drücken Sie eine beliebige Taste...");
                        Console.ReadKey();
                        check = false;
                    }
                }
                check = false;
            }
            Console.Clear();
            Console.WriteLine($"Sie haben {counter} Fragen richtig beantwortet:\n");
            foreach (var item in richtigeAnwenderAntworten)
            {
                if (item != null)
                    Console.WriteLine(item);
            }

            Console.WriteLine("\nDanke fürs Mitmachen!");
            Console.ReadKey();
        }
    }
}
