using System;
using System.Collections.Generic;

namespace KitStemHub.Repositories.Models;

public partial class Order
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

    public virtual ICollection<KitOrder> KitOrders { get; set; } = new List<KitOrder>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User User { get; set; } = null!;
}
