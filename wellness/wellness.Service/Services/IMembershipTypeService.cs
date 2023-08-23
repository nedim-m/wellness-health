using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.MembershipType;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public interface IMembershipTypeService:ICrudService<MembershipType,BaseSearchObject,MembershipTypePostRequest,MembershipTypePostRequest>
    {
    }
}
