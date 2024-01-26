using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class MembershipType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public float Price { get; set; }

    public int Duration { get; set; }

    public virtual ICollection<Membership> Memberships { get; } = new List<Membership>();
}
