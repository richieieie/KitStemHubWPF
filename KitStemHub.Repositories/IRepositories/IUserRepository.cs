using KitStemHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Repositories.IRepositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        bool UserExists(string username, string email);
        User GetById(Guid id);
        public int? Login(string email, string password);
        
    }
}
