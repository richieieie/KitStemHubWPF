﻿using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;

namespace KitStemHub.Repositories.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(KitStemHubWpfContext context) : base(context)
        {
        }
    }
}
