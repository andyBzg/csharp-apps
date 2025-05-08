namespace Aufgabe_Abstrakte_Kunde.Utils
{
    internal static class UserInputUtils
    {
        public static string ReadValidatedString(string message, string errorMsg)
        {
            string userInput;
            do
            {
                Console.Write(message);
                userInput = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(userInput))
                    PrintColoredMessage(errorMsg, ConsoleColor.Red);

            } while (string.IsNullOrWhiteSpace(userInput));
            return userInput;
        }

        public static decimal ReadValidatedDecimal(string prompt, string errorMsg)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                    PrintColoredMessage(errorMsg, ConsoleColor.Red);

                if (decimal.TryParse(input.Trim(), out decimal number))
                    return number;
                else
                    PrintColoredMessage(errorMsg, ConsoleColor.Red);
            }
        }

        public static bool ReadConsoleKey(string message, ConsoleKey consoleKey)
        {
            Console.Write(message);
            return Console.ReadKey().Key == consoleKey;
        }

        public static void WaitUserKey(string? message = null)
        {
            if (!string.IsNullOrEmpty(message))
                Console.WriteLine(message);

            Console.ReadKey();
        }

        private static void PrintColoredMessage(string message, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
