using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.IServices
{
    public interface ICartService
    {
        public bool CreateCart(CartCreateDTO cart);
        public bool RemoveAll(Guid userId);
        public List<CartResponseDTO> GetCart(Guid userId);

    }
}
