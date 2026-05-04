using cyrsach.BLL.Dto.Auth;
using cyrsach.BLL.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cyrsach.Extensions;
namespace cyrsach.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AuthController(IAuthService authService, IWebHostEnvironment environment)
        {
            _authService = authService;
            _webHostEnvironment = environment;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            var response = await _authService.LoginAsync(dto);
            return this.ToActionResult(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto dto)
        {
            var rootPath = _webHostEnvironment.ContentRootPath;
            var imagePath = Path.Combine(rootPath, "storage", "images");

            var response = await _authService.RegisterAsync(dto, imagePath);
            return this.ToActionResult(response);
        }
        [HttpPut("rename")]
        public async Task<IActionResult> Renemeasync([FromBody] RenemeDto dto)
        {
            var response = await _authService.RenameAsync(dto);
            return this.ToActionResult(response);


        }
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordDto dto)
        {
            var response = await _authService.ChangePasswordAsync(dto);
            return this.ToActionResult(response);
        }
    }
}
