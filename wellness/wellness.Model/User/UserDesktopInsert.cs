using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.User
{
    public class UserDesktopInsert
    {
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        
        public string? Phone { get; set; }

        public bool Status { get; set; } = false;

        public byte[]? Picture { get; set; }

        public int RoleId { get; set; } = 3;
        public int ShiftId { get; set; } = 1;
    }
}
