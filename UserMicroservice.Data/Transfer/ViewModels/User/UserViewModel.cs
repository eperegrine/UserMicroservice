using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using UserMicroservice.Data.Transfer.ViewModels.Permissions;

namespace UserMicroservice.Data.Transfer.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int PermissionId { get; set; }
    }
}
