using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Category;

namespace wellness.Service.IServices
{
    public interface ICategoryService : ICrudService<Category,BaseSearchObject,Category,Category>
    {

    }
}
