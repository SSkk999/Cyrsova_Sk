using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cyrsach.BLL.Dto.Answer;
using cyrsach.BLL.Dto.Test;
namespace cyrsach.BLL.Services.Answer
{
    public interface IAnswerService
    {
        Task<ServiceResponse> GetByQuestionIdAsync(string questionId);

        Task<ServiceResponse> CreateAsync(CreateAnswerDto dto);

        Task<ServiceResponse> RenemeTextAsync(RenemeTestTitleDto dto);

        Task<ServiceResponse> RenemeCorrectAsync(RenemeAnswerDto dto);

        Task<ServiceResponse> DeleteAsync(string id);
    }
}
