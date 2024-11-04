using AutoMapper;
using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using KitStemHub.Repositories.Repositories;
using KitStemHub.Services.Constants;
using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.DTOs.Responses;
using KitStemHub.Services.HelperExtension;
using KitStemHub.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository, ICartService cartService, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _cartService = cartService;
            _mapper = mapper;
        }
        public IEnumerable<Order> GetOrdersTest()
        {
            return _orderRepository.getOrderTest();
        }


        public (IEnumerable<Order>, int) GetOrders(string? search = null, string? status = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, int page = 1, int pageSize = 10)
        {

            Expression<Func<Order, bool>> filter = o => true;


            if (!string.IsNullOrWhiteSpace(search))
            {
                filter = filter.AndAlso(o => o.User.Email.Contains(search) || o.User.FirstName.Contains(search));
            }


            if (!string.IsNullOrWhiteSpace(status) && status != "Tất cả trạng thái")
            {
                filter = filter.AndAlso(o => o.ShippingStatus == status);
            }


            if (startDate.HasValue || endDate.HasValue)
            {
                filter = filter.AndAlso(o => (!startDate.HasValue || o.CreatedAt >= startDate) && (!endDate.HasValue || o.CreatedAt <= endDate));
            }


            return _orderRepository.GetFilter(
                filter: filter,
                orderBy: q => q.OrderBy(o => o.CreatedAt),
                skip: (page - 1) * pageSize,
                take: pageSize,
                includes: q => q.Include(o => o.User).Include(o => o.Payments));
        }

        public bool updateOrderStatus(Order order)
        {
            return _orderRepository.Update(order);
        }

        public List<KitInOrderDetailDTO> GetKitInOrderDetails(Guid orderId)
        {

            List<KitOrder> kitOrders = _orderRepository.GetKitOrdersByOrderId(orderId);
            return _mapper.Map<List<KitInOrderDetailDTO>>(kitOrders);
        }

        public bool CreateOrder(Guid userId, string shippingAddress, string phoneNumber, string? note)
        {
            var result = false;
            var carts = _cartRepository.GetCartByUserId(userId);
            if (carts == null)
            {
                return result;
            }

            var price = carts.Sum(c => c.Kit.Price * c.Quantity);
            var orderId = Guid.NewGuid();
            var createAt = DateTimeOffset.Now;
            var orderDTO = new OrderCreateDTO()
            {
                Id = orderId,
                UserId = userId,
                CreatedAt = createAt,
                DeliveredAt = null,
                ShippingStatus = OrderFulfillmentConstants.OrderFailStatus,
                ShippingAddress = shippingAddress,
                PhoneNumber = phoneNumber,
                Price = (int)price!,
                Note = note,
                KitOrders = carts.Select(c => new KitOrderCreateDTO
                {
                    KitId = c.KitId,
                    OrderId = orderId,
                    KitQuantity = c.Quantity,
                }).ToList(),
                Payments = carts.Select(c => new PaymentCreateDTO
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderId,
                    MethodId = 1,
                    CreatedAt = createAt,
                    Status = true,
                }).ToList(),
            };

            var newOrder = _mapper.Map<Order>(orderDTO);
            result = _cartService.RemoveAll(userId);
            result = _orderRepository.Create(newOrder);
            return result;
        }
    }
}
