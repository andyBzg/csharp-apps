using Hash.Utils;
using System.Security.Cryptography;

namespace Hash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SHA256();

            //Pbkdf2
            Console.WriteLine("Enter a password: ");
            string? password = Console.ReadLine();
            int iterations = 100000;

            // Generate a 128-Bit salt using a sequence of
            // cryptographically strong random bytes.
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            if (string.IsNullOrEmpty(password)) throw new ArgumentException("Input cannot be null or empty", nameof(password));

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(256 / 8); // divide by 8 to convert bits to bytes
            Console.WriteLine($"Hash (100000 itarations PBKDF2 + SHA256): {Convert.ToBase64String(hash)}");

            byte[] hashBytes = new byte[salt.Length + hash.Length];
            Array.Copy(salt, 0, hashBytes, 0, salt.Length);
            Array.Copy(hash, 0, hashBytes, salt.Length, hash.Length);

            Console.WriteLine($"Final Hash (salt + hash, Base64): {Convert.ToBase64String(hashBytes)}");

            string hashedPassword = "kO9QBIxHqNdYoLZjotgWOTX1U1rVxp2MfvrEpEvi6oxOwFhbdw0Yiv+qqW5yU27v"; // Password

            PasswordHasher hasher = new PasswordHasher();
            bool result = hasher.VerifyPassword(password, hashedPassword);
            if (result)
                Console.WriteLine("Password is correct");
            else 
                Console.WriteLine("Wrong password");
        }

        private static void SHA256()
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
