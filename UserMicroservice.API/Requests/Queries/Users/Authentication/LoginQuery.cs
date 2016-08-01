using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Data.Transfer.ViewModels.User;

namespace UserMicroservice.API.Requests.Queries.Users.Authentication
{
    public class LoginQuery : IQuery<AuthTokenDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
