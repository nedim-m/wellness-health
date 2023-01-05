using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Rating
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int StarRating { get; set; }

    public int TreatmentId { get; set; }

    public int UserId { get; set; }

    public virtual Treatment Treatment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
