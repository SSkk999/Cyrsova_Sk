using cyrsach.BLL.Dto.Auth;
using cyrsach.BLL.Dto.User;
using cyrsach.DAL.Entities;
using cyrsach.DAL.Repositories.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.BLL.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _UserRepository;
        private readonly PasswordHasher<UserEntity> _hasher = new();


        public AuthService(IUserRepository userRepository)
        {

            _UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        private static UserDto MapUserDto(UserEntity user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role,

            };
        }


        public async Task<ServiceResponse> LoginAsync(LoginDto dto)
        {


            var user = await _UserRepository.GetByNameAsync(dto.Name);

            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Логін вказано невірно"
                };
            }

            var result = _hasher.VerifyHashedPassword(user, user.HashPassword, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Пароль вказано невірно"
                };
            }



            return new ServiceResponse
            {
                Message = "Успішний вхід",
                Payload = new { User = MapUserDto(user) }
            };
        }



        public async Task<ServiceResponse> RegisterAsync(RegisterDto dto, string imagePath)
        {

            if (dto == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Помилка"
                };
            }

            var user = new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                Name = dto.Name,
                Role = dto.Role,


            };




            if (await _UserRepository.ExistsByNameAsync(user.Name))
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Вже є такий акаунт"
                };
            }
            var hash = _hasher.HashPassword(user, dto.Password);
            user.HashPassword = hash;

            await _UserRepository.CreateAsync(user);

            return new ServiceResponse
            {
                Message = "Успішна реєстрація",
                Payload = new { User = MapUserDto(user) }
            };
        }

        public async Task<ServiceResponse> RenameAsync(RenemeDto dto)
        {
            var user = await _UserRepository.GetByNameAsync(dto.OldName);
            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Помилка"
                };
            }
            if (await _UserRepository.ExistsByNameAsync(dto.NewName))
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Вже є такий акаунт"
                };
            }
            user.Name = dto.NewName;
            await _UserRepository.UpdateAsync(user);
            return new ServiceResponse
            {
                Message = "Успішна зміна імені",
                Payload = new { User = MapUserDto(user) }
            };
        }

        public async Task<ServiceResponse> ChangePasswordAsync(ChangePasswordDto dto)
        {
            var user = await _UserRepository.GetByIdAsync(dto.Id);
            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Помилка"
                };
            }
            var result = _hasher.VerifyHashedPassword(user, user.HashPassword, dto.OldPassword);
            if (result == PasswordVerificationResult.Failed)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Пароль вказано невірно"
                };
            }
            var hash = _hasher.HashPassword(user, dto.NewPassword);
            user.HashPassword = hash;
            await _UserRepository.UpdateAsync(user);
            return new ServiceResponse
            {
                Message = "Успішна зміна пароля",
                Payload = new { User = MapUserDto(user) }
            };
        }
    }
}
