using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Membership
{
    public class MembershipPostRequest
    {
        public DateTime ExpirationDate { get; set; }

        public DateTime StartDate { get; set; }

        public int UserId { get; set; }

        public int MemberShipTypeId { get; set; }
    }
}
