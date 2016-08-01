using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.API.Database.Repositories;
using UserMicroservice.API.Requests.Queries.Users.Authentication;
using UserMicroservice.Data.Transfer;

namespace UserMicroservice.API.Requests.Handlers.Users.Authentication
{
    public class RegistrationHandler : IQueryHandler<RegisterQuery, SuccessDTO>
    {
        UserRepository _repo;

        public RegistrationHandler(UserRepository repo)
        {
            _repo = repo;
        }

        public SuccessDTO Execute(RegisterQuery query)
        {
            
            throw new NotImplementedException();
        }
    }
}
