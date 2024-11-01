using AutoMapper;
using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.DTOs.Responses;
using KitStemHub.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return cartDTO;
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
    }
}
