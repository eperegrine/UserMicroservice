using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Data.Transfer
{
    public class SuccessDTO
    {
        public static SuccessDTO GenerateError(string error)
        {
            return new SuccessDTO() { Success = false, ErrorMessage = error };
        }

        public static SuccessDTO Successful() { return new SuccessDTO() { Success = true }; }

        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
