using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class Rating
{
    public int Id { get; set; }

    public int StarRating { get; set; }


    public int ReservationId { get; set; }

    public virtual Reservation Reservation { get; set; } = null!;
}
