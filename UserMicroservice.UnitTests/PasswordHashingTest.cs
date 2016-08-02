using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

using UserMicroservice.Data;

namespace UserMicroservice.UnitTests
{
    public class PasswordHashingTest
    {
        [Fact]
        void PasswordComparisonWorks()
        {
            var salt = PasswordHashing.GenerateSalt();
            var password = "super_s3cure!02";

            var hashA = PasswordHashing.GenerateHash(password, salt);

            Assert.True(PasswordHashing.ComparePasswords(password, salt, hashA));
        }

        [Fact]
        void SaltChangesPassword()
        {
            string password = "super_s3cure!02";

            string saltA = PasswordHashing.GenerateSalt();

            string saltB;

            do
            {
                saltB = PasswordHashing.GenerateSalt();
            }
            while (saltA == saltB);

            string hashA = PasswordHashing.GenerateHash(password, saltA);
            string hashB = PasswordHashing.GenerateHash(password, saltB);

            Assert.NotEqual(hashA, hashB);
        }
    }
}
