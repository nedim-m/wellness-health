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
    }
}
