using System;
using System.Security.Cryptography;
using System.Text;

namespace API.Infrastructure
{
    public class CryptographyTool
    {
        public static string CryptSHA512(string data)
        {
            using var sha512 = SHA512.Create();
            var sourcesBytes = Encoding.UTF8.GetBytes(data);
            var hashBytes = sha512.ComputeHash(sourcesBytes);
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }
    }
}