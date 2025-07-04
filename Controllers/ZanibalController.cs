using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using Refit_tutorial.Model_Interface;

namespace Refit_tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZanibalController : ControllerBase
    {
        private readonly ILogger<ZanibalController> _logger;
        private readonly IZanibalApi _zanibalApi;
        public ZanibalController(IZanibalApi zanibalApi, ILogger<ZanibalController> logger)
        {
            _zanibalApi = zanibalApi;
            _logger = logger;
        }


        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken([FromBody] ZaniRequest request)
        {
            try
            {
                var result = await _zanibalApi.GetTokenAsync(request);
                return Ok(result);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the webhook list.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Content:{ex.Content} \n {ex.ReasonPhrase}");



            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the webhook list.");
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
                    username = "Uq2bKq+/sdfsadfsadsfasf==",
                    password = "/sdfsadfsf/asdfsdfsf+GI0=",
                    tenant = "asdfsdfdsf"
                };

                var result = await _zanibalApi.GetTokenAsync(request);

                var getResp = await _zanibalApi.GetWebhooklistAsync($"Bearer {result.access_token}");

                return Ok(getResp);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the webhook list.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Content:{ex.Content} \n {ex.ReasonPhrase}");



            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the webhook list.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }

        }
    }
}
