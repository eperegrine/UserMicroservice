using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Data.Models;

using UserMicroservice.Data.Transfer.ViewModels.Permissions;

namespace UserMicroservice.API.Requests.Queries.Permissions
{
    public class GetPermissionsQuery : IQuery<PermissionListViewModel>
    {
    }
}
