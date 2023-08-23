using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Service.IServices;

namespace wellness.Controllers
{

    public class CrudController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        protected new readonly ICrudService<T, TSearch, TInsert, TUpdate> _service;
        protected new readonly ILogger<BaseController<T, TSearch>> _logger;

        public CrudController(ILogger<BaseController<T, TSearch>> logger, ICrudService<T, TSearch, TInsert, TUpdate> service)
            : base(logger, service)
        {
            _logger = logger;
            _service = service;
        }

        //[HttpPost, Authorize(Roles = "Administrator")]
        [HttpPost]
        public virtual async Task<T> Insert([FromBody] TInsert insert)
        {
            return await _service.Insert(insert);
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        public virtual async Task<T> Update(int id, [FromBody] TUpdate update)
        {
            return await _service.Update(id, update);
        }

    }
}
