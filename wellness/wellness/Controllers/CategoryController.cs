﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpDelete("{id}"), Authorize(Roles = "Administrator, Zaposlenik")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _service.Delete(id);
            if (response)
                return Ok(response);
            return BadRequest();
        }



        [Authorize(Roles = "Administrator,Zaposlenik,Korisnik")]
        public override Task<PagedResult<Category>> Get([FromQuery] BaseSearchObject? search = null)
        {
            return base.Get(search);
        }
        [Authorize(Roles = "Administrator,Zaposlenik")]
        public override Task<Category> Insert([FromBody] CategoryPostRequest insert)
        {
            return base.Insert(insert);

        }
        [Authorize(Roles = "Administrator,Zaposlenik")]
        public override Task<Category> Update(int id, [FromBody] CategoryPostRequest update)
        {
            return base.Update(id, update);
        }

        [Authorize(Roles = "Administrator,Zaposlenik,Korisnik")]
        public override Task<Category> GetById(int id)
        {
            return base.GetById(id);
        }


    }
}
