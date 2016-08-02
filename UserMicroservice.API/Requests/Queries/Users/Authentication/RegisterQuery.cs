using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Data.Transfer;

namespace UserMicroservice.API.Requests.Queries.Users.Authentication
{
    public class RegisterQuery : IQuery<AddDTO>
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
