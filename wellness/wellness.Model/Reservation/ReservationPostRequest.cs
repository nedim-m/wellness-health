﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Reservation
{
    public class ReservationPostRequest
    {
        public int UserId { get; set; }

        public string Date { get; set; } = null!;

        public string Time { get; set; } = null!;

        public bool? Status { get; set; }

        public int TreatmentId { get; set; }

    }
}
