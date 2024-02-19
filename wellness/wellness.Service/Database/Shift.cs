using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Service.Database
{
    public partial class Shift
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string WorkingHours { get; set; } = null!;
    }
}
