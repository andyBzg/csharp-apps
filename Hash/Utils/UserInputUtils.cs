namespace Hash.Utils
{
    internal class UserInputUtils
    {
        public static string ReadValidatedStringInput(string message, string errorMsg)
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
