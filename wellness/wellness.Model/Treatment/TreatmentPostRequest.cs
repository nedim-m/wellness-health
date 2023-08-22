using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Treatment
{
    public class TreatmentPostRequest
    {
        public int TreatmentTypeId { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; } = null!;

        public int Duration { get; set; }

        public float Price { get; set; }

        public byte[] Picture { get; set; } = null!;
    }
}
