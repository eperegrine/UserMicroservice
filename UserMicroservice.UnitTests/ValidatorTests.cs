using Xunit;
using System.Linq;
using System.Collections.Generic;

using UserMicroservice.Data;

namespace UserMicroservice.UnitTests
{
    public class ValidatorTests
    {
        Dictionary<string, bool> Emails = new Dictionary<string, bool>{
            { @"a", false },
            { @"david.jones@proseware.com", true },
            { @"d.j@server1.proseware.com", true },
            { @"jones@ms1.proseware.com", true },
            { @"j@proseware.com9", true },
            { @"js#internal@proseware.com", true },
            { @"j_9@[129.126.118.1]", true },
            { @"js@proseware.com9", true },
            { @"j.s@server1.proseware.com", true },
            { @"j.@server1.proseware.com", false },
            { @"j..s@proseware.com", false },
            { @"js*@proseware.com", false },
            { @"js@proseware..com", false },
        };

        [Fact]
        public void AllowsValidEmails()
        {
            var emails = Emails.Where(x => x.Value == true);

            foreach (KeyValuePair<string, bool> kvp in emails)
            {
                Assert.True(Validator.IsValidEmail(kvp.Key));
            }
        }

        [Fact]
        public void DontAllowInvalidEmails()
        {
            var emails = Emails.Where(x => x.Value == false);

            foreach (KeyValuePair<string, bool> kvp in emails)
            {
                Assert.False(Validator.IsValidEmail(kvp.Key));
            }
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
