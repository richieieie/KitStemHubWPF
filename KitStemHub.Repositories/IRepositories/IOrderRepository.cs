using KitStemHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Repositories.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> getOrderTest();
        List<KitOrder> GetKitOrdersByOrderId(Guid orderId);
        
    }
}
