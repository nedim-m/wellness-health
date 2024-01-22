using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Membership
{
    public class Membership
    {
        public int Id { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime StartDate { get; set; }

        public bool Status { get; set; }

        public string UserName { get; set; } = null!;

        public string? MemberShipTypeName { get; set; }
    }
}
