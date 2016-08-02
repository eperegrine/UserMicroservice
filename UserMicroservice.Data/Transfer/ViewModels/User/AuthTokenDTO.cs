using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Data.Transfer.ViewModels.User
{
    public class AuthTokenDTO : SuccessDTO
    {
        public static new AuthTokenDTO GenerateError(string error)
        {
            return new AuthTokenDTO() { Success = false, ErrorMessage = error };
        }
        public string AuthToken { get; set; }
    }
}
