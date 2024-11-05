using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.DTOs.Requests
{
    public class OrderCreateDTO
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? DeliveredAt { get; set; }

        public string ShippingStatus { get; set; } = null!;

        public string ShippingAddress { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public int Price { get; set; }

        public string? Note { get; set; }
        public ICollection<KitOrderCreateDTO> KitOrders { get; set; } = new List<KitOrderCreateDTO>();

        public ICollection<PaymentCreateDTO> Payments { get; set; } = new List<PaymentCreateDTO>();
    }
}
