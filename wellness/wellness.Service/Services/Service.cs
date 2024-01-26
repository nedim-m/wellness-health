using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class Service<T, TDb, TSearch> : IService<T, TSearch> where T : class where TDb : class where TSearch : BaseSearchObject
    {
        private readonly IMapper _mapper;
        private readonly DbWellnessContext _context;

        public Service(IMapper mapper, DbWellnessContext context)
        {
            _mapper=mapper;
            _context=context;
        }
        public virtual async Task<PagedResult<T>> Get(TSearch? search = null)
        {
            var query = _context.Set<TDb>().AsQueryable();

            PagedResult<T> result = new();



            query = AddFilter(query, search);

            query = AddInclude(query, search);

            result.Count = await query.CountAsync();

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                query = query.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }

            var list = await query.ToListAsync();


            var tmp = _mapper.Map<List<T>>(list);
            result.Result = tmp;
            return result;
        }

       

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch? search = null)
        {
            return query;
        }

        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query, TSearch? search = null)
        {
            return query;
        }

        public virtual async Task<T> GetById(int id)
        {

            var entity = await _context.Set<TDb>().FindAsync(id);

            return _mapper.Map<T>(entity);
        }

      

    }
}
