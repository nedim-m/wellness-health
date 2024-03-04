using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.Reservation;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    public class ReservationController : CrudController<Reservation, ReservationSearchObj, ReservationPostRequest, ReservationUpdateRequest>
    {
        public ReservationController(ILogger<BaseController<Reservation, ReservationSearchObj>> logger,IReservationService service) : base(logger, service)
        {
        }


        [Authorize(Roles = "Korisnik")]
        public override Task<Reservation> Insert([FromBody] ReservationPostRequest insert)
        {
            return base.Insert(insert);
        }

        [Authorize(Roles = "Korisnik,Zaposlenik")]
        public override Task<PagedResult<Reservation>> Get([FromQuery] ReservationSearchObj? search = null)
        {
            return base.Get(search);

        }
        [Authorize(Roles = "Korisnik,Zaposlenik")]
        public override Task<Reservation> GetById(int id)
        {
            return base.GetById(id);
        }

        [Authorize(Roles = "Korisnik,Zaposlenik")]
        public override Task<Reservation> Update(int id, [FromBody] ReservationUpdateRequest update)
        {
            return base.Update(id, update);
        }
    }
}
