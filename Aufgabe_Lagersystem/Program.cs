namespace Aufgabe_Lagersystem
{
    //Aufgabe:

    // Programmiere in C# nur mit der nutzung von Arrays folgendes:
    // ein Lagersystem hat 100 Plätze. Über ein Menü können wir 
    // Bauteile und schrauben über die Konsole in unser Lagersysten eintragen. 
    // Wenn ein Lagerplatz bereits belegt ist soll darauf verwiesen werden das 
    // element woander zu lagern. Wir können über die Lagerplatznummer uns auch 
    // Elemente anfordern die wir dann entfernen können wenn wir das wollen. 
    // und wir müssen die möglichkeit haben Das Lager auszugeben in der Konsole.
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] positions = new string[100];
            string[] menu = { "Find", "Add", "Show all", "Exit" };
            int index;

            do
            {
                PrintMenu(menu);
                index = GetUserInput(menu, "Please choose a menu item: ");
                ProcessUserInput(index, positions);
            }
            while (true);

        }

        private static void ProcessUserInput(int index, string[] positions)
        {
            switch (index)
            {
                case 1:
                    FindItemById(positions);
                    break;
                case 2:
                    AddItem(positions);
                    break;
                case 3:
                    ShowAllPositions(positions);
                    break;
                case 4:
                    EndProgram();
                    break;
                default:
                    break;
            }
        }

        private static void FindItemById(string[] positions)
        {
            int index = GetUserInput(positions, "Please enter a position index: ");
            if (positions[index - 1] != null)
            {
                Console.WriteLine($"[{index}] : {positions[index - 1]}");
                Console.Write("Do you want to delete the item? (y/n) ");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"\nItem {positions[index - 1]} deleted from slot {index}!");
                    positions[index - 1] = string.Empty;
                    ListenAnyKey();
                }
                else
                {
                    Console.WriteLine("\nProceeding without deletion");
                    ListenAnyKey();
                }
            }
            else
            {
                PrintFailure($"Position [{index}] is not found");
                ListenAnyKey();
            }
        }

        private static void PrintFailure(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void ListenAnyKey()
        {
            Console.WriteLine("Press any key to continiue ...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void AddItem(string[] positions)
        {
            int counter = 0;
            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i] == null)
                {
                    Console.WriteLine($"Adding description to position nr. {i + 1}: ");
                    positions[i] = (Console.ReadLine() ?? "").Trim();

                    if (positions[i] != null)
                        Thread.Sleep(1000);
                    Console.WriteLine($"Item {positions[i]} added to slot nr.{i + 1}!");

                    ListenAnyKey();
                    break;
                }
                else
                    counter++;
            }

            if (counter == positions.Length)
            {
                PrintFailure("All positions are full, please choos another storage");
                ListenAnyKey();
            }
        }

        private static void ShowAllPositions(string[] positions)
        {
            Console.Clear();
            Console.WriteLine("===== Show All =====");
            for (int i = 0; i < positions.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] : {positions[i]}");
            }
            ListenAnyKey();
        }

        private static void EndProgram()
        {
            Console.WriteLine("Press ESC to Exit");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                Environment.Exit(0);
            else
                Console.Clear();
        }

        private static int GetUserInput(string[] array, string message)
        {
            int index;
            do
            {
                Console.Write(message);
                bool check = int.TryParse(Console.ReadLine(), out index);
                if (!check)
                    PrintFailure("Please enter a number");
                else if (index <= 0 || index > array.Length)
                    PrintFailure($"Please enter a number between 1 and {array.Length}");
                else
                    break;
            }
            while (true);
            return index;
        }

        private static void PrintMenu(string[] menu)
        {
            Console.WriteLine("===== Menu =====");
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"({i + 1}) - {menu[i]}");
            }
        }
    }
}
