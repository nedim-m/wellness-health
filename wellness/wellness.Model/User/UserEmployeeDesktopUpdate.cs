using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.User
{
    public class UserEmployeeDesktopUpdate
    {
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]

        public string Phone { get; set; } = null!;
        public string? Password { get; set; }

        public byte[]? Picture { get; set; }
    }
}
