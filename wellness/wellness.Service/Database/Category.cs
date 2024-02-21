using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;



    public virtual ICollection<Treatment> Treatments { get; } = new List<Treatment>();
}
