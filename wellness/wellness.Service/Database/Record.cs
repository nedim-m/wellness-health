using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Record
{
    public int Id { get; set; }

    public DateTime EntryDate { get; set; }

    public DateTime LeaveEntryDate { get; set; }

    public int MemberId { get; set; }

    public virtual Member Member { get; set; } = null!;
}
