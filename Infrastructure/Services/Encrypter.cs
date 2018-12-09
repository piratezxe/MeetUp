using System;
using System.Security.Cryptography;

namespace PlayTogether.Infrastructure.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DeriveBytesIterationsCount = 10000;
        private static readonly int SaltSize = 40;

        public string GetSalt(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Can not generate salt from an empty value.", nameof(value));
            }

             var random = new Random();
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string password, string salt)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Can not generate salt from an empty value.", nameof(password));
            }
            if (string.IsNullOrEmpty(salt))
            {
                throw new ArgumentException("Can not generate salt from an empty value.", nameof(salt));
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }
        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
