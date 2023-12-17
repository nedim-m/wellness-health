using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Reservation
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public string Time { get; set; } = null!;

    public bool Status { get; set; }

    public int TreatmentId { get; set; }

    public virtual Treatment Treatment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
