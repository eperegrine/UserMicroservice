using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace UserMicroservice.Data
{
    public static class PasswordHashing
    {
        public static string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public static string GenerateHash(string password, string salt, 
            //Defaults:
            KeyDerivationPrf prf = KeyDerivationPrf.HMACSHA1, int iterationCount = 10000,int numBytesRequested= 265/8)
        {
            var byteSalt = Convert.FromBase64String(salt);
            var rawHash = KeyDerivation.Pbkdf2(password, byteSalt, prf, iterationCount, numBytesRequested);

            return Convert.ToBase64String(rawHash);
        }

        public static bool ComparePasswords(string password, string salt, string hashToCompare,
            //Defaults:
            KeyDerivationPrf prf = KeyDerivationPrf.HMACSHA1, int iterationCount = 10000, int numBytesRequested = 265 / 8)
        {
            string hashA = GenerateHash(password, salt, prf, iterationCount, numBytesRequested);

            return hashA == hashToCompare;
        }
    }
}
