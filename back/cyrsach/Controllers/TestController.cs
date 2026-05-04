using cyrsach.BLL.Dto.Auth;
using cyrsach.BLL.Dto.Test;
using cyrsach.BLL.Services.Test;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cyrsach.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTestDto dto)
        {


            var response = await _testService.CreateAsync(dto, dto.AuthorId);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var response = await _testService.GetByIdAsync(id);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _testService.GetAllAsync();

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("id-user")]
        public async Task<IActionResult> GetByUserId([FromQuery] string userId)
        {
            var response = await _testService.GetByUserIdAsync(userId);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteById([FromQuery] string id)
        {
            var response = await _testService.DeleteByIdAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPut("Reneme-Title")]
        public async Task<IActionResult> RenemeTitle([FromBody] RenemeTestTitleDto dto)
        {
            var response = await _testService.RenemeTitleAsync(dto);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut("Reneme-Description")]
        public async Task<IActionResult> RenemeDescription([FromBody] RenemeTestTitleDto dto)
        {
            var response = await _testService.RenemeDescriptionasync(dto);
            return StatusCode((int)response.StatusCode, response);
        
        }

        [HttpPut("Reneme-Time")]
        public async Task<IActionResult> RenemeTime([FromBody] RenemeTestTitleDto dto)
        {
            var response = await _testService.RenemeTimeAsync(dto);
            return StatusCode((int)response.StatusCode, response);

        }


        [HttpPut("Reneme-QuestionCount")]
        public async Task<IActionResult> RenemeQuestionCount([FromBody] RenemeTestTitleDto dto)
        {
            var response = await _testService.RenemeQuestionCountAsync(dto);
            return StatusCode((int)response.StatusCode, response);

        }
        
    }
}
