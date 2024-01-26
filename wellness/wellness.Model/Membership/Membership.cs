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

        public string ExpirationDate { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public bool Status { get; set; }

        public string UserName { get; set; } = null!;
        public float Price { get; set; }

        public string? MemberShipTypeName { get; set; }
    }
}
