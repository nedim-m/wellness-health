using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.MembershipType;

namespace wellness.Service.Services
{
    public class MembershipTypeService : CrudService<MembershipType, Database.MembershipType, BaseSearchObject, MembershipTypePostRequest, MembershipTypePostRequest>, IMembershipTypeService
    {
        public MembershipTypeService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
        }
    }
}
