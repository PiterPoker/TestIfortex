using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(ApplicationDbContext db) : base(db)
        {
        }

        public Task<User> GetUser()
        {
            return _db.Users
                .Select(u=> new { User = u, CountOrders = u.Orders.Count })
                .OrderByDescending(u => u.CountOrders)
                .Select(u=>u.User)
                .FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
