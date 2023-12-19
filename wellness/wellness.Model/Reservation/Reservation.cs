using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Reservation
{
    public class Reservation
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Time { get; set; } = null!;

        public bool Status { get; set; }

        public string Treatment { get; set; } = null!;
    }
}
