using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Data.Transfer.ViewModels.Permissions
{
    public class PermissionListViewModel : SuccessDTO
    {
        public List<PermissionViewModel> Permissions;
    }
}
