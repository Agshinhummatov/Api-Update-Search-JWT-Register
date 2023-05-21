using Services.DTOs.Account;
using Services.Helpers.Responses;

namespace Services.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResponse> SignUpAsync(RegisterDto model);
        Task<LoginResponse> SignInAsync(LoginDto model);
    }
}
