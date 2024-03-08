using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.Rating;
using wellness.Service.IServices;

namespace wellness.Controllers
{

    
    public class RatingController : CrudController<Rating, RatingSearchObj, RatingPostRequest, RatingUpdateRequest>
    {
        public RatingController(ILogger<BaseController<Rating, RatingSearchObj>> logger, IRatingService service) : base(logger, service)
        {
        }


        [Authorize(Roles = "Korisnik")]
        public override Task<PagedResult<Rating>> Get([FromQuery] RatingSearchObj? search = null)
        {
            return base.Get(search);
        }


        [Authorize(Roles = "Korisnik")]
        public override Task<Rating> GetById(int id)
        {
            return base.GetById(id);
        }

        [Authorize(Roles = "Korisnik")]
        public override Task<Rating> Insert([FromBody] RatingPostRequest insert)
        {
            return base.Insert(insert);
        }

        [Authorize(Roles = "Korisnik")]
        public override Task<Rating> Update(int id, [FromBody] RatingUpdateRequest update)
        {
            return base.Update(id, update);
        }
    }
}
