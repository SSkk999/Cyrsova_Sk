using cyrsach.BLL.Dto.Question;
using cyrsach.BLL.Dto.Test;
using cyrsach.BLL.Services.Question;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cyrsach.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("by-test")]
        public async Task<IActionResult> GetByTestId([FromQuery] string testId)
        {
            var response = await _questionService.GetByTestIdAsync(testId);

            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuestionDto dto)
        {
            var response = await _questionService.CreateAsync(dto);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut ("reneme-text")]
        public async Task<IActionResult> RenemeText([FromBody] RenemeTestTitleDto dto)
        {
            var response = await _questionService.RenemeTextAsync(dto);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpDelete("{id}")]

            public async Task<IActionResult> Delete(string id)
            {
                var response = await _questionService.DeleteAsync(id);
                return StatusCode((int)response.StatusCode, response);
        }
    }
}
