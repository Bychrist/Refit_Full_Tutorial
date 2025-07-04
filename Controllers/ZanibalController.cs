using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit_tutorial.Model_Interface;

namespace Refit_tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZanibalController : ControllerBase
    {
        private readonly ILogger<ZanibalController> _logger;
        private readonly IZanibalApi _zanibalApi;
        public ZanibalController(IZanibalApi zanibalApi)
        {
            _zanibalApi = zanibalApi;
        }


        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken([FromBody] ZaniRequest request)
        {
            try
            {
                var result = await _zanibalApi.GetTokenAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the token.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        [HttpPost("GetWebhooklist")]
        public async Task<IActionResult> Webhook()
        {
            try
            {
                var request = new ZaniRequest
                {
                    username = "your username here",
                    password = "your password here",
                    tenant = "tenant here"
                };

                var result = await _zanibalApi.GetTokenAsync(request);

                var getResp = await _zanibalApi.GetWebhooklistAsync($"Bearer {result.access_token}");

                return Ok(getResp);
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex);
            }
        }
    }
}
