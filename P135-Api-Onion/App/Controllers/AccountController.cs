using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Account;
using Services.DTOs.Country;
using Services.Services.Interfaces;

namespace App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }


        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto model)
        {
                return Ok(await _service.SignUpAsync(model));
        }


        //[HttpPost]
        //[Route("Login")]
        //public IActionResult SignIn([FromBody] LoginRequest request)
        //{
        //    var response = new Dictionary<string, string>();
        //    if (!(request.Username == "admin" && request.Password == "Admin@123"))
        //    {
        //        response.Add("Error", "Invalid username or password");
        //        return BadRequest(response);
        //    }

        //    var roles = new string[] { "Role1", "Role2" };
        //    var token = GenerateJwtToken(request.Username, roles.ToList());
        //    return Ok(new LoginResponse()
        //    {
        //        Access_Token = token,
        //        UserName = request.Username
        //    });
        //}

    }
}
