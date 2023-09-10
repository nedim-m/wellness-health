using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Record
{
    public class Record
    {
        public int Id { get; set; }

        public String? EntryDate { get; set; }

        public String? LeaveEntryDate { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
        public string UserName { get; set; } = null!;

    }
}
