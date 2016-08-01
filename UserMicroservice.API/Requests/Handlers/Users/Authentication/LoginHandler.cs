using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.API.Database.Repositories;
using UserMicroservice.API.Requests.Queries.Users.Authentication;
using UserMicroservice.Data.Transfer.ViewModels.User;

namespace UserMicroservice.API.Requests.Handlers.Users.Authentication
{
    public class LoginHandler : IQueryHandler<LoginQuery, AuthTokenDTO>
    {
        UserRepository _repo;

        public LoginHandler(UserRepository repo)
        {
            _repo = repo;
        }

        public AuthTokenDTO Execute(LoginQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
