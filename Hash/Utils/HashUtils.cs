using System.Security.Cryptography;
using System.Text;

namespace Hash.Utils
{
    public static class HashUtils
    {
        /// <summary>
        /// Computes the SHA256 hash for the provided input string.
        /// </summary>
        /// <param name="input">The string to hash.</param>
        /// <returns>The hexadecimal representation of the hash.</returns>
        public static string ComputeSHA256Hash(string input)
        {
            if (string.IsNullOrEmpty(input)) throw new ArgumentException("Input cannot be null or empty", nameof(input));

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        /// <summary>
        /// Verifies if the input string matches the provided hash using SHA256.
        /// </summary>
        /// <param name="input">The original string to verify.</param>
        /// <param name="hash">The hash to compare against.</param>
        /// <returns>True if the input string matches the hash; otherwise, false.</returns>
        public static bool VerifySHA256Hash(string input, string hash)
        {
            if (string.IsNullOrEmpty(input)) throw new ArgumentException("Input cannot be null or empty", nameof(input));

            var hashOfInput = ComputeSHA256Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
