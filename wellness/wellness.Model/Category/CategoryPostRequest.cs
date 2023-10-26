using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Category
{
    public class CategoryPostRequest
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Status { get; set; }
    }
}
