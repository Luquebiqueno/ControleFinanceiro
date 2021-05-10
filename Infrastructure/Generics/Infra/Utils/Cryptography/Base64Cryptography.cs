using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Infra.Utils.Cryptography
{
    public class Base64Cryptography
    {
        public static string Encrypt(string text)
        {
            Throw.IfIsNullOrEmpty(text);

            byte[] toEncodeAsBytes = ASCIIEncoding.UTF8.GetBytes(text);
            string returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string Decrypt(string text)
        {
            Throw.IfIsNullOrEmpty(text);

            byte[] encodedDataAsBytes = Convert.FromBase64String(text);
            string returnValue = ASCIIEncoding.UTF8.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}
