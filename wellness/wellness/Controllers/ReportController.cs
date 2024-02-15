using wellness.Model;
using wellness.Model.Report;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    public class ReportController : CrudController<Report, BaseSearchObject, ReportPostRequest, ReportPostRequest>
    {
        public ReportController(ILogger<BaseController<Report, BaseSearchObject>> logger, IReportService service) : base(logger, service)
        {
        }
    }
}
