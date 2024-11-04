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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(KitStemHubWpfContext context) : base(context)
        {
        }

        public List<User> GetUsersByRole(string roleName, int? skip = null, int? take = null)
        {
            return GetFilter(
                filter: user => user.Role != null && user.Role.Name == roleName,
                includes: query => query.Include(user => user.Role),
                skip: skip,
                take: take
            ).Item1.ToList();
        }
    }
}
