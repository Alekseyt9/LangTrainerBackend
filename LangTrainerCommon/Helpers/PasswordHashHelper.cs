
using System.Security.Cryptography;
using System.Text;

namespace LangTrainerServices.Helpers
{
    public class PasswordHashHelper
    {
        const int keySize = 64;
        const int iterations = 350000;
        private static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public static string HashPasword(string password, out string saltStr)
        {
            var salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            saltStr = Encoding.UTF8.GetString(salt);
            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string password, string hash, string saltStr)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
                password, Encoding.UTF8.GetBytes(saltStr), iterations, hashAlgorithm, keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }

    }
}
