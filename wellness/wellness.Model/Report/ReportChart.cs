﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Report
{
    public class ReportChart
    {
        public int Active { get; set; }
        public int Inactive { get; set; }

        public int? NotAnswered { get; set; }
    }
}
