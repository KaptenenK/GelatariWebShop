using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthservice _authService;

        public AuthController(IAuthservice authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>>Register (UserRegister request)
        {
            var responese = await _authService.Register(
            new Shared.User
            {
                Email = request.Email
            },
                request.Password);
            if(!responese.Success) 
            {
                return BadRequest(responese);
            }
            return Ok(responese);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login (UserLogin request)
        {
            var response = await _authService.Login(request.Email, request.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("change-password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
        {
            //NameIdentifier är skapad via ClaimTypes - > NameIdentifier -> userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authService.ChangePassword(int.Parse(userId), newPassword);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
