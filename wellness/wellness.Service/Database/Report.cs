using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Service.Database
{
    public partial class Report
    {
        public int Id { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }

        public decimal EarnedMoney { get; set; }

        public int MemberShipTypeId { get; set; }

        public virtual MembershipType MemberShipType { get; set; } = null!;


    }
}
