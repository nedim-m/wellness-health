using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Member
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<Membership> Memberships { get; } = new List<Membership>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<Record> Records { get; } = new List<Record>();

    public virtual User User { get; set; } = null!;
}
