using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.Category;
using wellness.Service.IServices;

namespace wellness.Controllers
{
   
    public class CategoryController : CrudController<Category, BaseSearchObject, CategoryPostRequest, CategoryPostRequest>
    {
        private new readonly ICategoryService _service;
        public CategoryController(ILogger<BaseController<Category, BaseSearchObject>> logger, ICategoryService service) : base(logger, service)
        {
            _service=service;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _service.Delete(id);
            if (response)
                return Ok(response);
            return BadRequest();
        }


    }
}
