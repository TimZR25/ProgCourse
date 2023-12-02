using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Utilities
{
    internal class HashConverter
    {
        public static string ToHashString(string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] hashValue = SHA256.HashData(messageBytes);
            return Convert.ToHexString(hashValue);
        }
    }
}
