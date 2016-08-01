using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.API.Database.Repositories;
using UserMicroservice.API.Requests.Queries.Users;
using UserMicroservice.Data.Transfer.ViewModels.Permissions;
using UserMicroservice.Data.Transfer.ViewModels.User;

namespace UserMicroservice.API.Requests.Handlers.Users
{
    public class GetUsersHandler : IQueryHandler<GetUsersQuery, UserListViewModel>
    {
        UserRepository _repo;

        public GetUsersHandler(UserRepository repo)
        {
            _repo = repo;
        }

        public UserListViewModel Execute(GetUsersQuery query)
        {
            var q = _repo.AsQuerable();
            var usersSelection = q.Select(x => new UserViewModel() {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                PermissionId = x.Permissions.Id
            });
            var users = usersSelection.ToList();
            //return new UserListViewModel();
            return new UserListViewModel()
            {
                Success = true,
                Users = users
            };
        }
    }
}
