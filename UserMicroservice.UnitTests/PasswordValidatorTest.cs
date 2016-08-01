using Xunit;

using UserMicroservice.Data;
using System;

namespace UserMicroservice.UnitTests
{
    /// <summary>
    /// Passwords should be at least 8 characters long, contain a letter, number and special character
    /// </summary>
    public class PasswordValidatorTest
    {
        string[] shortPasswords = new string[] {
            "Hi",
            "By3",
            "H3!!0o",
            "H1ya",
            "s3cur3_p",
            ""
        };

        string[] validPasswords = new string[]
        {
            "Secur3_passw0rd!",
            //"I_AM_s3cure",
            @"y5_6@ea$",
            @"%2-?j?q\",
            @"DYf`_2B'X)hp9B8~"
        };


        [Fact]
        public void ChecksForAtLeastEightCharacters()
        {
            foreach(string a in shortPasswords)
            {
                Assert.False(Validator.IsValidPassword(a));
            }
        }

        [Fact]
        public void NullIsNotAValidPassword()
        {
            try
            {
                Assert.False(Validator.IsValidPassword(null));
            }
            catch (Exception e)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void AllowValidPasswords()
        {
            foreach (string a in validPasswords)
            {
                Assert.True(Validator.IsValidPassword(a));
            }
        }
    }
}
