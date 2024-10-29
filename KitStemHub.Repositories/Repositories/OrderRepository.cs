using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Repositories.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(KitStemHubWpfContext context) : base(context)
        {

        }

        public IEnumerable<Order> getOrderTest()
        {
            return GetAll();
        }
    }
}
