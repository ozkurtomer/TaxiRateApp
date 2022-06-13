using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("getuser")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var result = await _usersService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return Ok(result);
        }

        [HttpPost("updateuser")]
        public async Task<IActionResult> UpdateUser(Users users)
        {
            var result = await _usersService.Update(users); 
            if (result.Success)
            {
                return Ok(result);
            }

            return Ok(result);
        }
    }
}
