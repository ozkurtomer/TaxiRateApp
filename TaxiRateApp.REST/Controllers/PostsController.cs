using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpPost("add")]
        public IActionResult Add(Posts posts)
        {
            try
            {
                var result = _postsService.Add(posts);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public IActionResult Update(Posts posts)
        {
            try
            {
                var result = _postsService.Update(posts);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Posts posts)
        {
            try
            {
                var result = _postsService.Delete(posts);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getpostshomescreen")]
        public IActionResult GetPostsHomeScreen()
        {
            try
            {
                var result = _postsService.GetPostsHomeScreen();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getallbyuserid")]
        public IActionResult GetAllByUserId(int userId)
        {
            try
            {
                var result = _postsService.GetAllByUserId(userId);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getdetailwithid")]
        public IActionResult GetDetailWithId(int postId)
        {
            try
            {
                var result = _postsService.GetPostsDetailWithId(postId);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getlastfiveposts")]
        public IActionResult GetLastFivePosts()
        {
            try
            {
                var result = _postsService.GetFivePosts(); 
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
