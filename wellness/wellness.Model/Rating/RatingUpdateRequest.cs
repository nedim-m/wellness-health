using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Rating
{
    public class RatingUpdateRequest
    {
        [Range(1, 5)]
        public int StarRating { get; set; }
    }
}
