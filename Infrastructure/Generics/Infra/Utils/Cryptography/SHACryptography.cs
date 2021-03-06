using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Generics.Infra.Utils.Cryptography
{
    public static class SHACryptography
    {
        public enum Algorithm
        {
            SHA1,
            SHA256,
            SHA384,
            SHA512
        }

        private static HashAlgorithm GetHashAlgorithm(Algorithm algorithm)
        {
            switch (algorithm)
            {
                case Algorithm.SHA256: return SHA256.Create();
                case Algorithm.SHA384: return SHA384.Create();
                case Algorithm.SHA512: return SHA512.Create();
                default:
                    return SHA1.Create();
            }
        }

        public static string Encrypt(Algorithm algorithm, string text)
        {
            var hashAlgorithm = GetHashAlgorithm(algorithm);
            var cryptoByte = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.Length);
        }
    }
}
