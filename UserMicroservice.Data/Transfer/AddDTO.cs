using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Data.Transfer
{
    public class AddDTO : SuccessDTO
    {
        public static new AddDTO GenerateError(string error)
        {
            return new AddDTO() { Success = false, ErrorMessage = error };
        }

        public int? Id { get; set; }
    }
}
