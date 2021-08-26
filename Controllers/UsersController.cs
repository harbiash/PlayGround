using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PlayGround.WebAPI.Helpers;
using PlayGround.WebAPI.Models;
using PlayGround.WebAPI.Models.ViewModels;
using PlayGround.WebAPI.Services;

namespace PlayGround.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly HttpClient HttpClient = new();
        private readonly IUserService _userService;
        private const string ApiKey = "key46INqjpp7lMzjd";
        private const string BaseApiUrl = "https://api.airtable.com/v0/appD1b1YjWoXkUJwR";

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Messages()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

       
    }
}