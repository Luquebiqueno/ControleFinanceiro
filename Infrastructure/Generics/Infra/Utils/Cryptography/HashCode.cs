using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Infra.Utils.Cryptography
{
    public static class HashCode
    {
        public static string Encrypt(string text) => string.Format("{0:X}", text.GetHashCode());
    }
}
