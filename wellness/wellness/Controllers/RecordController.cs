using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.Record;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    
    public class RecordController : CrudController<Record, RecordSearchObj, RecordPostRequest, RecordPostRequest>
    {
        public RecordController(ILogger<BaseController<Record, RecordSearchObj>> logger, IRecordService service) : base(logger, service)
        {
        }

        [Authorize(Roles = "Administrator,Zaposlenik")]
        public override Task<Record> Insert([FromBody] RecordPostRequest insert)
        {
            return base.Insert(insert);
        }
        [Authorize(Roles = "Administrator,Zaposlenik")]
        public override Task<PagedResult<Record>> Get([FromQuery] RecordSearchObj? search = null)
        {
            return base.Get(search);
        }
        [Authorize(Roles = "Administrator,Zaposlenik")]
        public override Task<Record> GetById(int id)
        {
            return base.GetById(id);
        }
        [Authorize(Roles = "Administrator,Zaposlenik")]
        public override Task<Record> Update(int id, [FromBody] RecordPostRequest update)
        {
            return base.Update(id, update);
        }
    }
}
