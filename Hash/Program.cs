using Hash.Utils;

namespace Hash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "Please provide the string to generate a hash value: ";
            string errorMessage = "Input cannot be empty. Please provide a valid string to hash.";
            string hintToPressKey = "Please press any key ...";

            string input = UserInputUtils.ReadValidatedStringInput(message, errorMessage);
            string hash = HashUtils.ComputeSHA256Hash(input);

            Console.Clear();
            ShowComputingInput(input);
            ShowLoadingProgress(5, "*", 500);
            Console.Clear();
            ShowComputingInput(input);
            Console.WriteLine(hash);
            Console.WriteLine();
            UserInputUtils.WaitUserKey(hintToPressKey);
        }

        private static void ShowLoadingProgress(int length, string symbol, int delayMills)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(symbol);
                Thread.Sleep(delayMills);
            }
        }

        private static void ShowComputingInput(string input)
        {
            Console.WriteLine($"Computing Hash for: {input}");
            Console.Write("Hash: ");
        }
    }
}
