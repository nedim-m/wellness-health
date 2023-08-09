using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Service.IServices
{
    public interface ICrudService<T, TSearch, TInsert, TUpdate> : IService<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        Task<T> Insert(TInsert insert);
        Task<T> Update(int id, TUpdate update);
    }
}
