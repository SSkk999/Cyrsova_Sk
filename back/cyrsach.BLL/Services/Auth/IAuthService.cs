using cyrsach.BLL.Dto.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.BLL.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse> LoginAsync(LoginDto dto);
        Task<ServiceResponse> RegisterAsync(RegisterDto dto, string imagePath);

        Task<ServiceResponse> RenameAsync(RenemeDto dto);

        Task<ServiceResponse> ChangePasswordAsync(ChangePasswordDto dto);



    }
}
