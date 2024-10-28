using System;
using System.Collections.Generic;

namespace KitStemHub.Repositories.Models;

public partial class Kit
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Breif { get; set; }

    public string? Description { get; set; }

    public int PurchaseCost { get; set; }

    public int Price { get; set; }

    public string? ImageUrl { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<KitOrder> KitOrders { get; set; } = new List<KitOrder>();
}
