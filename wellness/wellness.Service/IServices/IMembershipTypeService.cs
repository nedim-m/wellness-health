using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.MembershipType;

namespace wellness.Service.IServices
{
    public interface IMembershipTypeService : ICrudService<MembershipType, BaseSearchObject, MembershipTypePostRequest, MembershipTypePostRequest>
    {
    }
}
