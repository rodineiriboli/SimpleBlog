using System;
using System.Security.Cryptography;
using System.Text;

namespace SimpleBlog.Application.Helpers
{
    public class CryptoPassHelper : ICryptoPassHelper
    {
        public string CreatePass(string pass, string salt)
        {
            var hash = string.Empty;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                hash = GetHash(sha256Hash, string.Concat(pass, salt));

                //Console.WriteLine($"The SHA256 hash of {pass} is: {hash}.");

                //Console.WriteLine("Verifying the hash...");

                //if (VerifyHash(sha256Hash, pass, hash))
                //{
                //    Console.WriteLine("The hashes are the same.");
                //}
                //else
                //{
                //    Console.WriteLine("The hashes are not same.");
                //}
            }

            return hash;
        }

        public string CreateSaltSaltKey()
        {
            var random = new RNGCryptoServiceProvider();

            // Maximum length of salt
            int max_length = 32;

            // Empty salt array
            byte[] salt = new byte[max_length];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
            //{
            //    byte[] salt = new byte[16];
            //    rngCsp.GetBytes(salt);

            //Random nRandom = new();
            //nRandom.Next();
            //var textoAsBytes = Encoding.ASCII.GetBytes(nRandom.ToString());

            //return Convert.ToBase64String(Encoding.ASCII.GetBytes(salt.ToString()));
            //return Convert.ToBase64String(textoAsBytes);
        }

        public string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public bool VerifyHash(string input, string hash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                var hashOfInput = GetHash(sha256Hash, input);

                // Create a StringComparer an compare the hashes.
                var comparer = StringComparer.OrdinalIgnoreCase;
                return comparer.Compare(hashOfInput, hash) == 0;
            }

        }
    }
}
