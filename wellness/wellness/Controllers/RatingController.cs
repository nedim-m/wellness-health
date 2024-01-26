using wellness.Model;
using wellness.Model.Rating;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    public class RatingController : CrudController<Rating, BaseSearchObject, RatingPostRequest, RatingPostRequest>
    {
        public RatingController(ILogger<BaseController<Rating, BaseSearchObject>> logger, IRatingService service) : base(logger, service)
        {
        }
    }
}
