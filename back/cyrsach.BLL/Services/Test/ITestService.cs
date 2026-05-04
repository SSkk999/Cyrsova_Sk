using cyrsach.BLL.Dto.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.BLL.Services.Test
{
    public interface ITestService
    {
        Task<ServiceResponse> CreateAsync(CreateTestDto dto, string authorId);
        Task<ServiceResponse> GetByIdAsync(string id);
        Task<ServiceResponse> GetAllAsync();

        Task<ServiceResponse> GetByUserIdAsync(string userId);

            Task<ServiceResponse> DeleteByIdAsync(string id);

        Task<ServiceResponse> RenemeTitleAsync(RenemeTestTitleDto dto);

        Task<ServiceResponse> RenemeDescriptionasync(RenemeTestTitleDto dto);

        Task<ServiceResponse> RenemeTimeAsync(RenemeTestTitleDto dto);

        Task<ServiceResponse> RenemeQuestionCountAsync(RenemeTestTitleDto dto);



    }
}
