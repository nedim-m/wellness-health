using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;

namespace wellness.Service.IServices
{
    public interface IService<T,TSearch> where T : class where TSearch : class
    {
        Task<PagedResult<T>> Get(TSearch? search = null);
        Task<T> GetById(int id);
    }
}
