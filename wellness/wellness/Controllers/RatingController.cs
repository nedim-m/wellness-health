using Microsoft.AspNetCore.Authorization;
using wellness.Model;
using wellness.Model.Rating;
using wellness.Service.IServices;

namespace wellness.Controllers
{

    [Authorize(Roles = "Korisnik")]
    public class RatingController : CrudController<Rating, RatingSearchObj, RatingPostRequest, RatingUpdateRequest>
    {
        public RatingController(ILogger<BaseController<Rating, RatingSearchObj>> logger, IRatingService service) : base(logger, service)
        {
        }
    }
}
