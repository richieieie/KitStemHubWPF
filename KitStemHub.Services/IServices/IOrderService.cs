using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.IServices
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrdersTest();
        (IEnumerable<Order>, int) GetOrders(string? search = null, string? status = null,
            DateTimeOffset? startDate = null, DateTimeOffset? endDate = null,
            int page = 1, int pageSize = 10);

        bool updateOrderStatus(Order order);
        List<KitInOrderDetailDTO> GetKitInOrderDetails(Guid orderId);
        public bool CreateOrder(Guid userId, string shippingAddress, string phoneNumber, string? note);
    }
}
