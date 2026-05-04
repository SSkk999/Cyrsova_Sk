using AutoMapper;
using cyrsach.BLL.Dto.Question;
using cyrsach.DAL.Repositories.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using cyrsach.BLL.Dto.Test;
namespace cyrsach.BLL.Services.Question
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> CreateAsync(CreateQuestionDto questionCreateDto)
        {
            var question = _mapper.Map<DAL.Entities.QuestionEntity>(questionCreateDto);
            await _questionRepository.CreateAsync(question);

            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Question created",
                Payload = question.Id
            };
        }

        public async Task<ServiceResponse> GetByTestIdAsync(string testId)
        {
            var questions = await _questionRepository.GetByTestIdAsync(testId);

            if (questions == null || !questions.Any())
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Questions not found"
                };
            }

            var dto = _mapper.Map<List<QuestionDto>>(questions);

            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Payload = dto
            };
        }
        public async Task<ServiceResponse> RenemeTextAsync(RenemeTestTitleDto dto)
        {
            var question = await _questionRepository.GetByIdAsync(dto.Id);
            if (question == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Question not found"
                };
            }
            question.Text = dto.NewText;
            await _questionRepository.UpdateAsync(question);
            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Question text renamed"
            };
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            if (question == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Question not found"
                };
            }
            await _questionRepository.DeleteAsync(question);
            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Question deleted"
            };
        }
    }
}
