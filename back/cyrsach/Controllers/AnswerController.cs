using cyrsach.BLL.Dto.Answer;
using cyrsach.BLL.Dto.Test;
using cyrsach.BLL.Services.Answer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cyrsach.Controllers
{
    [Route("api/answer")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet("by-question")]
        public async Task<IActionResult> GetByQuestionId([FromQuery] string questionId)
        {
            var response = await _answerService.GetByQuestionIdAsync(questionId);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAnswerDto dto)
        {
            var response = await _answerService.CreateAsync(dto);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut("Reneme-Text")]
        public async Task<IActionResult> RenemeText([FromBody] RenemeTestTitleDto dto)
        {
            var response = await _answerService.RenemeTextAsync(dto);
            return StatusCode((int)response.StatusCode, response);
        }


        [HttpPut("Reneme-IsCorrect")]
        public async Task<IActionResult> RenemeIsCorrect([FromBody] RenemeAnswerDto dto)
        {
            var response = await _answerService.RenemeCorrectAsync(dto);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _answerService.DeleteAsync(id);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
