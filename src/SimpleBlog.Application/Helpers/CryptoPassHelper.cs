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
            }

            return hash;
        }

        public string CreateSaltSaltKey()
        {
            var random = new RNGCryptoServiceProvider();

            int max_length = 32;

            byte[] salt = new byte[max_length];
            random.GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public bool VerifyHash(string input, string hash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                var hashOfInput = GetHash(sha256Hash, input);

                var comparer = StringComparer.OrdinalIgnoreCase;
                return comparer.Compare(hashOfInput, hash) == 0;
            }

        }
    }
}
