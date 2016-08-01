using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Data.Transfer.ViewModels.Permissions
{
    public class PermissionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool? CanViewUser { get; set; }
        public bool? CanCreateUser { get; set; }
        public bool? CanUpdateUser { get; set; }
        public bool? CanDeleteUser { get; set; }

        public bool? CanViewPermission { get; set; }
        public bool? CanCreatePermission { get; set; }
        public bool? CanUpdatePermission { get; set; }
        public bool? CanDeletePermission { get; set; }
    }
}
