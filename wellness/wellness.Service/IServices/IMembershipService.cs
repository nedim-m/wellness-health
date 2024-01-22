using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Membership;
using wellness.Model.MembershipType;

namespace wellness.Service.IServices
{
    public interface IMembershipService:ICrudService<Membership,BaseSearchObject,MembershipPostRequest,MembershipPostRequest>
    {
    }
}
