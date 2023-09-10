using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Record
{
    public int Id { get; set; }

    public String? EntryDate { get; set; }

    public String? LeaveEntryDate { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
