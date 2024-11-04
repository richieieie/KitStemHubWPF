using KitStemHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.IServices
{
    public interface IUserService
    {
        // Existing method signatures...
        List<User> GetUsersByRole(int roleId, int? skip = null, int? take = null);
        List<User> SearchUsersByRoleAndNameOrEmail(int roleId, string searchText, int? skip = null, int? take = null);
        bool UpdateUserStatus(User user);

        bool UpdateUser(User user);

        // New method for creating a user
        bool CreateUser(User user);
        void DetachUser(User user);
        User? GetById(Guid id);
    }
}
