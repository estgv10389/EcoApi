using EcoApi.DTO;
using EcoApi.Models;
using EcoApi.Services.Interfaces;
using EcoApi.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly TokenHandler tokenHandler;
        public AuthController(IAuthService authService, TokenHandler tokenHandler)
        {
            this.authService = authService;
            this.tokenHandler = tokenHandler;
        }

        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDTO loginDTO)
        {
           ApiResponse<UserDTO> apiResponse = new ApiResponse<UserDTO>();
           UserDTO? result = await authService.Login(loginDTO);
           if(result == null)
            {
                apiResponse.ErrorMessage = "Invalid email or password.";
                apiResponse.Success = false;
                return Unauthorized(apiResponse);
            }

            object? token = tokenHandler.CreateToken(result);
            apiResponse.Token = token.ToString();
            apiResponse.Data = result;
            return Ok(apiResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            UserDTO result = await authService.Register(user);
            return Ok(result);
        }
        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
