using System.Text.Json;

namespace Aufgabe_Kaffeautomat_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxWasser = 200, maxBohnen = 200, wasser = 0, bohnen = 0, wasserProKaffee = 100, bohnenProKaffee = 50, kaffeezaehler = 0;
            Dictionary<string, string>? history = new Dictionary<string, string>();
            string filename = "history.json";

            if (File.Exists(filename))
            {
                string historyText = File.ReadAllText(filename);
                history = JsonSerializer.Deserialize<Dictionary<string, string>>(historyText);
            }
            if (history == null)
                history = new Dictionary<string, string>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("========MENÜ========");
                Console.WriteLine("1 - Kaffee zubereiten");
                Console.WriteLine("2 - Historie ansehen");
                Console.Write("\nGebe 1 oder 2 an: ");
                string antwort = (Console.ReadLine() ?? "").Trim();

                if (antwort == "1")
                {
                    string historyText;

                    if (wasser < wasserProKaffee)
                    {
                        Console.Clear();
                        Console.WriteLine("Der Wassertank ist leer, bitte drücke eine Taste um diesen wieder aufzufüllen.");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Wasser wird aufgefüllt ...");
                        Thread.Sleep(2000);
                        wasser = maxWasser;
                        Console.Clear();
                        Console.WriteLine("Der Wassertank wurde aufgefüllt");
                        Thread.Sleep(1000);
                        history[DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss")] = "Wasser aufgefüllt";
                        historyText = JsonSerializer.Serialize(history, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(filename, historyText);
                    }
                    if (bohnen < bohnenProKaffee)
                    {
                        Console.Clear();
                        Console.WriteLine("Der Bohnenbehälter ist leer, bitte drücke eine Taste um diesen wieder aufzufüllen.");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Bohnen werden aufgefüllt ...");
                        Thread.Sleep(2000);
                        bohnen = maxBohnen;
                        Console.Clear();
                        Console.WriteLine("Der Bohnenbehälter wurde aufgefüllt");
                        Thread.Sleep(1000);
                        history[DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss")] = "Bohnen aufgefüllt";
                        historyText = JsonSerializer.Serialize(history, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(filename, historyText);
                    }

                    wasser -= wasserProKaffee;
                    bohnen -= bohnenProKaffee;
                    kaffeezaehler++;

                    string anzeige = "";
                    for (int i = 0; i <= 50; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("======== Kaffee wird zubereitet ========");
                        Console.Write(anzeige);
                        anzeige += "|";
                        Thread.Sleep(100);
                    }

                    history[DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss")] = "Kaffee wurde ausgegeben";
                    historyText = JsonSerializer.Serialize(history, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(filename, historyText);
                    Console.Clear();
                    Console.WriteLine("Bitte entnehme deinen Kaffee und drücke eine Taste.");
                    Console.ReadKey();

                    if (kaffeezaehler >= 30)
                    {
                        Console.Clear();
                        Console.Write("Maschine muss entkalkt werden, möchtest du jetzt entkalken (ja/nein): ");
                        antwort = (Console.ReadLine() ?? "").Trim().ToLower();
                        if (antwort == "ja")
                        {
                            Console.Clear();
                            Console.WriteLine("Maschine wird entkalkt ...");
                            Thread.Sleep(2000);
                            Console.Clear();
                            Console.WriteLine("Maschine wurde entkalkt, bitte drücke eine Taste");
                            history[DateTime.Now.ToString("dd.MM.yyyy - HH.mm.ss")] = "Maschine wurde entkalkt";
                            historyText = JsonSerializer.Serialize(history, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText(filename, historyText);
                            kaffeezaehler = 0;
                            Console.ReadKey();
                        }
                    }
                }
                else if (antwort == "2")
                {
                    Console.Clear();
                    Console.WriteLine("======== Historie ========");

                    foreach (var item in history)
                    {
                        Console.WriteLine($"{item.Key} : {item.Value}");
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Falsche Eingabe");
                }
            }
        }
    }
}
