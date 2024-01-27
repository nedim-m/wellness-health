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
        public string PaymentGateway { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = null!;
        public DateTime Timestamp { get; set; }

        public int MemberShipId { get; set; }

        public virtual Membership MemberShip { get; set; } = null!;

    }
}
