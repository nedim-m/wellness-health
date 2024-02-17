using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model;
using wellness.Model.Report;

namespace wellness.Service.IServices
{
    public interface IReportService:ICrudService<Report,BaseSearchObject,ReportPostRequest,ReportPostRequest>
    {
        Task<ReportChart> GetNumOfActiveUseres();
        Task<ReportChart> GetNumOfActiveMemeberships();
        Task<ReportChart> GetNumOfReservations();
    }
}
