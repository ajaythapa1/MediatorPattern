using MediatorR.Dtos;
using MediatorR.Models;

namespace MediatorR.Repository.Interface
{
    public interface IUserRepository
    {
        Task<bool> IsUserNameTaken(string userName);
        Task<bool> IsEmailTaken(string email);
        Task<Guid> AddUser(Users user);
        Task<List<UserDto>> GetAllUser();
    }
}
