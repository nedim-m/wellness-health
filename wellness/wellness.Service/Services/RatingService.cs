using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Rating;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class RatingService : CrudService<Rating, Database.Rating, BaseSearchObject, RatingPostRequest, RatingPostRequest>, IRatingService
    {
        public RatingService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
        }
    }
}
