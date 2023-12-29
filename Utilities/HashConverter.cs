using System.Security.Cryptography;
using System.Text;

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
