using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Membership
{
    public int Id { get; set; }

    public DateTime ExpirationDate { get; set; }

    public DateTime StartDate { get; set; }

    public bool Status { get; set; }

    public int MemberId { get; set; }

    public int MemberShipTypeId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual MembershipType MemberShipType { get; set; } = null!;
}
