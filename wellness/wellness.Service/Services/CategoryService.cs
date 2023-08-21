using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Category;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class CategoryService : CrudService<Category, Database.Category, BaseSearchObject, CategoryPostRequest, CategoryPostRequest>,ICategoryService
    {
        public CategoryService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
        }

    }
}
