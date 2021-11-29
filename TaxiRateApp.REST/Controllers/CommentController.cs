using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        public ICommentsService _commentService;

        public CommentController(ICommentsService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("add")]
        public IActionResult Add(Comments comments)
        {
            try
            {
                var result = _commentService.Add(comments);
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
        public IActionResult Update(Comments comments)
        {
            try
            {
                var result = _commentService.Update(comments);
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
        public IActionResult Delete(Comments comments)
        {
            try
            {
                var result = _commentService.Delete(comments);
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

        [HttpGet("getbypostid")]
        public IActionResult GetByPostId(int id)
        {
            try
            {
                var result = _commentService.GetAllByPostsId(id);
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
