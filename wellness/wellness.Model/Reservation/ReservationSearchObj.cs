using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Reservation
{
    public class ReservationSearchObj : BaseSearchObject
    {
        public string? Date { get; set; } = null!;
        public int? TreatmentId { get; set; }
    }
}
