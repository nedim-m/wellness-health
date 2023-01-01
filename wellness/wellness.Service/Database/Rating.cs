using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Rating
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int Rating1 { get; set; }

    public int TreatmentId { get; set; }

    public int MemberId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual Treatment Treatment { get; set; } = null!;
}
