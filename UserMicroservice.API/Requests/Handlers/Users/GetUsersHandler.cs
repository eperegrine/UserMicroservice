using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.API.Database.Repositories;
using UserMicroservice.API.Requests.Queries.Users;
using UserMicroservice.Data.Models;
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
            List<User> userModelList = q.ToList();//usersSelection.ToList();
            List<UserViewModel> userViewModelList = new List<UserViewModel>();

            foreach (User u in userModelList)
            {
                UserViewModel uvm = new UserViewModel();

                uvm.Id = u.Id;
                uvm.Name = u.Username;
                uvm.Email = u.Email;

                if (u.Permissions != null)
                {
                    uvm.PermissionId = u.Permissions.Id;
                }

                userViewModelList.Add(uvm);
            }

            return new UserListViewModel()
            {
                Success = true,
                Users = userViewModelList
            };
        }
    }
}
