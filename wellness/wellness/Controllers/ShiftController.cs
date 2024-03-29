﻿using Microsoft.AspNetCore.Authorization;
using wellness.Model;
using wellness.Model.Record;
using wellness.Model.Role;
using wellness.Model.Shift;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ShiftController : BaseController<Shift,BaseSearchObject>
    {
        public ShiftController(ILogger<BaseController<Shift, BaseSearchObject>> logger, IShiftService service) : base(logger, service)
        {
        }
    }
}
