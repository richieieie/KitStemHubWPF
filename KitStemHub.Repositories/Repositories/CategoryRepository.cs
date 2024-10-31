using KitStemHub.Repositories.Models;
using KitStemHub.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitStemHub.Repositories.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly KitStemHubWpfContext _context;

        public CategoryRepository(KitStemHubWpfContext context) : base(context)
        {
            _context = context;
        }

        // Example of a category-specific method
        public async Task<IEnumerable<Category>> GetActiveCategoriesAsync()
        {
            return await _context.Set<Category>()
                .Where(c => c.Status == true)
                .ToListAsync();
        }

    }
}
