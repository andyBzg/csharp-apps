using System.Security.Cryptography;
using System.Text;

namespace Hash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello World!";

            string hash = HashUtils.GetHash(input);
            bool isSame = HashUtils.VerifyHash(input, hash);

            if (isSame)
                Console.WriteLine("The hashes are the same.");
            else
                Console.WriteLine("The hashes are not the same");

            /*using (SHA256 sha256Hash = SHA256.Create())
            {
                string hash = GetHash(sha256Hash, input);

                Console.WriteLine($"The SHA256 hash of {input} is: {hash}");

                Console.WriteLine("Verifying the hash ...");

                if (VerifyHash(sha256Hash, input, hash))
                {
                    Console.WriteLine("The hashes are the same.");
                }
                else
                {
                    Console.WriteLine("The hashes are not the same");
                }
            }*/
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            var hashOfInput = GetHash(hashAlgorithm, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
