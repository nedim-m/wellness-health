using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class TreatmentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public float Price { get; set; }

    public virtual ICollection<Treatment> Treatments { get; } = new List<Treatment>();
}
