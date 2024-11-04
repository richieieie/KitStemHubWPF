using KitStemHub.Repositories.Models;

using KitStemHub.Repositories.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Repositories.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<User> GetUsersByRole(string roleName, int? skip = null, int? take = null);

        void AddUser(User user);
        bool UserExists(string username, string email);
        User GetById(Guid id);
        public int? Login(string email, string password);
    }


}
