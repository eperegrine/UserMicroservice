using System;
using System.Text.RegularExpressions;

namespace UserMicroservice.Data
{
    public static class Validator
    {
        public static bool IsValidEmail(string emailToCheck)
        {
            bool invalid = false;
            if (string.IsNullOrEmpty(emailToCheck))
                return false;

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(emailToCheck,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                Console.WriteLine("Regex Timeout Error");
                return false;
            }
        }

        //Source: http://stackoverflow.com/a/21456918/3109126
        static Regex PasswordRegex = new Regex(
            @"[A-Za-z\d$@$!%*#?&_~`'\(\)%\\-]{8,}",
            RegexOptions.Multiline);

        public static bool IsValidPassword(string password)
        {
            
            return PasswordRegex.IsMatch(password);
        }
    }
}
