using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Membership
{
    public class MembershipPostRequest
    {
        public string ExpirationDate { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public int UserId { get; set; }

        public int MemberShipTypeId { get; set; }
    }
}
