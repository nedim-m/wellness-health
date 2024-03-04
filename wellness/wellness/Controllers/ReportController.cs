using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wellness.Model;
using wellness.Model.Report;
using wellness.Service.IServices;

namespace wellness.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class ReportController : CrudController<Report, BaseSearchObject, ReportPostRequest, ReportPostRequest>
    {

        private new readonly IReportService _service;
        public ReportController(ILogger<BaseController<Report, BaseSearchObject>> logger, IReportService service) : base(logger, service)
        {
            _service= service;
        }


        [HttpGet("report-users")]
        public async Task<ActionResult<ReportChart>> GetNumUsers()
        {
            try
            {
                var response = await _service.GetNumOfActiveUseres();
                return Ok(response);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Error: {ex.Message}");
            }
        }
        [HttpGet("report-memberships")]
        public async Task<ActionResult<ReportChart>> GetNumMemberships()
        {
            try
            {
                var response = await _service.GetNumOfActiveMemeberships();
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }
        [HttpGet("report-reservations")]
        public async Task<ActionResult<ReportChart>> GetNumReservations()
        {
            try
            {
                var response = await _service.GetNumOfReservations();
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}
