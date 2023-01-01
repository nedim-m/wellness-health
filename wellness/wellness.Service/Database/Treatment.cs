﻿using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Treatment
{
    public int Id { get; set; }

    public int TreatmentTypeId { get; set; }

    public int CategoryId { get; set; }

    public string Description { get; set; } = null!;

    public float Price { get; set; }

    public byte[] Picture { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual TreatmentType TreatmentType { get; set; } = null!;
}
