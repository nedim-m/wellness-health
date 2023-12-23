using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Rating;

namespace wellness.Service.IServices
{
    public interface IRatingService:ICrudService<Rating,BaseSearchObject,RatingPostRequest,RatingPostRequest>
    {

    }
}
