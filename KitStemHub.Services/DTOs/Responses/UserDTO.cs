using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.DTOs.Responses
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public int? RoleId { get; set; }

        public required string Username { get; set; }

        public required string Email { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string PhoneNumber { get; set; }

        public required string Address { get; set; }

        public bool? Status { get; set; }
    }
}
