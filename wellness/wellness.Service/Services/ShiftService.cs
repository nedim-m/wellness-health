using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Shift;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class ShiftService : Service<Shift, Database.Shift, BaseSearchObject>, IShiftService
    {
        public ShiftService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
        }

        public override IQueryable<Database.Shift> AddFilter(IQueryable<Database.Shift> query, BaseSearchObject? search = null)
        {
            query=query.Where(x => x.Id!=1);
            return base.AddFilter(query, search);
        }
    }
}
