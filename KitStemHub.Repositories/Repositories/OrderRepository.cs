using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Repositories.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(KitStemHubWpfContext context) : base(context)
        {

        }

        public List<KitOrder> GetKitOrdersByOrderId(Guid orderId)
        {
            return _dbContext.KitOrders
                .Include(ko => ko.Kit)  // Include related Kit data
                .Where(ko => ko.OrderId == orderId)
                .ToList();
        }

        public IEnumerable<Order> getOrderTest()
        {
            return GetAll();
        }

        

        
    }
}
