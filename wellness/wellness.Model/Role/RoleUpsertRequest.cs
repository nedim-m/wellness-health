using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.RoleUpsertRequest
{
    public class RoleUpsertRequest
    {


        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
        public string? ShiftTime { get; set; } = null!;

    }
}
