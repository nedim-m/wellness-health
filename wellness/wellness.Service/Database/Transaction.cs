using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Service.Database
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = null!;
        public DateTime Timestamp { get; set; }

        public int MemberShipTypeId { get; set; }

        public virtual MembershipType MemberShipType { get; set; } = null!;

        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;

    }
}
