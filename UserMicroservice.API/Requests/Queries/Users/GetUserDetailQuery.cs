using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Data.Transfer.ViewModels.User;

namespace UserMicroservice.API.Requests.Queries.Users
{
    public class GetUserDetailQuery : IQuery<UserResponseModel>
    {
        public string AuthToken { get; set; }
        public int UserId { get; set; }
    }
}
