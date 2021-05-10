using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Infra.Utils.Cryptography
{
    public class MD5Cryptography
    {
        public static string Encrypt(string text)
        {
            Throw.IfIsNullOrEmpty(text);

            var md5Hasher = System.Security.Cryptography.MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }
    }
}
