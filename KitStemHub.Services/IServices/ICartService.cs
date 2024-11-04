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
        public bool RemoveByKitId(Guid userId, int kitId);
        public List<CartResponseDTO> GetCart(Guid userId);
        public int GetTotal(Guid userId);
        public bool UpdateByKitId(Guid userId, int kitId, int quantity);

    }
}
