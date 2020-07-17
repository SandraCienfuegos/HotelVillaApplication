using System;
using API.Domain.Models;
using API.Infrastructure;

namespace API.Extensions
{
    public static class StringTokenExtension
    {
        public static Customer ToUser(this string token)
        {
            Console.WriteLine(token);
            return JWTProvider.DecryptJWT(token);
        }
    }
}