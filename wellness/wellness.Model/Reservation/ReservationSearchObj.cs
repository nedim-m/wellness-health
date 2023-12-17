using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Reservation
{
    public class ReservationSearchObj : BaseSearchObject
    {
        public DateTime? Date { get; set; } = null!;
    }
}
