using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Rating
{
    public class Rating
    {
        public int Id { get; set; }


        public int StarRating { get; set; }

        public int TreatmentId { get; set; }

        public int UserId { get; set; }

       
    }

}

