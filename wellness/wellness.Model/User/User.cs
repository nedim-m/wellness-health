using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;


        public string UserName { get; set; } = null!;

        public string? Phone { get; set; }

        public bool Status { get; set; }

        public byte[]? Picture { get; set; }

        public string Role { get; set; } = string.Empty;

        public string ShiftTime { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public int ShiftId { get; set; }

        public string? MembershipType { get; set; }
    }
}
