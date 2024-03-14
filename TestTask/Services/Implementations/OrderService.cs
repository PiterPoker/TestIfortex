using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : ServiceBase, IOrderService
    {
        public OrderService(ApplicationDbContext db) : base(db)
        {
        }

        public Task<Order> GetOrder()
        {
            return _db.Orders
                .Select(o => new { Order = o, Amount = o.Price * o.Quantity })
                .OrderByDescending(o => o.Amount)
                .Select(o => o.Order)
                .FirstOrDefaultAsync();
        }

        public Task<List<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
