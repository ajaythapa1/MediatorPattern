using MediatorR.Data;
using MediatorR.Models;
using MediatorR.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MediatorR.Repository.Implementaion
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsUserNameTaken(string userName)
        {
            return await _context.Users.AnyAsync(user => user.UserName == userName);
        }
        public async Task<Guid> AddUser(Users user)
        {
            Users users = new Users()
            {
                Id = Guid.NewGuid(),
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                //PasswordHash = user.Password,
                //IsActive = true,
                //LastLoginDate = DateTime.UtcNow,
                //RegistrationDate = DateTime.UtcNow
            };

            await _context.Users.AddAsync(users);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email == email);
        }
    }
}
