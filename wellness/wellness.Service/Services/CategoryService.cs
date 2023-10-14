using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Category;
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
   
    public class CategoryService : CrudService<Model.Category.Category, Database.Category, BaseSearchObject, CategoryPostRequest, CategoryPostRequest>, ICategoryService
    {
        private readonly DbWellnessContext _context;
        public CategoryService(IMapper mapper, Database.DbWellnessContext context) : base(mapper, context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var obj = await _context.Categories.FindAsync(id);
            if (obj != null)
            {
                var hasRelatedTreatments = await _context.Treatments
                    .AnyAsync(t => t.CategoryId == id);

                if (!hasRelatedTreatments)
                {
                    _context.Categories.Remove(obj);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
