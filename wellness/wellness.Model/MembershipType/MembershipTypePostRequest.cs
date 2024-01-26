using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.MembershipType
{
    public class MembershipTypePostRequest
    {

        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public float Price { get; set; }

        public int Duration { get; set; }
    }
}
