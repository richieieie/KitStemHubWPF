using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Repositories.Repositories
{
    
    public class UserRepository : IUserRepository
    {
        private readonly KitStemHubWpfContext _context;

        public UserRepository(KitStemHubWpfContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool UserExists(string username, string email)
        {
            return _context.Users.Any(u => u.Username == username || u.Email == email);
        }

        public User GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(a => a.Id == id);
        }

        public int? Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(p => p.Email == email && p.Password == password);
            if (user == null)
            {
                return 0;
            }
            return user.RoleId;
        }

    }
}
