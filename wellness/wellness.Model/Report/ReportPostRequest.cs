using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Report
{
    public class ReportPostRequest
    {
      
        public string DateTo { get; set; }
        public string DateFrom { get; set; }

        

        public int MemberShipTypeId { get; set; } 
    }
}
