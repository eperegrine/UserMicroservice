using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.API.Database.Repositories;
using UserMicroservice.API.Requests.Queries.Users;
using UserMicroservice.Data.Models;
using UserMicroservice.Data.Transfer.ViewModels.User;

namespace UserMicroservice.API.Requests.Handlers.Users
{
    public class GetUserDetailHandler : IQueryHandler<GetUserDetailQuery, UserResponseModel>
    {
        UserRepository _repo;
        PermissionRepository _permRepo;

        public GetUserDetailHandler(
            UserRepository repo,
            PermissionRepository permRepo)
        {
            _repo = repo;
            _permRepo = permRepo;
        }

        public UserResponseModel Execute(GetUserDetailQuery query)
        {
            try
            {
                User userRequested = _repo.RetrieveById(query.UserId);
                User userRequesting = _repo.AsQuerable().First(x => x.AuthToken == query.AuthToken);

                if (userRequesting.AuthTokenExpiration.HasValue &&
                    userRequesting.AuthTokenExpiration.Value > DateTime.Now)
                {
                    return new UserResponseModel()
                    {
                        Success = true,
                        user = new UserViewModel()
                        {
                            Id = userRequested.Id,
                            Email = userRequested.Email,
                            Name = userRequested.Username,
                            PermissionId = userRequested.PermissionId
                        }
                    };
                }
                else
                {
                    return new UserResponseModel()
                    {
                        Success = false,
                        ErrorMessage = "Auth Token has expired"
                    };
                }
            }
            catch
            {
                return new UserResponseModel()
                {
                    Success = false,
                    ErrorMessage = "Could not that user and/or auth token"
                };
            }
        }
    }
}
