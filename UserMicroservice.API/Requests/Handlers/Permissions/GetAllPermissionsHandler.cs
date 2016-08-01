using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UserMicroservice.API.Database.Repositories;

using UserMicroservice.API.Requests.Queries.Permissions;
using UserMicroservice.Data.Transfer.ViewModels.Permissions;

namespace UserMicroservice.API.Requests.Handlers.Permissions
{
    public class GetAllPermissionsHandler : IQueryHandler<GetPermissionsQuery, PermissionListViewModel>
    {
        PermissionRepository _repo;

        public GetAllPermissionsHandler(PermissionRepository repo)
        {
            _repo = repo;
        }

        public PermissionListViewModel Execute(GetPermissionsQuery query)
        {
           var perms = _repo.AsQuerable().Select(x => new PermissionViewModel() {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,

                CanViewUser = x.CanViewUser,
                CanCreateUser = x.CanCreateUser,
                CanDeleteUser = x.CanDeleteUser,
                CanUpdateUser = x.CanUpdateUser,

                CanViewPermission = x.CanViewPermission,
                CanCreatePermission = x.CanCreatePermission,
                CanUpdatePermission = x.CanUpdatePermission,
                CanDeletePermission = x.CanDeletePermission
            }).ToList();

            return new PermissionListViewModel()
            {
                Success = true,
                Permissions = perms
            };
        }
    }
}
