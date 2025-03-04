using MediatorR.Models;

namespace MediatorR.Services.Interface
{
    public interface IRegisterUserService
    {
        Task<Guid> Registeruser(Users user);
    }
}
