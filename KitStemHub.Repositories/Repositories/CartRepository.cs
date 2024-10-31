using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Repositories.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(KitStemHubWpfContext context) : base(context) 
        {

        }

        public Cart GetExistingKit(Guid userId, int kitId)
        {
            var existingKit = _dbContext.Carts.FirstOrDefault(c =>
            c.UserId == userId &&
            c.KitId == kitId);
            return existingKit!;
        }

        public IEnumerable<Cart> GetCartByUserId(Guid userId)
        {
            return _dbContext.Carts
                .Include(c => c.Kit)
                .Where(c => c.UserId == userId)
                .ToList();
        }
    }
}
