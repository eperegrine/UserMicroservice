using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Data.Transfer.ViewModels.User
{
    public class UserListViewModel : SuccessDTO
    {
        public List<UserViewModel> Users;
    }
}
