using AutoMapper;
using cyrsach.BLL.Dto.Answer;
using cyrsach.BLL.Dto.Test;
using cyrsach.DAL.Entities;
using cyrsach.DAL.Repositories.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.BLL.Services.Answer
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> CreateAsync(CreateAnswerDto dto)
        {
            var answer = _mapper.Map<AnswerEntity>(dto);
            await _answerRepository.CreateAsync(answer);

            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Answer created",
                Payload = answer.Id
            };
        }

        public async Task<ServiceResponse> GetByQuestionIdAsync(string questionId)
        {
            var answers = await _answerRepository.GetByQuestionIdAsync(questionId);

            if (answers == null || !answers.Any())
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Answers not found"
                };
            }

            var dto = _mapper.Map<List<AnswerDto>>(answers);

            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Payload = dto
            };
        }

        public async Task<ServiceResponse> RenemeTextAsync(RenemeTestTitleDto dto)
        {
            var answer = await _answerRepository.GetByIdAsync(dto.Id);
            if (answer == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Answer not found"
                };
            }
            answer.Text = dto.NewText;
            await _answerRepository.UpdateAsync(answer);
            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Answer text renamed"
            };
        }

        public async Task<ServiceResponse> RenemeCorrectAsync(RenemeAnswerDto dto)
        {
            var answer = await _answerRepository.GetByIdAsync(dto.Id);
            if (answer == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Answer not found"
                };
            }
            if (answer.IsCorrect)
            {
                answer.IsCorrect = false;
            }
            else
            {
                answer.IsCorrect = true;
            }
            await _answerRepository.UpdateAsync(answer);
            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Answer correctness renamed"
            };
        }
        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var answer = await _answerRepository.GetByIdAsync(id);
            if (answer == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Answer not found"
                };
            }
            await _answerRepository.DeleteAsync(answer);
            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Answer deleted"
            };
        }
    }
}
