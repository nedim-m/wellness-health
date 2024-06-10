using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    [Authorize(Roles = "Korisnik")]
    [ApiController]
    [Route("[controller]")]
    public class RecommendationController:ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService=recommendationService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetRecommendedTreatments(int userId)
        {
            var recommendedTreatments = _recommendationService.GetRecommendedTreatments(userId);
            return Ok(recommendedTreatments);
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Initialize()
        {
            var date= DateTime.Now;
            _recommendationService.InitializeRecommendations(date);
            return Ok("Preporučeni tretmani su inicijalizirani.");
        }
    }
}
