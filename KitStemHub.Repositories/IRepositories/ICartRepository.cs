using KitStemHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Repositories.IRepositories
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        List<Cart> GetAllCartByUserId(Guid userId);
        public IEnumerable<Cart> GetCartByUserId(Guid userId);
        public Cart GetExistingKit(Guid userId, int kitId);
    }
}
