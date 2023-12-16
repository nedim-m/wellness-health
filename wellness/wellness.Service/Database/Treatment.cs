using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Treatment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public int TreatmentTypeId { get; set; }

    public int CategoryId { get; set; }

    public string Description { get; set; } = null!;

    public int Duration { get; set; }

    public float Price { get; set; }

    public byte[] Picture { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    public virtual TreatmentType TreatmentType { get; set; } = null!;
}
