using MediatorR.Dtos;
using MediatorR.Models;

namespace MediatorR.Services.Interface
{
    public interface ILoginUserService
    {
        Task<string> LoginUser(LoginDto loginDto);
    }
}
