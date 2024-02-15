using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Report
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }

        public float EarnedMoney { get; set; }

        public string MemberShipTypeName { get; set; } = null!;
    }
}
