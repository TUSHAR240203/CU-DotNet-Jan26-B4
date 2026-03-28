using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBank.LogTrack.Services;

namespace SmartBank.LogTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackingController : ControllerBase
    {
        private readonly TrackingService _trackingService;

        public TrackingController(TrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_trackingService.GetAll());
        }

        [HttpGet("latest")]
        public IActionResult GetLatest()
        {
            var data = _trackingService.GetLatest();

            if (data == null)
            {
                return NotFound("No data yet");
            }

            return Ok(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            var history = _trackingService.GetHistory();

            if (history.Count == 0)
            {
                return NotFound("No GPS history found.");
            }

            return Ok(history);
        }
    }
}