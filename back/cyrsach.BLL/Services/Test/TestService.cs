using AutoMapper;
using cyrsach.BLL.Dto.Test;
using cyrsach.DAL.Entities;
using cyrsach.DAL.Repositories.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace cyrsach.BLL.Services.Test
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> CreateAsync(CreateTestDto dto, string authorId)
        {
            var test = _mapper.Map<TestEntity>(dto);

            test.AuthorId = authorId;


            await _testRepository.CreateAsync(test);

            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Payload = test.Id,
                Message = "Test created"
            };
        }

        public async Task<ServiceResponse> GetByIdAsync(string id)
        {
            var test = await _testRepository.GetFullByIdAsync(id);

            if (test == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Test not found"
                };
            }

            var dto = _mapper.Map<TestDto>(test);

            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Payload = dto
            };
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var tests = await _testRepository.GetAllFullAsync();

            var dto = _mapper.Map<List<TestDto>>(tests);

            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Payload = dto
            };
        }

        public async Task<ServiceResponse> GetByUserIdAsync(string userId)
        {
            var tests = await _testRepository.GetAllByUserIdAsync(userId);

            if (tests == null || tests.Count == 0)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Немає ваших тестів"
                };
            }
            var dto = _mapper.Map<List<TestDto>>(tests);
            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Payload = dto
            };
        }
        public async Task<ServiceResponse> DeleteByIdAsync(string id)
        {
            var test = await _testRepository.GetByIdAsync(id);
            if (test == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Test not found"
                };
            }
            await _testRepository.DeleteAsync(test);
            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Test deleted"
            };
        }

        public async Task<ServiceResponse> RenemeTitleAsync(RenemeTestTitleDto dto)
        {
            var test = await _testRepository.GetByIdAsync(dto.Id);
            if (test == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Test not found"
                };
            }
            test.Title = dto.NewText;
            await _testRepository.UpdateAsync(test);
            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Test title renamed"
            };
        }



        public async Task<ServiceResponse> RenemeDescriptionasync(RenemeTestTitleDto dto)
        {
            var test = await _testRepository.GetByIdAsync(dto.Id);
            if (test == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Test not found"
                };
            }
            test.Description = dto.NewText;
            await _testRepository.UpdateAsync(test);
            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Test description renamed"
            };
        }


        public async Task<ServiceResponse> RenemeTimeAsync(RenemeTestTitleDto dto)
        {

            var test = await _testRepository.GetByIdAsync(dto.Id);
            if (test == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Test not found"
                };
            }
            test.Time = dto.NewText;
            await _testRepository.UpdateAsync(test);
            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Test description renamed"
            };

        }
        public async Task<ServiceResponse> RenemeQuestionCountAsync(RenemeTestTitleDto dto)
        {

            var test = await _testRepository.GetByIdAsync(dto.Id);
            if (test == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "Test not found"
                };
            }
            test.QuestionCount = dto.NewText;
            await _testRepository.UpdateAsync(test);
            return new ServiceResponse
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Test description renamed"
            };

        }
    }
}