using KitStemHub.Services.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.IServices
{
    public interface IUserService
    {
        UserDTO GetById(Guid id);
        public int? Login(string email, string password);
    }
}
