using wellness.Model.Reservation;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    public class ReservationController : CrudController<Reservation, ReservationSearchObj, ReservationPostRequest, ReservationUpdateRequest>
    {
        public ReservationController(ILogger<BaseController<Reservation, ReservationSearchObj>> logger,IReservationService service) : base(logger, service)
        {
        }
    }
}
