using AutoMapper;
using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.DTOs.Responses;
using KitStemHub.Services.IServices;

namespace KitStemHub.Services.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public bool CreateCart(CartCreateDTO cart)
        {
            var result = false;
            var existingKit = _cartRepository.GetExistingKit(cart.UserId, cart.KitId);
            if (existingKit != null)
            {
                existingKit.Quantity += cart.Quantity;
                result = _cartRepository.Update(existingKit);
                return result;
            }
            else
            {
                var newKit = _mapper.Map<Cart>(cart);
                result = _cartRepository.Create(newKit);
                return result;
            }
        }

        public List<CartResponseDTO> GetCart(Guid userId)
        {
            var carts = _cartRepository.GetAllCartByUserId(userId);
            var cartDTO = _mapper.Map<List<CartResponseDTO>>(carts);
            cartDTO.Sum(c => c.Total = (int)c.Quantity! * c.Kit.Price);
            return cartDTO;
        }

        public int GetTotal(Guid userId)
        {
            var carts = _cartRepository.GetAllCartByUserId(userId);
            var cartDTO = _mapper.Map<List<CartResponseDTO>>(carts);
            cartDTO.Sum(c => c.Total = (int)c.Quantity! * c.Kit.Price);
            var total = cartDTO.Sum(c => c.Total);
            return total;
        }

        public bool RemoveAll(Guid userId)
        {
            var result = false;
            var cart = _cartRepository.GetCartByUserId(userId);
            if (cart == null)
            {
                return result;
            }

            foreach (var kit in cart)
            {
                result = _cartRepository.Remove(kit);
                if (result == false)
                {
                    break;
                }
            }
            return result;
        }

        public bool RemoveByKitId(Guid userId, int kitId)
        {
            var result = false;
            var kit = _cartRepository.GetExistingKit(userId, kitId);
            result = _cartRepository.Remove(kit);
            return result;
        }

        public bool UpdateByKitId(Guid userId, int kitId, int quantity)
        {
            var result = false;
            var kit = _cartRepository.GetExistingKit(userId, kitId);
            kit.Quantity = quantity;
            result = _cartRepository.Update(kit);
            return result;
        }
    }
}
