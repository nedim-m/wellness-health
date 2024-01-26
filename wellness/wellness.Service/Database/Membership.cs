using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Membership
{
    public int Id { get; set; }

    public string ExpirationDate { get; set; } = null!;

    public string StartDate { get; set; } = null!;

    public bool Status { get; set; }

    public int UserId { get; set; }

    public int MemberShipTypeId { get; set; }

    public virtual MembershipType MemberShipType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
