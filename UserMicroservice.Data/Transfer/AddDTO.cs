using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Data.Transfer
{
    public class AddDTO : SuccessDTO
    {
        public int? Id { get; set; }
    }
}
