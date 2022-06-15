<<<<<<< Updated upstream
﻿using System;
using System.Threading.Tasks;
=======
﻿using Microsoft.AspNetCore.Cors;
>>>>>>> Stashed changes
using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Core.Extensions;
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
        public async Task<IActionResult> Add(Posts posts)
        {
            try
            {
                var result = await _postsService.Add(posts);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Posts posts)
        {
            try
            {
                var result = await _postsService.Update(posts);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Posts posts)
        {
            try
            {
                var result = await _postsService.Delete(posts);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("getpostshomescreen")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _postsService.GetPostsHomeScreen();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("getpostsuser")]
        public async Task<IActionResult> GetPostUser(int userId)
        {
            try
            {
                var result = await _postsService.GetAllByUserId(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("getallbyuserid")]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            try
            {
                var result = await _postsService.GetAllByUserId(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("getdetailwithid")]
        public async Task<IActionResult> GetDetailWithId(string postId)
        {
            try
            {
                var result = await _postsService.GetPostsDetailWithId(postId.TryToInt());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("getlastfiveposts")]
        public async Task<IActionResult> GetLastFivePosts()
        {
            try
            {
                var result = await _postsService.GetFivePosts();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("getpostswithplateno")]
        public async Task<IActionResult> GetPostsWithPlateNo(string plateNo)
        {
            try
            {
                var result = await _postsService.GetPostWithPlateNo(plateNo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
