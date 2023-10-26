using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Models.UserPostRequest
{
    public class UserPostRequest
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
       
        public string Password { get; set; } = null!;
        
        public string ConfrimPassword { get; set; } = null!;
        public byte[]? Picture { get; set; }
        public int RoleId { get; set; }

        public string? Phone { get; set; }
    }
}
