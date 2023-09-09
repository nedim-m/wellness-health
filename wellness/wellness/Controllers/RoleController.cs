using wellness.Model;
using wellness.Model.Record;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    public class RecordController : CrudController<Record, BaseSearchObject, RecordPostRequest, RecordPostRequest>
    {
        public RecordController(ILogger<BaseController<Record, BaseSearchObject>> logger, IRecordService service) : base(logger, service)
        {
        }
    }
}
