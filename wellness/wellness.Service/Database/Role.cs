using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    public string? ShiftTime { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
