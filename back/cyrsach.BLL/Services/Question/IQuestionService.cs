using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cyrsach.BLL.Dto.Question;
using cyrsach.BLL.Dto.Test;
namespace cyrsach.BLL.Services.Question
{
    public interface IQuestionService
    {
        Task<ServiceResponse> GetByTestIdAsync(string testId);

        Task<ServiceResponse> CreateAsync (CreateQuestionDto questionCreateDto);

        Task<ServiceResponse> RenemeTextAsync(RenemeTestTitleDto dto);

        Task<ServiceResponse> DeleteAsync(string id);
    }
}
