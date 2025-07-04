using Microsoft.AspNetCore.Mvc;
using Refit_tutorial.Model_Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Refit_tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly I_PostService _postService;
        public PostController(I_PostService postService, ILogger<PostController> logger)
        {
            _postService = postService;
            _logger = logger;   
        }

        // GET: api/<PostController>
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            try
            {
                var result = await _postService.GetPostsAsync();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            try
            {
                var result  = await _postService.GetPostByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // POST api/<PostController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            try
            {
                var result = await _postService.CreatePostAsync(post);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Post post)
        {
            try
            {
                var result = await _postService.UpdatePostAsync(id, post);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _postService.DeletePostAsync(id);
                // Return a 204 No Content response
                Response.StatusCode = 204;
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, return an error response, etc.)
                throw;
            }
        }
    }
}
