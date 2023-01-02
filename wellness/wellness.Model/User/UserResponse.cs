using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.User
{
    public class UserResponse
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;


        public string UserName { get; set; } = null!;

        public string? Phone { get; set; }

        public bool Status { get; set; }

        public byte[]? Picture { get; set; }

        public string Role { get; set; } = string.Empty;
    }
}
