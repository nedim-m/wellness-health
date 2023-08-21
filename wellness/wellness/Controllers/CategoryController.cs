using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.Category;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CrudController<Category, BaseSearchObject, CategoryPostRequest, CategoryPostRequest>
    {
        public CategoryController(ILogger<BaseController<Category, BaseSearchObject>> logger, ICategoryService service) : base(logger, service)
        {
        }

       

    }
}
