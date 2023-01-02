using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Reservation
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime DateOf { get; set; }

    public DateTime DateTo { get; set; }

    public bool Status { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Treatment Treatment { get; set; } = null!;
    public int TreatmentId { get; set; }
}
