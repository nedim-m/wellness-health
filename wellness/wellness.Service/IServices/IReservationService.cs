using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model.Reservation;

namespace wellness.Service.IServices
{
    public interface IReservationService:ICrudService<Reservation,ReservationSearchObj,ReservationPostRequest,ReservationUpdateRequest>
    {
    }
}
