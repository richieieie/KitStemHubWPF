using AutoMapper;
using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using KitStemHub.Repositories.Repositories;
using KitStemHub.Services.DTOs.Responses;
using KitStemHub.Services.HelperExtension;
using KitStemHub.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
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
    }
}
