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

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public bool UserExists(string username, string email)
        {
            return  _dbContext.Users.Any(u => u.Username == username || u.Email == email);
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(a => a.Id == id);
        }

        public int? Login(string email, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(p => p.Email == email && p.Password == password);
            if (user == null)
            {
                return 0;
            }
            return user.RoleId;
        }
    }
}
