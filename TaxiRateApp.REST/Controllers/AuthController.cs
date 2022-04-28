using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Entities.Dtos;
using TaxiRateApp.Business.Abstract;

namespace TaxiRateApp.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return Ok(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return Ok(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.UserPassword);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
