using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserMicroservice.Data.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Key]
        public string Username { get; set; }

        [Required]
        [Key]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Salt { get; set; }

        public string AuthToken { get; set; }

        public DateTime? AuthTokenExpiration { get; set; }

        public int PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public Permission Permissions { get; set; }
    }
}
